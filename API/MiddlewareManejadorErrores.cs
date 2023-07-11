using System.Net;
using System.Text.Json;
using Compartidos.Excepciones;

namespace API
{
    public class MiddlewareManejadorErrores
    {
        private readonly RequestDelegate _seguir;

        public MiddlewareManejadorErrores(RequestDelegate request)
        {
            _seguir = request;
        }

        public async Task Invoke(HttpContext contextoHttp)
        {
            try
            {
                await _seguir(contextoHttp);
            }
            catch (Exception error)
            {
                var response = contextoHttp.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case Error e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case RegistroNoEncontrado e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var resultado = JsonSerializer.Serialize(new { Mensaje = error?.Message });
                await response.WriteAsync(resultado);
            }
        }
    }
}
