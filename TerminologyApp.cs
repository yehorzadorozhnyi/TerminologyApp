using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TerminologyApp
{
    public partial class TerminologyApp : Form
    {
        TerminologyBase db = new TerminologyBase();

        public TerminologyApp()
        {
            InitializeComponent();
        }

        // Допоміжні методи

        private List<string> GetReferences()
        {
            return txtReferences.Text
                .Split(',')
                .Select(r => r.Trim())
                .Where(r => !string.IsNullOrWhiteSpace(r))
                .ToList();
        }

        private void RefreshTermsList()
        {
            lstTerms.Items.Clear();

            foreach (var t in db.Terms)
            {
                lstTerms.Items.Add(t.Name);
            }
        }

        // Основні події

        // Додавання нового терміну
        private void btnAddTerm_Click(object sender, EventArgs e)
        {
            var term = new Term(
                txtTerm.Text,
                txtDefinition.Text,
                GetReferences()
            );

            db.AddTerm(term);
            lstTerms.Items.Add(term.Name);
        }

        // Виведення списку всіх термінів
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            foreach (var t in db.Terms)
            {
                txtOutput.AppendText($"{t.Name} - {t.Definition}\r\n");
            }
        }

        // Відображення ланцюжка термінів
        private void btnShowChain_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            ShowChain(txtTerm.Text);
        }

        // Рекурсивне виведення ланцюжка
        private void ShowChain(string name)
        {
            var term = db.Find(name);
            if (term == null) return;

            txtOutput.AppendText(term.Name + " -> ");

            foreach (var r in term.References)
            {
                ShowChain(r);
            }
        }

        // Очищення полів
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTerm.Clear();
            txtDefinition.Clear();
            txtReferences.Clear();
            txtOutput.Clear();
        }

        // Видалення терміну
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = txtTerm.Text;

            db.DeleteTerm(name);
            lstTerms.Items.Remove(name);
        }

        // Редагування терміну
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = txtTerm.Text;

            var updated = new Term(
                txtTerm.Text,
                txtDefinition.Text,
                GetReferences()
            );

            db.UpdateTerm(name, updated);
            RefreshTermsList();
        }

        // Автозаповнення при виборі
        private void lstTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTerms.SelectedItem is not string selectedName)
                return;

            var term = db.Find(selectedName);
            if (term == null) return;

            txtTerm.Text = term.Name;
            txtDefinition.Text = term.Definition;
            txtReferences.Text = string.Join(", ", term.References);
        }
    }
}