using ManipuladorDeArquivos;
using System.Text.Json;

namespace CadastroUsuarioArquivo
{
    public static class CadastroDeUsuario<T> where T : class
    {
        public static List<T> Usuarios()
        {
            List<T> usuarios = ManipuladorDeArquivos<T>.CarregarLista();
            return usuarios;
        }
        public static List<T> CarregarLista()
        {
            string tipo = typeof(T).Name;
            var relativo = Directory.GetCurrentDirectory();
            var nomeArquivo = $"{tipo}.json";
            var caminhoArquivo = Path.Combine(relativo, nomeArquivo);

            try
            {
                string jsonString = File.ReadAllText(caminhoArquivo);
                List<T> itemList = JsonSerializer.Deserialize<List<T>>(jsonString);
                return itemList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                return null;
            }
        }
        public static void AtualizarLista(List<T> lista)
        {
            string tipo = typeof(T).Name; // Recebe o nome da classe
            var relativo = Directory.GetCurrentDirectory();
            var nomeArquivo = $"{tipo}.json";
            var caminhoArquivo = Path.Combine(relativo, nomeArquivo);

            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(caminhoArquivo, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}

