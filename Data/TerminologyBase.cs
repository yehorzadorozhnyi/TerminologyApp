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

        // Друга база — категорії
        public List<Category> Categories = new List<Category>();

        // Додавання терміна
        public void AddTerm(Term term)
        {
            Terms.Add(term);

            // Пошук категорії
            var category = Categories
                .FirstOrDefault(c => c.Name == term.Category);

            // Якщо категорії нема — створити
            if (category == null)
            {
                category = new Category(term.Category, new List<string>());
                Categories.Add(category);
            }

            // Додати термін до категорії
            category.Terms.Add(term.Name);
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

            if (term == null)
                return;

            Terms.Remove(term);

            // Видалення з категорії
            var category = Categories
                .FirstOrDefault(c => c.Name == term.Category);

            if (category != null)
            {
                category.Terms.Remove(term.Name);
            }
        }

        // Редагування
        public void UpdateTerm(string oldName, Term updatedTerm)
        {
            DeleteTerm(oldName);
            AddTerm(updatedTerm);
        }

        // Отримання термінів категорії
        public List<Term> GetTermsByCategory(string categoryName)
        {
            return Terms
                .Where(t => t.Category == categoryName)
                .ToList();
        }

        // Оновлення списку термінів
        public List<string> GetAllTermNames()
        {
            return Terms.Select(t => t.Name).ToList();
        }


    }
}