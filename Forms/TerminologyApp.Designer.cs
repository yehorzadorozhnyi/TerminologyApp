namespace TerminologyApp
{
    partial class TerminologyApp
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnAddTerm;
        private Button btnShowAll;
        private Button btnShowChain;
        private Button btnClear;
        private Button btnDelete;
        private Button btnEdit;

        private ListBox lstTerms;

        private RichTextBox txtOutput;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TerminologyApp));
            btnAddTerm = new Button();
            btnShowAll = new Button();
            btnShowChain = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            lstTerms = new ListBox();
            txtOutput = new RichTextBox();
            txtSearch = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btnShowCategories = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnAddTerm
            // 
            btnAddTerm.BackColor = Color.RoyalBlue;
            btnAddTerm.ForeColor = SystemColors.Control;
            btnAddTerm.Location = new Point(196, 112);
            btnAddTerm.Name = "btnAddTerm";
            btnAddTerm.Size = new Size(90, 30);
            btnAddTerm.TabIndex = 7;
            btnAddTerm.Text = "Додати";
            btnAddTerm.UseVisualStyleBackColor = false;
            btnAddTerm.Click += btnAddTerm_Click;
            // 
            // btnShowAll
            // 
            btnShowAll.BackColor = Color.RoyalBlue;
            btnShowAll.ForeColor = SystemColors.Control;
            btnShowAll.Location = new Point(622, 112);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(90, 30);
            btnShowAll.TabIndex = 8;
            btnShowAll.Text = "Показати";
            btnShowAll.UseVisualStyleBackColor = false;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnShowChain
            // 
            btnShowChain.BackColor = Color.RoyalBlue;
            btnShowChain.ForeColor = SystemColors.Control;
            btnShowChain.Location = new Point(718, 112);
            btnShowChain.Name = "btnShowChain";
            btnShowChain.Size = new Size(90, 30);
            btnShowChain.TabIndex = 9;
            btnShowChain.Text = "Ланцюг";
            btnShowChain.UseVisualStyleBackColor = false;
            btnShowChain.Click += btnShowChain_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.RoyalBlue;
            btnClear.ForeColor = SystemColors.Control;
            btnClear.Location = new Point(814, 114);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(90, 30);
            btnClear.TabIndex = 10;
            btnClear.Text = "Очистити";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.RoyalBlue;
            btnDelete.ForeColor = SystemColors.Control;
            btnDelete.Location = new Point(388, 112);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 30);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.RoyalBlue;
            btnEdit.ForeColor = SystemColors.Control;
            btnEdit.Location = new Point(292, 112);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(90, 30);
            btnEdit.TabIndex = 12;
            btnEdit.Text = "Редагувати";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // lstTerms
            // 
            lstTerms.Dock = DockStyle.Left;
            lstTerms.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lstTerms.ForeColor = Color.RoyalBlue;
            lstTerms.Location = new Point(0, 150);
            lstTerms.Margin = new Padding(5, 5, 5, 15);
            lstTerms.Name = "lstTerms";
            lstTerms.Size = new Size(160, 529);
            lstTerms.TabIndex = 13;
            lstTerms.SelectedIndexChanged += lstTerms_SelectedIndexChanged;
            // 
            // txtOutput
            // 
            txtOutput.Dock = DockStyle.Fill;
            txtOutput.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtOutput.Location = new Point(160, 150);
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.Size = new Size(839, 529);
            txtOutput.TabIndex = 0;
            txtOutput.Text = "";
            txtOutput.LinkClicked += txtOutput_LinkClicked;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(0, 119);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(160, 23);
            txtSearch.TabIndex = 14;
            txtSearch.Text = "Пошук терміну";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(23, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(107, 111);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(196, 29);
            label1.Name = "label1";
            label1.Size = new Size(198, 35);
            label1.TabIndex = 16;
            label1.Text = "База Термінів";
            // 
            // btnShowCategories
            // 
            btnShowCategories.BackColor = Color.RoyalBlue;
            btnShowCategories.ForeColor = SystemColors.Control;
            btnShowCategories.Location = new Point(622, 83);
            btnShowCategories.Name = "btnShowCategories";
            btnShowCategories.Size = new Size(282, 23);
            btnShowCategories.TabIndex = 17;
            btnShowCategories.Text = "Показати категорії";
            btnShowCategories.UseVisualStyleBackColor = false;
            btnShowCategories.Click += btnShowCategories_Click;
            // 
            // TerminologyApp
            // 
            ClientSize = new Size(999, 679);
            Controls.Add(btnShowCategories);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(txtSearch);
            Controls.Add(txtOutput);
            Controls.Add(btnAddTerm);
            Controls.Add(btnShowAll);
            Controls.Add(btnShowChain);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(lstTerms);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TerminologyApp";
            Padding = new Padding(0, 150, 0, 0);
            Text = "База Термінів";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtSearch;
        private PictureBox pictureBox1;
        private Label label1;
        private Button btnShowCategories;
    }
}