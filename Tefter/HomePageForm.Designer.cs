namespace Tefter
{
    partial class HomePageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePageForm));
            this.CreateNewServiceBook_Button = new System.Windows.Forms.Button();
            this.SearchButton = new FontAwesome.Sharp.IconButton();
            this.Search_TextBox = new System.Windows.Forms.TextBox();
            this.SearchAllNotesForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateNewServiceBook_Button
            // 
            this.CreateNewServiceBook_Button.Font = new System.Drawing.Font("Times New Roman", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewServiceBook_Button.Location = new System.Drawing.Point(72, 281);
            this.CreateNewServiceBook_Button.Name = "CreateNewServiceBook_Button";
            this.CreateNewServiceBook_Button.Size = new System.Drawing.Size(525, 79);
            this.CreateNewServiceBook_Button.TabIndex = 2;
            this.CreateNewServiceBook_Button.Text = "Създай нова книжка";
            this.CreateNewServiceBook_Button.UseVisualStyleBackColor = true;
            this.CreateNewServiceBook_Button.Click += new System.EventHandler(this.CreateNewServiceBook_Button_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.SystemColors.Control;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.SearchButton.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.SearchButton.IconColor = System.Drawing.Color.Black;
            this.SearchButton.IconSize = 55;
            this.SearchButton.Location = new System.Drawing.Point(496, 71);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Rotation = 0D;
            this.SearchButton.Size = new System.Drawing.Size(100, 79);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // Search_TextBox
            // 
            this.Search_TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Search_TextBox.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_TextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.Search_TextBox.Location = new System.Drawing.Point(71, 71);
            this.Search_TextBox.Multiline = true;
            this.Search_TextBox.Name = "Search_TextBox";
            this.Search_TextBox.Size = new System.Drawing.Size(426, 79);
            this.Search_TextBox.TabIndex = 4;
            this.Search_TextBox.Text = "РЕГИСТРАЦИОНЕН НОМЕР";
            this.Search_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Search_TextBox.Enter += new System.EventHandler(this.Search_TextBox_Enter);
            this.Search_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Search_TextBox_KeyPress);
            this.Search_TextBox.Leave += new System.EventHandler(this.Search_TextBox_Leave);
            // 
            // SearchAllNotesForm
            // 
            this.SearchAllNotesForm.Font = new System.Drawing.Font("Times New Roman", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchAllNotesForm.Location = new System.Drawing.Point(72, 174);
            this.SearchAllNotesForm.Name = "SearchAllNotesForm";
            this.SearchAllNotesForm.Size = new System.Drawing.Size(525, 79);
            this.SearchAllNotesForm.TabIndex = 5;
            this.SearchAllNotesForm.Text = "Бележки";
            this.SearchAllNotesForm.UseVisualStyleBackColor = true;
            this.SearchAllNotesForm.Click += new System.EventHandler(this.SearchAllNotesForm_Click);
            // 
            // HomePageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(667, 406);
            this.Controls.Add(this.SearchAllNotesForm);
            this.Controls.Add(this.Search_TextBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.CreateNewServiceBook_Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(683, 445);
            this.MinimumSize = new System.Drawing.Size(683, 445);
            this.Name = "HomePageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Начало";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CreateNewServiceBook_Button;
        private FontAwesome.Sharp.IconButton SearchButton;
        private System.Windows.Forms.TextBox Search_TextBox;
        private System.Windows.Forms.Button SearchAllNotesForm;
    }
}

