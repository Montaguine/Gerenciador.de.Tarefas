using ManipuladorDeArquivos;
using System;
using System.Collections.Generic;
using Tarefas;

namespace Usuarios
{
    public class Desenvolvedor : Usuario
    {
        public Desenvolvedor()
        {
        }
        public override void CriarTarefa(int idResponsavel, string titulo, string descricao, DateTime prazo)
        {
            Tarefa.CriarTarefa(idResponsavel, id, DateTime.Now, SituacaoTarefa.AutorizacaoPendente, titulo, descricao);
        }
        public override List<Tarefa> ObterTarefas()
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            foreach (Tarefa tarefa in Tarefa.ObterTarefas())
            {
                if (tarefa.idResponsavel == id) tarefas.Add(tarefa);
            }
            return tarefas;
        }
        public List<Tarefa> ObterTarefasRelacionadas()
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            foreach (Tarefa tarefa in Tarefa.ObterTarefas())
            {
                if (tarefa.idResponsavel == this.id) tarefas.Add(tarefa);
            }
            foreach (Tarefa tarefa in tarefas)
            {
                foreach (int id in tarefa.relacionamentos)
                {
                    tarefas.Add(Tarefa.ObterTarefa(id));
                }
            }
            return tarefas.Distinct().ToList();
        }
        public Tarefa ObterTarefa(int idTarefa)
        {
            foreach (Tarefa tarefa in ObterTarefas())
            {
                if (tarefa.id == idTarefa && tarefa.idResponsavel == id) return tarefa;
            }
            return null;
        }
    }
}
