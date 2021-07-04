using MetragemCore;
using MetragemCore.Controllers;
using MetragemCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MetragemTests
{
    public class TestIntegrationValorImovel
    {
        private readonly HttpClient _Client;


        public TestIntegrationValorImovel()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _Client = appFactory.CreateClient();
        }

        [Fact]
        public async Task CalculoValorImovel_ValorCorretoAsync()
        {
            ConsultaValorImovel consulta = new ConsultaValorImovel() { MetroQuadrado = 65, VlMetro = 2769.23M };
            var serializedRequest = JsonConvert.SerializeObject(consulta);

            var response = await _Client.PostAsync("api/Metragem/CalculaValorImovel", new StringContent(serializedRequest,
            Encoding.UTF8,
            "application/json"));

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CalculoValorImovel_TodosValoresVazioAsync()
        {
            ConsultaValorImovel consulta = new ConsultaValorImovel() { MetroQuadrado = 0, VlMetro = 0 };
            var serializedRequest = JsonConvert.SerializeObject(consulta);

            var response = await _Client.PostAsync("api/Metragem/CalculaValorImovel", new StringContent(serializedRequest,
            Encoding.UTF8,
            "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CalculoValorImovel_ValorMetragemVazio()
        {
            ConsultaValorImovel consulta = new ConsultaValorImovel() { MetroQuadrado = 65, VlMetro = 0 };
            var serializedRequest = JsonConvert.SerializeObject(consulta);

            var response = await _Client.PostAsync("api/Metragem/CalculaValorImovel", new StringContent(serializedRequest,
            Encoding.UTF8,
            "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CalculoValorImovel_ValorImovelVazio()
        {
            ConsultaValorImovel consulta = new ConsultaValorImovel() { MetroQuadrado = 0, VlMetro = 2769.23M };
            var serializedRequest = JsonConvert.SerializeObject(consulta);

            var response = await _Client.PostAsync("api/Metragem/CalculaValorImovel", new StringContent(serializedRequest,
            Encoding.UTF8,
            "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
