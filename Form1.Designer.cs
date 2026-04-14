namespace TerminologyApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


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
            lstTerms = new ListBox();
            txtOutput = new TextBox();

            SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.Text = "Термін";

            // txtTerm
            txtTerm.Location = new Point(30, 47);
            txtTerm.Name = "txtTerm";
            txtTerm.Size = new Size(200, 23);

            // label2
            label2.AutoSize = true;
            label2.Location = new Point(30, 80);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.Text = "Визначення";

            // txtDefinition
            txtDefinition.Location = new Point(30, 105);
            txtDefinition.Multiline = true;
            txtDefinition.Name = "txtDefinition";
            txtDefinition.Size = new Size(200, 60);

            // label3
            label3.AutoSize = true;
            label3.Location = new Point(30, 180);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.Text = "Посилання";

            // txtReferences
            txtReferences.Location = new Point(30, 205);
            txtReferences.Name = "txtReferences";
            txtReferences.Size = new Size(200, 23);

            // btnAddTerm
            btnAddTerm.Location = new Point(260, 45);
            btnAddTerm.Name = "btnAddTerm";
            btnAddTerm.Size = new Size(120, 25);
            btnAddTerm.Text = "Додати термін";

            // btnShowAll
            btnShowAll.Location = new Point(260, 80);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(120, 25);
            btnShowAll.Text = "Показати всі";

            // btnShowChain
            btnShowChain.Location = new Point(260, 115);
            btnShowChain.Name = "btnShowChain";
            btnShowChain.Size = new Size(120, 25);
            btnShowChain.Text = "Показати ланцюг";

            // btnClear
            btnClear.Location = new Point(260, 150);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 25);
            btnClear.Text = "Очистити";

            // lstTerms
            lstTerms.Location = new Point(400, 45);
            lstTerms.Name = "lstTerms";
            lstTerms.Size = new Size(200, 199);

            // txtOutput
            txtOutput.Location = new Point(30, 250);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(570, 150);

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 420);
            Text = "Terminology App";
            Name = "Form1";

            // Controls
            Controls.Add(txtOutput);
            Controls.Add(lstTerms);
            Controls.Add(btnClear);
            Controls.Add(btnShowChain);
            Controls.Add(btnShowAll);
            Controls.Add(btnAddTerm);
            Controls.Add(txtReferences);
            Controls.Add(label3);
            Controls.Add(txtDefinition);
            Controls.Add(label2);
            Controls.Add(txtTerm);
            Controls.Add(label1);

            //ПІДКЛЮЧЕННЯ ПОДІЙ
            btnAddTerm.Click += btnAddTerm_Click;
            btnShowAll.Click += btnShowAll_Click;
            btnShowChain.Click += btnShowChain_Click;
            btnClear.Click += btnClear_Click;

            ResumeLayout(false);
            PerformLayout();
        }

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
        private ListBox lstTerms;
        private TextBox txtOutput;
    }
}