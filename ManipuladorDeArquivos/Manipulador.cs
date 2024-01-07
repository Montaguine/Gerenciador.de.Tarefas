using System.Reflection;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using JsonProperty = Newtonsoft.Json.Serialization.JsonProperty;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ManipuladorDeArquivos
{
    public static class Manipulador<T> where T : class
    {
        private static readonly string DiretorioArquivosJson = "ArquivosJSON"; // Nome da pasta

        public static List<T> CarregarLista()
        {
            string tipo = typeof(T).Name;
            var diretorioProjeto = ObterDiretorioProjeto();
            var nomeArquivo = $"{tipo}.json";
            var caminhoArquivo = Path.Combine(diretorioProjeto, DiretorioArquivosJson, nomeArquivo);

            try
            {
                string jsonString = File.ReadAllText(caminhoArquivo);
                List<T> itemList = DeserializarJson<List<T>>(jsonString);
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
            string tipo = typeof(T).Name;
            var diretorioProjeto = ObterDiretorioProjeto();
            var nomeArquivo = $"{tipo}.json";
            var caminhoArquivo = Path.Combine(diretorioProjeto, DiretorioArquivosJson, nomeArquivo);

            try
            {
                string json = SerializarJson(lista);
                File.WriteAllText(caminhoArquivo, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        private static T DeserializarJson<T>(string jsonString)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonUsuarioConverter() } // Adiciona o conversor personalizado
            };

            return JsonSerializer.Deserialize<T>(jsonString, options);
        }


        private static string SerializarJson(object obj)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(obj, options);
        }

        private static string ObterDiretorioProjeto()
        {
            // Retorna o diretório do projeto, considerando a estrutura de pastas típica
            var diretorioAtual = Directory.GetCurrentDirectory();
            return Path.GetFullPath(Path.Combine(diretorioAtual, "..", "..", "..", ".."));
        }
    }

    // Conversor personalizado para desserializar tipos abstratos ou interfaces
    public class JsonPrivateResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (!property.Writable)
            {
                var propertyInfo = member as PropertyInfo;
                if (propertyInfo != null)
                {
                    var hasPrivateSetter = propertyInfo.GetSetMethod(true) != null;
                    property.Writable = hasPrivateSetter;
                }
            }

            return property;
        }
    }
}
