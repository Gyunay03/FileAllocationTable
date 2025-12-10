using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileAllocationTable
{
    public partial class StateForm : Form
    {
        public StateForm(string content)
        {
            InitializeComponent();
            richTextBox1.Text = content;
        }
    }
}
