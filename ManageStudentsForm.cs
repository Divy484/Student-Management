using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADT_Project
{
    public partial class ManageStudentsForm : Form
    {
        public ManageStudentsForm()
        {
            InitializeComponent();
        }

        STUDENT student = new STUDENT();

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ManageStudentsForm_Load(object sender, EventArgs e)
        {
            fillGrid(new SqlCommand("SELECT * FROM student"));
        }

        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DataSource = student.getStudents(command);
            dataGridView1.AllowUserToAddRows = false;

            labelTotalStudents.Text = "Total Students : " + dataGridView1.Rows.Count;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxLname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxEnroll.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            
            dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;

            if(dataGridView1.CurrentRow.Cells[5].Value.ToString() == "Female")
            {
                radioFemale.Checked = true;
            }
            else
            {
                radioMale.Checked = true;
            }
            textBoxPhone.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBoxAddress.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxFname.Text = "";
            textBoxLname.Text = "";
            textBoxEnroll.Text = "";
            textBoxPhone.Text = "";
            textBoxAddress.Text = "";
            radioMale.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM student WHERE CONCAT(id, first_name, last_name, enrollment, address) LIKE '%" + textBoxSearch.Text + "%' ";
            SqlCommand command = new SqlCommand(query);
            fillGrid(command);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            STUDENT s = new STUDENT();
            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            string enrollment = textBoxEnroll.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = textBoxPhone.Text;
            string address = textBoxAddress.Text;
            string gender = "Male";

            if (radioFemale.Checked)
            {
                gender = "Female";
            }

            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;

            if (((this_year - born_year) < 10 || ((this_year - born_year) > 100)))
            {
                MessageBox.Show("The Student Age Must be between 10 an 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (verify())
            {
                if (s.insertStudent(fname, lname, enrollment, bdate, phone, gender, address))
                {
                    MessageBox.Show("New Student added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillGrid(new SqlCommand("SELECT * FROM student"));
                }
                else
                {
                    MessageBox.Show("Error", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                string fname = textBoxFname.Text;
                string lname = textBoxLname.Text;
                string enrollment = textBoxEnroll.Text;
                DateTime bdate = dateTimePicker1.Value;
                string phone = textBoxPhone.Text;
                string address = textBoxAddress.Text;
                string gender = "Male";

                if (radioFemale.Checked)
                {
                    gender = "Female";
                }

                int born_year = dateTimePicker1.Value.Year;
                int this_year = DateTime.Now.Year;

                if (((this_year - born_year) < 10 || ((this_year - born_year) > 100)))
                {
                    MessageBox.Show("The Student Age Must be between 10 an 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (verify())
                {
                    if (student.updateStudent(id, fname, lname, enrollment, bdate, phone, gender, address))
                    {
                        MessageBox.Show("Student information updated", "Edit Student info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillGrid(new SqlCommand("SELECT * FROM student"));
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Student info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    MessageBox.Show("Empty Fields", "Edit Student info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Please Enter a valid Student id", "Edit Student info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                if (MessageBox.Show("Are you sure you want to delete this student information??", "Delete Student info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (student.deleteStudent(id))
                    {
                        MessageBox.Show("Student Information deleted", "Delete Student info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxID.Text = "";
                        textBoxFname.Text = "";
                        textBoxLname.Text = "";
                        textBoxEnroll.Text = "";
                        textBoxPhone.Text = "";
                        textBoxAddress.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                    }
                    else
                    {
                        MessageBox.Show("Student information not deleted", "Delete Student info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter a valid Student id", "Delete Student info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool verify()
        {
            if ((textBoxFname.Text.Trim() == "") ||
                (textBoxLname.Text.Trim() == "") ||
                (textBoxEnroll.Text.Trim() == "") ||
                (textBoxPhone.Text.Trim() == "") ||
                (textBoxAddress.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
