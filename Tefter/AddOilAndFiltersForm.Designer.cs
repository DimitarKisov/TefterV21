
namespace Tefter
{
    partial class AddOilAndFiltersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOilAndFiltersForm));
            this.ChangeOilAndFilters_Label = new System.Windows.Forms.Label();
            this.OilAndFilters_PictureBox = new System.Windows.Forms.PictureBox();
            this.AddOilAndFiltersRow = new FontAwesome.Sharp.IconButton();
            this.Oil_TextBox = new System.Windows.Forms.TextBox();
            this.Oil_Label = new System.Windows.Forms.Label();
            this.DateMadeChanges_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.CoupeFilter_TextBox = new System.Windows.Forms.TextBox();
            this.AirFilter_TextBox = new System.Windows.Forms.TextBox();
            this.FuelFilter_TextBox = new System.Windows.Forms.TextBox();
            this.OilFilter_TextBox = new System.Windows.Forms.TextBox();
            this.NextOilChangeKilometers_TextBox = new System.Windows.Forms.TextBox();
            this.CurrentKilometers_TextBox = new System.Windows.Forms.TextBox();
            this.AirFilter_Label = new System.Windows.Forms.Label();
            this.CoupeFilter_Label = new System.Windows.Forms.Label();
            this.FuelFilter_Label = new System.Windows.Forms.Label();
            this.OilFilter_Label = new System.Windows.Forms.Label();
            this.NextOilChangeKilometers_Label = new System.Windows.Forms.Label();
            this.CurrentKilometers_Label = new System.Windows.Forms.Label();
            this.DateMadeChanges_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OilAndFilters_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangeOilAndFilters_Label
            // 
            this.ChangeOilAndFilters_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChangeOilAndFilters_Label.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeOilAndFilters_Label.Location = new System.Drawing.Point(0, 0);
            this.ChangeOilAndFilters_Label.Name = "ChangeOilAndFilters_Label";
            this.ChangeOilAndFilters_Label.Size = new System.Drawing.Size(934, 55);
            this.ChangeOilAndFilters_Label.TabIndex = 49;
            this.ChangeOilAndFilters_Label.Text = "СМЯНА НА МАСЛО И ФИЛТРИ";
            this.ChangeOilAndFilters_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OilAndFilters_PictureBox
            // 
            this.OilAndFilters_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.OilAndFilters_PictureBox.Image = global::Tefter.Properties.Resources.OilAndFilters;
            this.OilAndFilters_PictureBox.InitialImage = null;
            this.OilAndFilters_PictureBox.Location = new System.Drawing.Point(565, 118);
            this.OilAndFilters_PictureBox.Name = "OilAndFilters_PictureBox";
            this.OilAndFilters_PictureBox.Size = new System.Drawing.Size(357, 386);
            this.OilAndFilters_PictureBox.TabIndex = 68;
            this.OilAndFilters_PictureBox.TabStop = false;
            // 
            // AddOilAndFiltersRow
            // 
            this.AddOilAndFiltersRow.BackColor = System.Drawing.Color.Gainsboro;
            this.AddOilAndFiltersRow.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.AddOilAndFiltersRow.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddOilAndFiltersRow.IconChar = FontAwesome.Sharp.IconChar.None;
            this.AddOilAndFiltersRow.IconColor = System.Drawing.Color.Black;
            this.AddOilAndFiltersRow.IconSize = 16;
            this.AddOilAndFiltersRow.Location = new System.Drawing.Point(752, 533);
            this.AddOilAndFiltersRow.Name = "AddOilAndFiltersRow";
            this.AddOilAndFiltersRow.Rotation = 0D;
            this.AddOilAndFiltersRow.Size = new System.Drawing.Size(170, 41);
            this.AddOilAndFiltersRow.TabIndex = 8;
            this.AddOilAndFiltersRow.Text = "ДОБАВИ";
            this.AddOilAndFiltersRow.UseVisualStyleBackColor = false;
            this.AddOilAndFiltersRow.Click += new System.EventHandler(this.AddOilAndFiltersRow_Click);
            // 
            // Oil_TextBox
            // 
            this.Oil_TextBox.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Oil_TextBox.Location = new System.Drawing.Point(341, 176);
            this.Oil_TextBox.Multiline = true;
            this.Oil_TextBox.Name = "Oil_TextBox";
            this.Oil_TextBox.Size = new System.Drawing.Size(170, 38);
            this.Oil_TextBox.TabIndex = 1;
            // 
            // Oil_Label
            // 
            this.Oil_Label.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Oil_Label.Location = new System.Drawing.Point(12, 176);
            this.Oil_Label.Name = "Oil_Label";
            this.Oil_Label.Size = new System.Drawing.Size(103, 33);
            this.Oil_Label.TabIndex = 65;
            this.Oil_Label.Text = "Масло";
            // 
            // DateMadeChanges_DatePicker
            // 
            this.DateMadeChanges_DatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateMadeChanges_DatePicker.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateMadeChanges_DatePicker.Location = new System.Drawing.Point(295, 118);
            this.DateMadeChanges_DatePicker.Name = "DateMadeChanges_DatePicker";
            this.DateMadeChanges_DatePicker.Size = new System.Drawing.Size(216, 30);
            this.DateMadeChanges_DatePicker.TabIndex = 64;
            // 
            // CoupeFilter_TextBox
            // 
            this.CoupeFilter_TextBox.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoupeFilter_TextBox.Location = new System.Drawing.Point(341, 524);
            this.CoupeFilter_TextBox.Multiline = true;
            this.CoupeFilter_TextBox.Name = "CoupeFilter_TextBox";
            this.CoupeFilter_TextBox.Size = new System.Drawing.Size(170, 38);
            this.CoupeFilter_TextBox.TabIndex = 7;
            // 
            // AirFilter_TextBox
            // 
            this.AirFilter_TextBox.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AirFilter_TextBox.Location = new System.Drawing.Point(341, 466);
            this.AirFilter_TextBox.Multiline = true;
            this.AirFilter_TextBox.Name = "AirFilter_TextBox";
            this.AirFilter_TextBox.Size = new System.Drawing.Size(170, 38);
            this.AirFilter_TextBox.TabIndex = 6;
            // 
            // FuelFilter_TextBox
            // 
            this.FuelFilter_TextBox.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FuelFilter_TextBox.Location = new System.Drawing.Point(341, 408);
            this.FuelFilter_TextBox.Multiline = true;
            this.FuelFilter_TextBox.Name = "FuelFilter_TextBox";
            this.FuelFilter_TextBox.Size = new System.Drawing.Size(170, 38);
            this.FuelFilter_TextBox.TabIndex = 5;
            // 
            // OilFilter_TextBox
            // 
            this.OilFilter_TextBox.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OilFilter_TextBox.Location = new System.Drawing.Point(341, 350);
            this.OilFilter_TextBox.Multiline = true;
            this.OilFilter_TextBox.Name = "OilFilter_TextBox";
            this.OilFilter_TextBox.Size = new System.Drawing.Size(170, 38);
            this.OilFilter_TextBox.TabIndex = 4;
            // 
            // NextOilChangeKilometers_TextBox
            // 
            this.NextOilChangeKilometers_TextBox.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextOilChangeKilometers_TextBox.Location = new System.Drawing.Point(341, 292);
            this.NextOilChangeKilometers_TextBox.Multiline = true;
            this.NextOilChangeKilometers_TextBox.Name = "NextOilChangeKilometers_TextBox";
            this.NextOilChangeKilometers_TextBox.Size = new System.Drawing.Size(170, 38);
            this.NextOilChangeKilometers_TextBox.TabIndex = 3;
            // 
            // CurrentKilometers_TextBox
            // 
            this.CurrentKilometers_TextBox.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentKilometers_TextBox.Location = new System.Drawing.Point(341, 234);
            this.CurrentKilometers_TextBox.Multiline = true;
            this.CurrentKilometers_TextBox.Name = "CurrentKilometers_TextBox";
            this.CurrentKilometers_TextBox.Size = new System.Drawing.Size(170, 38);
            this.CurrentKilometers_TextBox.TabIndex = 2;
            // 
            // AirFilter_Label
            // 
            this.AirFilter_Label.AutoSize = true;
            this.AirFilter_Label.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AirFilter_Label.Location = new System.Drawing.Point(12, 466);
            this.AirFilter_Label.Name = "AirFilter_Label";
            this.AirFilter_Label.Size = new System.Drawing.Size(236, 33);
            this.AirFilter_Label.TabIndex = 57;
            this.AirFilter_Label.Text = "Въздушен филтър";
            // 
            // CoupeFilter_Label
            // 
            this.CoupeFilter_Label.AutoSize = true;
            this.CoupeFilter_Label.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoupeFilter_Label.Location = new System.Drawing.Point(12, 524);
            this.CoupeFilter_Label.Name = "CoupeFilter_Label";
            this.CoupeFilter_Label.Size = new System.Drawing.Size(173, 33);
            this.CoupeFilter_Label.TabIndex = 56;
            this.CoupeFilter_Label.Text = "Филтър купе";
            // 
            // FuelFilter_Label
            // 
            this.FuelFilter_Label.AutoSize = true;
            this.FuelFilter_Label.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FuelFilter_Label.Location = new System.Drawing.Point(12, 408);
            this.FuelFilter_Label.Name = "FuelFilter_Label";
            this.FuelFilter_Label.Size = new System.Drawing.Size(214, 33);
            this.FuelFilter_Label.TabIndex = 55;
            this.FuelFilter_Label.Text = "Горивен филтър";
            // 
            // OilFilter_Label
            // 
            this.OilFilter_Label.AutoSize = true;
            this.OilFilter_Label.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OilFilter_Label.Location = new System.Drawing.Point(12, 350);
            this.OilFilter_Label.Name = "OilFilter_Label";
            this.OilFilter_Label.Size = new System.Drawing.Size(206, 33);
            this.OilFilter_Label.TabIndex = 54;
            this.OilFilter_Label.Text = "Маслен филтър";
            // 
            // NextOilChangeKilometers_Label
            // 
            this.NextOilChangeKilometers_Label.AutoSize = true;
            this.NextOilChangeKilometers_Label.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextOilChangeKilometers_Label.Location = new System.Drawing.Point(12, 292);
            this.NextOilChangeKilometers_Label.Name = "NextOilChangeKilometers_Label";
            this.NextOilChangeKilometers_Label.Size = new System.Drawing.Size(308, 33);
            this.NextOilChangeKilometers_Label.TabIndex = 53;
            this.NextOilChangeKilometers_Label.Text = "Следваща смяна на (км)";
            // 
            // CurrentKilometers_Label
            // 
            this.CurrentKilometers_Label.AutoSize = true;
            this.CurrentKilometers_Label.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentKilometers_Label.Location = new System.Drawing.Point(12, 234);
            this.CurrentKilometers_Label.Name = "CurrentKilometers_Label";
            this.CurrentKilometers_Label.Size = new System.Drawing.Size(52, 33);
            this.CurrentKilometers_Label.TabIndex = 52;
            this.CurrentKilometers_Label.Text = "Км";
            // 
            // DateMadeChanges_Label
            // 
            this.DateMadeChanges_Label.AutoSize = true;
            this.DateMadeChanges_Label.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateMadeChanges_Label.Location = new System.Drawing.Point(12, 118);
            this.DateMadeChanges_Label.Name = "DateMadeChanges_Label";
            this.DateMadeChanges_Label.Size = new System.Drawing.Size(71, 33);
            this.DateMadeChanges_Label.TabIndex = 51;
            this.DateMadeChanges_Label.Text = "Дата";
            // 
            // AddOilAndFiltersForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(934, 575);
            this.Controls.Add(this.OilAndFilters_PictureBox);
            this.Controls.Add(this.AddOilAndFiltersRow);
            this.Controls.Add(this.Oil_TextBox);
            this.Controls.Add(this.Oil_Label);
            this.Controls.Add(this.DateMadeChanges_DatePicker);
            this.Controls.Add(this.CoupeFilter_TextBox);
            this.Controls.Add(this.AirFilter_TextBox);
            this.Controls.Add(this.FuelFilter_TextBox);
            this.Controls.Add(this.OilFilter_TextBox);
            this.Controls.Add(this.NextOilChangeKilometers_TextBox);
            this.Controls.Add(this.CurrentKilometers_TextBox);
            this.Controls.Add(this.AirFilter_Label);
            this.Controls.Add(this.CoupeFilter_Label);
            this.Controls.Add(this.FuelFilter_Label);
            this.Controls.Add(this.OilFilter_Label);
            this.Controls.Add(this.NextOilChangeKilometers_Label);
            this.Controls.Add(this.CurrentKilometers_Label);
            this.Controls.Add(this.DateMadeChanges_Label);
            this.Controls.Add(this.ChangeOilAndFilters_Label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(950, 614);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "AddOilAndFiltersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Масла и филтри";
            ((System.ComponentModel.ISupportInitialize)(this.OilAndFilters_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ChangeOilAndFilters_Label;
        private System.Windows.Forms.PictureBox OilAndFilters_PictureBox;
        private FontAwesome.Sharp.IconButton AddOilAndFiltersRow;
        private System.Windows.Forms.TextBox Oil_TextBox;
        private System.Windows.Forms.Label Oil_Label;
        private System.Windows.Forms.DateTimePicker DateMadeChanges_DatePicker;
        private System.Windows.Forms.TextBox CoupeFilter_TextBox;
        private System.Windows.Forms.TextBox AirFilter_TextBox;
        private System.Windows.Forms.TextBox FuelFilter_TextBox;
        private System.Windows.Forms.TextBox OilFilter_TextBox;
        private System.Windows.Forms.TextBox NextOilChangeKilometers_TextBox;
        private System.Windows.Forms.TextBox CurrentKilometers_TextBox;
        private System.Windows.Forms.Label AirFilter_Label;
        private System.Windows.Forms.Label CoupeFilter_Label;
        private System.Windows.Forms.Label FuelFilter_Label;
        private System.Windows.Forms.Label OilFilter_Label;
        private System.Windows.Forms.Label NextOilChangeKilometers_Label;
        private System.Windows.Forms.Label CurrentKilometers_Label;
        private System.Windows.Forms.Label DateMadeChanges_Label;
    }
}