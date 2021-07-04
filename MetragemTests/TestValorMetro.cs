using MetragemCore.Controllers;
using MetragemCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetragemTests
{
    public class TestValorMetro
    {
        [Fact]
        public void CalculoValorMetro_ValorCorreto()
        {
            ConsultaValorMetro consulta = new ConsultaValorMetro() { Metragem = 65, VlImovel = 180000 };
            var controller = new MetragemController();
            var result = controller.CalculaValorMetro(consulta) as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CalculoValorMetro_TodosValoresVazio()
        {
            ConsultaValorMetro consulta = new ConsultaValorMetro() { Metragem = 0, VlImovel = 0 };
            var controller = new MetragemController();
            var result = controller.CalculaValorMetro(consulta) as BadRequestObjectResult;
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CalculoValorMetro_ValorMetragemVazio()
        {
            ConsultaValorMetro consulta = new ConsultaValorMetro() { Metragem = 65, VlImovel = 0 };
            var controller = new MetragemController();
            var result = controller.CalculaValorMetro(consulta) as BadRequestObjectResult;
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CalculoValorMetro_ValorImovelVazio()
        {
            ConsultaValorMetro consulta = new ConsultaValorMetro() { Metragem = 0, VlImovel = 180000 };
            var controller = new MetragemController();
            var result = controller.CalculaValorMetro(consulta) as BadRequestObjectResult;
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
