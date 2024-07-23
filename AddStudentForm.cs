using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADT_Project
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            STUDENT s = new STUDENT();
            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            string enrollment = textBoxEnroll.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = textBoxPhone.Text;
            string address = textBoxAddress.Text;
            string gender = "Male";

            if(radioButtonFemale.Checked)
            {
                gender = "Female";
            }

            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;

            if(((this_year - born_year) < 10 || ((this_year - born_year) > 100)))
            {
                MessageBox.Show("The Student Age Must be between 10 an 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (verify())
            {
                if(s.insertStudent(fname,lname,enrollment,bdate,phone,gender,address))
                {
                    MessageBox.Show("New Student added","Add Student",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

        //function for verify data
        bool verify()
        {
            if((textBoxFname.Text.Trim() == "") ||
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

        private void buttonCancelStudent_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
