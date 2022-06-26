using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core_App.Models
{
    public class CourseDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;


        public CourseDAL()
        {
            con = new System.Data.SqlClient.SqlConnection(Startup.ConnectionString);
        }
        public List<Course> GetAllCourse()
        {
            List<Course> list = new List<Course>();
            String str = "Select * from Employee";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                  Course C= new Course();
                    C.Id = Convert.ToInt32(dr["Id"]);
                    C.Name = dr["Name"].ToString();
                    C.Fees = Convert.ToDecimal(dr["Fees"]);
                    list.Add(C);
                }
                con.Close();
                return list;
            }
            else
            {

                return null;
            }
        }

        internal int Save(Employee e)
        {
            throw new NotImplementedException();
        }

        public Course GetCourseById(int id)
        {
            Course C=new Course();
            string str = "select * from Course where Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    C.Id = Convert.ToInt32(dr["Id"]);
                    C.Name = dr["Name"].ToString();
                    C.Fees = Convert.ToDecimal(dr["Fees"]);

                }
                con.Close();
                return C;
            }
            else
            {
                con.Close();
                return C;
            }


            return null;
        }

        internal int Update(Employee e)
        {
            throw new NotImplementedException();
        }

        internal Employee GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(Course c)
        {
            string str = "insert into course values(@name,@price)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", c.Name);
            cmd.Parameters.AddWithValue("@price", c.Fees);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;


        }
        public int Update(Course c)
        {
            string str = "update Course set Name=@name,Price=@price where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", c.Id);
            cmd.Parameters.AddWithValue("@name",c.Name);
            cmd.Parameters.AddWithValue("@price", c.Fees);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;


        }

        public int Delete(int id)
        {
            string str = "delete from Course where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }

    }
}

    


    

