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
            this.SearchServiceBook_TextBox = new System.Windows.Forms.TextBox();
            this.CreateNewServiceBook_Button = new System.Windows.Forms.Button();
            this.SearchButton = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // SearchServiceBook_TextBox
            // 
            this.SearchServiceBook_TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SearchServiceBook_TextBox.Font = new System.Drawing.Font("Times New Roman", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchServiceBook_TextBox.Location = new System.Drawing.Point(70, 95);
            this.SearchServiceBook_TextBox.Multiline = true;
            this.SearchServiceBook_TextBox.Name = "SearchServiceBook_TextBox";
            this.SearchServiceBook_TextBox.Size = new System.Drawing.Size(426, 79);
            this.SearchServiceBook_TextBox.TabIndex = 0;
            this.SearchServiceBook_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SearchServiceBook_TextBox.TextChanged += new System.EventHandler(this.SearchServiceBook_TextBox_TextChanged);
            // 
            // CreateNewServiceBook_Button
            // 
            this.CreateNewServiceBook_Button.Font = new System.Drawing.Font("Times New Roman", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewServiceBook_Button.Location = new System.Drawing.Point(70, 249);
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
            this.SearchButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.SearchButton.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.SearchButton.IconColor = System.Drawing.Color.Black;
            this.SearchButton.IconSize = 55;
            this.SearchButton.Location = new System.Drawing.Point(495, 95);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Rotation = 0D;
            this.SearchButton.Size = new System.Drawing.Size(100, 79);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // HomePageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 406);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.CreateNewServiceBook_Button);
            this.Controls.Add(this.SearchServiceBook_TextBox);
            this.Name = "HomePageForm";
            this.Text = "Начало";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchServiceBook_TextBox;
        private System.Windows.Forms.Button CreateNewServiceBook_Button;
        private FontAwesome.Sharp.IconButton SearchButton;
    }
}

