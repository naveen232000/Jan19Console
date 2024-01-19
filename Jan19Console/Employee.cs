using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Jan19Console
{
    public class Employee
    {
        static SqlConnection MyConnect()
        {
            SqlConnection connt = new SqlConnection("Data Source=LAPTOP-SG7H0DO8;Initial Catalog=Employee;Integrated Security=True;Encrypt=False");
            return connt;
        }
        public static void InsertData() {
            SqlConnection c = MyConnect();
            c.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = c;
            command.CommandType = CommandType.Text;
            command.CommandText = "insert into EmployeeDetails values (108,'Das',4545,'hyd')";
            try { 
                command.ExecuteNonQuery();
                Console.WriteLine("Done");
            } 
            catch(Exception ex) { 
                Console.WriteLine(ex.Message); 
            }
            c.Close();
        }
        public static void GetData() {
            SqlConnection c = MyConnect();
            c.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = c;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from EmployeeDetails";
            //command.CommandText = "sp_help Employee";
            try
            {
                SqlDataReader reader = command.ExecuteReader();
          
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string empid = reader[0].ToString(); 
                        string empName = reader[1].ToString();
                        string salary = reader[2].ToString();
                        string city = reader[3].ToString();
                        string sysid = reader[4].ToString();
                  
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", empid, empName, salary, city, sysid);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DisplaySet()
        {
            try {
                SqlConnection c = MyConnect();
                SqlCommand cmd = new SqlCommand("select * from employeedetails", c);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds, "empDs");
                DataTable dt = ds.Tables["empDs"];
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine($"{dr[0]}\t{dr[1]}\t{dr[2]}\t{dr[3]}\t{dr[4]}");
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }           
        }
    }
}
