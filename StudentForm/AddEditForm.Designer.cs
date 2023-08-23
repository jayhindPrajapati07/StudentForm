namespace StudentForm
{
    partial class AddEditForm
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
            panel = new Panel();
            PanelContainer = new Panel();
            lblGenderValidator = new Label();
            lblDateOfBirthValidator = new Label();
            lblAgeValidator = new Label();
            lblFirstNameValidator = new Label();
            lblLastNameValidator = new Label();
            dtDateOfBirth = new DateTimePicker();
            cmbGender = new ComboBox();
            lblyears = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            textAreaAddress = new TextBox();
            txtClass = new TextBox();
            txtAge = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            Star1 = new Label();
            btnCancel = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            lblAddress = new Label();
            lblLastName = new Label();
            lblGender = new Label();
            lblDateOfBirth = new Label();
            lblClass = new Label();
            lblAge = new Label();
            lblFirstName = new Label();
            lblStudentHeader = new Label();
            panel.SuspendLayout();
            PanelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(PanelContainer);
            panel.Controls.Add(lblStudentHeader);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(852, 834);
            panel.TabIndex = 0;
            // 
            // PanelContainer
            // 
            PanelContainer.Controls.Add(lblGenderValidator);
            PanelContainer.Controls.Add(lblDateOfBirthValidator);
            PanelContainer.Controls.Add(lblAgeValidator);
            PanelContainer.Controls.Add(lblFirstNameValidator);
            PanelContainer.Controls.Add(lblLastNameValidator);
            PanelContainer.Controls.Add(dtDateOfBirth);
            PanelContainer.Controls.Add(cmbGender);
            PanelContainer.Controls.Add(lblyears);
            PanelContainer.Controls.Add(txtFirstName);
            PanelContainer.Controls.Add(txtLastName);
            PanelContainer.Controls.Add(textAreaAddress);
            PanelContainer.Controls.Add(txtClass);
            PanelContainer.Controls.Add(txtAge);
            PanelContainer.Controls.Add(label4);
            PanelContainer.Controls.Add(label3);
            PanelContainer.Controls.Add(label2);
            PanelContainer.Controls.Add(label1);
            PanelContainer.Controls.Add(Star1);
            PanelContainer.Controls.Add(btnCancel);
            PanelContainer.Controls.Add(btnDelete);
            PanelContainer.Controls.Add(btnSave);
            PanelContainer.Controls.Add(lblAddress);
            PanelContainer.Controls.Add(lblLastName);
            PanelContainer.Controls.Add(lblGender);
            PanelContainer.Controls.Add(lblDateOfBirth);
            PanelContainer.Controls.Add(lblClass);
            PanelContainer.Controls.Add(lblAge);
            PanelContainer.Controls.Add(lblFirstName);
            PanelContainer.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            PanelContainer.Location = new Point(53, 132);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(748, 659);
            PanelContainer.TabIndex = 5;
            // 
            // lblGenderValidator
            // 
            lblGenderValidator.AutoSize = true;
            lblGenderValidator.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblGenderValidator.ForeColor = Color.Red;
            lblGenderValidator.Location = new Point(192, 228);
            lblGenderValidator.Name = "lblGenderValidator";
            lblGenderValidator.Size = new Size(0, 21);
            lblGenderValidator.TabIndex = 29;
            // 
            // lblDateOfBirthValidator
            // 
            lblDateOfBirthValidator.AutoSize = true;
            lblDateOfBirthValidator.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblDateOfBirthValidator.ForeColor = Color.Red;
            lblDateOfBirthValidator.Location = new Point(192, 315);
            lblDateOfBirthValidator.Name = "lblDateOfBirthValidator";
            lblDateOfBirthValidator.Size = new Size(0, 21);
            lblDateOfBirthValidator.TabIndex = 28;
            // 
            // lblAgeValidator
            // 
            lblAgeValidator.AutoSize = true;
            lblAgeValidator.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblAgeValidator.ForeColor = Color.Red;
            lblAgeValidator.Location = new Point(589, 319);
            lblAgeValidator.Name = "lblAgeValidator";
            lblAgeValidator.Size = new Size(0, 21);
            lblAgeValidator.TabIndex = 27;
            // 
            // lblFirstNameValidator
            // 
            lblFirstNameValidator.AutoSize = true;
            lblFirstNameValidator.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblFirstNameValidator.ForeColor = Color.Red;
            lblFirstNameValidator.Location = new Point(192, 50);
            lblFirstNameValidator.Name = "lblFirstNameValidator";
            lblFirstNameValidator.Size = new Size(0, 21);
            lblFirstNameValidator.TabIndex = 26;
            // 
            // lblLastNameValidator
            // 
            lblLastNameValidator.AutoSize = true;
            lblLastNameValidator.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblLastNameValidator.ForeColor = Color.Red;
            lblLastNameValidator.Location = new Point(192, 140);
            lblLastNameValidator.Name = "lblLastNameValidator";
            lblLastNameValidator.Size = new Size(0, 21);
            lblLastNameValidator.TabIndex = 24;
            // 
            // dtDateOfBirth
            // 
            dtDateOfBirth.Format = DateTimePickerFormat.Short;
            dtDateOfBirth.Location = new Point(192, 270);
            dtDateOfBirth.Name = "dtDateOfBirth";
            dtDateOfBirth.Size = new Size(265, 42);
            dtDateOfBirth.TabIndex = 23;
            dtDateOfBirth.Value = new DateTime(2023, 8, 19, 0, 0, 0, 0);
            dtDateOfBirth.ValueChanged += dtDateOfBirth_ValueChanged;
            // 
            // cmbGender
            // 
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Male", "Female" });
            cmbGender.Location = new Point(192, 181);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(265, 44);
            cmbGender.TabIndex = 22;
            cmbGender.DropDownClosed += cmbGender_DropDownClosed;
            cmbGender.Enter += cmbGender_Enter;
            cmbGender.KeyDown += cmbGender_KeyDown;
            cmbGender.MouseClick += cmbGender_MouseClick;
            // 
            // lblyears
            // 
            lblyears.AutoSize = true;
            lblyears.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblyears.Location = new Point(693, 291);
            lblyears.Name = "lblyears";
            lblyears.Size = new Size(47, 21);
            lblyears.TabIndex = 21;
            lblyears.Text = "years";
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Location = new Point(192, 5);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "Please enter First Name";
            txtFirstName.Size = new Size(553, 42);
            txtFirstName.TabIndex = 20;
            txtFirstName.KeyPress += txtFirstName_KeyPress;
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Location = new Point(192, 95);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Please enter Last Name";
            txtLastName.Size = new Size(553, 42);
            txtLastName.TabIndex = 19;
            txtLastName.KeyPress += txtLastName_KeyPress;
            // 
            // textAreaAddress
            // 
            textAreaAddress.BorderStyle = BorderStyle.FixedSingle;
            textAreaAddress.Location = new Point(187, 440);
            textAreaAddress.Multiline = true;
            textAreaAddress.Name = "textAreaAddress";
            textAreaAddress.PlaceholderText = "Please enter address";
            textAreaAddress.ScrollBars = ScrollBars.Vertical;
            textAreaAddress.Size = new Size(553, 115);
            textAreaAddress.TabIndex = 18;
            // 
            // txtClass
            // 
            txtClass.BorderStyle = BorderStyle.FixedSingle;
            txtClass.Location = new Point(192, 355);
            txtClass.Name = "txtClass";
            txtClass.PlaceholderText = "Please enter Class";
            txtClass.Size = new Size(265, 42);
            txtClass.TabIndex = 17;
            // 
            // txtAge
            // 
            txtAge.BorderStyle = BorderStyle.FixedSingle;
            txtAge.Location = new Point(589, 270);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(98, 42);
            txtAge.TabIndex = 16;
            txtAge.KeyPress += txtAge_KeyPress;
            txtAge.KeyUp += txtAge_KeyUp;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(135, 100);
            label4.Name = "label4";
            label4.Size = new Size(25, 32);
            label4.TabIndex = 14;
            label4.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(98, 181);
            label3.Name = "label3";
            label3.Size = new Size(25, 32);
            label3.TabIndex = 13;
            label3.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(162, 268);
            label2.Name = "label2";
            label2.Size = new Size(25, 32);
            label2.TabIndex = 12;
            label2.Text = "*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(559, 268);
            label1.Name = "label1";
            label1.Size = new Size(25, 32);
            label1.TabIndex = 11;
            label1.Text = "*";
            // 
            // Star1
            // 
            Star1.AutoSize = true;
            Star1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Star1.ForeColor = Color.Red;
            Star1.Location = new Point(135, 10);
            Star1.Name = "Star1";
            Star1.Size = new Size(25, 32);
            Star1.TabIndex = 10;
            Star1.Text = "*";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.GrayText;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.Location = new Point(611, 607);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(134, 46);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.GrayText;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.DarkRed;
            btnDelete.Location = new Point(0, 607);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(134, 46);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SteelBlue;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.Location = new Point(427, 607);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(134, 46);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblAddress.Location = new Point(3, 440);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(107, 36);
            lblAddress.TabIndex = 6;
            lblAddress.Text = "Address";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblLastName.Location = new Point(3, 101);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(135, 36);
            lblLastName.TabIndex = 5;
            lblLastName.Text = "Last Name";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblGender.Location = new Point(3, 188);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(100, 36);
            lblGender.TabIndex = 4;
            lblGender.Text = "Gender";
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblDateOfBirth.Location = new Point(3, 275);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(165, 36);
            lblDateOfBirth.TabIndex = 3;
            lblDateOfBirth.Text = "Date Of Birth";
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblClass.Location = new Point(3, 355);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(72, 36);
            lblClass.TabIndex = 2;
            lblClass.Text = "Class";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblAge.Location = new Point(500, 273);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(61, 36);
            lblAge.TabIndex = 1;
            lblAge.Text = "Age";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblFirstName.Location = new Point(3, 15);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(138, 36);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "First Name";
            // 
            // lblStudentHeader
            // 
            lblStudentHeader.AutoSize = true;
            lblStudentHeader.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            lblStudentHeader.Location = new Point(202, 21);
            lblStudentHeader.Name = "lblStudentHeader";
            lblStudentHeader.Size = new Size(447, 93);
            lblStudentHeader.TabIndex = 4;
            lblStudentHeader.Text = "Our Students";
            // 
            // AddEditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(852, 834);
            Controls.Add(panel);
            MaximizeBox = false;
            Name = "AddEditForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddEditForm";
            Load += AddEditForm_Load;
            panel.ResumeLayout(false);
            panel.PerformLayout();
            PanelContainer.ResumeLayout(false);
            PanelContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Label lblStudentHeader;
        private Panel PanelContainer;
        private Label lblLastName;
        private Label lblGender;
        private Label lblDateOfBirth;
        private Label lblClass;
        private Label lblAge;
        private Label lblFirstName;
        private Label lblAddress;
        private Button btnCancel;
        private Button btnDelete;
        private Button btnSave;
        private Label Star1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtLastName;
        private TextBox textAreaAddress;
        private TextBox txtClass;
        private TextBox txtAge;
        private TextBox txtFirstName;
        private ComboBox cmbGender;
        private Label lblyears;
        private DateTimePicker dtDateOfBirth;
        private Label lblGenderValidator;
        private Label lblDateOfBirthValidator;
        private Label lblAgeValidator;
        private Label lblFirstNameValidator;
        private Label lblLastNameValidator;
    }
}