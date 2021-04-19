
namespace Tefter
{
    partial class SearchServiceBookFormTwo
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
            this.OilAndFilterDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.OilAndFilterDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OilAndFilterDataGridView
            // 
            this.OilAndFilterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OilAndFilterDataGridView.Location = new System.Drawing.Point(12, 12);
            this.OilAndFilterDataGridView.Name = "OilAndFilterDataGridView";
            this.OilAndFilterDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OilAndFilterDataGridView.Size = new System.Drawing.Size(910, 430);
            this.OilAndFilterDataGridView.TabIndex = 0;
            // 
            // SearchServiceBookFormTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(934, 575);
            this.Controls.Add(this.OilAndFilterDataGridView);
            this.MaximumSize = new System.Drawing.Size(950, 614);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "SearchServiceBookFormTwo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchServiceBookFormTwo";
            this.Load += new System.EventHandler(this.SearchServiceBookFormTwo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OilAndFilterDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView OilAndFilterDataGridView;
    }
}