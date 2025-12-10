using System;
using System.Windows.Forms;

namespace FileAllocationTable
{
    public partial class Form1 : Form
    {
        FileSystem fs = new FileSystem();
        public Form1()
        {
            InitializeComponent();

            // изглед за таблицата на директорията
            dgvDirectory.AutoGenerateColumns = false;
            dgvDirectory.Columns.Clear();
            dgvDirectory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Име на файл", ReadOnly = true });
            dgvDirectory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Size", HeaderText = "Размер на файл", ReadOnly = true });
            dgvDirectory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FirstBlock", HeaderText = "Първи блок", ReadOnly = true });
            dgvDirectory.DataSource = fs.ActiveFiles;

            // изглед за FAT таблицата
            dgvFAT.AutoGenerateColumns = false;
            dgvFAT.Columns.Clear();
            dgvFAT.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BlockIndex", HeaderText = "Блок", ReadOnly = true });
            dgvFAT.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NextBlockDisplay", HeaderText = "Следващ блок", ReadOnly = true });
            dgvFAT.DataSource = fs.FatList;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = tbFileName.Text;
            if (!int.TryParse(tbFileSize.Text, out int size))
            {
                MessageBox.Show("Невалиден размер.");
                return;
            }

            fs.SaveFile(name, size);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = tbFileName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Въведете име на файл за изтриване.");
                return;
            }

            fs.DeleteFile(name);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            StateForm form = new StateForm(fs.Show());
            form.Show();
        }
    }
}