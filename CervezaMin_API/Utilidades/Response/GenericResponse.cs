using System.Net;

namespace CervezaMin_API.Utilidades.Response
{
    public class GenericResponse<TObject>
    {
        public HttpStatusCode StatusCode { set; get; }
        public bool IsExitoso { set; get; } = true;
        public List<string>? ErrorMensajes { set; get; }
        public TObject? Resultado { set; get; }
        public List<TObject>? Resultados { get; set; }

    }
}
