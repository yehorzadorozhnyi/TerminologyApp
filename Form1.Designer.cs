namespace TerminologyApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label label1;
        private TextBox txtTerm;
        private Label label2;
        private TextBox txtDefinition;
        private Label label3;
        private TextBox txtReferences;
        private Button btnAddTerm;
        private Button btnShowAll;
        private Button btnShowChain;
        private Button btnClear;
        private Button btnDelete;
        private Button btnEdit;
        private ListBox lstTerms;
        private TextBox txtOutput;

        private void InitializeComponent()
        {
            label1 = new Label();
            txtTerm = new TextBox();
            label2 = new Label();
            txtDefinition = new TextBox();
            label3 = new Label();
            txtReferences = new TextBox();

            btnAddTerm = new Button();
            btnShowAll = new Button();
            btnShowChain = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnEdit = new Button();

            lstTerms = new ListBox();
            txtOutput = new TextBox();

            SuspendLayout();

            // label1
            label1.Location = new System.Drawing.Point(30, 20);
            label1.Text = "Термін";

            // txtTerm
            txtTerm.Location = new System.Drawing.Point(30, 47);

            // label2
            label2.Location = new System.Drawing.Point(30, 80);
            label2.Text = "Визначення";

            // txtDefinition
            txtDefinition.Location = new System.Drawing.Point(30, 105);
            txtDefinition.Multiline = true;

            // label3
            label3.Location = new System.Drawing.Point(30, 180);
            label3.Text = "Посилання";

            // txtReferences
            txtReferences.Location = new System.Drawing.Point(30, 205);

            // btnAddTerm
            btnAddTerm.Location = new System.Drawing.Point(260, 45);
            btnAddTerm.Text = "Додати";

            // btnShowAll
            btnShowAll.Location = new System.Drawing.Point(260, 80);
            btnShowAll.Text = "Показати всі";

            // btnShowChain
            btnShowChain.Location = new System.Drawing.Point(260, 115);
            btnShowChain.Text = "Ланцюг";

            // btnClear
            btnClear.Location = new System.Drawing.Point(260, 150);
            btnClear.Text = "Очистити";

            // btnDelete
            btnDelete.Location = new System.Drawing.Point(260, 185);
            btnDelete.Text = "Видалити";

            // btnEdit
            btnEdit.Location = new System.Drawing.Point(260, 220);
            btnEdit.Text = "Редагувати";

            // lstTerms
            lstTerms.Location = new System.Drawing.Point(400, 45);

            // txtOutput
            txtOutput.Location = new System.Drawing.Point(30, 250);
            txtOutput.Multiline = true;

            // Form
            ClientSize = new System.Drawing.Size(650, 420);
            Text = "Terminology App";

            Controls.Add(label1);
            Controls.Add(txtTerm);
            Controls.Add(label2);
            Controls.Add(txtDefinition);
            Controls.Add(label3);
            Controls.Add(txtReferences);

            Controls.Add(btnAddTerm);
            Controls.Add(btnShowAll);
            Controls.Add(btnShowChain);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);

            Controls.Add(lstTerms);
            Controls.Add(txtOutput);

            btnAddTerm.Click += btnAddTerm_Click;
            btnShowAll.Click += btnShowAll_Click;
            btnShowChain.Click += btnShowChain_Click;
            btnClear.Click += btnClear_Click;
            btnDelete.Click += btnDelete_Click;
            btnEdit.Click += btnEdit_Click;

            ResumeLayout(false);
        }
    }
}