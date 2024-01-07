using Tarefas;
using Usuarios;

namespace UI
{
    internal class MenuTechLeader
    {
        public static void Menu(TechLeader usuario)
        {
            Console.WriteLine($"Bem vindo {usuario.nome}");
            Console.WriteLine();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Criar tarefa");
            Console.WriteLine("2 - Autorizar tarefa");
            Console.WriteLine("3 - Listar tarefas");
            Console.WriteLine("4 - Listar tarefas atrasadas");
            Console.WriteLine("5 - Listar tarefas concluidas");
            Console.WriteLine("6 - Listar tarefas abandonadas");
            Console.WriteLine("7 - Listar tarefas impedidas");
            Console.WriteLine("8 - Listar tarefas pendentes de aprovação");
            Console.WriteLine("0 - Sair");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Informe o id do responsável");
                    int idResponsavel = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe o titulo da tarefa");
                    string titulo = Console.ReadLine();
                    Console.WriteLine("Informe a descrição da tarefa");
                    string descricao = Console.ReadLine();
                    Console.WriteLine("Informe o prazo da tarefa");
                    DateTime prazo = DateTime.Parse(Console.ReadLine());
                    usuario.CriarTarefa(idResponsavel, titulo, descricao, prazo);
                    break;
                case 2:
                    Console.WriteLine("Informe o id da tarefa");
                    int idTarefa = int.Parse(Console.ReadLine());
                    usuario.AutorizarTarefa(idTarefa);
                    break;
                case 3:
                    foreach (Tarefa t in usuario.ObterTarefas())
                    {
                        Console.WriteLine("ID: " + t.id);
                        Console.WriteLine("ID Criador: " + t.idCriador);
                        Console.WriteLine("ID Responsável: " + t.idResponsavel);
                        Console.WriteLine("Data de Criação: " + t.dataCriacao);
                        if (t.status == StatusTarefa.Concluida)
                            Console.WriteLine("Data de Conclusão: " + t.dataConclusao);
                        if (t.situacao == SituacaoTarefa.Autorizada || t.status == StatusTarefa.EmAndamentoAtrasada)
                            Console.WriteLine("Data Prevista de Conclusão: " + t.dataPrevistaConclusao);
                        Console.WriteLine("Título: " + t.titulo);
                        Console.WriteLine("Descrição: " + t.descricao);
                        Console.WriteLine("Status: " + t.status);
                        Console.WriteLine("Situação: " + t.situacao);
                        Console.WriteLine();
                    }
                    break;
                case 4:
                    foreach (Tarefa t in usuario.ObterTarefasAtrasadas())
                    {
                        Console.WriteLine("ID: " + t.id);
                        Console.WriteLine("ID Criador: " + t.idCriador);
                        Console.WriteLine("ID Responsável: " + t.idResponsavel);
                        Console.WriteLine("Data de Criação: " + t.dataCriacao);
                        if (t.status == StatusTarefa.Concluida)
                            Console.WriteLine("Data de Conclusão: " + t.dataConclusao);
                        if (t.situacao == SituacaoTarefa.Autorizada || t.status == StatusTarefa.EmAndamentoAtrasada)
                            Console.WriteLine("Data Prevista de Conclusão: " + t.dataPrevistaConclusao);
                        Console.WriteLine("Título: " + t.titulo);
                        Console.WriteLine("Descrição: " + t.descricao);
                        Console.WriteLine("Status: " + t.status);
                        Console.WriteLine("Situação: " + t.situacao);
                        Console.WriteLine();
                    }
                    break;
                case 5:
                    foreach (Tarefa t in usuario.ObterTarefasConcluidas())
                    {
                        Console.WriteLine("ID: " + t.id);
                        Console.WriteLine("ID Criador: " + t.idCriador);
                        Console.WriteLine("ID Responsável: " + t.idResponsavel);
                        Console.WriteLine("Data de Criação: " + t.dataCriacao);
                        if (t.status == StatusTarefa.Concluida)
                            Console.WriteLine("Data de Conclusão: " + t.dataConclusao);
                        if (t.situacao == SituacaoTarefa.Autorizada || t.status == StatusTarefa.EmAndamentoAtrasada)
                            Console.WriteLine("Data Prevista de Conclusão: " + t.dataPrevistaConclusao);
                        Console.WriteLine("Título: " + t.titulo);
                        Console.WriteLine("Descrição: " + t.descricao);
                        Console.WriteLine("Status: " + t.status);
                        Console.WriteLine("Situação: " + t.situacao);
                        Console.WriteLine();
                    }
                    break;
                case 6:
                    foreach (Tarefa t in usuario.ObterTarefasAbandonadas())
                    {
                        Console.WriteLine("ID: " + t.id);
                        Console.WriteLine("ID Criador: " + t.idCriador);
                        Console.WriteLine("ID Responsável: " + t.idResponsavel);
                        Console.WriteLine("Data de Criação: " + t.dataCriacao);
                        if (t.status == StatusTarefa.Concluida)
                            Console.WriteLine("Data de Conclusão: " + t.dataConclusao);
                        if (t.situacao == SituacaoTarefa.Autorizada || t.status == StatusTarefa.EmAndamentoAtrasada)
                            Console.WriteLine("Data Prevista de Conclusão: " + t.dataPrevistaConclusao);
                        Console.WriteLine("Título: " + t.titulo);
                        Console.WriteLine("Descrição: " + t.descricao);
                        Console.WriteLine("Status: " + t.status);
                        Console.WriteLine("Situação: " + t.situacao);
                        Console.WriteLine();
                    }
                    break;
                case 7:
                    foreach (Tarefa t in usuario.ObterTarefasImpedidas())
                    {
                        Console.WriteLine("ID: " + t.id);
                        Console.WriteLine("ID Criador: " + t.idCriador);
                        Console.WriteLine("ID Responsável: " + t.idResponsavel);
                        Console.WriteLine("Data de Criação: " + t.dataCriacao);
                        if (t.status == StatusTarefa.Concluida)
                            Console.WriteLine("Data de Conclusão: " + t.dataConclusao);
                        if (t.situacao == SituacaoTarefa.Autorizada || t.status == StatusTarefa.EmAndamentoAtrasada)
                            Console.WriteLine("Data Prevista de Conclusão: " + t.dataPrevistaConclusao);
                        Console.WriteLine("Título: " + t.titulo);
                        Console.WriteLine("Descrição: " + t.descricao);
                        Console.WriteLine("Status: " + t.status);
                        Console.WriteLine("Situação: " + t.situacao);
                        Console.WriteLine();
                    }
                    break;
                case 8:
                    foreach (Tarefa t in usuario.ObterTarefasPendentesDeAprovacao())
                    {
                        Console.WriteLine("ID: " + t.id);
                        Console.WriteLine("ID Criador: " + t.idCriador);
                        Console.WriteLine("ID Responsável: " + t.idResponsavel);
                        Console.WriteLine("Data de Criação: " + t.dataCriacao);
                        if (t.status == StatusTarefa.Concluida)
                            Console.WriteLine("Data de Conclusão: " + t.dataConclusao);
                        if (t.situacao == SituacaoTarefa.Autorizada || t.status == StatusTarefa.EmAndamentoAtrasada)
                            Console.WriteLine("Data Prevista de Conclusão: " + t.dataPrevistaConclusao);
                        Console.WriteLine("Título: " + t.titulo);
                        Console.WriteLine("Descrição: " + t.descricao);
                        Console.WriteLine("Status: " + t.status);
                        Console.WriteLine("Situação: " + t.situacao);
                        Console.WriteLine();
                    }
                    break;
            }
        }
    }
}