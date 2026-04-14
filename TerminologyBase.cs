using System;
using System.Collections.Generic;
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

        //Видалення
        public void DeleteTerm(string name)
        {
            var term = Find(name);
            if (term != null)
            {
                Terms.Remove(term);
            }
        }

        //Редагування
        public void UpdateTerm(string oldName, Term updatedTerm)
        {
            var index = Terms.FindIndex(t => t.Name == oldName);

            if (index != -1)
            {
                Terms[index] = updatedTerm;
            }
        }
    }
}