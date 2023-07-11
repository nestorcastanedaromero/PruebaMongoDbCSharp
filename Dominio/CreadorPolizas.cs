using Compartidos.Utilidades;
using Interfaces.Datos;
using Interfaces.Dominio;
using Modelos.Entidades;
using Modelos.Modelos;

namespace Dominio
{
    public class CreadorPolizas : ICreadorPolizas
    {
        private readonly IPolizasServicios _polizasServicios;
        private readonly IFecha _fecha;

        public CreadorPolizas(IPolizasServicios polizasServicios, IFecha fecha)
        {
            _polizasServicios = polizasServicios;
            _fecha = fecha;
        }

        public Task CrearAsync(SolicitudCreacionPoliza solicitudCreacionPoliza)
        {
            Poliza nuevaPoliza = new Poliza(solicitudCreacionPoliza, _fecha);

            return _polizasServicios.CrearAsync(nuevaPoliza);
        }
    }
}
