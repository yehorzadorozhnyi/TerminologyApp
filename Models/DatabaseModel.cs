using System;
using System.Collections.Generic;
using System.Text;

namespace TerminologyApp.Models
{
    public class DatabaseModel
    {
        public List<Term> Terms { get; set; }

        public List<Category> Categories { get; set; }

        public DatabaseModel()
        {
            Terms = new List<Term>();
            Categories = new List<Category>();
        }
    }
}
