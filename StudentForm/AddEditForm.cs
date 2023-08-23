using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentForm
{
    public partial class AddEditForm : Form
    {
        public AddEditForm()
        {
            InitializeComponent();
        }

        StudentDetailForm studentDetailForm;
        public void setMain(StudentDetailForm studentDetailForm)
        {
            this.studentDetailForm = studentDetailForm;
        }
        public string StudentHeaderText;
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
            if (txtAge.Text.Trim() == "") { studentModel.Age = 0; } else { studentModel.Age = int.Parse(txtAge.Text); }
            studentModel.Class = txtClass.Text.Trim();
            studentModel.Address = textAreaAddress.Text.Trim();

            AddEditBuisnessLogic validator = new AddEditBuisnessLogic();
            //validator.setdataAccessLayer(dataAccessLayer);
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
            string action = studentDetailForm.action;
            if (action == "Add")
            {
                if (Validated)
                {
                    dataLayer.AddData();
                    Close();
                }
            }
            else
            {
                if (Validated)
                {
                    int index = studentDetailForm.rowIndex;
                    dataLayer.UpdateData(index);
                    Close();
                }
            }
        }

        public void LoadData()
        {
            int index = studentDetailForm.rowIndex;
            string[] DataToEdit = DataLayer.studentList[index];
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
            int index = studentDetailForm.rowIndex;
            var confirmResult = MessageBox.Show("Are you sure you want to delete this student record?", "Confirm Delete!!", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                DataLayer dataLayer = new DataLayer();
                dataLayer.DeleteData(index);
                Close();
            }
        }


        //Set Age from Date Of Birth
        private void dtDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            if (dtDateOfBirth.Text != "")
            {
                AddEditBuisnessLogic ageCalculator = new AddEditBuisnessLogic();
                int age;
                ageCalculator.ageCalc(dtDateOfBirth.Value, out age);
                txtAge.Text = age.ToString();
                if (txtAge.Text == "0") txtAge.Text = "";
            }
        }


        //Set Date Of Birth from Age
        private void txtAge_KeyUp(object sender, KeyEventArgs e)
        {
            AddEditBuisnessLogic dobCalculator = new AddEditBuisnessLogic();
            DateTime date;
            dobCalculator.dobCalc(txtAge.Text, out date);
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

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            var todaysDate = DateTime.Now.Date;
            dtDateOfBirth.MaxDate = todaysDate;
            dtDateOfBirth.MinDate = DateTime.Parse("1/1/" + (DateTime.Now.Date.Year - 100));
            lblStudentHeader.Text = StudentHeaderText;
            btnDelete.Visible = true;
            txtAge.MaxLength = 2;
            txtFirstName.MaxLength = 47;
            txtLastName.MaxLength = 47;
            txtClass.MaxLength = 47;
            textAreaAddress.MaxLength = 300;

            if (lblStudentHeader.Text == "Add Students")
            {
                dtDateOfBirth.Text = DateTime.Now.ToShortDateString();
                btnDelete.Visible = false;
                setGenderPlaceHolder();
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
