namespace StudentForm
{
    partial class StudentDetailForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            lblStudentHeader = new Label();
            GroupBox = new GroupBox();
            dataGridView = new DataGridView();
            btnAdd = new Button();
            txtSearch = new TextBox();
            panel1.SuspendLayout();
            GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblStudentHeader);
            panel1.Controls.Add(GroupBox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1230, 834);
            panel1.TabIndex = 0;
            // 
            // lblStudentHeader
            // 
            lblStudentHeader.AutoSize = true;
            lblStudentHeader.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            lblStudentHeader.Location = new Point(404, 26);
            lblStudentHeader.Name = "lblStudentHeader";
            lblStudentHeader.Size = new Size(447, 93);
            lblStudentHeader.TabIndex = 3;
            lblStudentHeader.Text = "Our Students";
            // 
            // GroupBox
            // 
            GroupBox.BackColor = SystemColors.Control;
            GroupBox.BackgroundImageLayout = ImageLayout.None;
            GroupBox.Controls.Add(dataGridView);
            GroupBox.Controls.Add(btnAdd);
            GroupBox.Controls.Add(txtSearch);
            GroupBox.Location = new Point(-1, 122);
            GroupBox.Name = "GroupBox";
            GroupBox.Size = new Size(1230, 657);
            GroupBox.TabIndex = 2;
            GroupBox.TabStop = false;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.SelectionBackColor = Color.SeaGreen;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.ColumnHeadersHeight = 34;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.Location = new Point(56, 128);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 62;
            dataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dataGridView.RowTemplate.Height = 33;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(1116, 529);
            dataGridView.TabIndex = 2;
            dataGridView.CellDoubleClick += dataGridView_CellDoubleClick;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SteelBlue;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(1038, 30);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(134, 46);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "+Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(761, 30);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search...";
            txtSearch.Size = new Size(221, 46);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyPress += txtSearch_KeyPress;
            // 
            // StudentDetailForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 834);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "StudentDetailForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentDetailForm";
            Load += StudentDetailForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            GroupBox.ResumeLayout(false);
            GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblStudentHeader;
        private GroupBox GroupBox;
        private DataGridView dataGridView;
        private Button btnAdd;
        private TextBox txtSearch;
    }
}