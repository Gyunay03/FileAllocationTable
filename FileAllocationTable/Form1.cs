namespace FileAllocationTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            rtfOutput.Clear();
            rtfOutput.Text = fs.GetState();
        }
    }
}
