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
    public class TestIntegrationValorMetro
    {
        private readonly HttpClient _Client;


        public TestIntegrationValorMetro()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _Client = appFactory.CreateClient();
        }


        [Fact]
        public async Task CalculoValorMetro_ValorCorreto()
        {
            ConsultaValorMetro consulta = new ConsultaValorMetro() { Metragem = 65, VlImovel = 180000 };
            var serializedRequest = JsonConvert.SerializeObject(consulta);

            var response = await _Client.PostAsync("api/Metragem/CalculaValorMetro", new StringContent(serializedRequest,
            Encoding.UTF8,
            "application/json"));

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CalculoValorMetro_TodosValoresVazio()
        {
            ConsultaValorMetro consulta = new ConsultaValorMetro() { Metragem = 0, VlImovel = 0 };
            var serializedRequest = JsonConvert.SerializeObject(consulta);

            var response = await _Client.PostAsync("api/Metragem/CalculaValorMetro", new StringContent(serializedRequest,
            Encoding.UTF8,
            "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CalculoValorMetro_ValorMetragemVazio()
        {
            ConsultaValorMetro consulta = new ConsultaValorMetro() { Metragem = 65, VlImovel = 0 };
            var serializedRequest = JsonConvert.SerializeObject(consulta);

            var response = await _Client.PostAsync("api/Metragem/CalculaValorMetro", new StringContent(serializedRequest,
            Encoding.UTF8,
            "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CalculoValorMetro_ValorImovelVazio()
        {
            ConsultaValorMetro consulta = new ConsultaValorMetro() { Metragem = 0, VlImovel = 180000 };
            var serializedRequest = JsonConvert.SerializeObject(consulta);

            var response = await _Client.PostAsync("api/Metragem/CalculaValorMetro", new StringContent(serializedRequest,
            Encoding.UTF8,
            "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
