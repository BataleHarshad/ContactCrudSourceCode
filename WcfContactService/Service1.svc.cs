using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Hosting;
using System.IO;
using System.Configuration;
namespace WcfContactService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    
    public class Service1 : IService1
    {
        

        public List<ContactModel> GetContactList()
        {
            List<ContactModel> ContactList = new List<ContactModel>();    
            try
            {
                string RetVal = string.Empty;
                SqlConnection lSQLConn = null;
                SqlCommand lSQLCmd = new SqlCommand();
                string connStr = "";
                DataSet dt1 = new DataSet();
                connStr =ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;
    
                ParameterCollection pColl = new ParameterCollection();
                pColl.Clear();
                lSQLConn = new SqlConnection(connStr);
                lSQLConn.Open();
                //The CommandType must be StoredProcedure if we are using an ExecuteScalar
                lSQLCmd.CommandType = CommandType.StoredProcedure;
                lSQLCmd.CommandText = "GetContactList";
                //lSQLCmd.Parameters.Add(pColl);
                lSQLCmd.Connection = lSQLConn;
                DataTable dt = new DataTable(); 
                SqlDataAdapter sda = new SqlDataAdapter(lSQLCmd);
                sda.Fill(dt);
                lSQLCmd.Connection.Close();
                foreach (DataRow dr in dt.Rows)
                {

                    ContactList.Add(
                        new ContactModel
                        {

                            Id = Convert.ToInt32(dr["Id"]),
                            FName = Convert.ToString(dr["FName"]),
                            LName = Convert.ToString(dr["LName"]),
                            EmailId = Convert.ToString(dr["EmailId"]),
                            Status = Convert.ToString(dr["Status"])
                        }

                        );
                }    
  

                return ContactList;
            }
            catch (Exception ex)
            {
                return ContactList;
            }
        }
        public string AddContact(string FName,string LName,string EmailId,string Status )
        {
            try
            {
                string RetVal = string.Empty;
                SqlConnection lSQLConn = null;
                SqlCommand lSQLCmd = new SqlCommand();
                string connStr = "";
                DataSet dt1 = new DataSet();
                connStr = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;

                lSQLConn = new SqlConnection(connStr);
                lSQLConn.Open();
                //The CommandType must be StoredProcedure if we are using an ExecuteScalar
                lSQLCmd.CommandType = CommandType.StoredProcedure;
                lSQLCmd.CommandText = "InsertContact";
                lSQLCmd.Parameters.AddWithValue("@FName", FName);
                lSQLCmd.Parameters.AddWithValue("@LName", LName);
                lSQLCmd.Parameters.AddWithValue("@EmailId", EmailId);
                lSQLCmd.Parameters.AddWithValue("@Status", Status);

                lSQLCmd.Connection = lSQLConn;
                RetVal =Convert.ToString( lSQLCmd.ExecuteNonQuery());
                return RetVal;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public string UpateContact(int Id, string FName, string LName, string EmailId, string Status)
        {
            try
            {
                string RetVal = string.Empty;
                SqlConnection lSQLConn = null;
                SqlCommand lSQLCmd = new SqlCommand();
                string connStr = "";
                DataSet dt1 = new DataSet();
                connStr = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;

                lSQLConn = new SqlConnection(connStr);
                lSQLConn.Open();
                //The CommandType must be StoredProcedure if we are using an ExecuteScalar
                lSQLCmd.CommandType = CommandType.StoredProcedure;
                lSQLCmd.CommandText = "UpdateContact";
                lSQLCmd.Parameters.AddWithValue("@Id", Id);
                lSQLCmd.Parameters.AddWithValue("@FName", FName);
                lSQLCmd.Parameters.AddWithValue("@LName", LName);
                lSQLCmd.Parameters.AddWithValue("@EmailId", EmailId);
                lSQLCmd.Parameters.AddWithValue("@Status", Status);

                lSQLCmd.Connection = lSQLConn;
                RetVal = Convert.ToString(lSQLCmd.ExecuteNonQuery());
                return RetVal;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public string DeleteContact(int Id)
        {
            try
            {
                string RetVal = string.Empty;
                SqlConnection lSQLConn = null;
                SqlCommand lSQLCmd = new SqlCommand();
                string connStr = "";
                DataSet dt1 = new DataSet();
                connStr = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;

                lSQLConn = new SqlConnection(connStr);
                lSQLConn.Open();
                //The CommandType must be StoredProcedure if we are using an ExecuteScalar
                lSQLCmd.CommandType = CommandType.StoredProcedure;
                lSQLCmd.CommandText = "DeleteContact";
                lSQLCmd.Parameters.AddWithValue("@Id", Id);
                lSQLCmd.Connection = lSQLConn;
                RetVal = Convert.ToString(lSQLCmd.ExecuteNonQuery());
                return RetVal;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
