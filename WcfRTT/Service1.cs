using RTTProjectWCF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfRTT
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    { 
        //CONNECTION
        public Service1()
    {

        ConnectToDb();

    }
        SqlConnection conn;
        SqlCommand comm;

        SqlConnectionStringBuilder connStringBuilder;


        void ConnectToDb()
        {
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "BOOTCAMP23\\SQLEXPRESS"; //SERVER NAME
            connStringBuilder.InitialCatalog = "RTTEmployees"; //DATABASE NAME
            connStringBuilder.Encrypt = true;
            connStringBuilder.TrustServerCertificate = true;
            connStringBuilder.ConnectTimeout = 30;
            connStringBuilder.AsynchronousProcessing = true;
            connStringBuilder.MultipleActiveResultSets = true;
            connStringBuilder.IntegratedSecurity = true;


            conn = new SqlConnection(connStringBuilder.ToString());
            comm = conn.CreateCommand();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        //=============INSERT EMPLOYEE======================
       public int InsertEmployee(Employee e)
        {
            try
            {
                comm.CommandText = "INSERT INTO Employees VALUES(@name,@surname,@email,@resAddress,@workAddress,@postAddress,@cellNum,@workNum)";
                comm.Parameters.AddWithValue("name", e.name);
                comm.Parameters.AddWithValue("surname", e.surname);
                comm.Parameters.AddWithValue("email", e.email);
                comm.Parameters.AddWithValue("resAddress", e.resAddress);
                comm.Parameters.AddWithValue("workAddress", e.workAddress);
                comm.Parameters.AddWithValue("postAddress", e.postAddress);
                comm.Parameters.AddWithValue("cellNum", e.cellNum);
                comm.Parameters.AddWithValue("workNum", e.workNum);
                comm.CommandType = CommandType.Text;
                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
               if (conn != null )
                {
                    conn.Close();
                }

            }


        }
        //==============================GET ALL EMPLOYEES===========
        public List<Employee> GetEmployee()
        {

            List<Employee> employeeE = new List<Employee>();

            try
            {
                comm.CommandText = "SELECT * FROM Employees";
                comm.CommandType = CommandType.Text;

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee()
                    {
                        empId = Convert.ToInt32(reader[0]),
                        name = reader[1].ToString(),
                        surname = reader[2].ToString(),
                        email = reader[3].ToString(),
                        resAddress = reader[4].ToString(),
                        workAddress = reader[5].ToString(),
                        postAddress = reader[6].ToString(),
                        cellNum = reader[7].ToString(),
                        workNum = reader[8].ToString()
                    };
                    employeeE.Add(employee);
                }

                return employeeE;
            }
            catch(Exception)
            {

                throw;
            }

            finally
            {
                if(conn != null )
                {
                    conn.Close();
                }
            }
        }

        public int UpdateEmployee(Employee e)
        {

            try
            {
                comm.CommandText = "UPDATE Employees SET name = @name,surname = @surname,email = @email,resAddress = @resAddress,workAddress = @workAddress,postAddress= @postAddress,cellNum= @cellNum,workNum= @workNum WHERE name= @name";
                //comm.Parameters.AddWithValue("empId", e.empId);
                comm.Parameters.AddWithValue("@name", e.name);
                comm.Parameters.AddWithValue("@surname", e.surname);
                comm.Parameters.AddWithValue("@email", e.email);
                comm.Parameters.AddWithValue("@resAddress", e.resAddress);
                comm.Parameters.AddWithValue("@workAddress", e.workAddress);
                comm.Parameters.AddWithValue("@postAddress", e.postAddress);
                comm.Parameters.AddWithValue("@cellNum", e.cellNum);
                comm.Parameters.AddWithValue("@workNum", e.workNum);
                comm.CommandType = CommandType.Text;
                conn.Open();


                return comm.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }

        }

        public int DeleteEmployee(Employee e)
        {

            try
            {
                comm.CommandText = "DELETE FROM Employees WHERE empId=@empId";
                comm.Parameters.AddWithValue("empId", e.empId);
                comm.CommandType = CommandType.Text;
                conn.Open();


                return comm.ExecuteNonQuery();
            }
            catch(Exception)

            {
                throw;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }



        }

    }
}
