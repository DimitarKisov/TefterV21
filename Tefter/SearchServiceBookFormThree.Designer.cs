
namespace Tefter
{
    partial class SearchServiceBookFormThree
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
            this.OtherServicesDataGridView = new System.Windows.Forms.DataGridView();
            this.Search_BackButton = new FontAwesome.Sharp.IconButton();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateMadeChanges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kilometers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.OtherServicesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OtherServicesDataGridView
            // 
            this.OtherServicesDataGridView.AllowUserToAddRows = false;
            this.OtherServicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OtherServicesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DateMadeChanges,
            this.Kilometers,
            this.ServiceDone});
            this.OtherServicesDataGridView.Location = new System.Drawing.Point(0, 61);
            this.OtherServicesDataGridView.Name = "OtherServicesDataGridView";
            this.OtherServicesDataGridView.ReadOnly = true;
            this.OtherServicesDataGridView.Size = new System.Drawing.Size(934, 415);
            this.OtherServicesDataGridView.TabIndex = 0;
            // 
            // Search_BackButton
            // 
            this.Search_BackButton.BackColor = System.Drawing.SystemColors.Control;
            this.Search_BackButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.Search_BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_BackButton.IconChar = FontAwesome.Sharp.IconChar.LongArrowAltLeft;
            this.Search_BackButton.IconColor = System.Drawing.Color.Black;
            this.Search_BackButton.IconSize = 50;
            this.Search_BackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Search_BackButton.Location = new System.Drawing.Point(0, 0);
            this.Search_BackButton.Name = "Search_BackButton";
            this.Search_BackButton.Rotation = 0D;
            this.Search_BackButton.Size = new System.Drawing.Size(64, 55);
            this.Search_BackButton.TabIndex = 102;
            this.Search_BackButton.UseVisualStyleBackColor = false;
            this.Search_BackButton.Click += new System.EventHandler(this.Search_BackButton_Click);
            // 
            // Id
            // 
            this.Id.Frozen = true;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // DateMadeChanges
            // 
            this.DateMadeChanges.HeaderText = "Дата";
            this.DateMadeChanges.Name = "DateMadeChanges";
            this.DateMadeChanges.ReadOnly = true;
            // 
            // Kilometers
            // 
            this.Kilometers.HeaderText = "Изминати километри";
            this.Kilometers.Name = "Kilometers";
            this.Kilometers.ReadOnly = true;
            // 
            // ServiceDone
            // 
            this.ServiceDone.HeaderText = "Извършена сервизна дейност";
            this.ServiceDone.Name = "ServiceDone";
            this.ServiceDone.ReadOnly = true;
            // 
            // SearchServiceBookFormThree
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(934, 575);
            this.Controls.Add(this.Search_BackButton);
            this.Controls.Add(this.OtherServicesDataGridView);
            this.MaximumSize = new System.Drawing.Size(950, 614);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "SearchServiceBookFormThree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchServiceBookFormThree";
            this.Load += new System.EventHandler(this.SearchServiceBookFormThree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OtherServicesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView OtherServicesDataGridView;
        private FontAwesome.Sharp.IconButton Search_BackButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateMadeChanges;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kilometers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceDone;
    }
}