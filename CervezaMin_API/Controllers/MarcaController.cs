using AutoMapper;
using CervezaMin_API.Models;
using CervezaMin_API.Models.Dtos;
using CervezaMin_API.Respositorio.Interfaces;
using CervezaMin_API.Utilidades.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CervezaMin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly ILogger<MarcaController> _logger;
        private readonly IMarcaRepository _marcaRepo;
        private readonly IMapper _mapper;
        protected GenericResponse<MarcaDto> _response;
        public MarcaController(ILogger<MarcaController> logger,IMarcaRepository marcaRepo,IMapper mapper)
        {
            _logger = logger;
            _marcaRepo = marcaRepo;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GenericResponse<MarcaDto>>> GetMarcas()
        {
            try
            {
                _logger.LogInformation("OK() log:Obtener marcas");
                List<MarcaDto> villaList = _mapper.Map<List<MarcaDto>>(await _marcaRepo.Consultar());
                _response.Resultados = villaList;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return _response;
        }
        [HttpGet("Id:int", Name = "GetMarca")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenericResponse<MarcaDto>>> GetMarca(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    _logger.LogError("BadRequest() log: error al obtener la marca con id:{Id} ", Id);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    return BadRequest(_response);
                }
                MarcaDto marcaDto = _mapper.Map<MarcaDto>(await _marcaRepo.Obtener(v => v.IdMarca == Id, false));
                if (marcaDto == null)
                {
                    _logger.LogError("NotFound(): log:la varca con ID {Id} no existe en el registro ", Id);
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }
                _logger.LogInformation("OK(): log: Obtener marca con ID {Id}", Id);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = marcaDto;
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
        public async Task<ActionResult<GenericResponse<MarcaDto>>> CrearMarca([FromBody] MarcaCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if (createDto == null) return BadRequest(createDto);
                if (await _marcaRepo.Obtener(v => v.Nombre.ToUpper() == createDto.Nombre.ToUpper(), false) != null)
                {
                    ModelState.AddModelError("NombreExiste", "La marca con este nombre ya existe");
                    return BadRequest(ModelState);
                }
                Marca modelo = _mapper.Map<Marca>(createDto);
                modelo.FechaCreacion = DateTime.Now;
                modelo.FechaActualizacion = DateTime.Now;
                await _marcaRepo.Crear(modelo);
                _response.Resultado = _mapper.Map<MarcaDto>(modelo);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetMarca", new { id = modelo.IdMarca }, _response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return _response;
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    BadRequest(_response);
                };
                var marca = await _marcaRepo.Obtener(v => v.IdMarca== id, false);
                if (marca == null)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _marcaRepo.Eliminar(marca);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return BadRequest(_response);
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] MarcaUpdateDto updateDto)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                if (updateDto == null || id != updateDto.IdMarca)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                await _marcaRepo.Editar(_mapper.Map<Marca>(updateDto));
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return BadRequest(_response);
        }
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> PartialUpdate(int id, JsonPatchDocument<MarcaUpdateDto> patchDto)
        {
            try
            {
                if (patchDto == null || id == 0)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var marcaActual = await _marcaRepo.Obtener(v => v.IdMarca == id, false);
                if (marcaActual == null)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                MarcaUpdateDto villaParchada = _mapper.Map<MarcaUpdateDto>(marcaActual);
                patchDto.ApplyTo(villaParchada, ModelState);
                if (!ModelState.IsValid) return BadRequest(ModelState);
                await _marcaRepo.Editar(_mapper.Map<Marca>(villaParchada));
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMensajes = [ex.ToString()];
            }
            return BadRequest(_response);
        }



    }
}
