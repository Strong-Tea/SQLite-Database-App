namespace SQLiteDatabaseApp.windows
{
    partial class DataGridWindow
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
            dataGridView = new System.Windows.Forms.DataGridView();
            cbTables = new System.Windows.Forms.ComboBox();
            ImportExcel = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new System.Drawing.Point(0, 80);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new System.Drawing.Size(1227, 598);
            dataGridView.TabIndex = 0;
            dataGridView.CellEndEdit += dataGridView_CellEndEdit;
            dataGridView.KeyDown += dataGridView_KeyDown;
            // 
            // cbTables
            // 
            cbTables.FormattingEnabled = true;
            cbTables.Location = new System.Drawing.Point(12, 21);
            cbTables.Name = "cbTables";
            cbTables.Size = new System.Drawing.Size(198, 28);
            cbTables.TabIndex = 3;
            cbTables.SelectedIndexChanged += cbTables_SelectedIndexChanged;
            // 
            // ImportExcel
            // 
            ImportExcel.BackColor = System.Drawing.Color.White;
            ImportExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            ImportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ImportExcel.Location = new System.Drawing.Point(266, 16);
            ImportExcel.Name = "ImportExcel";
            ImportExcel.Size = new System.Drawing.Size(156, 37);
            ImportExcel.TabIndex = 4;
            ImportExcel.Text = "Import from Excel";
            ImportExcel.UseVisualStyleBackColor = false;
            ImportExcel.Click += btImportExcel_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // DataGridWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(247, 247, 247);
            ClientSize = new System.Drawing.Size(1227, 678);
            Controls.Add(ImportExcel);
            Controls.Add(cbTables);
            Controls.Add(dataGridView);
            Name = "DataGridWindow";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DataGridWindow";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox cbTables;
        private System.Windows.Forms.Button ImportExcel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}