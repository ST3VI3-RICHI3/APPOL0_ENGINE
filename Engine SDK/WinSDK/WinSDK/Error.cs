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
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
        }
        public static string[] Errors;
        public static void UpdateErrorList()
        {
            ListBox ErrorList = new ListBox();
            ErrorList.DataSource = Errors;
        }

        private static void ErrorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
