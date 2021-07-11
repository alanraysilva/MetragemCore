using MetragemCore;
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
    public class TestIntegrationValorMetroDb
    {
        private readonly HttpClient _Client;


        public TestIntegrationValorMetroDb()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _Client = appFactory.CreateClient();
        }


        [Fact]
        public async Task CalculoValorMetroDb_ValorCorreto()
        {
            var response = await _Client.GetAsync($"api/CalculoMetragemDB/GetValorMetro?IdImovel={1}");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CalculoValorMetroDb_TodosValoresVazio()
        {
            var response = await _Client.GetAsync($"api/CalculoMetragemDB/GetValorMetro?IdImovel={0}");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
