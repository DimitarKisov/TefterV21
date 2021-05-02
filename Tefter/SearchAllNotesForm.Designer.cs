
namespace Tefter
{
    partial class SearchAllNotesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchAllNotesForm));
            this.SearchAllNotes_DataGridView = new System.Windows.Forms.DataGridView();
            this.AddButton = new FontAwesome.Sharp.IconButton();
            this.SaveChangesButton = new FontAwesome.Sharp.IconButton();
            this.DeleteRecordButton = new FontAwesome.Sharp.IconButton();
            this.Search_BackButton = new FontAwesome.Sharp.IconButton();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SearchAllNotes_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchAllNotes_DataGridView
            // 
            this.SearchAllNotes_DataGridView.AllowUserToAddRows = false;
            this.SearchAllNotes_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchAllNotes_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Description});
            this.SearchAllNotes_DataGridView.Location = new System.Drawing.Point(0, 61);
            this.SearchAllNotes_DataGridView.Name = "SearchAllNotes_DataGridView";
            this.SearchAllNotes_DataGridView.Size = new System.Drawing.Size(934, 513);
            this.SearchAllNotes_DataGridView.TabIndex = 0;
            this.SearchAllNotes_DataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SearchAllNotesForm_CellDoubleClick);
            // 
            // AddButton
            // 
            this.AddButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.AddButton.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.AddButton.IconColor = System.Drawing.Color.Black;
            this.AddButton.IconSize = 60;
            this.AddButton.Location = new System.Drawing.Point(877, 0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Padding = new System.Windows.Forms.Padding(0, 2, 15, 0);
            this.AddButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AddButton.Rotation = 0D;
            this.AddButton.Size = new System.Drawing.Size(57, 55);
            this.AddButton.TabIndex = 103;
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SaveChangesButton
            // 
            this.SaveChangesButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.SaveChangesButton.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.SaveChangesButton.IconColor = System.Drawing.Color.Black;
            this.SaveChangesButton.IconSize = 60;
            this.SaveChangesButton.Location = new System.Drawing.Point(814, 0);
            this.SaveChangesButton.Name = "SaveChangesButton";
            this.SaveChangesButton.Padding = new System.Windows.Forms.Padding(0, 2, 15, 0);
            this.SaveChangesButton.Rotation = 0D;
            this.SaveChangesButton.Size = new System.Drawing.Size(57, 55);
            this.SaveChangesButton.TabIndex = 104;
            this.SaveChangesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.SaveChangesButton.UseVisualStyleBackColor = true;
            this.SaveChangesButton.Click += new System.EventHandler(this.SaveChangesButton_Click);
            // 
            // DeleteRecordButton
            // 
            this.DeleteRecordButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.DeleteRecordButton.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.DeleteRecordButton.IconColor = System.Drawing.Color.Black;
            this.DeleteRecordButton.IconSize = 54;
            this.DeleteRecordButton.Location = new System.Drawing.Point(751, 0);
            this.DeleteRecordButton.Name = "DeleteRecordButton";
            this.DeleteRecordButton.Padding = new System.Windows.Forms.Padding(0, 2, 15, 0);
            this.DeleteRecordButton.Rotation = 0D;
            this.DeleteRecordButton.Size = new System.Drawing.Size(57, 55);
            this.DeleteRecordButton.TabIndex = 105;
            this.DeleteRecordButton.UseVisualStyleBackColor = true;
            this.DeleteRecordButton.Click += new System.EventHandler(this.DeleteRecordButton_Click);
            // 
            // Search_BackButton
            // 
            this.Search_BackButton.BackColor = System.Drawing.Color.Gainsboro;
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
            this.Search_BackButton.TabIndex = 106;
            this.Search_BackButton.UseVisualStyleBackColor = false;
            this.Search_BackButton.Click += new System.EventHandler(this.Search_BackButton_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "Регистрационен номер";
            this.Id.Name = "Id";
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Описание";
            this.Description.Name = "Description";
            // 
            // SearchAllNotesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(934, 575);
            this.Controls.Add(this.Search_BackButton);
            this.Controls.Add(this.DeleteRecordButton);
            this.Controls.Add(this.SaveChangesButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SearchAllNotes_DataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(950, 614);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "SearchAllNotesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Бележки";
            this.Load += new System.EventHandler(this.SearchAllNotesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SearchAllNotes_DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SearchAllNotes_DataGridView;
        private FontAwesome.Sharp.IconButton AddButton;
        private FontAwesome.Sharp.IconButton SaveChangesButton;
        private FontAwesome.Sharp.IconButton DeleteRecordButton;
        private FontAwesome.Sharp.IconButton Search_BackButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}