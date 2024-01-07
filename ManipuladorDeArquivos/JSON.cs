using Newtonsoft.Json;
using Newtonsoft
using System;
using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ManipuladorDeArquivos
{
    internal class JSON
    {

public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
    }

    class Program
    {
        static void Main()
        {
            // Passo 1: Ler o JSON
            string jsonFilePath = "tarefas.json";
            List<Tarefa> listaTarefas;

            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                listaTarefas = JsonConvert.DeserializeObject<List<Tarefa>>(json);
            }
            else
            {
                listaTarefas = new List<Tarefa>();
            }

            // Passo 2: Adicionar uma nova tarefa à lista
            Tarefa novaTarefa = new Tarefa
            {
                Id = 4,
                Descricao = "Tarefa 4",
                Status = "Pendente"
            };
            listaTarefas.Add(novaTarefa);

            // Passo 3: Atualizar a lista no JSON
            string novaListaJson = JsonConvert.SerializeObject(listaTarefas, Formatting.Indented);
            File.WriteAllText(jsonFilePath, novaListaJson);

            Console.WriteLine("Operações concluídas com sucesso.");
        }
    }

}
}
