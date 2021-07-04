﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetragemCore.Models
{
    public class ConsultaValorMetro
    {
        [JsonProperty("metragem")]
        public double Metragem { get; set; }
        [JsonProperty("vlimovel")]
        public decimal VlImovel { get; set; }
    }
}
