using System;
using System.Collections.Generic;
using System.Text;

namespace TerminologyApp.Models
{
    // Клас для зберігання інформації про термін
    public class Term
    {
        public string Name { get; set; }
        public string Definition { get; set; }
        public List<string> References { get; set; }
        public string Category { get; set; }
        public string DisplayName => Name?.Replace("_", " ");

        public Term()
        {
            References = new List<string>();
        }

        public Term(
            string name,
            string definition,
            List<string> references,
            string category)
        {
            Name = name;
            Definition = definition;
            References = references;
            Category = category;
        }
    }
}