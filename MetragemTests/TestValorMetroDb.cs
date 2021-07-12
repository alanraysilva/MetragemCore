using MetragemCore;
using MetragemCore.Controllers;
using MetragemCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    public class TestValorMetroDb : IDisposable
    {
        CalculoMetragemDBController _controller;
        Context _dbCtx;

        public TestValorMetroDb()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<Context>();

            builder.UseSqlServer($"Server = (localdb)\\mssqllocaldb; Database = AspCore_NovoDB; Trusted_Connection = True;")
                    .UseInternalServiceProvider(serviceProvider);

            _dbCtx = new Context(builder.Options);

            _controller = new CalculoMetragemDBController(_dbCtx);
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

        public void Dispose()
        {
            _dbCtx.Database.CloseConnection();
        }
    }
}
