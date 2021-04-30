
namespace Tefter
{
    partial class AddNewNoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewNoteForm));
            this.PlateNumber_TextBox = new System.Windows.Forms.TextBox();
            this.SaveChanges_Button = new System.Windows.Forms.Button();
            this.Description_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PlateNumber_TextBox
            // 
            this.PlateNumber_TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PlateNumber_TextBox.Font = new System.Drawing.Font("Times New Roman", 19.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlateNumber_TextBox.Location = new System.Drawing.Point(0, 0);
            this.PlateNumber_TextBox.Name = "PlateNumber_TextBox";
            this.PlateNumber_TextBox.Size = new System.Drawing.Size(800, 37);
            this.PlateNumber_TextBox.TabIndex = 1;
            this.PlateNumber_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PlateNumber_TextBox.Enter += new System.EventHandler(this.PlateNumber_TextBox_Enter);
            this.PlateNumber_TextBox.Leave += new System.EventHandler(this.PlateNumber_TextBox_Leave);
            // 
            // SaveChanges_Button
            // 
            this.SaveChanges_Button.BackColor = System.Drawing.Color.Gainsboro;
            this.SaveChanges_Button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveChanges_Button.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.SaveChanges_Button.Location = new System.Drawing.Point(0, 413);
            this.SaveChanges_Button.Name = "SaveChanges_Button";
            this.SaveChanges_Button.Size = new System.Drawing.Size(800, 37);
            this.SaveChanges_Button.TabIndex = 3;
            this.SaveChanges_Button.Text = "ДОБАВИ";
            this.SaveChanges_Button.UseVisualStyleBackColor = false;
            this.SaveChanges_Button.Click += new System.EventHandler(this.AddNote_Button_Click);
            // 
            // Description_TextBox
            // 
            this.Description_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description_TextBox.Location = new System.Drawing.Point(0, 43);
            this.Description_TextBox.Multiline = true;
            this.Description_TextBox.Name = "Description_TextBox";
            this.Description_TextBox.Size = new System.Drawing.Size(800, 364);
            this.Description_TextBox.TabIndex = 2;
            // 
            // AddNewNoteForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Description_TextBox);
            this.Controls.Add(this.SaveChanges_Button);
            this.Controls.Add(this.PlateNumber_TextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNewNoteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Нова бележка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PlateNumber_TextBox;
        private System.Windows.Forms.Button SaveChanges_Button;
        private System.Windows.Forms.TextBox Description_TextBox;
    }
}