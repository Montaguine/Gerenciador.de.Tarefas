using ManipuladorDeArquivos;
using Usuarios;

namespace AcessoAutenticacao
{
    public class AutenticacaoUsuario
    {
        static List<Usuario> usuarios = Manipulador<Usuario>.CarregarLista();
        public static Usuario Autenticar(int login, string senha)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.id == login)
                {
                    if (usuario.chaveAcesso == senha) return usuario;
                    else return null;
                }
                else return null;
            }
            return null;
        }
    }
}
