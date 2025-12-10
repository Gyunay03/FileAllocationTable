namespace FileAllocationTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvDirectory.DataSource = fs.ActiveFiles;
            dgvFAT.DataSource = fs.ActiveFiles;
            dgvFAT.AutoGenerateColumns = false;
            dgvFAT.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BlockIndex", HeaderText = "Блок" });
            dgvFAT.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NextBlockDisplay", HeaderText = "Следващ блок" });
        }

        FileSystem fs = new FileSystem();

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
            string name = tbFileName.Text;
            fs.DeleteFile(name);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            
        }
    }
}
