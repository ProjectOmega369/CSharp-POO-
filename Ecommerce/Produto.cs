using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class Produto
    {
        public string Nome;
        private decimal Preco;
        private int Estoque;

        public Produto(string nome, decimal precoInicial, int estoqueInicial)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do produto não pode ser vazio.");

            if (precoInicial < 0)
                throw new ArgumentException("O preço não pode ser negativo.");

            if (estoqueInicial < 0)
                throw new ArgumentException("O estoque não pode ser negativo.");

            Nome = nome;
            Preco = precoInicial;
            Estoque = estoqueInicial;
        }

        public int Repor(int quantidade)
        {
            if (int.IsNegative(quantidade) || quantidade < 0)
            {
                throw new Exception("A quantidade não pode ser negativa");
            }
            return Estoque += quantidade;
        }

        public int Vender(int quantidade)
        {
            if(int.IsNegative(quantidade) || quantidade < 0)
            {
                throw new Exception("A quantidade não pode ser negativa");
            }

            return Estoque -= quantidade;
        }

        public int ObterEstoque()
        {
            return Estoque;
        }

        public decimal AtualizarPreco(decimal novopreco)
        {
            if (decimal.IsNegative(novopreco) && novopreco < 0)
            {
                throw new Exception("O novo preço deve ser positivo");
            }

            return Preco = novopreco;
        }

        public decimal ObterPreco()
        {
            return Preco;
        }


    }
}
