using MetragemCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetragemCore.Data
{
    // Esta classe simula uma base de dados 
    public class DB
    {
        public List<Imovel> LstImovel = new List<Imovel>();

        public DB()
        {
            LstImovel.Add(new Imovel() { ImovelId = 1, Metragem = 65, Valor = 180.000M });
            LstImovel.Add(new Imovel() { ImovelId = 2, Metragem = 80, Valor = 200.000M });
            LstImovel.Add(new Imovel() { ImovelId = 3, Metragem = 85, Valor = 250.000M });
            LstImovel.Add(new Imovel() { ImovelId = 4, Metragem = 100, Valor = 300.000M });
        }
    }
}