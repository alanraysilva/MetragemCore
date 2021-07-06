using MetragemCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MetragemCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetragemController : ControllerBase
    {
        [AcceptVerbs("POST")]
        [Route("CalculaValorMetro")]
        public IActionResult CalculaValorMetro([FromBody] ConsultaValorMetro mdl) 
        {
            if (ModelState.IsValid)
            {
                if (mdl.Metragem == 0 && mdl.VlImovel == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular valores zerados.");
                }
                else if (mdl.VlImovel == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular, pois o valor do imovel está zerado ou nulo.");
                }
                else if (mdl.Metragem == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular, pois o valor do metragem está zerada ou nulo.");
                }
                else
                {                    
                    try
                    {
                        Imovel imovel = new Imovel();
                        imovel.Metragem = mdl.Metragem;
                        imovel.Valor = mdl.VlImovel;
                        imovel.ValorMetro = imovel.calculaValorMetro().ToString("F2");
                        return Ok(imovel);
                    }
                    catch (WebException we)
                    {
                        return BadRequest("Erro na execução da api: " + we.Message);
                    }
                }


            }
            else
            {
                return BadRequest("Não existem dados inseridos na chamada.");
            }


        }

        [AcceptVerbs("POST")]
        [Route("CalculaValorImovel")]
        public IActionResult CalculaValorImovel([FromBody] ConsultaValorImovel mdl)
        {
            if (ModelState.IsValid)
            {
                if (mdl.MetroQuadrado == 0 && mdl.VlMetro == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular valores zerados.");
                }
                else if (mdl.VlMetro == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular, pois o valor do metro quadrado está zerado ou nulo.");
                }
                else if (mdl.MetroQuadrado == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular, pois o metro quadrado está zerado  ou nulo.");
                }
                else
                {
                    try
                    {
                        Imovel imovel = new Imovel();
                        imovel.Metragem = mdl.MetroQuadrado;
                        imovel.Valor = mdl.VlMetro;
                        imovel.ValorMetro = Math.Round(imovel.CalculaValorImovel(), MidpointRounding.ToEven).ToString("F2");
                        return Ok(imovel);
                    }
                    catch (WebException we)
                    {
                        return BadRequest("Erro na execução da api: " + we.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Não existem dados inseridos na chamada.");
            }


        }


        /// <summary>
        /// Apenas teste Hello Word!
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Hello")]
        public async Task<IActionResult> GetHelloWord(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return BadRequest("Variavel texto não pode ser branco ou nulo");
            

            var resultado = $"Obrigado {texto} por utilizar nosso Hello Word!";
            return await Task.FromResult(Ok(resultado));
        }
    }
}
