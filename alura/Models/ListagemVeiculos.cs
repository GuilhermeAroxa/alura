using System;
using System.Collections.Generic;

namespace alura.Models
{
    public class ListagemVeiculos
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemVeiculos()
        {
            this.Veiculos = new List<Veiculo>
            {
                new Veiculo { Nome = "Azera V6", Preco = 60000 },
                new Veiculo { Nome = "Fiesta 2.0", Preco = 50000 },
                new Veiculo { Nome = "HB20 S", Preco = 40000},
                new Veiculo { Nome = "Ford Ka", Preco = 9000 },
                new Veiculo { Nome = "Corsa", Preco = 13000 },
                new Veiculo { Nome = "Fox", Preco = 14000},
                new Veiculo { Nome = "Celta", Preco = 17000 },
                new Veiculo { Nome = "Gol", Preco = 20000 },
                new Veiculo { Nome = "Spin", Preco = 35000 },
                new Veiculo { Nome = "Zafira", Preco = 25000},
                new Veiculo { Nome = "Sandero", Preco = 30000 },
                new Veiculo { Nome = "Fusca", Preco = 10000 }

            };
        }
    }
}
