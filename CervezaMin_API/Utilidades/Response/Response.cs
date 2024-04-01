using System.Net;

namespace CervezaMin_API.Utilidades.Response
{
    public class Response
    {
        public HttpStatusCode StatusCode { set; get; }
        public bool IsExitoso { set; get; } = true;
        public List<string>? ErrorMensajes { set; get; }
        public Object? Resultado { set; get; }

    }
}
