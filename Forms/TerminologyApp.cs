using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TerminologyApp.Models;
using TerminologyApp.Data;

namespace TerminologyApp
{
    public partial class TerminologyApp : Form
    {
        private readonly TerminologyBase db = new TerminologyBase();
        private readonly JsonStorage storage = new JsonStorage();

        public TerminologyApp()
        {
            InitializeComponent();

            db.Terms = storage.LoadTerms() ?? new();
            db.Categories = storage.LoadCategories() ?? new();



            txtSearch.Text = "Знайти термін...";
            RefreshTermsList();
        }

        // =========================
        // UI ОНОВЛЕННЯ
        // =========================

        private void RefreshTermsList()
        {
            lstTerms.Items.Clear();

            foreach (var category in db.Categories)
            {
                lstTerms.Items.Add($"[{category.Name.ToUpper()}]");

                var categoryTerms = db.GetTermsByCategory(category.Name);

                foreach (var term in categoryTerms)
                {
                    lstTerms.Items.Add($"\t{term.DisplayName}");
                }
            }
        }

        // =========================
        // ПОДІЇ НА КНОПКИ
        // =========================

        private void btnAddTerm_Click(object sender, EventArgs e)
        {
            AddTermForm form = new AddTermForm();
            form.LoadCategories(db.Categories);

            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                db.AddTerm(form.NewTerm);
                RefreshTermsList();
                Save();
            }
            else if (result == DialogResult.Yes)
            {
                string categoryToDelete = form.NewTerm.Name;

                var termsInCategory = db.GetTermsByCategory(categoryToDelete);
                foreach (var term in termsInCategory)
                {
                    db.DeleteTerm(term.Name);
                }

                var categoryObj = db.Categories.FirstOrDefault(c => c.Name.Equals(categoryToDelete, StringComparison.OrdinalIgnoreCase));
                if (categoryObj != null)
                {
                    db.Categories.Remove(categoryObj);
                }

                txtOutput.Clear();
                RefreshTermsList();
                Save();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTerms.SelectedItem is not string selectedItem || !selectedItem.StartsWith("\t"))
            {
                MessageBox.Show("Будь ласка, виберіть конкретний термін для видалення!", "Увага");
                return;
            }

            string cleanedTermName = selectedItem.Replace("\t", "").Trim().Replace(" ", "_");
            var selectedTerm = db.Find(cleanedTermName);

            if (selectedTerm == null) return;

            var confirmResult = MessageBox.Show(
                $"Ви впевнені, що хочете видалити термін '{selectedTerm.DisplayName}'?",
                "Підтвердження видалення",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                db.DeleteTerm(selectedTerm.Name);
                txtOutput.Clear(); 
                RefreshTermsList();
                Save();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstTerms.SelectedItem is not string selectedItem || !selectedItem.StartsWith("\t"))
            {
                MessageBox.Show("Будь ласка, виберіть конкретний термін для редагування! (Якщо бажаєте видалити категорії, перейдіть у вікно додавання терміну, оберіть відповідну категорію натисність кнопку ВИДАЛИТИ КАТЕГОРІЮ)", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cleanedTermName = selectedItem.Replace("\t", "").Trim().Replace(" ", "_");
            var selectedTerm = db.Find(cleanedTermName);

            if (selectedTerm == null)
            {
                MessageBox.Show("Термін не знайдено в базі даних!", "Помилка");
                return;
            }

            AddTermForm form = new AddTermForm(selectedTerm);
            form.LoadCategories(db.Categories);

            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                db.UpdateTerm(selectedTerm.Name, form.NewTerm);
                RefreshTermsList();
                Save();
            }
            else if (result == DialogResult.Yes)
            {
                string categoryToDelete = form.NewTerm.Name;

                var termsInCategory = db.GetTermsByCategory(categoryToDelete);
                foreach (var term in termsInCategory)
                {
                    db.DeleteTerm(term.Name);
                }

                var categoryObj = db.Categories.FirstOrDefault(c => c.Name.Equals(categoryToDelete, StringComparison.OrdinalIgnoreCase));
                if (categoryObj != null)
                {
                    db.Categories.Remove(categoryObj);
                }

                txtOutput.Clear(); // Очищаємо екран
                RefreshTermsList();
                Save();
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            foreach (var t in db.Terms)
            {
                PrintTermDetails(t);
                txtOutput.AppendText("---------------------------\n");
            }
        }

        // =========================
        // ЛАНЦЮГ
        // =========================

        private void btnShowChain_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            if (lstTerms.SelectedItem == null)
                return;

            string selectedText = lstTerms.SelectedItem.ToString().Trim();

            var selectedTerm = db.Terms.FirstOrDefault(t =>
                t.Name.Replace("_", " ").Equals(selectedText, StringComparison.OrdinalIgnoreCase)
            );
            if (selectedTerm == null)
                return;

            ShowChain(selectedTerm.Name);
        }

