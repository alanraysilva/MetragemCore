using MetragemCore.Controllers;
using MetragemCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
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
    public class TestValoImovelDb
    {
        CalculoMetragemDBController _controller;

        public TestValoImovelDb()
        {
            _controller = new CalculoMetragemDBController();
        }

        [Fact]
        public void CalculoValorImovelDb_ValorCorretoAsync()
        {
            var result =  _controller.GetValorImovel(1) as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CalculoValorImovelDb_TodosValoresVazioAsync()
        {
            var result = _controller.GetValorImovel(0) as BadRequestObjectResult;
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
