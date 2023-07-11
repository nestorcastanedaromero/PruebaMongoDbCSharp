using Compartidos.Utilidades;
using Datos;
using Dominio;
using Interfaces.Datos;
using Interfaces.Dominio;
using Microsoft.Extensions.DependencyInjection;

namespace Resolver
{
    public static class Resolver
    {
        public static void ResolverDependencias(this IServiceCollection servicios)
        {
            servicios.AddSingleton<IPolizasServicios, PolizasServicios>();
            servicios.AddSingleton<ICreadorPolizas, CreadorPolizas>();
            servicios.AddSingleton<IFecha,Fecha>();
        }

    }
}
