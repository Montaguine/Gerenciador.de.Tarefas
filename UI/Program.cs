using AcessoAutenticacao;
using ManipuladorDeArquivos;
using Usuarios;
using System;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Carrega a lista de usuários diretamente do arquivo usando o Manipulador
            List<Usuario> lista = Manipulador<Usuario>.CarregarLista();

            foreach (var item in lista)
            {
                Console.WriteLine(item.nome);
            }

            // Restante do seu código...
        }
    }
}
