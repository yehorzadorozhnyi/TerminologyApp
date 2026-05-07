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

        // Оновлення списку термінів
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

        // Додавання терміна
        private void btnAddTerm_Click(object sender, EventArgs e)
        {
            AddTermForm form = new AddTermForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                db.AddTerm(form.NewTerm);

                RefreshTermsList();

                SaveData();
            }
        }
        // Виведення всіх термінів
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

        // Виведення ланцюга посилань для вибраного терміна
        private void btnShowChain_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            if (lstTerms.SelectedItem is not string selectedName)
                return;
            txtOutput.Clear();
            ShowChain(selectedName);
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

        // Очистка полів
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
        }

        // Видалення терміна
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTerms.SelectedItem is not string name)
                return;

            db.DeleteTerm(name);
            lstTerms.Items.Remove(name);
            SaveData();
        }

        // Редагуання терміна
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstTerms.SelectedItem is not string oldName)
                return;

            var term = db.Find(oldName);

            if (term == null)
                return;

            AddTermForm form = new AddTermForm(term);

            if (form.ShowDialog() == DialogResult.OK)
            {
                db.UpdateTerm(oldName, form.NewTerm);

                RefreshTermsList();

                SaveData();
            }
        }

        // Виведення інформації про вибраний термін
        private void lstTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTerms.SelectedItem is not string selectedName)
                return;

            var term = db.Find(selectedName);
            if (term == null) return;

            txtOutput.Clear();
            txtOutput.AppendText($"Термін: {term.Name}\n\n");
            txtOutput.AppendText($"Визначення: {term.Definition}\n\n");
            txtOutput.AppendText("Посилання:\n");
            foreach (var r in term.References)
            {
                txtOutput.AppendText($"http://term/{r}\n");
            }
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

            if (term == null)
                return;

            lstTerms.SelectedItem = term.Name;
        }

        // =========================
        // ПОШУК
        // =========================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();

            lstTerms.Items.Clear();

            var filtered = db.Terms
                .Where(t => t.Name.ToLower().Contains(search))
                .ToList();

            foreach (var term in filtered)
            {
                lstTerms.Items.Add(term.Name);
            }
        }
    }
}