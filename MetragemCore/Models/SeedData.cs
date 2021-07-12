using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetragemCore.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var ctx = new Context(
                serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (ctx.Imovel.Any())
                {
                    return;
                }

                ctx.Imovel.AddRange(

                    new Imovel() { Metragem = 65, Valor = 180.000M },
                    new Imovel() { Metragem = 80, Valor = 200.000M },
                    new Imovel() { Metragem = 85, Valor = 250.000M },
                    new Imovel() { Metragem = 100, Valor = 300.000M }
               );
               ctx.SaveChanges();
            }
        }
    }
}
