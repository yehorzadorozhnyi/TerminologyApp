using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TerminologyApp.Models;

namespace TerminologyApp.Data
{
    public class JsonStorage
    {
        private readonly string termsFilePath = "terms.json";
        private readonly string categoriesFilePath = "categories.json";

        public void SaveAll(List<Term> terms, List<Category> categories)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            var termsJson = JsonSerializer.Serialize(terms, options);
            File.WriteAllText(termsFilePath, termsJson);

            var categoriesJson = JsonSerializer.Serialize(categories, options);
            File.WriteAllText(categoriesFilePath, categoriesJson);
        }

        public List<Term> LoadTerms()
        {
            if (!File.Exists(termsFilePath))
                return new List<Term>();

            var json = File.ReadAllText(termsFilePath);
            return JsonSerializer.Deserialize<List<Term>>(json) ?? new List<Term>();
        }

        public List<Category> LoadCategories()
        {
            if (!File.Exists(categoriesFilePath))
                return new List<Category>();

            var json = File.ReadAllText(categoriesFilePath);
            return JsonSerializer.Deserialize<List<Category>>(json) ?? new List<Category>();
        }
    }
}