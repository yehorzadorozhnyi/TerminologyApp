using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TerminologyApp
{
    internal class TerminologyBase
    {
        public List<Term> Terms = new List<Term>();

        public void AddTerm(Term term)
        {
            Terms.Add(term);
        }

        public Term Find(string name)
        {
            return Terms.FirstOrDefault(t => t.Name == name);
        }
    }
}