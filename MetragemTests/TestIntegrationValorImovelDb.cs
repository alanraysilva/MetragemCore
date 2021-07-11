using MetragemCore;
using MetragemCore.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MetragemTests
{
    public class TestIntegrationValorImovelDb
    {
        private readonly HttpClient _Client;


        public TestIntegrationValorImovelDb()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _Client = appFactory.CreateClient();
        }

        [Fact]
        public async Task CalculoValorImovel_ValorCorreto()
        {

            var response = await _Client.GetAsync($"api/CalculoMetragemDB/GetValorImovel?IdImovel={1}");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CalculoValorImovel_TodosValoresVazio()
        {
            var response = await _Client.GetAsync($"api/CalculoMetragemDB/GetValorImovel?IdImovel={0}");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
