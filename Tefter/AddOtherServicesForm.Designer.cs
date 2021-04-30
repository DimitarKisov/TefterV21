
namespace Tefter
{
    partial class AddOtherServicesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOtherServicesForm));
            this.CurrentKilometers_TextBox = new System.Windows.Forms.TextBox();
            this.AddOtherServicesRow = new System.Windows.Forms.Button();
            this.Description_TextBox = new System.Windows.Forms.TextBox();
            this.Description_Label = new System.Windows.Forms.Label();
            this.CurrentKilometers_Label = new System.Windows.Forms.Label();
            this.DateMadeChanges_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.DateMadeChanged_Label = new System.Windows.Forms.Label();
            this.OtherService_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CurrentKilometers_TextBox
            // 
            this.CurrentKilometers_TextBox.Font = new System.Drawing.Font("Times New Roman", 19.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentKilometers_TextBox.Location = new System.Drawing.Point(709, 118);
            this.CurrentKilometers_TextBox.Name = "CurrentKilometers_TextBox";
            this.CurrentKilometers_TextBox.Size = new System.Drawing.Size(170, 38);
            this.CurrentKilometers_TextBox.TabIndex = 1;
            // 
            // AddOtherServicesRow
            // 
            this.AddOtherServicesRow.BackColor = System.Drawing.Color.Gainsboro;
            this.AddOtherServicesRow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddOtherServicesRow.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.AddOtherServicesRow.Location = new System.Drawing.Point(0, 538);
            this.AddOtherServicesRow.Name = "AddOtherServicesRow";
            this.AddOtherServicesRow.Size = new System.Drawing.Size(934, 37);
            this.AddOtherServicesRow.TabIndex = 3;
            this.AddOtherServicesRow.Text = "ДОБАВИ";
            this.AddOtherServicesRow.UseVisualStyleBackColor = false;
            this.AddOtherServicesRow.Click += new System.EventHandler(this.AddOtherServicesRow_Click);
            // 
            // Description_TextBox
            // 
            this.Description_TextBox.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description_TextBox.Location = new System.Drawing.Point(1, 201);
            this.Description_TextBox.Multiline = true;
            this.Description_TextBox.Name = "Description_TextBox";
            this.Description_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Description_TextBox.Size = new System.Drawing.Size(933, 337);
            this.Description_TextBox.TabIndex = 2;
            // 
            // Description_Label
            // 
            this.Description_Label.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description_Label.Location = new System.Drawing.Point(273, 163);
            this.Description_Label.Name = "Description_Label";
            this.Description_Label.Size = new System.Drawing.Size(381, 35);
            this.Description_Label.TabIndex = 63;
            this.Description_Label.Text = "Извършена сервизна дейност:";
            // 
            // CurrentKilometers_Label
            // 
            this.CurrentKilometers_Label.AutoSize = true;
            this.CurrentKilometers_Label.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentKilometers_Label.Location = new System.Drawing.Point(473, 118);
            this.CurrentKilometers_Label.Name = "CurrentKilometers_Label";
            this.CurrentKilometers_Label.Size = new System.Drawing.Size(183, 33);
            this.CurrentKilometers_Label.TabIndex = 62;
            this.CurrentKilometers_Label.Text = "Изминати км:";
            this.CurrentKilometers_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DateMadeChanges_DatePicker
            // 
            this.DateMadeChanges_DatePicker.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateMadeChanges_DatePicker.Location = new System.Drawing.Point(137, 121);
            this.DateMadeChanges_DatePicker.Name = "DateMadeChanges_DatePicker";
            this.DateMadeChanges_DatePicker.Size = new System.Drawing.Size(200, 30);
            this.DateMadeChanges_DatePicker.TabIndex = 61;
            // 
            // DateMadeChanged_Label
            // 
            this.DateMadeChanged_Label.AutoSize = true;
            this.DateMadeChanged_Label.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateMadeChanged_Label.Location = new System.Drawing.Point(12, 118);
            this.DateMadeChanged_Label.Name = "DateMadeChanged_Label";
            this.DateMadeChanged_Label.Size = new System.Drawing.Size(79, 33);
            this.DateMadeChanged_Label.TabIndex = 60;
            this.DateMadeChanged_Label.Text = "Дата:";
            // 
            // OtherService_Label
            // 
            this.OtherService_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.OtherService_Label.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherService_Label.Location = new System.Drawing.Point(0, 0);
            this.OtherService_Label.Name = "OtherService_Label";
            this.OtherService_Label.Size = new System.Drawing.Size(934, 55);
            this.OtherService_Label.TabIndex = 58;
            this.OtherService_Label.Text = "ДРУГИ СЕРВИЗНИ НАМЕСИ";
            this.OtherService_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddOtherServicesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(934, 575);
            this.Controls.Add(this.CurrentKilometers_TextBox);
            this.Controls.Add(this.AddOtherServicesRow);
            this.Controls.Add(this.Description_TextBox);
            this.Controls.Add(this.Description_Label);
            this.Controls.Add(this.CurrentKilometers_Label);
            this.Controls.Add(this.DateMadeChanges_DatePicker);
            this.Controls.Add(this.DateMadeChanged_Label);
            this.Controls.Add(this.OtherService_Label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(950, 614);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "AddOtherServicesForm";
            this.Text = "Други сервизни намеси";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CurrentKilometers_TextBox;
        private System.Windows.Forms.Button AddOtherServicesRow;
        private System.Windows.Forms.TextBox Description_TextBox;
        private System.Windows.Forms.Label Description_Label;
        private System.Windows.Forms.Label CurrentKilometers_Label;
        private System.Windows.Forms.DateTimePicker DateMadeChanges_DatePicker;
        private System.Windows.Forms.Label DateMadeChanged_Label;
        private System.Windows.Forms.Label OtherService_Label;
    }
}