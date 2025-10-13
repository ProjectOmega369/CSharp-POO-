using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula06102025
{
    class Locacao
    {
        public Cliente Cliente { get; set; }

        public Filme Filme { get; set; }

        public Locacao(Cliente cliente, Filme filme, int quantidade)
        {
            if (quantidade > filme.Unidades)
            {
                //Gerar Exceção
                throw new ArgumentException("Quantidade Pedida é maior que a disponivel");
            }

            Filme = filme;
            Cliente = cliente;
            filme.Unidades -= quantidade;
        }
    }
}
