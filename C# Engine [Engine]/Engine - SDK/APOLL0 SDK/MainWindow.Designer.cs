namespace APOLL0_SDK
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Root");
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.MinButton = new System.Windows.Forms.Button();
            this.MaxButton = new System.Windows.Forms.Button();
            this.AppTitle = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.GameVeiw = new SharpGL.SceneControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FileTree = new System.Windows.Forms.TreeView();
            this.ObjVeiw = new System.Windows.Forms.TreeView();
            this.FileSystemWatcher = new System.IO.FileSystemWatcher();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameVeiw)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TitlePanel.Controls.Add(this.MinButton);
            this.TitlePanel.Controls.Add(this.MaxButton);
            this.TitlePanel.Controls.Add(this.AppTitle);
            this.TitlePanel.Controls.Add(this.CloseButton);
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(800, 25);
            this.TitlePanel.TabIndex = 0;
            // 
            // MinButton
            // 
            this.MinButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MinButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MinButton.FlatAppearance.BorderSize = 0;
            this.MinButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.MinButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.MinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MinButton.Location = new System.Drawing.Point(713, 0);
            this.MinButton.Name = "MinButton";
            this.MinButton.Size = new System.Drawing.Size(25, 25);
            this.MinButton.TabIndex = 1;
            this.MinButton.TabStop = false;
            this.MinButton.Text = "_";
            this.MinButton.UseVisualStyleBackColor = false;
            this.MinButton.Click += new System.EventHandler(this.MinButton_Click);
            // 
            // MaxButton
            // 
            this.MaxButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MaxButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MaxButton.FlatAppearance.BorderSize = 0;
            this.MaxButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.MaxButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.MaxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaxButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MaxButton.Location = new System.Drawing.Point(744, 0);
            this.MaxButton.Name = "MaxButton";
            this.MaxButton.Size = new System.Drawing.Size(25, 25);
            this.MaxButton.TabIndex = 1;
            this.MaxButton.TabStop = false;
            this.MaxButton.Text = "☐";
            this.MaxButton.UseVisualStyleBackColor = false;
            this.MaxButton.Click += new System.EventHandler(this.MaxButton_Click);
            // 
            // AppTitle
            // 
            this.AppTitle.AutoSize = true;
            this.AppTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.AppTitle.Location = new System.Drawing.Point(12, 6);
            this.AppTitle.Name = "AppTitle";
            this.AppTitle.Size = new System.Drawing.Size(108, 13);
            this.AppTitle.TabIndex = 2;
            this.AppTitle.Text = "APOLL0 Engine SDK";
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CloseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CloseButton.Location = new System.Drawing.Point(775, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(25, 25);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.TabStop = false;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // GameVeiw
            // 
            this.GameVeiw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameVeiw.DrawFPS = false;
            this.GameVeiw.FrameRate = 60;
            this.GameVeiw.Location = new System.Drawing.Point(200, 75);
            this.GameVeiw.Name = "GameVeiw";
            this.GameVeiw.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.GameVeiw.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.GameVeiw.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.GameVeiw.Size = new System.Drawing.Size(400, 200);
            this.GameVeiw.TabIndex = 1;
            this.GameVeiw.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.panel1.Controls.Add(this.FileTree);
            this.panel1.Location = new System.Drawing.Point(0, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 175);
            this.panel1.TabIndex = 2;
            // 
            // FileTree
            // 
            this.FileTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.FileTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileTree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FileTree.LineColor = System.Drawing.Color.White;
            this.FileTree.Location = new System.Drawing.Point(0, 0);
            this.FileTree.Name = "FileTree";
            treeNode1.Name = "Root";
            treeNode1.Text = "Root";
            this.FileTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.FileTree.ShowNodeToolTips = true;
            this.FileTree.Size = new System.Drawing.Size(200, 175);
            this.FileTree.TabIndex = 0;
            // 
            // ObjVeiw
            // 
            this.ObjVeiw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ObjVeiw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.ObjVeiw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ObjVeiw.Location = new System.Drawing.Point(600, 75);
            this.ObjVeiw.Name = "ObjVeiw";
            this.ObjVeiw.Size = new System.Drawing.Size(200, 200);
            this.ObjVeiw.TabIndex = 3;
            // 
            // FileSystemWatcher
            // 
            this.FileSystemWatcher.EnableRaisingEvents = true;
            this.FileSystemWatcher.IncludeSubdirectories = true;
            this.FileSystemWatcher.SynchronizingObject = this;
            this.FileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.FileSystemWatcher_Changed);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ObjVeiw);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GameVeiw);
            this.Controls.Add(this.TitlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.Text = "APOLL0 Engine SDK";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameVeiw)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileSystemWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label AppTitle;
        private System.Windows.Forms.Button MaxButton;
        private System.Windows.Forms.Button MinButton;
        private SharpGL.SceneControl GameVeiw;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView ObjVeiw;
        private System.Windows.Forms.TreeView FileTree;
        private System.IO.FileSystemWatcher FileSystemWatcher;
    }
}

