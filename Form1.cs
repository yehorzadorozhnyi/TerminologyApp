using System;
using System.Linq;
using System.Windows.Forms;

namespace TerminologyApp
{
    public partial class Form1 : Form
    {
        TerminologyBase db = new TerminologyBase();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddTerm_Click(object sender, EventArgs e)
        {
            var refs = txtReferences.Text
                .Split(',')
                .Select(r => r.Trim())
                .ToList();

            Term term = new Term(txtTerm.Text, txtDefinition.Text, refs);

            db.AddTerm(term);

            lstTerms.Items.Add(term.Name);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            foreach (var t in db.Terms)
            {
                txtOutput.AppendText($"{t.Name} - {t.Definition}\r\n");
            }
        }

        private void btnShowChain_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            ShowChain(txtTerm.Text);
        }

        void ShowChain(string name)
        {
            var term = db.Find(name);

            if (term == null) return;

            txtOutput.AppendText(term.Name + " -> ");

            foreach (var r in term.References)
            {
                ShowChain(r);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTerm.Clear();
            txtDefinition.Clear();
            txtReferences.Clear();
            txtOutput.Clear();
        }

        // Видалення
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = txtTerm.Text;

            db.DeleteTerm(name);

            lstTerms.Items.Remove(name);
        }

        // Редагування
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string oldName = txtTerm.Text;

            var updated = new Term(
                txtTerm.Text,
                txtDefinition.Text,
                txtReferences.Text
                    .Split(',')
                    .Select(r => r.Trim())
                    .ToList()
            );

            db.UpdateTerm(oldName, updated);

            lstTerms.Items.Clear();
            foreach (var t in db.Terms)
                lstTerms.Items.Add(t.Name);
        }
    }
}