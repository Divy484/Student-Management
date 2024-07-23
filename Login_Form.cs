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
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("D:\\College\\4th Sem\\ADT (Application Development Tools)\\ADT Project\\images\\login.png");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();
            SqlDataAdapter ad = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username = @usn AND password = @pass",db.GetConnection);

            cmd.Parameters.Add("@usn",SqlDbType.NVarChar).Value = textBoxUsername.Text;
            cmd.Parameters.Add("@pass",SqlDbType.NVarChar).Value = textBoxPassword.Text;

            ad.SelectCommand = cmd;

            ad.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            
            else
            {
                MessageBox.Show("Invalid Username or Password.","Login Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
