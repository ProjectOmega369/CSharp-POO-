using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce
{
    public class Pedido
    {
        // Propriedade pública: número do pedido (Guid gerado automaticamente)
        public Guid NumeroPedido { get; private set; }

        // Lista privada para proteger os itens de alterações externas
        private readonly List<ItemPedido> itens;

        // Valor total é calculado automaticamente (sem setter)
        public decimal ValorTotal => itens.Sum(i => i.ValorTotal);

        // Propriedade pública somente leitura (não permite modificações diretas)
        public IReadOnlyCollection<ItemPedido> Itens => itens.AsReadOnly();

        // Construtor
        public Pedido()
        {
            NumeroPedido = Guid.NewGuid();
            itens = new List<ItemPedido>();
        }

        // Método para adicionar item ao pedido
        public void AdicionarItem(Produto produto, int quantidade)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            if (quantidade > produto.ObterEstoque())
                throw new InvalidOperationException("Estoque insuficiente para adicionar ao pedido.");

            // Verifica se o produto já existe no pedido
            var itemExistente = itens.FirstOrDefault(i => i.Produto == produto);

            if (itemExistente != null)
            {
                itemExistente.AdicionarQuantidade(quantidade);
            }
            else
            {
                var novoItem = new ItemPedido(produto, quantidade);
                itens.Add(novoItem);
            }

            // Atualiza o estoque do produto (vende)
            produto.Vender(quantidade);
        }

        // Método para remover item do pedido
        public void RemoverItem(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            var item = itens.FirstOrDefault(i => i.Produto == produto);
            if (item == null)
                throw new InvalidOperationException("O produto não está no pedido.");

            // Repor o estoque do produto (já que foi removido do pedido)
            produto.Repor(item.Quantidade);

            itens.Remove(item);
        }

        // Exibe resumo do pedido
        public void ExibirResumo()
        {
            Console.WriteLine($"Pedido Nº: {NumeroPedido}");
            Console.WriteLine("Itens do Pedido:");
            foreach (var item in itens)
            {
                Console.WriteLine($"- {item.Produto.Nome} x{item.Quantidade} = R${item.ValorTotal:F2}");
            }
            Console.WriteLine($"Valor Total: R${ValorTotal:F2}");
        }
    }

    // Classe auxiliar para representar o item do pedido
    public class ItemPedido
    {
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorTotal => Produto.ObterPreco() * Quantidade;

        public ItemPedido(Produto produto, int quantidade)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            Produto = produto;
            Quantidade = quantidade;
        }

        public void AdicionarQuantidade(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade adicional deve ser maior que zero.");

            Quantidade += quantidade;
        }
    }
}
