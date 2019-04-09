using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APOLL0_SDK
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MaxButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void MinButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(Environment.CurrentDirectory);
            if (info.Exists)
            {
                FileTree.Nodes[0].Nodes.Clear();
                TreeNode Rootnode = new TreeNode("Root");
                Rootnode.Tag = info;
                GetDirs(info.GetDirectories(), Rootnode);
                FileTree.Nodes.Add(Rootnode);
            }
        }

        private void GetDirs(DirectoryInfo[] subDirs, TreeNode tree)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirs(subSubDirs, aNode);
                }
                tree.Nodes.Add(aNode);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            FileSystemWatcher.Path = Environment.CurrentDirectory;
            DirectoryInfo info = new DirectoryInfo(Environment.CurrentDirectory);
            if (info.Exists)
            {
                FileTree.Nodes.Clear();
                TreeNode Rootnode = new TreeNode("Root");
                Rootnode.Tag = info;
                GetDirs(info.GetDirectories(), Rootnode);
                FileTree.Nodes.Add(Rootnode);
            }
        }
    }
}
