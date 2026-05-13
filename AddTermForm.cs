using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

            txtTerm.Text = term.Name;
            txtDefinition.Text = term.Definition;
            txtReferences.Text = string.Join(", ", term.References);
        }

        // Збереження нового або відредагованого терміна
        private void btnSave_Click_1(object sender, EventArgs e)
        {
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
                .Select(r => r.Trim())
                .Where(r => !string.IsNullOrWhiteSpace(r))
                .ToList();

            NewTerm = new Term(
                txtTerm.Text,
                txtDefinition.Text,
                refs
            );

            DialogResult = DialogResult.OK;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}