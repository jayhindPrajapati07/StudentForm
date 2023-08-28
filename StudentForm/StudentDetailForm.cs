using System.Linq;
using System.Windows.Forms;

namespace StudentForm
{
    public partial class StudentDetailForm : Form
    {
        public StudentDetailForm()
        {
            InitializeComponent();
        }

        private void RefreshDataGridView()
        {
            dataGridView.Rows.Clear();
            foreach (var studentData in DataLayer.studentList)
            {
                string[] stdData = new string[6];
                Array.Copy(studentData, stdData, 6);
                dataGridView.Rows.Add(stdData);
            }
        }

        internal int Id;
        internal string action;
        internal bool refreshRequired;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditForm addEditForm = new AddEditForm();
            addEditForm.setMain(this);
            action = "Add";
            addEditForm.StudentHeaderText = "Add Students";
            addEditForm.ShowDialog();
            if(refreshRequired) { RefreshDataGridView(); }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = e.RowIndex;
            string id;
            if (Id >= 0)
            {
                AddEditForm addEditForm = new AddEditForm();
                addEditForm.setMain(this);
                id = dataGridView.Rows[Id].Cells[0].Value.ToString();
                for (int i = 0; i < DataLayer.studentList.Count; i++)
                {
                    if (DataLayer.studentList[i][0] == id) { Id = i; break; };
                }
                action = "Edit";
                addEditForm.StudentHeaderText = "Edit Students";
                addEditForm.LoadData();
                addEditForm.ShowDialog();
                if (refreshRequired) { RefreshDataGridView(); }
            }
        }

        //Search Functionality
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string SearchText = txtSearch.Text.ToLower().Trim();
            if (string.IsNullOrEmpty(SearchText))
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    dataGridView.Rows[i].Visible = true;
                }
            }
            else
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    string stdFirstNameCellData = dataGridView.Rows[i].Cells[1].Value.ToString().ToLower();
                    string stdLastNameCellData = dataGridView.Rows[i].Cells[2].Value.ToString().ToLower();
                    string stdAgeCellData = dataGridView.Rows[i].Cells[4].Value.ToString();
                    stdAgeCellData = stdAgeCellData[..2].Trim();

                    if (stdFirstNameCellData.Contains(SearchText) || stdLastNameCellData.Contains(SearchText) || stdAgeCellData.Contains(SearchText))
                    {
                        dataGridView.Rows[i].Visible = true;
                        continue;
                    }
                    else
                    {
                        dataGridView.Rows[i].Visible = false;
                        continue;
                    }
                }
            }
        }
        private void StudentDetailForm_Load(object sender, EventArgs e)
        {
            dataGridView.Columns.Add("StudentId", "StudentId");
            dataGridView.Columns.Add("First Name", "First Name");
            dataGridView.Columns.Add("Last Name", "Last Name");
            dataGridView.Columns.Add("Gender", "Gender");
            dataGridView.Columns.Add("Age", "Age");
            dataGridView.Columns.Add("Class", "Class");

            int columnWidth = 223;
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].Width = columnWidth;
            dataGridView.Columns[2].Width = columnWidth;
            dataGridView.Columns[3].Width = columnWidth;
            dataGridView.Columns[4].Width = columnWidth;
            dataGridView.Columns[5].Width = columnWidth;

            setDefaultLayout();

            DataLayer dataLayer = new DataLayer();
            dataLayer.defaultStudents();
            RefreshDataGridView();
            dataGridView.Rows[0].Selected = true;
            txtSearch.MaxLength = 30;
        }

        private void setDefaultLayout()
        {
            Fonts fonts = new Fonts();
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = fonts.selectionForeColor;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = fonts.selectionColor;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(fonts.mediumFont, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = fonts.selectionColor;
            dataGridView.DefaultCellStyle.Font = fonts.mediumFont;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridView.DefaultCellStyle;
            lblStudentHeader.Font = fonts.LargeFont;
            btnAdd.Font = fonts.mediumFont;
            btnAdd.BackColor = fonts.btnPrimary;
            txtSearch.Font = fonts.mediumFont;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}