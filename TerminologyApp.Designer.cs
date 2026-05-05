namespace TerminologyApp
{
    partial class TerminologyApp
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
            // 
            // label1
            // 
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            label1.Text = "Термін";
            // 
            // txtTerm
            // 
            txtTerm.Location = new Point(30, 45);
            txtTerm.Name = "txtTerm";
            txtTerm.Size = new Size(180, 23);
            txtTerm.TabIndex = 1;
            // 
            // label2
            // 
            label2.Location = new Point(30, 80);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 2;
            label2.Text = "Визначення";
            // 
            // txtDefinition
            // 
            txtDefinition.Location = new Point(30, 105);
            txtDefinition.Multiline = true;
            txtDefinition.Name = "txtDefinition";
            txtDefinition.Size = new Size(180, 50);
            txtDefinition.TabIndex = 3;
            // 
            // label3
            // 
            label3.Location = new Point(30, 180);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 4;
            label3.Text = "Посилання";
            // 
            // txtReferences
            // 
            txtReferences.Location = new Point(30, 205);
            txtReferences.Name = "txtReferences";
            txtReferences.Size = new Size(180, 23);
            txtReferences.TabIndex = 5;
            // 
            // btnAddTerm
            // 
            btnAddTerm.Location = new Point(260, 45);
            btnAddTerm.Name = "btnAddTerm";
            btnAddTerm.Size = new Size(90, 30);
            btnAddTerm.TabIndex = 6;
            btnAddTerm.Text = "Додати";
            btnAddTerm.Click += btnAddTerm_Click;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(260, 80);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(90, 30);
            btnShowAll.TabIndex = 7;
            btnShowAll.Text = "Показати";
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnShowChain
            // 
            btnShowChain.Location = new Point(260, 115);
            btnShowChain.Name = "btnShowChain";
            btnShowChain.Size = new Size(90, 30);
            btnShowChain.TabIndex = 8;
            btnShowChain.Text = "Ланцюг";
            btnShowChain.Click += btnShowChain_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(260, 150);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(90, 30);
            btnClear.TabIndex = 9;
            btnClear.Text = "Очистити";
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(260, 185);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 30);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Видалити";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(260, 220);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(90, 30);
            btnEdit.TabIndex = 11;
            btnEdit.Text = "Редагувати";
            btnEdit.Click += btnEdit_Click;
            // 
            // lstTerms
            // 
            lstTerms.Location = new Point(400, 45);
            lstTerms.Name = "lstTerms";
            lstTerms.Size = new Size(150, 139);
            lstTerms.TabIndex = 12;
            lstTerms.SelectedIndexChanged += lstTerms_SelectedIndexChanged;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(30, 270);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(520, 100);
            txtOutput.TabIndex = 13;
            // 
            // TerminologyApp
            // 
            ClientSize = new Size(650, 420);
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
            Name = "TerminologyApp";
            Text = "Terminology App";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}