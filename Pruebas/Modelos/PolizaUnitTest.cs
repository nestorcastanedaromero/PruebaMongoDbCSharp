using System;
using System.Collections.Generic;
using Compartidos.Excepciones;
using Compartidos.Utilidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelos.Entidades;
using Modelos.Modelos;

namespace Pruebas.Modelos
{
    [TestClass]
    public class PolizaUnitTest
    {
        [TestMethod]
        public void Debe_LanzarExcepcionSiFechaPolizaNoVigente()
        {
            var fechaVencimiento = new DateTime(2022, 12, 1);
            var fechaActual = new Fecha(2023, 1, 1);
            
            var excepcion = Assert.ThrowsException<Error>(() => new Poliza(
                new SolicitudCreacionPoliza("12345",
                    "nombre cliente",
                    new DateTime(1989, 04, 01),
                    new DateTime(2022, 1, 1),
                    fechaVencimiento,
                    new List<string>() { "" },
                    1_000_000,
                    "Plan Super", "Bogotá",
                    "Calle 1 13 - 38", "UCR097", "2015", true),
                fechaActual));

            Assert.AreEqual(Poliza.FechaPolizaNoVigente, excepcion.Message);
        }

        [TestMethod]
        public void Debe_LanzarExcepcionSiFechaTomaPolizaMayorAFechaVencimiento()
        {
            var fechaTomaPoliza = new DateTime(2024, 2, 1);
            var fechaVencimiento = new DateTime(2024, 1, 1 );

            var excepcion = Assert.ThrowsException<Error>(() => new Poliza(
                new SolicitudCreacionPoliza("12345",
                    "nombre cliente",
                    new DateTime(1989, 04, 01),
                    fechaTomaPoliza,
                    fechaVencimiento,
                    new List<string>() { "" },
                    1_000_000,
                    "Plan Super", "Bogotá",
                    "Calle 1 13 - 38", "UCR097", "2015", true),
                new Fecha(2023, 6, 1)));

            Assert.AreEqual(Poliza.FechaDePolizaInvalida, excepcion.Message);
        }

        [TestMethod]
        public void Debe_CrearEntidadCorrectamente()
        {
            var poliza = new Poliza(new SolicitudCreacionPoliza("12345",
                    "nombre cliente",
                    new DateTime(1989, 04, 01),
                    new DateTime(2023, 2, 1),
                    new DateTime(2024, 1, 1),
                    new List<string>() { "" },
                    1_000_000,
                    "Plan Super", "Bogotá",
                    "Calle 1 13 - 38", "UCR097", "2015", true),
                new Fecha(2023, 6, 1));

            Assert.IsNotNull(poliza);
        }
    }
}