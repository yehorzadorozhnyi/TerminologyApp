using System.Collections.Generic;

namespace TerminologyApp.Models
{
    public class Category
    {
        public string Name { get; set; }

        public List<string> Terms { get; set; }

        public Category()
        {
            Terms = new List<string>();
        }

        public Category(string name, List<string> terms)
        {
            Name = name;
            Terms = terms;
        }
    }
}
