using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADT_Project
{
    public partial class UpdateDeleteStudentForm : Form
    {
        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
        }
 
        STUDENT s = new STUDENT();
       
        private void UpdateDeleteStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void textBoxLname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void buttonEditStudent_Click(object sender, EventArgs e)
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
                    if (s.updateStudent(id, fname, lname, enrollment, bdate, phone, gender, address))
                    {
                        MessageBox.Show("Student information updated", "Edit Student info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (s.deleteStudent(id))
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
            }catch
            {
                MessageBox.Show("Please Enter a valid Student id", "Delete Student info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                SqlCommand command = new SqlCommand("SELECT id, first_name, last_name, enrollment, birthdate, gender, phone, address FROM student WHERE id ="+id);

                DataTable table = s.getStudents(command);

                if (table.Rows.Count > 0)
                {
                    textBoxFname.Text = table.Rows[0]["first_name"].ToString();
                    textBoxLname.Text = table.Rows[0]["last_name"].ToString();
                    textBoxEnroll.Text = table.Rows[0]["enrollment"].ToString();
                    textBoxPhone.Text = table.Rows[0]["phone"].ToString();
                    textBoxAddress.Text = table.Rows[0]["address"].ToString();

                    dateTimePicker1.Value = (DateTime)table.Rows[0]["birthdate"];

                    if (table.Rows[0]["gender"].ToString() == "Female")
                    {
                        radioFemale.Checked = true;
                    }
                    else
                    {
                        radioMale.Checked = true;
                    }
                }
            }catch
            {
                MessageBox.Show("Enter a valid Student id","Invalid ID",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
