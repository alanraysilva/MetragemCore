using MetragemCore.Data;
using MetragemCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetragemCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoMetragemDBController : ControllerBase
    {

        [AcceptVerbs("GET")]
        [Route("GetValorMetro")]
        public IActionResult ObterValorMetro(int IdImovel)
        {
            if (ModelState.IsValid)
            {
                if (IdImovel == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular valores o id do imóvel não pode ser vazio.");
                }
                else
                {
                    try
                    {

                        DB data = new DB();

                        Imovel imovel = data.LstImovel.Where(x => x.ImovelId == IdImovel).FirstOrDefault();
                        if (imovel != null)
                        {
                            imovel.ValorMetro = imovel.calculaValorMetro().ToString("F2");
                            return Ok(imovel);
                        }
                        else
                        {
                            return BadRequest("Erro não foi possível obter o valor do metro. Id inexistente");
                        }

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

        [AcceptVerbs("GET")]
        [Route("GetValorImovel")]
        public IActionResult GetValorImovel(int IdImovel)
        {
            if (ModelState.IsValid)
            {
                if (IdImovel == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular valores o id do imóvel não pode ser vazio.");
                }
                else
                {

                    try
                    {

                        var actionResult =  ObterValorMetro(IdImovel);

                        OkObjectResult okresult = (OkObjectResult)actionResult;

                        if (okresult.StatusCode == 200)
                        {
                            Imovel i1 = (Imovel)okresult.Value;


                            if (i1 != null)
                            {
                                DB data = new DB();

                                //Imovel imovel = _context.Imovel.Where(x => x.ImovelId == IdImovel).FirstOrDefault();

                                Imovel imovel = data.LstImovel.Where(x => x.ImovelId == IdImovel).FirstOrDefault();
                                imovel.Metragem = i1.Metragem;
                                imovel.Valor = Convert.ToDecimal(i1.ValorMetro);
                                imovel.ValorMetro = Math.Round(imovel.CalculaValorImovel(), MidpointRounding.ToEven).ToString("F2");
                                return Ok(imovel);
                            }
                            else
                            {
                                return BadRequest("Erro não foi possível obter o valor do metro. Id inexistente");
                            }
                        }
                        else 
                        {
                            return BadRequest("Erro não foi possível obter o valor do metro.");
                        }


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
    }
}
