using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Windows.Forms.AxHost;
using System.Net;
using System.Xml.Linq;

namespace ADT_Project
{
    internal class STUDENT
    {
        MY_DB db = new MY_DB();
        public bool insertStudent(string fname, string lname, string enrollment, DateTime bdate, string phone, string gender, string address)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO student (first_name, last_name, enrollment, birthdate, gender, phone, address) VALUES (@fn, @ln, @enr, @bdt, @gdr, @phn, @add)", db.GetConnection);

            //@fn, @ln, @enr, @bdt, @gdr, @phn, @add

            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@enr", SqlDbType.VarChar).Value = enrollment;
            cmd.Parameters.Add("@bdt", SqlDbType.Date).Value = bdate;
            cmd.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            cmd.Parameters.Add("@add", SqlDbType.Text).Value = address;

            db.openConnection();

            if(cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool updateStudent(int id, string fname, string lname, string enrollment, DateTime bdate, string phone, string gender, string address)
        {
            SqlCommand cmd = new SqlCommand("UPDATE student SET first_name = @fn, last_name = @ln, enrollment = @enr, birthdate = @bdt, gender = @gdr, phone = @phn, address = @add WHERE id = @ID", db.GetConnection);

            //@ID, @fn, @ln, @enr, @bdt, @gdr, @phn, @add

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@enr", SqlDbType.VarChar).Value = enrollment;
            cmd.Parameters.Add("@bdt", SqlDbType.Date).Value = bdate;
            cmd.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            cmd.Parameters.Add("@add", SqlDbType.Text).Value = address;

            db.openConnection();

            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }


        public bool deleteStudent(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM student WHERE id = @studentID", db.GetConnection);

            //@studentID

            cmd.Parameters.Add("@studentID", SqlDbType.Int).Value = id;

            db.openConnection();

            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public DataTable getStudents(SqlCommand command)
        {
            command.Connection = db.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
    }
}
