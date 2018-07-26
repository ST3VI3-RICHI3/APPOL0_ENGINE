namespace WinSDK
{
    partial class Error
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.Context = new System.Windows.Forms.Label();
            this.ErrorList = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 186);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.ErrorList);
            this.panel2.Controls.Add(this.Context);
            this.panel2.Controls.Add(this.Title);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(453, 180);
            this.panel2.TabIndex = 0;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Ubuntu", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(4, 4);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(79, 26);
            this.Title.TabIndex = 0;
            this.Title.Text = "ERROR";
            // 
            // Context
            // 
            this.Context.AutoSize = true;
            this.Context.Font = new System.Drawing.Font("Ubuntu Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Context.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Context.Location = new System.Drawing.Point(6, 35);
            this.Context.Name = "Context";
            this.Context.Size = new System.Drawing.Size(209, 18);
            this.Context.TabIndex = 1;
            this.Context.Text = "The following error(s) have occured.";
            // 
            // ErrorList
            // 
            this.ErrorList.BackColor = System.Drawing.Color.DimGray;
            this.ErrorList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ErrorList.Font = new System.Drawing.Font("Ubuntu Condensed", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ErrorList.FormattingEnabled = true;
            this.ErrorList.ItemHeight = 17;
            this.ErrorList.Location = new System.Drawing.Point(9, 56);
            this.ErrorList.Name = "ErrorList";
            this.ErrorList.Size = new System.Drawing.Size(441, 121);
            this.ErrorList.TabIndex = 2;
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Error";
            this.Opacity = 0.1D;
            this.Text = "Error";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox ErrorList;
        private System.Windows.Forms.Label Context;
        private System.Windows.Forms.Label Title;
    }
}