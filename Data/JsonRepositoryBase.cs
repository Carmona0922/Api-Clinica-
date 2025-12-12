using System.Text.Json;

namespace API_Biblioteca.Data
{
    public abstract class JsonRepositoryBase<T> where T : class
    {
        protected readonly string FilePath;

        protected JsonRepositoryBase(string filePath)
        {
            FilePath = filePath;

            // Si el archivo no existe, lo crea
            if (!File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, "[]");
            }
        }

        protected List<T> LoadAll()
        {
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<T>>(json)
                   ?? new List<T>();
        }

        protected void SaveAll(List<T> items)
        {
            var json = JsonSerializer.Serialize(items,
                new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(FilePath, json);
        }
    }
}

