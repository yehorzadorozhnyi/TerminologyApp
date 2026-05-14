using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TerminologyApp.Models;

namespace TerminologyApp.Data
{
    public class JsonStorage
    {
        private readonly string filePath;

        public JsonStorage(string filePath)
        {
            this.filePath = filePath;
        }

        // Збереження
        public void Save(DatabaseModel data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        // Завантаження
        public DatabaseModel Load()
        {
            if (!File.Exists(filePath))
                return new DatabaseModel();

            var json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<DatabaseModel>(json)
                   ?? new DatabaseModel();
        }
    }
}