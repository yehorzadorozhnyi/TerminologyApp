using System;
using System.Linq;
using System.Windows.Forms;
using TerminologyApp.Models;
using TerminologyApp.Data;

namespace TerminologyApp
{
    public partial class TerminologyApp : Form
    {
        private readonly TerminologyBase db = new TerminologyBase();
        private readonly JsonStorage storage = new JsonStorage("terms.json");

        public TerminologyApp()
        {
            InitializeComponent();


            var data = storage.Load();

            db.Terms = data.Terms ?? new();
            db.Categories = data.Categories ?? new();

            RefreshTermsList();
        }

        // =========================
        // UI ОНОВЛЕННЯ
        // =========================

        private void RefreshTermsList()
        {
            lstTerms.Items.Clear();
            lstTerms.Items.AddRange(db.GetAllTermNames().ToArray());
        }

        // =========================
        // ПОДІЇ НА КНОПКИ
        // =========================
        // ДОДАТИ ТЕРМІН
        private void btnAddTerm_Click(object sender, EventArgs e)
        {
            AddTermForm form = new AddTermForm();
            form.LoadCategories(db.Categories);

            if (form.ShowDialog() == DialogResult.OK)
            {
                db.AddTerm(form.NewTerm);

                RefreshTermsList();
                Save();
            }
        }
        // ОЧИСТИТИ ВИХІД
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
        }
        // ВИДАЛЕННЯ ТЕРМІНА
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTerms.SelectedItem is not string name)
                return;

            db.DeleteTerm(name);

            lstTerms.Items.Remove(name);

            storage.Save(new DatabaseModel
            {
                Terms = db.Terms,
                Categories = db.Categories
            });
        }
        // РЕДАГУВАННЯ ТЕРМІНА

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

                storage.Save(new DatabaseModel
                {
                    Terms = db.Terms,
                    Categories = db.Categories
                });
            }
        }
        // ПОКАЗАТИ ВСІ ТЕРМІНИ

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            foreach (var t in db.Terms)
            {
                txtOutput.AppendText($"{t.Name} - {t.Definition}\n");
                txtOutput.AppendText("Посилання: ");

                foreach (var r in t.References)
                {
                    txtOutput.AppendText($"http://term/{r.Replace(" ", "_")} ");
                }

                txtOutput.AppendText("\n\n");
            }
        }

        // ЛАНЦЮГ ПОСИЛАНЬ
        private void btnShowChain_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            if (lstTerms.SelectedItem is not string selected)
                return;

            ShowChain(selected);
        }

        private void ShowChain(string name)
        {
            var term = db.Find(name);
            if (term == null) return;

            txtOutput.AppendText($"{term.Name} -> ");

            foreach (var r in term.References)
            {
                ShowChain(r);
            }
        }

        // =========================
        // ВИБІР ТЕРМІНА
        // =========================

        private void lstTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTerms.SelectedItem is not string name)
                return;

            var term = db.Find(name);
            if (term == null) return;

            txtOutput.Clear();

            txtOutput.AppendText($"Термін: {term.Name}\n\n");
            txtOutput.AppendText($"Визначення: {term.Definition}\n\n");
            txtOutput.AppendText($"Категорія: {term.Category}\n\n");
            txtOutput.AppendText("Посилання:\n");

            foreach (var r in term.References)
            {
                txtOutput.AppendText($"http://term/{r.Replace(" ", "_")} ");
            }
        }

        // =========================
        // КЛІК ПО ПОСИЛАННЮ
        // =========================

        private void txtOutput_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            string clicked = e.LinkText;

            if (string.IsNullOrWhiteSpace(clicked))
                return;

            string termName = clicked.Replace("http://term/", "").Replace("_", " ");

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

            var filtered = db.Terms.Where(t =>
                (!string.IsNullOrEmpty(t.Name) && t.Name.ToLower().Contains(search)) ||
                (!string.IsNullOrEmpty(t.Category) && t.Category.ToLower().Contains(search))
            );

            lstTerms.Items.AddRange(filtered.Select(t => t.Name).ToArray());
        }

        // =========================
        // КАТЕГОРІЇ
        // =========================

        private void btnShowCategories_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            foreach (var c in db.Categories)
            {
                txtOutput.AppendText($"Категорія: {c.Name}\n");

                foreach (var term in c.Terms)
                {
                    txtOutput.AppendText($" - {term}\n");
                }

                txtOutput.AppendText("\n");
            }
        }

        // =========================
        // ЗБЕРЕЖЕННЯ ДОПОМІЖНЕ
        // =========================

        private void Save()
        {
            storage.Save(new DatabaseModel
            {
                Terms = db.Terms,
                Categories = db.Categories
            });
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            storage.Save(new DatabaseModel
            {
                Terms = db.Terms,
                Categories = db.Categories
            });

            base.OnFormClosing(e);
        }

    }
}