using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinSDK
{
    public partial class EditCommand : Form
    {
        public string NewCommand = null;
        public EditCommand(string Current_Command)
        {
            InitializeComponent();
            textBox1.Text = Current_Command;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewCommand = textBox1.Text;
            this.Close();
        }
    }
}
