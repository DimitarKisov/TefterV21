namespace Tefter
{
    partial class CreateNewServiceBookFormThree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewServiceBookFormThree));
            this.OtherService_Label = new System.Windows.Forms.Label();
            this.BackButton = new FontAwesome.Sharp.IconButton();
            this.DateMadeChanged_Label = new System.Windows.Forms.Label();
            this.DateMadeChanges_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.CurrentKilometers_Label = new System.Windows.Forms.Label();
            this.Description_Label = new System.Windows.Forms.Label();
            this.Description_TextBox = new System.Windows.Forms.TextBox();
            this.End_Button = new System.Windows.Forms.Button();
            this.CurrentKilometers_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OtherService_Label
            // 
            this.OtherService_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.OtherService_Label.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherService_Label.Location = new System.Drawing.Point(0, 0);
            this.OtherService_Label.Name = "OtherService_Label";
            this.OtherService_Label.Size = new System.Drawing.Size(934, 55);
            this.OtherService_Label.TabIndex = 0;
            this.OtherService_Label.Text = "ДРУГИ СЕРВИЗНИ НАМЕСИ";
            this.OtherService_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.Control;
            this.BackButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.IconChar = FontAwesome.Sharp.IconChar.LongArrowAltLeft;
            this.BackButton.IconColor = System.Drawing.Color.Black;
            this.BackButton.IconSize = 50;
            this.BackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackButton.Location = new System.Drawing.Point(1, 0);
            this.BackButton.Name = "BackButton";
            this.BackButton.Rotation = 0D;
            this.BackButton.Size = new System.Drawing.Size(64, 55);
            this.BackButton.TabIndex = 49;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // DateMadeChanged_Label
            // 
            this.DateMadeChanged_Label.AutoSize = true;
            this.DateMadeChanged_Label.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateMadeChanged_Label.Location = new System.Drawing.Point(12, 118);
            this.DateMadeChanged_Label.Name = "DateMadeChanged_Label";
            this.DateMadeChanged_Label.Size = new System.Drawing.Size(79, 33);
            this.DateMadeChanged_Label.TabIndex = 50;
            this.DateMadeChanged_Label.Text = "Дата:";
            // 
            // DateMadeChanges_DatePicker
            // 
            this.DateMadeChanges_DatePicker.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateMadeChanges_DatePicker.Location = new System.Drawing.Point(137, 121);
            this.DateMadeChanges_DatePicker.Name = "DateMadeChanges_DatePicker";
            this.DateMadeChanges_DatePicker.Size = new System.Drawing.Size(200, 30);
            this.DateMadeChanges_DatePicker.TabIndex = 51;
            // 
            // CurrentKilometers_Label
            // 
            this.CurrentKilometers_Label.AutoSize = true;
            this.CurrentKilometers_Label.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentKilometers_Label.Location = new System.Drawing.Point(473, 118);
            this.CurrentKilometers_Label.Name = "CurrentKilometers_Label";
            this.CurrentKilometers_Label.Size = new System.Drawing.Size(183, 33);
            this.CurrentKilometers_Label.TabIndex = 52;
            this.CurrentKilometers_Label.Text = "Изминати км:";
            this.CurrentKilometers_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Description_Label
            // 
            this.Description_Label.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description_Label.Location = new System.Drawing.Point(273, 163);
            this.Description_Label.Name = "Description_Label";
            this.Description_Label.Size = new System.Drawing.Size(381, 35);
            this.Description_Label.TabIndex = 54;
            this.Description_Label.Text = "Извършена сервизна дейност:";
            // 
            // Description_TextBox
            // 
            this.Description_TextBox.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description_TextBox.Location = new System.Drawing.Point(1, 201);
            this.Description_TextBox.Multiline = true;
            this.Description_TextBox.Name = "Description_TextBox";
            this.Description_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Description_TextBox.Size = new System.Drawing.Size(933, 337);
            this.Description_TextBox.TabIndex = 55;
            // 
            // End_Button
            // 
            this.End_Button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.End_Button.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.End_Button.Location = new System.Drawing.Point(0, 538);
            this.End_Button.Name = "End_Button";
            this.End_Button.Size = new System.Drawing.Size(934, 37);
            this.End_Button.TabIndex = 56;
            this.End_Button.Text = "КРАЙ";
            this.End_Button.UseVisualStyleBackColor = true;
            this.End_Button.Click += new System.EventHandler(this.End_Button_Click);
            // 
            // CurrentKilometers_TextBox
            // 
            this.CurrentKilometers_TextBox.Font = new System.Drawing.Font("Times New Roman", 19.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentKilometers_TextBox.Location = new System.Drawing.Point(709, 118);
            this.CurrentKilometers_TextBox.Name = "CurrentKilometers_TextBox";
            this.CurrentKilometers_TextBox.Size = new System.Drawing.Size(170, 38);
            this.CurrentKilometers_TextBox.TabIndex = 57;
            // 
            // CreateNewServiceBookFormThree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(934, 575);
            this.Controls.Add(this.CurrentKilometers_TextBox);
            this.Controls.Add(this.End_Button);
            this.Controls.Add(this.Description_TextBox);
            this.Controls.Add(this.Description_Label);
            this.Controls.Add(this.CurrentKilometers_Label);
            this.Controls.Add(this.DateMadeChanges_DatePicker);
            this.Controls.Add(this.DateMadeChanged_Label);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.OtherService_Label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(950, 614);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "CreateNewServiceBookFormThree";
            this.Text = "Други сервизни намеси";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OtherService_Label;
        private FontAwesome.Sharp.IconButton BackButton;
        private System.Windows.Forms.Label DateMadeChanged_Label;
        private System.Windows.Forms.DateTimePicker DateMadeChanges_DatePicker;
        private System.Windows.Forms.Label CurrentKilometers_Label;
        private System.Windows.Forms.Label Description_Label;
        private System.Windows.Forms.TextBox Description_TextBox;
        private System.Windows.Forms.Button End_Button;
        private System.Windows.Forms.TextBox CurrentKilometers_TextBox;
    }
}