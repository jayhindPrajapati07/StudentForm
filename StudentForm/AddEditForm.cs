using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace StudentForm
{
    public partial class AddEditForm : Form
    {
        public AddEditForm()
        {
            InitializeComponent();
        }
        Layout layout = new Layout();
        StudentDetailForm studentDetailForm;
        internal void setMain(StudentDetailForm studentDetailForm)
        {
            this.studentDetailForm = studentDetailForm;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataLayer dataLayer = new DataLayer();
            StudentModel studentModel = new StudentModel();
            dataLayer.setStudentModel(studentModel);

            studentModel.FirstName = txtFirstName.Text.Trim();
            studentModel.LastName = txtLastName.Text.Trim();
            studentModel.GenderIndex = cmbGender.SelectedIndex;
            studentModel.Gender = cmbGender.Text;
            studentModel.DateOfBirth = dtDateOfBirth.Value;
            studentModel.Age = txtAge.Text.Trim() == "" ? 0 : int.Parse(txtAge.Text);
            studentModel.Class = txtClass.Text.Trim();
            studentModel.Address = textAreaAddress.Text.Trim();

            AddEditBuisnessLogic validator = new AddEditBuisnessLogic();
            validator.setStudentModel(studentModel);

            bool Validated = validator.ValidateFields();
            if (Validated == false)
            {
                lblFirstNameValidator.Text = validator.errFirstName;
                lblLastNameValidator.Text = validator.errLastName;
                lblGenderValidator.Text = validator.errGender;
                lblDateOfBirthValidator.Text = validator.errDateOfBirth;
                lblAgeValidator.Text = validator.errAge;
            }
            if (!studentDetailForm.EditMode)
            {
                if (Validated)
                {
                    dataLayer.AddData();
                    studentDetailForm.refreshRequired = true;
                    Close();
                }
            }
            else
            {
                if (Validated)
                {
                    int id = studentDetailForm.Id;
                    dataLayer.UpdateData(id);
                    studentDetailForm.refreshRequired = true;
                    Close();
                }
            }
        }

        internal void LoadData()
        {
            int id = studentDetailForm.Id;
            string[] DataToEdit = DataLayer.studentList[id];
            txtFirstName.Text = DataToEdit[1];
            txtLastName.Text = DataToEdit[2];
            txtClass.Text = DataToEdit[5];
            textAreaAddress.Text = DataToEdit[6];
            dtDateOfBirth.Text = DataToEdit[7];
            int genderIndex = int.Parse(DataToEdit[8]);
            cmbGender.Text = cmbGender.Items[genderIndex].ToString();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = studentDetailForm.Id;
            var confirmResult = MessageBox.Show("Are you sure you want to delete this student record?", "Confirm Delete!!", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                DataLayer dataLayer = new DataLayer();
                dataLayer.DeleteData(id);
                studentDetailForm.refreshRequired = true;
                Close();
            }
        }


        //Set Age from Date Of Birth
        private void dtDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            AddEditBuisnessLogic ageCalculator = new AddEditBuisnessLogic();
            ageCalculator.ageCalc(dtDateOfBirth.Value, out int age);
            txtAge.Text = age.ToString();
            if (txtAge.Text == "0") txtAge.Text = "";
        }


        //Set Date Of Birth from Age
        private void txtAge_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtAge.Text == "0" ||txtAge.Text=="00") { txtAge.Text = ""; }
            //else {
            //    AddEditBuisnessLogic dobCalculator = new AddEditBuisnessLogic();
            //    dobCalculator.dobCalc(txtAge.Text, out DateTime date);
            //    dtDateOfBirth.Value = date;
            //}
            AddEditBuisnessLogic dobCalculator = new AddEditBuisnessLogic();
            dobCalculator.dobCalc(txtAge.Text, out DateTime date);
            dtDateOfBirth.Value = date;
        }

        private void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Block the input
            }
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPress(sender, e);
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPress(sender, e);
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        //Form Load
        private void AddEditForm_Load(object sender, EventArgs e)
        {
            dtDateOfBirth.MaxDate = DateTime.Now.Date;
            dtDateOfBirth.MinDate = DateTime.Parse("1/1/" + (DateTime.Now.Date.Year - 100));
            lblStudentHeader.Text = layout.EditStudentHeader;
            btnDelete.Visible = true;
            txtAge.MaxLength = 2;
            txtFirstName.MaxLength = 47;
            txtLastName.MaxLength = 47;
            txtClass.MaxLength = 47;
            textAreaAddress.MaxLength = 300;
            studentDetailForm.refreshRequired = false;
            if (!studentDetailForm.EditMode)
            {
                dtDateOfBirth.Text = DateTime.Now.ToShortDateString();
                btnDelete.Visible = false;
                setGenderPlaceHolder();
                lblStudentHeader.Text = layout.AddStudentHeader;
            }
            setDefaultLayout();
        }
        private void setDefaultLayout()
        {
            Fonts fonts = new Fonts();
            panel.Font = fonts.mediumFont;
            LoopThroughControls(this);
            lblStudentHeader.Font = fonts.LargeFont;
            lblFirstNameValidator.Font = fonts.smallFont;
            lblLastNameValidator.Font = fonts.smallFont;
            lblGenderValidator.Font = fonts.smallFont;
            lblDateOfBirthValidator.Font = fonts.smallFont;
            lblAgeValidator.Font = fonts.smallFont;
            lblyears.Font = fonts.smallFont;
            btnSave.BackColor = fonts.btnPrimary;
            btnCancel.BackColor = fonts.btnSecondary;
            btnDelete.ForeColor = fonts.btnDanger;
            lblFirstName.Text = layout.FirstNameLabel;
            lblLastName.Text = layout.LastNameLabel;
            lblGender.Text = layout.GenderLabel;
            lblDateOfBirth.Text = layout.DateOfBirthLabel;
            lblAge.Text = layout.AgeLabel;
            lblClass.Text = layout.ClassLabel;
            lblAddress.Text = layout.AddressLabel;
            btnSave.Text = layout.saveBtnText;
            btnCancel.Text = layout.cancelBtnText;
            btnDelete.Text= layout.deleteBtnText;
            Star1.Text = layout.stars;
            star2.Text = layout.stars;
            star3.Text = layout.stars;
            star4.Text = layout.stars;
            star5.Text = layout.stars;
        }
        private void LoopThroughControls(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                Fonts fonts = new Fonts();
                control.Font = fonts.mediumFont;
                if (control.HasChildren)
                {
                    LoopThroughControls(control);
                }
            }
        }
        //PlaceHolder For Gender
        private void setGenderPlaceHolder()
        {
            cmbGender.DropDownStyle = ComboBoxStyle.DropDown;
            cmbGender.Text = "Select Gender";
            cmbGender.ForeColor = Color.Gray;
        }

        private void cmbGender_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = lblGender;
        }
        private void cmbGender_MouseClick(object sender, MouseEventArgs e)
        {
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.ForeColor = Color.Black;
            cmbGender.DroppedDown = true;
        }
        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                cmbGender.ForeColor = SystemColors.WindowText;
            }
        }
        private void cmbGender_DropDownClosed(object sender, EventArgs e)
        {

            if (cmbGender.SelectedIndex == -1)
            {
                this.ActiveControl = lblGender;
                setGenderPlaceHolder();
            }
        }
    }
}
