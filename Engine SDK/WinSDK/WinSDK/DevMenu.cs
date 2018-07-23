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
    public partial class DevMenu : Form
    {
        public DevMenu()
        {
            InitializeComponent();
        }

        private void DEV_Beep_Click(object sender, EventArgs e)
        {
            WinSDK.DevCommands.Beep();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WinSDK.DevCommands.Splash_screen();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength <= 1)
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            if (textBox1.TextLength >= 1)
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WinSDK.DevCommands.packFile.load(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WinSDK.DevCommands.packFile.Create(textBox1.Text);
        }
    }
}
