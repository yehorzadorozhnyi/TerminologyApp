using System;
using System.Collections.Generic;
using System.Text;

namespace TerminologyApp
{
    internal class Term
    {
        public string Name { get; set; }
        public string Definition { get; set; }
        public List<string> References { get; set; }

        public Term(string name, string definition, List<string> references)
        {
            Name = name;
            Definition = definition;
            References = references;
        }
    }
}