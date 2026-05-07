using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TerminologyApp
{
    public partial class AddTermForm : Form
    {
        public Term NewTerm { get; private set; }

        public AddTermForm()
        {
            InitializeComponent();
        }

        public AddTermForm(Term term)
        {
            InitializeComponent();

            txtTerm.Text = term.Name;
            txtDefinition.Text = term.Definition;
            txtReferences.Text = string.Join(", ", term.References);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
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