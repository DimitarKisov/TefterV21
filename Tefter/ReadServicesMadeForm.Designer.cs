
namespace Tefter
{
    partial class ReadServicesMadeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadServicesMadeForm));
            this.LoadContext_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LoadContext_TextBox
            // 
            this.LoadContext_TextBox.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadContext_TextBox.Location = new System.Drawing.Point(12, 12);
            this.LoadContext_TextBox.Multiline = true;
            this.LoadContext_TextBox.Name = "LoadContext_TextBox";
            this.LoadContext_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LoadContext_TextBox.Size = new System.Drawing.Size(780, 437);
            this.LoadContext_TextBox.TabIndex = 0;
            // 
            // ReadServicesMadeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.LoadContext_TextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(950, 614);
            this.MinimumSize = new System.Drawing.Size(820, 500);
            this.Name = "ReadServicesMadeForm";
            this.Text = "Описание";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReadServicesMadeForm_FormClosing);
            this.Load += new System.EventHandler(this.ReadServicesMadeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LoadContext_TextBox;
    }
}