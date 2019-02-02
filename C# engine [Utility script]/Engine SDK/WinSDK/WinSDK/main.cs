using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
using Apollo;

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
        private ListBox CommandsListBox;
        public System.Windows.Forms.Timer SettingsTimer;
        private IContainer components;
        private Label CommandsLabel;
        private ToolStripMenuItem buildToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private Label AssetsLabel;
        private ListBox AssetsListBox;
        private string language = null;
        private string savedir = null;
        private string savename = null;
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        private IntPtr handle = GetConsoleWindow();

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
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.CommandsListBox = new System.Windows.Forms.ListBox();
            this.SettingsTimer = new System.Windows.Forms.Timer(this.components);
            this.CommandsLabel = new System.Windows.Forms.Label();
            this.AssetsLabel = new System.Windows.Forms.Label();
            this.AssetsListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
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
            this.runToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Visible = false;
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "aprog";
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Apoll0 project files|*.aprog";
            this.openFileDialog.InitialDirectory = "C:\\Users\\%username%\\Documents";
            // 
            // CommandsListBox
            // 
            this.CommandsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CommandsListBox.FormattingEnabled = true;
            this.CommandsListBox.Items.AddRange(new object[] {
            "Print(\"Hello, World!\");",
            "Input();"});
            this.CommandsListBox.Location = new System.Drawing.Point(15, 48);
            this.CommandsListBox.Name = "CommandsListBox";
            this.CommandsListBox.Size = new System.Drawing.Size(169, 689);
            this.CommandsListBox.TabIndex = 1;
            this.CommandsListBox.Visible = false;
            this.CommandsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CommandsListBox_MouseDoubleClick);
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
            // AssetsLabel
            // 
            this.AssetsLabel.AutoSize = true;
            this.AssetsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssetsLabel.Location = new System.Drawing.Point(1186, 28);
            this.AssetsLabel.Name = "AssetsLabel";
            this.AssetsLabel.Size = new System.Drawing.Size(38, 13);
            this.AssetsLabel.TabIndex = 4;
            this.AssetsLabel.Text = "Assets";
            this.AssetsLabel.Visible = false;
            // 
            // AssetsListBox
            // 
            this.AssetsListBox.FormattingEnabled = true;
            this.AssetsListBox.Location = new System.Drawing.Point(1189, 44);
            this.AssetsListBox.Name = "AssetsListBox";
            this.AssetsListBox.Size = new System.Drawing.Size(169, 680);
            this.AssetsListBox.TabIndex = 5;
            this.AssetsListBox.Visible = false;
            // 
            // MainWindow
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.AssetsListBox);
            this.Controls.Add(this.AssetsLabel);
            this.Controls.Add(this.CommandsLabel);
            this.Controls.Add(this.CommandsListBox);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APOLL0 SDK";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Validated += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Newproject newproject = new Newproject();
            newproject.ShowDialog();
            if (newproject.created == true)
            {
                goto CreateProject;
            }
            else if (newproject.DialogResult == DialogResult.Cancel | newproject.DialogResult == DialogResult.Abort | newproject.DialogResult == DialogResult.None)
            {
                goto cancel;
            }
            CreateProject:
            Directory.CreateDirectory(newproject.ProjDir);
            using (StreamWriter writer = new StreamWriter(newproject.ProjDir + "/" + newproject.Projname + ".aproj"))
            {
                Directory.CreateDirectory(newproject.ProjDir + "/build");
                Directory.CreateDirectory(newproject.ProjDir + "/assets/");
                if (!File.Exists(newproject.ProjDir + "/assets/Engine.cs"))
                {
                    File.Copy("Engine.cs", newproject.ProjDir + "/assets/Engine.cs");
                }
                writer.WriteLine("ProjData{");
                //file details
                writer.WriteLine("    Projname=" + newproject.Projname);
                writer.WriteLine("    ProjDir=" + newproject.ProjDir);
                writer.WriteLine("    ProjType=C#");
                //Put commands / data above this comment, DO NOT put outside the '{' '}' symbols.
                writer.WriteLine("}");
                writer.WriteLine("ProjCommands{");
                //This is a hello world program due to a new project.
                writer.WriteLine("    Text.Print(\"Hello, World!\");");
                writer.WriteLine("    Console.ReadLine();");
                writer.WriteLine("}");
            }
            closeProjectToolStripMenuItem.Visible = true;
            toolStripSeparator3.Visible = true;
            CommandsListBox.Visible = true;
            CommandsLabel.Visible = true;
            applicatonToolStripMenuItem.Visible = true;
            AssetsLabel.Visible = true;
            AssetsListBox.Items.Clear();
            DirectoryInfo dinfo = new DirectoryInfo(newproject.ProjDir+"\\assets");
            FileInfo[] smFiles = dinfo.GetFiles("*.*");
            foreach (FileInfo fi in smFiles)
            {
                AssetsListBox.Items.Add(Path.GetFileName(fi.Name));
            }
            AssetsListBox.Visible = true;
            runToolStripMenuItem.Visible = true;
            
            if (language == "C#")
            {
                CommandsListBox.Items.Clear();
                CommandsListBox.Items.Add("Text.Print(\"Hello, World!\");");
                CommandsListBox.Items.Add("Console.ReadLine();");
            }
            if (language == "Simple")
            {
                CommandsListBox.Items.Clear();
                CommandsListBox.Items.Add("Print \"Hello, World!\"");
                CommandsListBox.Items.Add("Input");
            }
            cancel:
            savedir = newproject.ProjDir;
            savename = newproject.Projname;
            this.Text = newproject.Projname + " | APOLL0 SDK";
            newproject.Dispose();
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
                if (FileData[i] == "ProjData")
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
            ShowWindow(handle, SW_HIDE);
        }

        private void elementHost1_ChildChanged_1(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeProjectToolStripMenuItem.Visible = false;
            toolStripSeparator3.Visible = false;
            CommandsListBox.Visible = false;
            projectToolStripMenuItem.Visible = false;
            AssetsLabel.Visible = false;
            AssetsListBox.Visible = false;
            CommandsLabel.Visible = false;
            runToolStripMenuItem.Visible = false;
        }

        private void toolStripSeparator3_Click(object sender, EventArgs e)
        {

        }
        private static void ProjectText()
        {

        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow(handle, SW_SHOW);
            Apollo.Text.Newline();
            Apollo.Text.Print("Saving...");
            if (language == "C#")
            {
                using (StreamWriter writer = new StreamWriter(savedir + "/assets/program.cs"))
                {
                    writer.WriteLine("using system;");
                    writer.WriteLine("using Apollo;");
                    writer.WriteLine("");
                    writer.WriteLine("namespace " + savename);
                    writer.WriteLine("{");
                    writer.WriteLine("  public class Program");
                    writer.WriteLine("  {");
                    writer.WriteLine("      public static void Main(string[] args)");
                    writer.WriteLine("      {");
                    int i = 0;
                    while (i != CommandsListBox.Items.Count)
                    {
                        writer.WriteLine("          " + CommandsListBox.Items[i]);
                        i++;
                    }
                    writer.WriteLine("      }");
                    writer.WriteLine("  }");
                    writer.WriteLine("}");
                }
            }
            Apollo.Text.Print("Done");
            Apollo.Text.Newline();
            Apollo.Text.Print("Building project...");
            Process cmd = new Process();
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.FileName = "C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community\\MSBuild\\15.0\\Bin\\MSBuild.exe";
            cmd.StartInfo.Arguments = "-p:OutputPath="+savedir+"\\build -t:NotInSolutionfolder:" + savedir + "\\assets\\program.cs:Build";
            cmd.Start();
            int o = 0;
            string buffer = "unset";
            string[] output = new string[7];
            while (buffer != null)
            {
                buffer = cmd.StandardOutput.ReadLine();
                if (buffer != null)
                {
                    output[o] = buffer;
                    Console.WriteLine(buffer);
                }
                o++;
            }
            cmd.WaitForExit();
            Apollo.Text.Print("Done");
        }

        private void SettingsTimer_Tick(object sender, EventArgs e)
        {
            string[] Settings = Apollo.Files.Read("settings.ini");
            if (Settings[0].Substring(6) == "Light")
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
                CommandsListBox.BackColor = Color.White;
                CommandsListBox.ForeColor = Color.Black;
                menuStrip1.BackColor = Color.WhiteSmoke;
                menuStrip1.ForeColor = Color.Black;
            }
            if (Settings[0].Substring(6) == "Dark")
            {
                this.BackColor = Color.DimGray;
                this.ForeColor = Color.WhiteSmoke;
                CommandsListBox.BackColor = Color.DimGray;
                CommandsListBox.ForeColor = Color.WhiteSmoke;
                CommandsListBox.BorderStyle = BorderStyle.None;
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

        private void CommandsListBox_MouseDoubleClick(object sender, EventArgs e)
        {
            EditCommand edit = new EditCommand();
            edit.ShowDialog();
            int index = CommandsListBox.SelectedIndex;
            CommandsListBox.Items[index] = edit.NewCommand;
            CommandsListBox.Enabled = true;
            index = 0;
            edit.Dispose();
        }

        private void EditCommandConfirm_Click(object sender, EventArgs e)
        {
            
        }
    }
}
