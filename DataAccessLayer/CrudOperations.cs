using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CustomerObjects;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataAccessLayer
{
    public class CrudOperations
    {
        static string ConnectionStringInformation = ConfigurationManager.ConnectionStrings["CustomerDBConfig"].ConnectionString;

        public static int SaveEmployee(Customer customer)
        {
            //Step1
            SqlConnection con;
            con = new SqlConnection(ConnectionStringInformation);
            con.Open();

            //Step2
            SqlCommand cmd;
            cmd = new SqlCommand("spSaveCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@Name", customer.Name);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);

            //Step3
            int rowsAffected = cmd.ExecuteNonQuery();

            //step4
            cmd.Dispose();
            con.Close();

            //Step5
            return rowsAffected;
        }

        public static List<Customer> GetAllCustomers()
        {

            using (SqlConnection con = new SqlConnection(ConnectionStringInformation))
            {
                //Step1
                con.Open();

                //Step2
                SqlCommand cmd;
                cmd = new SqlCommand("spGetAllCustomers", con);
                cmd.CommandType=CommandType.StoredProcedure;    
                //Step3
                SqlDataReader dr = cmd.ExecuteReader();

               
                List<Customer> customers = new List<Customer>();

                while (dr.Read()) { 
                    Customer cust = new Customer()
                    {
                        ID = Convert.ToInt16(dr["ID"]),
                        Name = dr["Name"].ToString(),
                        City = dr["City"].ToString(),
                        PhoneNumber = dr["PhoneNumber"].ToString()
                    };

                    customers.Add(cust); 

                } 

                
                return customers;

            } 

        }
        
        public static int UpdateCustomer(Customer CustomerNeededtobeUpdated)
        {
            using (SqlConnection con = new SqlConnection(ConnectionStringInformation))
            {
                //Step1
                con.Open();

                //Step2
                SqlCommand cmd;
                cmd = new SqlCommand("spUpdateCustomer", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", CustomerNeededtobeUpdated.ID);
                cmd.Parameters.AddWithValue("@Name", CustomerNeededtobeUpdated.Name);
                cmd.Parameters.AddWithValue("@City", CustomerNeededtobeUpdated.City);
                cmd.Parameters.AddWithValue("@PhoneNumber", CustomerNeededtobeUpdated.PhoneNumber);

                //Step3
                int rowsAffected = cmd.ExecuteNonQuery();

                //Step4
                return rowsAffected;

            } //using

        } //UpdateC

        public static int UpdateByAttrCustomer(string colname,string colvalue,int Id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionStringInformation))
            {
                //Step1
                con.Open();

                //Step2
                SqlCommand cmd;
                cmd = new SqlCommand("spUpdateByAttrCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@colname", colname);
                cmd.Parameters.AddWithValue("@value", colvalue);
                cmd.Parameters.AddWithValue("@id", Id);
                

                //Step3
                int rowsAffected = cmd.ExecuteNonQuery();

                //Step4
                return rowsAffected;

            } //using

        } //UpdateC
        public static int DeleteCustomer(int ID)
        {
            using (SqlConnection con = new SqlConnection(ConnectionStringInformation))
            {
                //Step1
                con.Open();

                //Step2
                SqlCommand cmd;
                cmd = new SqlCommand("spDeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;  
                cmd.Parameters.AddWithValue("@ID", ID);

                //Step3
                int rowsAffected = cmd.ExecuteNonQuery();

                //Step4
                return rowsAffected;

            } //using

        }
    }
}
