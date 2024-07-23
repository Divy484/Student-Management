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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm add = new AddStudentForm();
            add.Show(this);
        }

        private void studentsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            studentsListForm stli = new studentsListForm();
            stli.Show(this);
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm upDelStF = new UpdateDeleteStudentForm();
            upDelStF.Show(this);
        }

        private void manageStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudentsForm mngStdF = new ManageStudentsForm();
            mngStdF.Show(this);
        }

        private void mARKSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void removeMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
