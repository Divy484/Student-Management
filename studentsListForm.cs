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
    public partial class studentsListForm : Form
    { 
        STUDENT student = new STUDENT();
        public studentsListForm()
        {
            InitializeComponent();
        }


        private void studentsListForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM student");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DataSource = student.getStudents(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDeleteStudentForm updateDeleteStdF = new UpdateDeleteStudentForm();
            updateDeleteStdF.textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateDeleteStdF.textBoxFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateDeleteStdF.textBoxLname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            updateDeleteStdF.textBoxEnroll.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            updateDeleteStdF.dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;

            if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "Female")
            {
                updateDeleteStdF.radioFemale.Checked = true;
            }
            updateDeleteStdF.textBoxPhone.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();    
            updateDeleteStdF.textBoxAddress.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            updateDeleteStdF.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM student");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DataSource = student.getStudents(command);
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
