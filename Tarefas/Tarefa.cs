using ManipuladorDeArquivos;

namespace Tarefas
{
    public class Tarefa
    {
        static List<Tarefa> tarefas = CarregarTarefas();

        static int contadorDeTarefas = 0;
        public int id;
        public int idCriador;
        public int idResponsavel;
        public DateTime dataCriacao;
        public DateTime dataPrevistaConclusao;
        public DateTime dataConclusao;
        public StatusTarefa status;
        public SituacaoTarefa situacao;
        public string titulo;
        public string descricao;
        public List<int> relacionamentos = new List<int>();

        public Tarefa(int idCriador, int idResponsavel, DateTime dataCriacao, SituacaoTarefa situacao, string titulo, string descricao)
        {
            id = contadorDeTarefas + 1;
            contadorDeTarefas++;
            this.idCriador = idCriador;
            this.idResponsavel = idResponsavel;
            this.dataCriacao = dataCriacao;
            this.titulo = titulo;
            this.descricao = descricao;
            status = StatusTarefa.NaoIniciada;
            this.situacao = situacao;
        }
        public static void CriarTarefa(int idCriador, int idResponsavel, DateTime dataCriacao, SituacaoTarefa situacao, string titulo, string descricao, DateTime? prazo = null)
        {
            if(prazo != null)
            {
                Tarefa tarefa = new Tarefa(idCriador, idResponsavel, dataCriacao, situacao, titulo, descricao);
                tarefa.dataPrevistaConclusao = (DateTime)prazo;
                tarefas.Add(tarefa);
            }
            else
            {
                Tarefa tarefa = new Tarefa(idCriador, idResponsavel, dataCriacao, situacao, titulo, descricao);
                tarefas.Add(tarefa);
            }
        }
        public static void ExibirTarefas(List<Tarefa> lista)
        {
            foreach (Tarefa tarefa in lista)
            {
                Console.WriteLine("ID: " + tarefa.id);
                Console.WriteLine("ID Criador: " + tarefa.idCriador);
                Console.WriteLine("ID Responsável: " + tarefa.idResponsavel);
                Console.WriteLine("Data de Criação: " + tarefa.dataCriacao);
                if(tarefa.status == StatusTarefa.Concluida)
                    Console.WriteLine("Data de Conclusão: " + tarefa.dataConclusao);
                if(tarefa.situacao == SituacaoTarefa.Autorizada || tarefa.status == StatusTarefa.EmAndamentoAtrasada)
                    Console.WriteLine("Data Prevista de Conclusão: " + tarefa.dataPrevistaConclusao);
                Console.WriteLine("Título: " + tarefa.titulo);
                Console.WriteLine("Descrição: " + tarefa.descricao);
                Console.WriteLine("Status: " + tarefa.status);
                Console.WriteLine("Situação: " + tarefa.situacao);
                Console.WriteLine();
            }
        }
        public static Tarefa ObterTarefa(int id)
        {
            foreach (Tarefa tarefa in tarefas)
            {
                if (tarefa.id == id)
                    return tarefa;
            }
            return null;
        }
        public static List<Tarefa> ObterTarefas()
        {
            return tarefas;
        }
        static List<Tarefa> CarregarTarefas()
        {
            return Manipulador<Tarefa>.CarregarLista();
        }
    }
}
