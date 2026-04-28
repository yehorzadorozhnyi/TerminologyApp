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
                .Where(r => !string.IsNullOrWhiteSpace(r))
                .ToList();

            Term term = new Term(
                txtTerm.Text,
                txtDefinition.Text,
                refs
            );

            db.AddTerm(term);

            lstTerms.Items.Add(term.Name);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            foreach (var t in db.Terms)
            {
                txtOutput.AppendText(
                    $"{t.Name} - {t.Definition}\r\n"
                );
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

            if (term == null)
                return;

            txtOutput.AppendText(
                term.Name + " -> "
            );

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = txtTerm.Text;

            db.DeleteTerm(name);

            lstTerms.Items.Remove(name);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string oldName = txtTerm.Text;

            var updated = new Term(
                txtTerm.Text,
                txtDefinition.Text,
                txtReferences.Text
                    .Split(',')
                    .Select(r => r.Trim())
                    .Where(r => !string.IsNullOrWhiteSpace(r))
                    .ToList()
            );

            db.UpdateTerm(oldName, updated);

            lstTerms.Items.Clear();

            foreach (var t in db.Terms)
            {
                lstTerms.Items.Add(t.Name);
            }
        }

        // Автозаповнення полів при виборі терміна
        private void lstTerms_SelectedIndexChanged(
            object sender,
            EventArgs e
        )
        {
            if (lstTerms.SelectedItem is not string selectedName)
                return;

            Term term = db.Find(selectedName);

            if (term != null)
            {
                txtTerm.Text = term.Name;
                txtDefinition.Text = term.Definition;

                txtReferences.Text =
                    string.Join(
                        ", ",
                        term.References
                    );
            }
        }
    }
}