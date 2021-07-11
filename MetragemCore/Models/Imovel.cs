using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetragemCore.Models
{
    public class Imovel
    {
        [JsonProperty("codigo")]
        public int Codigo { get; set; }
        [JsonProperty("metragem")]
        public double Metragem { get; set; }
        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("valormetro")]
        public string ValorMetro { get; set; }


        public double calculaValorMetro()
        {
            return ((double)Valor / Metragem) * 1000;
        }

        public double CalculaValorImovel()
        {
            return ((double)Valor * Metragem);
        }

        public Imovel()
        {

        }
    }
}
