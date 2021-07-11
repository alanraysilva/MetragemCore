using MetragemCore;
using MetragemCore.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MetragemTests
{
    public class TestValorMetroDb : ControllerBase
    {
        CalculoMetragemDBController _controller;

        public TestValorMetroDb()
        {
            _controller = new CalculoMetragemDBController();
        }

        [Fact]
        public void CalculoValorImovelDb_ValorCorreto()
        {
            // Passando o Id 1 para pegar o primeiro da da lista db simulada
            var result = _controller.ObterValorMetro(1) as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CalculoValorImovelDb_TodosValoresVazio()
        {
            var result = _controller.ObterValorMetro(0) as BadRequestObjectResult;
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}
