using MetragemCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetragemTests
{
    public class TestHelloWord
    {
        [Fact]
        public void VerificaResposta()
        {
            var controller = new MetragemController();
            var resultado = controller.GetHelloWord("Pai de Todos");

            Assert.IsType<OkObjectResult>(resultado.Result);
            Assert.IsNotType<BadRequestResult>(resultado.Result);
        }
    }
}
