using System.Collections.Generic;
using System.Linq;
using TerminologyApp.Models;
using TerminologyApp.Data;

namespace TerminologyApp.Data
{
    internal class TerminologyBase
    {
        // База термінів
        public List<Term> Terms = new List<Term>();

        // База категорій
        public List<Category> Categories = new List<Category>();



        // Додавання терміна
        public void AddTerm(Term term)
        {
            Terms.Add(term);

            var category = Categories
                .FirstOrDefault(c => c.Name.Equals(term.Category, System.StringComparison.OrdinalIgnoreCase));

            if (category == null)
            {
                category = new Category(term.Category, new List<string>());
                Categories.Add(category);
            }

            if (!category.Terms.Contains(term.Name))
            {
                category.Terms.Add(term.Name);
            }
        }

        // Пошук терміна
        public Term Find(string name)
        {
            return Terms.FirstOrDefault(t => t.Name == name);
        }

        // Видалення
        public void DeleteTerm(string name)
        {
            var term = Find(name);
            if (term == null) return;

            string originalTermName = term.Name;
            string targetCategoryName = term.Category;

            Terms.Remove(term);

            var category = Categories.FirstOrDefault(c =>
                c.Name.Equals(targetCategoryName, StringComparison.OrdinalIgnoreCase)
            );

            if (category != null)
            {
                category.Terms.Remove(originalTermName);
                category.Terms.Remove(originalTermName.Replace("_", " "));
            }

            foreach (var cat in Categories)
            {
                cat.Terms.Remove(originalTermName);
                cat.Terms.Remove(originalTermName.Replace("_", " "));
            }

            // ОЧИЩЕННЯ ПОВ'ЯЗАНИХ ПОСИЛАНЬ В ІНШИХ ТЕРМІНАХ
            foreach (var t in Terms)
            {
                if (t.References != null)
                {
                    t.References.RemoveAll(r =>
                        r.Equals(originalTermName, StringComparison.OrdinalIgnoreCase) ||
                        r.Replace("_", " ").Equals(originalTermName.Replace("_", " "), StringComparison.OrdinalIgnoreCase)
                    );
                }
            }

            var storage = new JsonStorage();
            storage.SaveAll(Terms, Categories);
        }

        // Редагування
        public void UpdateTerm(string oldName, Term updatedTerm)
        {
            DeleteTerm(oldName);
            AddTerm(updatedTerm);
        }

        // Отримання термінів за категорією
        public List<Term> GetTermsByCategory(string categoryName)
        {
            return Terms
                .Where(t => t.Category == categoryName)
                .ToList();
        }
        // Отримання всіх категорій
        public List<string> GetAllTermNames()
        {
            return Terms
                .Select(t => t.Name.Replace("_", " "))
                .ToList();
        }


    }
}