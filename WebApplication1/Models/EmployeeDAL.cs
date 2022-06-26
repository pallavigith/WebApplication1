using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core_App.Models
{
    public class EmployeeDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;


        public EmployeeDAL()
        {
            con = new System.Data.SqlClient.SqlConnection(Startup.ConnectionString);
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> list = new List<Employee>();
            String str = "Select * from Employee";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                   Employee E = new Employee();
                    E.Id = Convert.ToInt32(dr["Id"]);
                    E.Name = dr["Name"].ToString();
                    E.Salary= Convert.ToDecimal(dr["Salary"]);
                    list.Add(E);
                }
                con.Close();
                return list;
            }
            else
            {

                return null;
            }
        }
        public Employee GetEmployeeById(int id)
        {
            Employee E = new Employee();
            string str = "select * from Employee where Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    E.Id = Convert.ToInt32(dr["Id"]);
                    E.Name = dr["Name"].ToString();
                    E.Salary = Convert.ToDecimal(dr["Salary"]);

                }
                con.Close();
                return E;
            }
            else
            {
                con.Close();
                return E;
            }


            return null;
        }
        public int Save(Employee E)
        {
            string str = "insert into Employee values(@name,@price)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", E.Name);
            cmd.Parameters.AddWithValue("@price", E.Salary);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

         
        }
        public int Update(Employee E)
        {
            string str = "update Employee set Name=@name,Price=@price where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", E.Id);
            cmd.Parameters.AddWithValue("@name", E.Name);
            cmd.Parameters.AddWithValue("@price", E.Salary);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;


        }

        public int Delete(int id)
        {
            string str = "delete from Employee where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }

    }
}

    

