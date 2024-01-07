using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas;

namespace Usuarios
{
    public class TechLeader : Usuario
    {
        public TechLeader()
        {
            this.nivelAcesso = NivelAcesso.TechLeader;
        }
        public override void CriarTarefa(int idResponsavel, string titulo, string descricao, DateTime prazo)
        {
            Tarefa.CriarTarefa(id, idResponsavel, DateTime.Now, SituacaoTarefa.Autorizada, titulo, descricao, prazo);
        }
        public override List<Tarefa> ObterTarefas()
        {
            return Tarefa.ObterTarefas();
        }
        public List<Tarefa> ObterTarefasAtrasadas()
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            foreach (Tarefa tarefa in Tarefa.ObterTarefas())
            {
                if (DateTime.Now>tarefa.dataPrevistaConclusao)
                    tarefas.Add(tarefa);
            }
            return tarefas;
        }
        public List<Tarefa> ObterTarefasConcluidas()
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            foreach (Tarefa tarefa in Tarefa.ObterTarefas())
            {
                if (tarefa.idResponsavel == id && tarefa.status == StatusTarefa.Concluida)
                    tarefas.Add(tarefa);
            }
            return tarefas;
        }
        public List<Tarefa> ObterTarefasAbandonadas()
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            foreach (Tarefa tarefa in Tarefa.ObterTarefas())
            {
                if (tarefa.idResponsavel == id && tarefa.status == StatusTarefa.Abandonada)
                    tarefas.Add(tarefa);
            }
            return tarefas;
        }
        public List<Tarefa> ObterTarefasImpedidas()
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            foreach (Tarefa tarefa in ObterTarefas())
            {
                if (tarefa.idResponsavel == id && tarefa.status == StatusTarefa.Impedida)
                    tarefas.Add(tarefa);
            }
            return tarefas;
        }
        public List<Tarefa> ObterTarefasPendentesDeAprovacao()
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            foreach (Tarefa tarefa in Tarefa.ObterTarefas())
            {
                if (tarefa.idCriador == id && tarefa.situacao == SituacaoTarefa.AutorizacaoPendente)
                    tarefas.Add(tarefa);
            }
            return tarefas;
        }
        public void AutorizarTarefa(int idTarefa)
        {
            Tarefa tarefa = Tarefa.ObterTarefa(idTarefa);
            if (tarefa.idCriador == id && tarefa.situacao != SituacaoTarefa.Autorizada)
            {
                tarefa.situacao = SituacaoTarefa.Autorizada;
            }
        }
        public void AssumirTarefa(int idTarefa)
        {
            Tarefa tarefa = Tarefa.ObterTarefa(idTarefa);
            if (tarefa.idResponsavel == id)
            {
                tarefa.status = StatusTarefa.EmAndamento;
                tarefa.situacao = SituacaoTarefa.Apropriada;
            }
        }
        public void MudarResponsavelTarefa(int idResponsavel, int idTarefa)
        {
            Tarefa tarefa = Tarefa.ObterTarefa(idTarefa);
            if (tarefa.idCriador == id)
            {
                tarefa.idResponsavel = idResponsavel;
            }
        }
        public void DefinirTempoEstimadoTarefa(DateTime tempoEstimado, int idTarefa)
        {
            Tarefa tarefa = Tarefa.ObterTarefa(idTarefa);
            if (tarefa.id == idTarefa)
            {
                tarefa.dataPrevistaConclusao = tempoEstimado;
            }
        }
        public void RelacionarTarefas(int idTarefa1, int idTarefa2)
        {
            Tarefa tarefa1 = Tarefa.ObterTarefa(idTarefa1);
            Tarefa tarefa2 = Tarefa.ObterTarefa(idTarefa2);
            if(!tarefa1.relacionamentos.Contains(idTarefa2) && !tarefa2.relacionamentos.Contains(idTarefa1))
            {
                tarefa1.relacionamentos.Add(tarefa2.id);
                tarefa2.relacionamentos.Add(tarefa1.id);
            }
        }
    }
}
