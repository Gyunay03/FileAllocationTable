namespace FileAllocationTable
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
            btnCreate = new Button();
            btnDelete = new Button();
            btnShow = new Button();
            FileName = new Label();
            FileSize = new Label();
            tbFileName = new TextBox();
            tbFileSize = new TextBox();
            dgvDirectory = new DataGridView();
            dgvFAT = new DataGridView();
            Directory = new Label();
            FAT = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvDirectory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFAT).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnCreate
            // 
            btnCreate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCreate.Location = new Point(279, 21);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(166, 41);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Създаване на файл";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnDelete.Location = new Point(451, 21);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(164, 40);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Изтриване на файл";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnShow
            // 
            btnShow.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShow.Location = new Point(621, 21);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(96, 40);
            btnShow.TabIndex = 2;
            btnShow.Text = "Показване";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // FileName
            // 
            FileName.AutoSize = true;
            FileName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FileName.Location = new Point(40, 14);
            FileName.Name = "FileName";
            FileName.Size = new Size(107, 18);
            FileName.TabIndex = 3;
            FileName.Text = "Име на файл:";
            // 
            // FileSize
            // 
            FileSize.AutoSize = true;
            FileSize.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FileSize.Location = new Point(6, 45);
            FileSize.Name = "FileSize";
            FileSize.Size = new Size(150, 18);
            FileSize.TabIndex = 4;
            FileSize.Text = "Размер (в байтове)";
            // 
            // tbFileName
            // 
            tbFileName.Location = new Point(162, 10);
            tbFileName.Name = "tbFileName";
            tbFileName.Size = new Size(100, 23);
            tbFileName.TabIndex = 5;
            // 
            // tbFileSize
            // 
            tbFileSize.Location = new Point(162, 43);
            tbFileSize.Name = "tbFileSize";
            tbFileSize.Size = new Size(100, 23);
            tbFileSize.TabIndex = 6;
            // 
            // dgvDirectory
            // 
            dgvDirectory.BackgroundColor = SystemColors.Window;
            dgvDirectory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDirectory.Location = new Point(13, 34);
            dgvDirectory.Name = "dgvDirectory";
            dgvDirectory.Size = new Size(350, 311);
            dgvDirectory.TabIndex = 8;
            // 
            // dgvFAT
            // 
            dgvFAT.BackgroundColor = SystemColors.Window;
            dgvFAT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFAT.Location = new Point(410, 34);
            dgvFAT.Name = "dgvFAT";
            dgvFAT.Size = new Size(263, 311);
            dgvFAT.TabIndex = 9;
            // 
            // Directory
            // 
            Directory.AutoSize = true;
            Directory.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Directory.Location = new Point(136, 7);
            Directory.Name = "Directory";
            Directory.Size = new Size(104, 19);
            Directory.TabIndex = 10;
            Directory.Text = "Директория";
            // 
            // FAT
            // 
            FAT.AutoSize = true;
            FAT.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            FAT.Location = new Point(462, 7);
            FAT.Name = "FAT";
            FAT.Size = new Size(160, 19);
            FAT.TabIndex = 11;
            FAT.Text = "File Allocation Table";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(tbFileSize);
            panel1.Controls.Add(tbFileName);
            panel1.Controls.Add(FileSize);
            panel1.Controls.Add(FileName);
            panel1.Controls.Add(btnShow);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnCreate);
            panel1.Location = new Point(6, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(735, 84);
            panel1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(FAT);
            panel2.Controls.Add(Directory);
            panel2.Controls.Add(dgvFAT);
            panel2.Controls.Add(dgvDirectory);
            panel2.Location = new Point(6, 108);
            panel2.Name = "panel2";
            panel2.Size = new Size(735, 356);
            panel2.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(749, 474);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "File Allocation Table";
            ((System.ComponentModel.ISupportInitialize)dgvDirectory).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFAT).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCreate;
        private Button btnDelete;
        private Button btnShow;
        private Label FileName;
        private Label FileSize;
        private TextBox tbFileName;
        private TextBox tbFileSize;
        private DataGridView dgvDirectory;
        private DataGridView dgvFAT;
        private Label Directory;
        private Label FAT;
        private Panel panel1;
        private Panel panel2;
    }
}
