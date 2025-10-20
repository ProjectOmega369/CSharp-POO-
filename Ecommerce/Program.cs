

namespace Ecommerce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                var p1 = new Produto("Mouse", 150, 10);
                var p2 = new Produto("Cadeira", 100, 10);

                Console.WriteLine("Produtos criados:");
                Console.WriteLine(p1);
                Console.WriteLine(p2);

                var pedido = new Pedido();

                pedido.AdicionarItem(p1, 2);
                pedido.AdicionarItem(p2, 3);

                Console.WriteLine("\nEstoque atual:");
                Console.WriteLine($"{p1.Nome}: {p1.ObterEstoque()} unidades");
                Console.WriteLine($"{p2.Nome}: {p2.ObterEstoque()} unidades");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
