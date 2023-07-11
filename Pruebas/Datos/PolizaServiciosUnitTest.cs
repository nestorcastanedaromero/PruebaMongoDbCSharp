using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelos.Entidades;
using System.Threading.Tasks;
using Compartidos.Utilidades;
using Modelos.Modelos;

namespace Pruebas.Datos
{
    [TestClass]
    public class PolizaServiciosUnitTest : ContextoMongoTestBase
    {
        [ClassCleanup]
        public static void LimpiarClase() => TerminarMongoDb();

        [TestMethod]
        public async Task Debe_CrearAsync_CrearDocumentoCorrectamente()
        {
            SolicitudCreacionPoliza solicitudCreacionPoliza = new("12345",
                "nombre cliente",
                new DateTime(1989, 04, 01),
                new DateTime(2023, 2, 1),
                new DateTime(2024, 1, 1),
                new List<string>() { "" },
                1_000_000,
                "Plan Super",
                "Bogotá",
                "Calle 1 13 - 38",
                "UCR097",
                "2015",
                true);

            Poliza poliza = new(solicitudCreacionPoliza, new Fecha(2023, 6, 1));

            await _polizasServicios.CrearAsync(poliza);

            List<Poliza> polizas = await _polizasServicios.ObtenerAsync();

            Assert.AreEqual(1, polizas.Count);
        }

        [TestMethod]
        public async Task Debe_ObtenerAsync_ObtenerPolizaPorId()
        {
            SolicitudCreacionPoliza solicitudCreacionPoliza = new("12345",
                "nombre cliente",
                new DateTime(1989, 04, 01),
                new DateTime(2023, 2, 1),
                new DateTime(2024, 1, 1),
                new List<string>() { "" },
                1_000_000,
                "Plan Super",
                "Bogotá",
                "Calle 1 13 - 38",
                "UCR097",
                "2015",
                true);

            Poliza poliza = new(solicitudCreacionPoliza, new Fecha(2023, 6, 1));

            await _polizasServicios.CrearAsync(poliza);

            Poliza? polizas = await _polizasServicios.ObtenerAsync(poliza.Id.ToString());

            Assert.IsNotNull(polizas);
        }

        [TestMethod]
        public async Task Debe_ObtenerAsync_ObtenerPolizaPorPlaca()
        {
            SolicitudCreacionPoliza solicitudCreacionPoliza = new("12345",
                "nombre cliente",
                new DateTime(1989, 04, 01),
                new DateTime(2023, 2, 1),
                new DateTime(2024, 1, 1),
                new List<string>() { "" },
                1_000_000,
                "Plan Super",
                "Bogotá",
                "Calle 1 13 - 38",
                "UCR097",
                "2015",
                true);

            Poliza poliza = new Poliza(solicitudCreacionPoliza, new Fecha(2023, 6, 1));

            await _polizasServicios.CrearAsync(poliza);

            Poliza? polizas = await _polizasServicios.ObtenerAsync("UCR097");

            Assert.IsNotNull(polizas);
        }

    }
}