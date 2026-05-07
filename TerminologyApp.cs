using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace TerminologyApp
{
    public partial class TerminologyApp : Form
    {
        private readonly TerminologyBase db = new TerminologyBase();
        private string filePath = "terms.json";

        public TerminologyApp()
        {
            InitializeComponent();
            LoadData();
            RefreshTermsList();
        }
        // =========================
        // JSON ЗБЕРІГАННЯ
        // =========================

        private void SaveData()
        {
            var json = JsonSerializer.Serialize(db.Terms, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        private void LoadData()
        {
            if (!File.Exists(filePath))
                return;

            var json = File.ReadAllText(filePath);

            var data = JsonSerializer.Deserialize<List<Term>>(json);

            if (data != null)
                db.Terms = data;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveData();
            base.OnFormClosing(e);
        }

        // =========================
        // ДОПОМІЖНІ МЕТОДИ
        // =========================

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

        // =========================
        // ОСНОВНІ ДІЇ
        // =========================

        private void btnAddTerm_Click(object sender, EventArgs e)
        {
            var term = new Term(
                txtTerm.Text,
                txtDefinition.Text,
                GetReferences()
            );

            db.AddTerm(term);
            lstTerms.Items.Add(term.Name);
            SaveData();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            foreach (var t in db.Terms)
            {
                txtOutput.AppendText(t.Name + " - " + t.Definition + "\n");
                txtOutput.AppendText("Посилання на термін: ");

                foreach (var r in t.References)
                {
                    txtOutput.AppendText($"http://term/{r} ");
                }

                txtOutput.AppendText("\n\n");
            }
        }

        private void btnShowChain_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            ShowChain(txtTerm.Text);
        }

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
            SaveData();
        }

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
            SaveData();
        }

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

        // =========================
        // ГІПЕРПОСИЛАННЯ
        // =========================

        private void txtOutput_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.LinkText))
                return;

            string termName = e.LinkText.Replace("http://term/", "");

            var term = db.Find(termName);
            if (term == null) return;

            txtTerm.Text = term.Name;
            txtDefinition.Text = term.Definition;
            txtReferences.Text = string.Join(", ", term.References);
        }

    }
}