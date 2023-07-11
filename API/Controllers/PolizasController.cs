using Interfaces.Datos;
using Interfaces.Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelos.Entidades;
using Modelos.Modelos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolizasController : ControllerBase
    {
        private readonly IPolizasServicios _polizasServicios;
        private readonly ICreadorPolizas _creadorPolizas;

        public PolizasController(IPolizasServicios polizasServicios, ICreadorPolizas creadorPolizas)
        {
            _polizasServicios = polizasServicios;
            _creadorPolizas = creadorPolizas;
        }

        [HttpPost(Name = "CrearPolizas")]
        [Authorize]
        public Task Crear(SolicitudCreacionPoliza poliza) => _creadorPolizas.CrearAsync(poliza);

        [HttpGet(Name = "ObtenerPolizas")]
        [Authorize]
        public Task<List<Poliza>> Obtener() => _polizasServicios.ObtenerAsync();
        
        [HttpGet("{filtro}")]
        [Authorize]
        public Task<Poliza?> Obtener(string filtro) => _polizasServicios.ObtenerAsync(filtro);

    }
}