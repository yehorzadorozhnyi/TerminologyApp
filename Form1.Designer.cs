namespace TerminologyApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 38);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Термін";
            // 
            // txtTerm
            // 
            txtTerm.Location = new Point(64, 87);
            txtTerm.Name = "txtTerm";
            txtTerm.Size = new Size(100, 23);
            txtTerm.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 139);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 2;
            label2.Text = "Визначення";
            // 
            // txtDefinition
            // 
            txtDefinition.Location = new Point(64, 182);
            txtDefinition.Multiline = true;
            txtDefinition.Name = "txtDefinition";
            txtDefinition.Size = new Size(100, 23);
            txtDefinition.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 252);
            label3.Name = "label3";
            label3.Size = new Size(142, 15);
            label3.TabIndex = 4;
            label3.Text = "Посилання (через кому)";
            label3.Click += label3_Click;
            // 
            // txtReferences
            // 
            txtReferences.Location = new Point(64, 305);
            txtReferences.Name = "txtReferences";
            txtReferences.Size = new Size(100, 23);
            txtReferences.TabIndex = 5;
            // 
            // btnAddTerm
            // 
            btnAddTerm.Location = new Point(331, 86);
            btnAddTerm.Name = "btnAddTerm";
            btnAddTerm.Size = new Size(96, 23);
            btnAddTerm.TabIndex = 6;
            btnAddTerm.Text = "Додати термін";
            btnAddTerm.UseVisualStyleBackColor = true;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(331, 139);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(87, 23);
            btnShowAll.TabIndex = 7;
            btnShowAll.Text = "Показати всі";
            btnShowAll.UseVisualStyleBackColor = true;
            // 
            // btnShowChain
            // 
            btnShowChain.Location = new Point(331, 195);
            btnShowChain.Name = "btnShowChain";
            btnShowChain.Size = new Size(111, 23);
            btnShowChain.TabIndex = 8;
            btnShowChain.Text = "Показати ланцюг";
            btnShowChain.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(331, 244);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 9;
            btnClear.Text = "Очистити";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
    }
}
