using AutoMapper;
using CervezaMin_API.Models;
using CervezaMin_API.Models.Dtos;
using CervezaMin_API.Respositorio.Interfaces;
using CervezaMin_API.Utilidades.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CervezaMin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CervezaSPController : ControllerBase
    {
        private readonly ICervezaRepositorySP _cervezaRepo;
        private readonly IMarcaRepository _marcaRepo;
        private readonly ILogger<CervezaController> _logger;
        private readonly IMapper _mapper;
        protected Response _response;
        public CervezaSPController(ILogger<CervezaController> logger, ICervezaRepositorySP cervezaRepo, IMarcaRepository marcaRepo, IMapper mapper)
        {
            _logger = logger;
            _cervezaRepo = cervezaRepo;
            _marcaRepo = marcaRepo;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet("Id:int", Name = "GetCervezasp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response>> GetCervezasp(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    _logger.LogError("BadRequest() log: error al obtener la cerveza con id:{Id} ", Id);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    return BadRequest(_response);
                }
                CervezaDto cervezaDto = _mapper.Map<CervezaDto>(await _cervezaRepo.Obtener(c => c.IdCerveza == Id, false));
                if (cervezaDto == null)
                {
                    _logger.LogError("NotFound(): log:la cerveza con ID {Id} no existe en el registro ", Id);
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }
                _logger.LogInformation("OK(): log: Obtener cerveza con ID {Id}", Id);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = cervezaDto;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return _response;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> CrearCerveza([FromBody] CervezaCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if (createDto == null) return BadRequest(createDto);
                if (await _cervezaRepo.Obtener(v => v.Nombre.ToUpper() == createDto.Nombre.ToUpper(), false) != null)
                {
                    ModelState.AddModelError("NombreExiste", "La cerveza con este nombre ya existe");
                    return BadRequest(ModelState);
                }
                if (await _marcaRepo.Obtener(m => m.IdMarca == createDto.IdMarca, false) == null)
                {
                    ModelState.AddModelError("Marca Existe", "el ID de la  marca ingresada no existe");
                    return BadRequest(ModelState);
                }
                Cerveza modelo = _mapper.Map<Cerveza>(createDto);
                modelo.FechaCreacion = DateTime.Now;
                modelo.FechaActualizacion = DateTime.Now;
                await _cervezaRepo.Crearsp(modelo);
                _response.Resultado = _mapper.Map<CervezaDto>(modelo);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetCervezasp", new { id = modelo.IdCerveza }, _response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return _response;
        }
    }
}
