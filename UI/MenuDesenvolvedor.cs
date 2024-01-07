using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using Tarefas;
using Usuarios;

namespace UI
{
    internal class MenuDesenvolvedor
    {
        public static void Menu(Desenvolvedor usuario)
        {
            Console.Clear();
            Console.WriteLine($"Logado como {usuario.nome}");
            Console.WriteLine();
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1 - Cadastrar Tarefa");
            Console.WriteLine("2 - Visualizar tarefa por id da tarefa");
            Console.WriteLine("3 - Visualizar todas as tarefas do usuario");
            Console.WriteLine("4 - Visualizar todas as tarefas do usuario e seus relacionamentos");
            Console.WriteLine("0 - Sair");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Informe o titulo da tarefa");
                    string titulo = Console.ReadLine();
                    Console.WriteLine("Informe a descrição da tarefa");
                    string descricao = Console.ReadLine();
                    DateTime prazo = DateTime.Now;
                    usuario.CriarTarefa(usuario.id, titulo, descricao, prazo);
                    break;
                case 2:
                    Console.WriteLine("Informe o id da tarefa");
                    int idTarefa = int.Parse(Console.ReadLine());
                    Tarefa tarefa = usuario.ObterTarefa(idTarefa);
                    Console.WriteLine("ID: " + tarefa.id);
                    Console.WriteLine("ID Criador: " + tarefa.idCriador);
                    Console.WriteLine("ID Responsável: " + tarefa.idResponsavel);
                    Console.WriteLine("Data de Criação: " + tarefa.dataCriacao);
                    if (tarefa.status == StatusTarefa.Concluida)
                        Console.WriteLine("Data de Conclusão: " + tarefa.dataConclusao);
                    if (tarefa.situacao == SituacaoTarefa.Autorizada || tarefa.status == StatusTarefa.EmAndamentoAtrasada)
                        Console.WriteLine("Data Prevista de Conclusão: " + tarefa.dataPrevistaConclusao);
                    Console.WriteLine("Título: " + tarefa.titulo);
                    Console.WriteLine("Descrição: " + tarefa.descricao);
                    Console.WriteLine("Status: " + tarefa.status);
                    Console.WriteLine("Situação: " + tarefa.situacao);
                    Console.WriteLine();
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
                    foreach (Tarefa t in usuario.ObterTarefasRelacionadas())
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
                case 0:
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }
}