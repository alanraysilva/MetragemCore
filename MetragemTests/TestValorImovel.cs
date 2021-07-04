using MetragemCore.Controllers;
using MetragemCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetragemTests
{
    public class TestValorImovel
    {
        [Fact]
        public void CalculoValorImovel_ValorCorreto()
        {
            ConsultaValorImovel consulta = new ConsultaValorImovel() { MetroQuadrado = 65, VlMetro = 2769.23M };
            var controller = new MetragemController();
            var result = controller.CalculaValorImovel(consulta) as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CalculoValorImovel_TodosValoresVazio()
        {
            ConsultaValorImovel consulta = new ConsultaValorImovel() { MetroQuadrado = 0, VlMetro = 0 };
            var controller = new MetragemController();
            var result = controller.CalculaValorImovel(consulta) as BadRequestObjectResult;
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CalculoValorImovel_ValorMetragemVazio()
        {
            ConsultaValorImovel consulta = new ConsultaValorImovel() { MetroQuadrado = 65, VlMetro = 0 };
            var controller = new MetragemController();
            var result = controller.CalculaValorImovel(consulta) as BadRequestObjectResult;
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CalculoValorImovel_ValorImovelVazio()
        {
            ConsultaValorImovel consulta = new ConsultaValorImovel() { MetroQuadrado = 0, VlMetro = 2769.23M };
            var controller = new MetragemController();
            var result = controller.CalculaValorImovel(consulta) as BadRequestObjectResult;
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
