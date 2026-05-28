using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TerminologyApp.Models;

namespace TerminologyApp
{
    // У гіперпосиланні не працює посилання, якщо термін має більше 1 слова
    // Пошук по визначенню
    // При видалянні термінів робити попередження, що він існує
    // Додати другу сутність, яка буде використовуватись (наприклад галузь знань)

    public partial class AddTermForm : Form
    {
        public Term NewTerm { get; private set; }

        public AddTermForm()
        {
            InitializeComponent();
        }

        // Конструктор для редагування існуючого терміна
        public AddTermForm(Term term)
        {
            InitializeComponent();
            txtTerm.Text = term.Name.Replace("_", " ");

            cmbCategory.Text = term.Category;
            txtDefinition.Text = term.Definition;

            if (term.References != null)
            {
                txtReferences.Text = string.Join(", ", term.References.Select(r => r.Replace("_", " ")));
            }
        }

        // Збереження нового або відредагованого терміна
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string categoryName = cmbCategory.Text.Trim();
            if (string.IsNullOrWhiteSpace(categoryName) || categoryName.Equals("НАПИШІТЬ КАТЕГОРІЮ", StringComparison.OrdinalIgnoreCase))
            {
                categoryName = "Без категорії";
            }

            if (string.IsNullOrWhiteSpace(txtTerm.Text))
            {
                MessageBox.Show(
                    "Поле 'Термін' не може бути порожнім!",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtTerm.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDefinition.Text))
            {
                MessageBox.Show(
                    "Поле 'Визначення' не може бути порожнім!",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtDefinition.Focus();
                return;
            }

            var refs = txtReferences.Text
                .Split(',')
                .Select(r => r.Trim().Replace(" ", "_"))
                .Where(r => !string.IsNullOrWhiteSpace(r))
                .ToList();

            NewTerm = new Term(
                txtTerm.Text.Trim().Replace(" ", "_"),
                txtDefinition.Text.Trim(),
                refs,
                categoryName
            );

            DialogResult = DialogResult.OK;
            Close();
        }

        public void LoadCategories(List<Category> categories)
        {
            cmbCategory.Items.Clear();

            foreach (var c in categories)
            {
                cmbCategory.Items.Add(c.Name);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbCategory_Enter(object sender, EventArgs e)
        {
            if (cmbCategory.Text == "НАПИШІТЬ КАТЕГОРІЮ")
            {
                cmbCategory.Text = string.Empty;
            }
        }

        private void cmbCategory_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                cmbCategory.Text = "Без категорії";
            }
        }

        private void BtnCategoryDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("Спочатку виберіть категорію для видалення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string categoryName = cmbCategory.Text;

            var dialogResult = MessageBox.Show(
                $"Ви впевнені, що хочете видалити категорію '{categoryName}' та ВСІ терміни, які до неї належать?",
                "Підтвердження повного видалення",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dialogResult != DialogResult.Yes)
                return;

            NewTerm = new Term { Name = categoryName };

            DialogResult = DialogResult.Yes;
            Close();
        }

        private void BtnCategoryEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("Спочатку виберіть категорію для редагування!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string oldCategoryName = cmbCategory.Text;
            string newCategoryName = Microsoft.VisualBasic.Interaction.InputBox(
                "Введіть нову назву для категорії:",
                "Редагування категорії",
                oldCategoryName
            ).Trim();

            if (string.IsNullOrWhiteSpace(newCategoryName) || newCategoryName == oldCategoryName)
                return;

            NewTerm = new Term { Name = newCategoryName, Category = oldCategoryName };
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
    
