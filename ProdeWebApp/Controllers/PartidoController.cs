using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prode.Core.Entidades;
using Prode.Core.Entidades.Interfaces;
using ProdeWebApp.Codigo;

namespace ProdeWebApp.Controllers
{
    [Route("[controller]")]
    public class PartidoController : Controller
    {
        public ILogger _logger;

        private IFormateador _formateador;
        public PartidoController(IFormateador formateador)
        {
            _formateador = formateador;
        }
        public IActionResult Index()
        {
            var argentina = new Equipo()
            {
                Nombre = "Argentina",
                Abreviatura = "ARG"
            };

            var brasil = new Equipo()
            {
                Nombre = "Brasil",
                Abreviatura = "BRA"
            };


            ViewData["Nombre1"] = _formateador.NombreCompleto(argentina);
            ViewData["Nombre2"] = _formateador.NombreCompleto(brasil);

            return View();
        }

        public IActionResult Detalle(string equipo1, string equipo2)
        {
            _logger.LogInformation("lala");
            if (equipo1.Length > 3)
            {
                throw new ArgumentException("El equipo 1 es incorrecto");
            }
            throw new ArgumentException("Todo bien");

            if (equipo1.Equals("RIB") || equipo2.Equals("RIB"))
            {

                var ex = new PartidoMalFormadoException()
                {
                    Equipo1 = equipo1,
                    Equipo2 = equipo2
                };

                _logger.LogError("ex.ToString");
                try
                {
                    var resultado = equipo1.Length / (equipo2.Length - 1);
                    ViewBag.Resultado = resultado;
                }
                catch (DivideByZeroException ex)
                {
                    //   Logger
                }
                catch (Exception ex)
                {
                    //   Logger
                }

                return View();
            }
        }
    }
}