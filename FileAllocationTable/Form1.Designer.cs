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
            label1 = new Label();
            label2 = new Label();
            tbFileName = new TextBox();
            tbFileSize = new TextBox();
            rtfOutput = new RichTextBox();
            SuspendLayout();
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(176, 131);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(97, 41);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Създаване на файл";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(328, 131);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(109, 40);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Изтриване на файл";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(505, 137);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(88, 35);
            btnShow.TabIndex = 2;
            btnShow.Text = "Показване";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 38);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 3;
            label1.Text = "Име на файл:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 67);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 4;
            label2.Text = "Размер (в байтове)";
            // 
            // tbFileName
            // 
            tbFileName.Location = new Point(183, 30);
            tbFileName.Name = "tbFileName";
            tbFileName.Size = new Size(100, 23);
            tbFileName.TabIndex = 5;
            // 
            // tbFileSize
            // 
            tbFileSize.Location = new Point(183, 64);
            tbFileSize.Name = "tbFileSize";
            tbFileSize.Size = new Size(100, 23);
            tbFileSize.TabIndex = 6;
            // 
            // rtfOutput
            // 
            rtfOutput.Location = new Point(188, 196);
            rtfOutput.Name = "rtfOutput";
            rtfOutput.Size = new Size(399, 180);
            rtfOutput.TabIndex = 7;
            rtfOutput.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtfOutput);
            Controls.Add(tbFileSize);
            Controls.Add(tbFileName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnShow);
            Controls.Add(btnDelete);
            Controls.Add(btnCreate);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreate;
        private Button btnDelete;
        private Button btnShow;
        private Label label1;
        private Label label2;
        private TextBox tbFileName;
        private TextBox tbFileSize;
        private RichTextBox rtfOutput;
    }
}
