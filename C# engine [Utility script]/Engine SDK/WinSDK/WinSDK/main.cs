using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Xml;
using MonoGame;
using MonoGame.Framework.WpfInterop;
using WinSDK;

namespace MainWindow
{
    public class MainWindow : Form
    {
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem projectToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem Settings;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem closeProjectToolStripMenuItem;
        private ToolStripMenuItem applicatonToolStripMenuItem;
        private ToolStripMenuItem runToolStripMenuItem;
        private ListBox listBox1;
        public System.Windows.Forms.Timer SettingsTimer;
        private IContainer components;
        private Label CommandsLabel;
        private Panel CommandEditPanel;
        private Button EditCommandConfirm;
        private TextBox EditCommandBox;
        private Label EditCommandLabel;
        private ToolStripMenuItem buildToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private string language = null;

        public MainWindow()
        {
            // Initialize the window...
            InitializeComponent();
            //
            // Code goes here...
            //
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicatonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SettingsTimer = new System.Windows.Forms.Timer(this.components);
            this.CommandsLabel = new System.Windows.Forms.Label();
            this.CommandEditPanel = new System.Windows.Forms.Panel();
            this.EditCommandLabel = new System.Windows.Forms.Label();
            this.EditCommandBox = new System.Windows.Forms.TextBox();
            this.EditCommandConfirm = new System.Windows.Forms.Button();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.CommandEditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.applicatonToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator3,
            this.closeProjectToolStripMenuItem,
            this.toolStripSeparator2,
            this.Settings,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.projectToolStripMenuItem.Text = "Project";
            this.projectToolStripMenuItem.Click += new System.EventHandler(this.projectToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(140, 6);
            this.toolStripSeparator3.Visible = false;
            this.toolStripSeparator3.Click += new System.EventHandler(this.toolStripSeparator3_Click);
            // 
            // closeProjectToolStripMenuItem
            // 
            this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
            this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.closeProjectToolStripMenuItem.Text = "Close project";
            this.closeProjectToolStripMenuItem.Visible = false;
            this.closeProjectToolStripMenuItem.Click += new System.EventHandler(this.closeProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // Settings
            // 
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(143, 22);
            this.Settings.Text = "Settings";
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // applicatonToolStripMenuItem
            // 
            this.applicatonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.buildToolStripMenuItem});
            this.applicatonToolStripMenuItem.Name = "applicatonToolStripMenuItem";
            this.applicatonToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.applicatonToolStripMenuItem.Text = "Project";
            this.applicatonToolStripMenuItem.Visible = false;
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Visible = false;
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "aprog";
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Apoll0 project files|*.aprog";
            this.openFileDialog.InitialDirectory = "C:\\Users\\%username%\\Documents";
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Print(\"Hello, World!\");",
            "Input();"});
            this.listBox1.Location = new System.Drawing.Point(15, 48);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(169, 689);
            this.listBox1.TabIndex = 1;
            this.listBox1.Visible = false;
            // 
            // SettingsTimer
            // 
            this.SettingsTimer.Enabled = true;
            this.SettingsTimer.Interval = 1;
            this.SettingsTimer.Tick += new System.EventHandler(this.SettingsTimer_Tick);
            // 
            // CommandsLabel
            // 
            this.CommandsLabel.AutoSize = true;
            this.CommandsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandsLabel.Location = new System.Drawing.Point(12, 28);
            this.CommandsLabel.Name = "CommandsLabel";
            this.CommandsLabel.Size = new System.Drawing.Size(172, 13);
            this.CommandsLabel.TabIndex = 2;
            this.CommandsLabel.Text = "Application Sequence (Commands)";
            this.CommandsLabel.Visible = false;
            // 
            // CommandEditPanel
            // 
            this.CommandEditPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandEditPanel.Controls.Add(this.EditCommandConfirm);
            this.CommandEditPanel.Controls.Add(this.EditCommandBox);
            this.CommandEditPanel.Controls.Add(this.EditCommandLabel);
            this.CommandEditPanel.Location = new System.Drawing.Point(494, 372);
            this.CommandEditPanel.Name = "CommandEditPanel";
            this.CommandEditPanel.Size = new System.Drawing.Size(112, 74);
            this.CommandEditPanel.TabIndex = 3;
            // 
            // EditCommandLabel
            // 
            this.EditCommandLabel.AutoSize = true;
            this.EditCommandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCommandLabel.Location = new System.Drawing.Point(4, 4);
            this.EditCommandLabel.Name = "EditCommandLabel";
            this.EditCommandLabel.Size = new System.Drawing.Size(74, 13);
            this.EditCommandLabel.TabIndex = 0;
            this.EditCommandLabel.Text = "Edit command";
            // 
            // EditCommandBox
            // 
            this.EditCommandBox.Location = new System.Drawing.Point(7, 20);
            this.EditCommandBox.Name = "EditCommandBox";
            this.EditCommandBox.Size = new System.Drawing.Size(100, 20);
            this.EditCommandBox.TabIndex = 1;
            // 
            // EditCommandConfirm
            // 
            this.EditCommandConfirm.Location = new System.Drawing.Point(32, 46);
            this.EditCommandConfirm.Name = "EditCommandConfirm";
            this.EditCommandConfirm.Size = new System.Drawing.Size(75, 23);
            this.EditCommandConfirm.TabIndex = 2;
            this.EditCommandConfirm.Text = "Confirm";
            this.EditCommandConfirm.UseVisualStyleBackColor = true;
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // MainWindow
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.CommandEditPanel);
            this.Controls.Add(this.CommandsLabel);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APOLL0 SDK";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.CommandEditPanel.ResumeLayout(false);
            this.CommandEditPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeProjectToolStripMenuItem.Visible = true;
            toolStripSeparator3.Visible = true;
            listBox1.Visible = true;
            CommandsLabel.Visible = true;
            applicatonToolStripMenuItem.Visible = true;
            if (language == "C#")
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Console.WriteLine(\"Hello, World!\");");
                listBox1.Items.Add("Console.ReadLine();");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenProject = new OpenFileDialog();
            OpenProject.Title = "Open project";
            var FileToOpen = OpenProject.ShowDialog();
            string[] FileData = new string[Apollo.Files.Read("test.aproj").Length];
            FileData = Apollo.Files.Read("test.aproj");
            //File reading
            int i = 0;
            while (i != FileData.Length)
            {
                if (FileData[i] == "Project-Type=Text")
                {
                    ProjectText();
                }
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
            SettingsTimer.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void elementHost1_ChildChanged_1(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeProjectToolStripMenuItem.Visible = false;
            toolStripSeparator3.Visible = false;
            listBox1.Visible = false;
        }

        private void toolStripSeparator3_Click(object sender, EventArgs e)
        {

        }
        private static void ProjectText()
        {

        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SettingsTimer_Tick(object sender, EventArgs e)
        {
            string[] Settings = Apollo.Files.Read("settings.ini");
            if (Settings[0].Substring(6) == "Light")
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
                listBox1.BackColor = Color.White;
                listBox1.ForeColor = Color.Black;
                menuStrip1.BackColor = Color.White;
                menuStrip1.ForeColor = Color.Black;
            }
            if (Settings[0].Substring(6) == "Dark")
            {
                this.BackColor = Color.DimGray;
                this.ForeColor = Color.WhiteSmoke;
                listBox1.BackColor = Color.DimGray;
                listBox1.ForeColor = Color.WhiteSmoke;
                listBox1.BorderStyle = BorderStyle.None;
                menuStrip1.BackColor = Color.DimGray;
                menuStrip1.ForeColor = Color.WhiteSmoke;
            }
            if (Settings[0].Substring(6) == "System")
            {
                this.BackColor = System.Drawing.SystemColors.Window;
                this.ForeColor = System.Drawing.SystemColors.WindowText;

            }
            if (Settings[1].Substring(9) == "Simple")
            {
                language = "Simple";
            }
            if (Settings[1].Substring(9) == "C#")
            {
                language = "C#";
            }
            SettingsTimer.Enabled = false;
        }
    }
}
