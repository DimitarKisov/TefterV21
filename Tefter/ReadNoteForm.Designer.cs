
namespace Tefter
{
    partial class ReadNoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadNoteForm));
            this.ReadDescription_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ReadDescription_TextBox
            // 
            this.ReadDescription_TextBox.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadDescription_TextBox.Location = new System.Drawing.Point(12, 12);
            this.ReadDescription_TextBox.Multiline = true;
            this.ReadDescription_TextBox.Name = "ReadDescription_TextBox";
            this.ReadDescription_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ReadDescription_TextBox.Size = new System.Drawing.Size(780, 437);
            this.ReadDescription_TextBox.TabIndex = 0;
            // 
            // ReadNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.ReadDescription_TextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(950, 614);
            this.MinimumSize = new System.Drawing.Size(820, 500);
            this.Name = "ReadNoteForm";
            this.Text = "Описание";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReadNoteForm_FormClosing);
            this.Load += new System.EventHandler(this.ReadNoteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ReadDescription_TextBox;
    }
}