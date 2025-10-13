
namespace Aula06102025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Filme filme = new Filme();
            filme.Titulo = "Filme1";
            filme.Genero = "Genero1";
            filme.Unidades = 10;

            Filme filme2 = new Filme();
            filme2.Titulo = "Filme1";
            filme2.Genero = "Genero1";
            filme2.Unidades = 40;

            Console.WriteLine("Estado Inicial");
            Console.WriteLine("Quantidade Filme1: " + filme.Unidades);
            Console.WriteLine("Quantidade Filme2: " + filme2.Unidades);

            Cliente cliente = new Cliente();
            cliente.Nome = "Charles";
            //cliente.FilmesAlugados = filmesAlugados;

            Locacao locacao = new Locacao(cliente, filme2, 5);
            Console.WriteLine("Estado Depois de uma Locação");
            Console.WriteLine("Quantidade Filme1: " + filme.Unidades);
            Console.WriteLine("Quantidade Filme2: " + filme2.Unidades);
        }
    }
}
