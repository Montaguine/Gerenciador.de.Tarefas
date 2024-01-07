using ManipuladorDeArquivos;
using System.Text.Json.Serialization;
using Tarefas;

namespace Usuarios
{
    public abstract class Usuario
    {
        static List<Usuario> usuarios = new List<Usuario>();
        public int id;
        public string? nome;
        public string? chaveAcesso;
        public NivelAcesso nivelAcesso;

        public abstract void CriarTarefa(int idResponsavel, string titulo, string descricao, DateTime prazo);
        public abstract List<Tarefa> ObterTarefas();
        public List<Usuario> ObterUsuarios()
        {
            return usuarios = Manipulador<Usuario>.CarregarLista();
        }
        public void AtualizarUsuarios(List<Usuario> listaUsuarios)
        {
            Manipulador<Usuario>.AtualizarLista(listaUsuarios);
        }
    }
}
