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
    public partial class Newproject : Form
    {
        public bool created = false;
        public string Projname = null;
        public string ProjDir = null;
        public Newproject()
        {
            InitializeComponent();
        }

        private void ChooseDirButton_Click(object sender, EventArgs e)
        {
            DirBrowser.ShowDialog();
            ProjDirBox.Text = DirBrowser.SelectedPath;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Projname = ProjName.Text;
            ProjDir = ProjDirBox.Text;
            created = true;
            this.Close();
        }
    }
}
