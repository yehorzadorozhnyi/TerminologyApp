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

            // Термін
            label1.Location =
                new System.Drawing.Point(30, 20);
            label1.Text = "Термін";

            txtTerm.Location =
                new System.Drawing.Point(30, 45);
            txtTerm.Size =
                new System.Drawing.Size(180, 23);

            // Визначення
            label2.Location =
                new System.Drawing.Point(30, 80);
            label2.Text = "Визначення";

            txtDefinition.Location =
                new System.Drawing.Point(30, 105);
            txtDefinition.Size =
                new System.Drawing.Size(180, 50);
            txtDefinition.Multiline = true;

            // Посилання
            label3.Location =
                new System.Drawing.Point(30, 180);
            label3.Text = "Посилання";

            txtReferences.Location =
                new System.Drawing.Point(30, 205);
            txtReferences.Size =
                new System.Drawing.Size(180, 23);

            // Кнопки
            btnAddTerm.Location =
                new System.Drawing.Point(260, 45);
            btnAddTerm.Size =
                new System.Drawing.Size(90, 30);
            btnAddTerm.Text = "Додати";

            btnShowAll.Location =
                new System.Drawing.Point(260, 80);
            btnShowAll.Size =
                new System.Drawing.Size(90, 30);
            btnShowAll.Text = "Показати";

            btnShowChain.Location =
                new System.Drawing.Point(260, 115);
            btnShowChain.Size =
                new System.Drawing.Size(90, 30);
            btnShowChain.Text = "Ланцюг";

            btnClear.Location =
                new System.Drawing.Point(260, 150);
            btnClear.Size =
                new System.Drawing.Size(90, 30);
            btnClear.Text = "Очистити";

            btnDelete.Location =
                new System.Drawing.Point(260, 185);
            btnDelete.Size =
                new System.Drawing.Size(90, 30);
            btnDelete.Text = "Видалити";

            btnEdit.Location =
                new System.Drawing.Point(260, 220);
            btnEdit.Size =
                new System.Drawing.Size(90, 30);
            btnEdit.Text = "Редагувати";

            // Список термінів
            lstTerms.Location =
                new System.Drawing.Point(400, 45);
            lstTerms.Size =
                new System.Drawing.Size(150, 150);

            // Вивід
            txtOutput.Location =
                new System.Drawing.Point(30, 270);
            txtOutput.Size =
                new System.Drawing.Size(520, 100);
            txtOutput.Multiline = true;
            txtOutput.ScrollBars =
                ScrollBars.Vertical;

            // Form
            ClientSize =
                new System.Drawing.Size(650, 420);

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

            // Events
            btnAddTerm.Click += btnAddTerm_Click;
            btnShowAll.Click += btnShowAll_Click;
            btnShowChain.Click += btnShowChain_Click;
            btnClear.Click += btnClear_Click;
            btnDelete.Click += btnDelete_Click;
            btnEdit.Click += btnEdit_Click;

            lstTerms.SelectedIndexChanged +=
                lstTerms_SelectedIndexChanged;

            ResumeLayout(false);
        }
    }
}