        private void ShowChain(string name, HashSet<string> visited = null)
        {
            if (visited == null)
                visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            if (visited.Contains(name)) return;
            visited.Add(name);

            var term = db.Terms.FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (term == null) return;

            txtOutput.AppendText($"{term.DisplayName} -> ");

            foreach (var r in term.References)
            {
                ShowChain(r, visited);
            }
        }

        // =========================
        // ВИБІР ТЕРМІНА
        // =========================

        private void lstTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTerms.SelectedItem is not string selectedItem)
            {
                txtOutput.Clear();
                return;
            }

            if (!selectedItem.StartsWith("\t"))
            {
                txtOutput.Clear(); 
                txtOutput.AppendText("Вибрано категорію. Оберіть термін нижче для перегляду деталей.");
                return;
            }

            string cleanedTermName = selectedItem.Replace("\t", "").Trim().Replace(" ", "_");
            var selectedTerm = db.Find(cleanedTermName);

            txtOutput.Clear();

            if (selectedTerm != null)
            {
                PrintTermDetails(selectedTerm);
            }
        }

        private void PrintTermDetails(Term term)
        {
            txtOutput.AppendText($"Термін: {term.DisplayName}\n\n");
            txtOutput.AppendText($"Визначення: {term.Definition}\n\n");
            txtOutput.AppendText($"Категорія: {term.Category}\n\n");
            txtOutput.AppendText("Посилання:\n");

            foreach (var r in term.References)
            {
                string beautifulLink = r.Replace(" ", "-");
                txtOutput.AppendText($"http://term/{beautifulLink}\n");
            }
        }

        // =========================
        // КЛІК ПО ПОСИЛАННЮ
        // =========================

        private void txtOutput_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.LinkText)) return;

            string rawName = e.LinkText.Replace("http://term/", "");

            string targetName = rawName.Replace("_", " ").Trim();

            var foundTerm = db.Terms.FirstOrDefault(t =>
                t.Name.Replace("_", " ").Equals(targetName, StringComparison.OrdinalIgnoreCase)
            );

            if (foundTerm == null) return;

            txtSearch.Text = string.Empty;
            RefreshTermsList();

            int targetIndex = -1;
            for (int i = 0; i < lstTerms.Items.Count; i++)
            {
                string itemText = lstTerms.Items[i].ToString().Trim();

                if (itemText.Equals(targetName, StringComparison.OrdinalIgnoreCase))
                {
                    targetIndex = i;
                    break;
                }
            }

            if (targetIndex != -1)
            {
                lstTerms.SelectedIndex = targetIndex;
            }
        }

        // =========================
        // ПОШУК
        // =========================

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower().Trim();
            lstTerms.Items.Clear();

            if (search == "знайти термін..." || string.IsNullOrWhiteSpace(search))
            {
                RefreshTermsList();
                return;
            }

            var filteredTerms = db.Terms.Where(t =>
                (!string.IsNullOrEmpty(t.DisplayName) && t.DisplayName.ToLower().Contains(search)) ||
                (!string.IsNullOrEmpty(t.Category) && t.Category.ToLower().Contains(search)) ||
                (!string.IsNullOrEmpty(t.Definition) && t.Definition.ToLower().Contains(search))
            ).ToList();

            foreach (var category in db.Categories)
            {
                var categoryTerms = filteredTerms
                    .Where(t => t.Category.Equals(category.Name, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (categoryTerms.Any())
                {
                    lstTerms.Items.Add($"[{category.Name.ToUpper()}]");
                    foreach (var term in categoryTerms)
                    {
                        lstTerms.Items.Add($"\t{term.DisplayName}");
                    }
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Знайти термін...")
            {
                txtSearch.Text = string.Empty;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Знайти термін...";
            }
        }




        // =========================
        // КАТЕГОРІЇ ТА ЗБЕРЕЖЕННЯ
        // =========================

        private void btnShowCategories_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            txtOutput.DetectUrls = true;

            foreach (var c in db.Categories)
            {
                txtOutput.AppendText($"Категорія: {c.Name}\n");
                foreach (var term in c.Terms)
                {
                    string formattedLink = term.Replace(" ", "_");

                    txtOutput.AppendText(" - ");
                    txtOutput.AppendText($"http://term/{formattedLink}");
                    txtOutput.AppendText("\n");
                }
                txtOutput.AppendText("\n");
            }
        }

        // Метод для збереження даних

        private void Save()
        {
            storage.SaveAll(db.Terms, db.Categories);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Save();
            base.OnFormClosing(e);
        }

        
    }
}