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
            foreach (var studentData in DataAccessLayer.studentList)
            {
                //dataGridView.Rows.Add(studentData);
                string[] stdData = new string[6];
                for (int i = 0; i < 6; i++)
                {
                    stdData[i] = studentData[i];
                }
                dataGridView.Rows.Add(stdData);
            }
        }

        public int rowIndex;
        public bool deleteVisible = false;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditForm addEditForm = new AddEditForm();
            addEditForm.setMain(this);

            addEditForm.StudentHeaderText = "Add Students";
            addEditForm.ShowDialog();
            RefreshDataGridView();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            string id;
            if (rowIndex >= 0)
            {
                AddEditForm addEditForm = new AddEditForm();
                addEditForm.setMain(this);
                id = dataGridView.Rows[rowIndex].Cells[0].Value.ToString();
                for (int i = 0; i < DataAccessLayer.studentList.Count; i++)
                {
                    if (DataAccessLayer.studentList[i][0] == id) rowIndex = i;
                }
                addEditForm.StudentHeaderText = "Edit Students";
                addEditForm.LoadData();
                deleteVisible = true;
                addEditForm.ShowDialog();
                RefreshDataGridView();
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
                    stdAgeCellData = stdAgeCellData.Substring(0, 2).Trim();

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
            // Populating data with two rows
            dataGridView.Columns.Add("StudentId", "StudentId");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns.Add("First Name", "First Name");
            dataGridView.Columns.Add("Last Name", "Last Name");
            dataGridView.Columns.Add("Gender", "Gender");
            dataGridView.Columns.Add("Age", "Age");
            dataGridView.Columns.Add("Class", "Class");

            int columnWidth = 223;
            dataGridView.Columns[1].Width = columnWidth;
            dataGridView.Columns[2].Width = columnWidth;
            dataGridView.Columns[3].Width = columnWidth;
            dataGridView.Columns[4].Width = columnWidth;
            dataGridView.Columns[5].Width = columnWidth;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dataGridView.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13);

            DataAccessLayer dataAccessLayer = new DataAccessLayer();
            dataAccessLayer.defaultStudents();
            RefreshDataGridView();
            dataGridView.Rows[0].Selected = true;
            txtSearch.MaxLength = 30;
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