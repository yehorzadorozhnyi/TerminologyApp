namespace TerminologyApp
{
    partial class AddTermForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTermForm));
            txtTerm = new TextBox();
            txtDefinition = new TextBox();
            txtReferences = new TextBox();
            btnSave = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // txtTerm
            // 
            txtTerm.Dock = DockStyle.Top;
            txtTerm.Location = new Point(120, 40);
            txtTerm.Margin = new Padding(3, 0, 0, 10);
            txtTerm.Multiline = true;
            txtTerm.Name = "txtTerm";
            txtTerm.Size = new Size(660, 100);
            txtTerm.TabIndex = 0;
            // 
            // txtDefinition
            // 
            txtDefinition.Dock = DockStyle.Top;
            txtDefinition.Location = new Point(120, 140);
            txtDefinition.Multiline = true;
            txtDefinition.Name = "txtDefinition";
            txtDefinition.Size = new Size(660, 100);
            txtDefinition.TabIndex = 1;
            // 
            // txtReferences
            // 
            txtReferences.Dock = DockStyle.Top;
            txtReferences.Location = new Point(120, 240);
            txtReferences.Multiline = true;
            txtReferences.Name = "txtReferences";
            txtReferences.Size = new Size(660, 100);
            txtReferences.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.RoyalBlue;
            btnSave.Dock = DockStyle.Fill;
            btnSave.Font = new Font("Segoe UI", 16F);
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(120, 340);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(660, 90);
            btnSave.TabIndex = 3;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 64);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 4;
            label1.Text = "Термін:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 174);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 5;
            label2.Text = "Визначення:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 282);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 6;
            label3.Text = "Посилання:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.RoyalBlue;
            label4.Location = new Point(349, 12);
            label4.Name = "label4";
            label4.Size = new Size(198, 24);
            label4.TabIndex = 7;
            label4.Text = "ДОДАВАННЯ ТЕРМІНУ";
            // 
            // AddTermForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(txtReferences);
            Controls.Add(txtDefinition);
            Controls.Add(txtTerm);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddTermForm";
            Padding = new Padding(120, 40, 20, 20);
            Text = "Додавання Терміну";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTerm;
        private TextBox txtDefinition;
        private TextBox txtReferences;
        private Button btnSave;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}