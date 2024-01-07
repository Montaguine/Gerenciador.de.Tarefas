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
            Console.WriteLine("Usuario: ");
            int usuario = int.Parse(Console.ReadLine());
            Console.WriteLine("Senha: ");
            string senha = Console.ReadLine();
            Usuario usuarioLogado = AutenticacaoUsuario.Autenticar(usuario, senha);
            if (usuarioLogado.nivelAcesso == NivelAcesso.TechLeader)
            {
                MenuTechLeader.Menu((TechLeader)usuarioLogado);
            }
            if (usuarioLogado.nivelAcesso == NivelAcesso.Desenvolvedor)
            {
                MenuDesenvolvedor.Menu((Desenvolvedor)usuarioLogado);
            }
            else
            {
                Console.WriteLine("Usuário ou senha inválidos");
            }
        }
    }
}
