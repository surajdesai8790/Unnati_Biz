using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;


namespace BAL
{
   public class CommonFunctions
    {
       /// <summary>
       
       /// </summary>
       /// 
       public string conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBCON"].ToString();
       public int _strrecordExsit;
       SqlDataAdapter da = new SqlDataAdapter();
       
       /// <summary>
       /// Function to insert record into Databse
       /// </summary>
       /// <param name="SpName"> Stored procedure name to insert record</param>
       /// <param name="param"> Parameters array to insert records.</param>
       /// <returns></returns>
       /// 
       public int IsExist(string tablename,string whereCondition)
       {
           DataTable Dt = new DataTable();
           SqlConnection con = new SqlConnection(conString);
           con.Open();
           SqlCommand cmd = new SqlCommand("select count(0) from "+ tablename + "  where  " + whereCondition +" ",con);
           da = new SqlDataAdapter(cmd);
           da.Fill(Dt);
           con.Close();
           if (Dt.Rows.Count > 0)
           {
               _strrecordExsit =Convert.ToInt32 ( Dt.Rows[0][0].ToString());
           }
           else {
               _strrecordExsit = 0;
           }
           return _strrecordExsit;
           
       }

       public decimal CheckIsNull(string input)
       {
           decimal output;
           if (input == "")
           {
               output = Convert.ToDecimal(0.00);
           }
           else
           {
               output = Convert.ToDecimal(input);
           }

           return output;
       }
       public void FillDropDownList(DropDownList ddl,string valuefield,string textfield,string tablename,string where )
       {
           SqlConnection con = new SqlConnection(conString);
           string query = "select  " + valuefield + " as valuefield , " + textfield + " as textfield from  " + tablename + "";
            if(where !="")
           {
               query += " where "+ where +"";
           }
            query += " order by " + textfield + " asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
                       con.Close();
                       if (dt.Rows.Count > 0)
                       {
                           ddl.DataSource = dt;
                           ddl.DataTextField = "textfield";
                           ddl.DataValueField = "valuefield";
                           ddl.DataBind();
                           ddl.Items.Insert(0, "Select");
                       }
                       else
                       {
                           ddl.DataSource = null;
                           ddl.DataBind();
                           ddl.Items.Insert(0, "Select");
                       }
           
       }
       public int InsertRecord(string SpName, object[] param)
       {
           SqlConnection con = new SqlConnection(conString);
           try
           {
               
               con.Open();
               SqlCommand cmd = new SqlCommand(SpName);
               cmd.CommandType = CommandType.StoredProcedure;

               if (param != null)
               {
                   for (int i = 0; i < param.Length; i++)
                   {
                       cmd.Parameters.Add(param[i]);
                   }

               }


               cmd.Connection = con;
               int count =cmd.ExecuteNonQuery();
               return count;



           }
           catch (Exception)
           {

               throw;
           }
           finally
           {
               con.Close();
               con.Dispose();

           }

       }

       /// <summary>
       /// Function to update records in database
       /// </summary>
       /// <param name="SpName"> Stored procedure name to update records.</param>
       /// <param name="param">Parameter array to update records</param>
       /// <returns></returns>
       public int UpdateRecord(string SpName, object[] param)
       {
           SqlConnection con = new SqlConnection(conString);
           try
           {

               con.Open();
               SqlCommand cmd = new SqlCommand(SpName);
               cmd.CommandType = CommandType.StoredProcedure;

               if (param != null)
               {
                   for (int i = 0; i < param.Length; i++)
                   {
                       cmd.Parameters.Add(param[i]);
                   }

               }


               cmd.Connection = con;
               int count = cmd.ExecuteNonQuery();
               return count;



           }
           catch (Exception)
           {

               throw;
           }
           finally
           {
               con.Close();
               con.Dispose();

           }

       }

       /// <summary>
       /// Function to Delete record from database.
       /// </summary>
       /// <param name="SpName"> Stored procedure name to delete</param>
       /// <param name="param">Parameter array to pass sp</param>
       /// <returns></returns>
       public int DeleteRecord(string SpName, object[] param)
       {
           SqlConnection con = new SqlConnection(conString);
           try
           {

               con.Open();
               SqlCommand cmd = new SqlCommand(SpName);
               cmd.CommandType = CommandType.StoredProcedure;

               if (param != null)
               {
                   for (int i = 0; i < param.Length; i++)
                   {
                       cmd.Parameters.Add(param[i]);
                   }

               }


               cmd.Connection = con;
               int count = cmd.ExecuteNonQuery();
               return count;



           }
           catch (Exception)
           {

               throw;
           }
           finally
           {
               con.Close();
               con.Dispose();

           }

       }
       

       /// <summary>
       /// function to retrive DataTable from database
       /// </summary>
       /// <param name="SpName"></param>
       /// <param name="param"></param>
       /// <returns></returns>
       public DataTable SelectRecords(string SpName, object[] param)
       {
           SqlConnection con = new SqlConnection(conString);
           try
           {

               con.Open();
               SqlCommand cmd = new SqlCommand(SpName);
               cmd.CommandType = CommandType.StoredProcedure;

               if (param != null)
               {
                   for (int i = 0; i < param.Length; i++)
                   {
                       cmd.Parameters.Add(param[i]);
                   }

               }

               cmd.Connection = con;

               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataTable dt = new DataTable();

               da.Fill(dt);


               con.Close();

               return dt;

           }
           catch (Exception)
           {

               throw;
           }
           finally
           {
               con.Close();
               con.Dispose();

           }

       }

       public DataSet  SelectRecordsDS(string SpName, object[] param)
       {
           SqlConnection con = new SqlConnection(conString);
           try
           {

               con.Open();
               SqlCommand cmd = new SqlCommand(SpName);
               cmd.CommandType = CommandType.StoredProcedure;

               if (param != null)
               {
                   for (int i = 0; i < param.Length; i++)
                   {
                       cmd.Parameters.Add(param[i]);
                   }

               }

               cmd.Connection = con;

               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataSet dt = new DataSet();

               da.Fill(dt);


               con.Close();

               return dt;

           }
           catch (Exception)
           {

               throw;
           }
           finally
           {
               con.Close();
               con.Dispose();

           }

       }

       //public string GetSerialNumber()
       //{
       //    Guid serialGuid = Guid.NewGuid();
       //    string uniqueSerial = serialGuid.ToString("N");

       //    string uniqueSerialLength = uniqueSerial.Substring(0, 24).ToUpper();

       //    char[] serialArray = uniqueSerialLength.ToCharArray();
       //    string finalSerialNumber = "";

       //    int j = 0;
       //    for (int i = 0; i < 24; i++)
       //    {
       //        for (j = i; j < 4 + i; j++)
       //        {
       //            finalSerialNumber += serialArray[j];
       //        }
       //        if (j == 24)
       //        {
       //            break;
       //        }
       //        else
       //        {
       //            i = (j) - 1;
       //            finalSerialNumber += "-";
       //        }
       //    }

          


       //    //Get host name and Ip Address
       //    string hostName = Dns.GetHostName();
       //    string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

       //    StreamWriter writer = new StreamWriter(Application.StartupPath  + "\\SerialKey.txt", true);
       //    writer.WriteLine("=================================================");
       //    writer.WriteLine("Your Serial Key Code For Application Is: ");
       //    writer.WriteLine("Key         : " + finalSerialNumber);
       //    writer.WriteLine("IP Address         : " + myIP);
       //    writer.WriteLine("=================================================");
       //    writer.Close();

       //    return finalSerialNumber;
       //}


       public bool LogException(string Page, string FunctionName, string Exception, string logPath)
       {
           try
           {
               //How to Call Function 
               // CommonFunctions cf = new CommonFunctions();
               // cf.LogException("Form Name", "Function Name", "" + ex.Message, Application.StartupPath + "\\LogFile.txt");

               StreamWriter writer = new StreamWriter(logPath, true);
               writer.WriteLine("Date         : " + DateTime.Now.ToString("f"));
               writer.WriteLine("Page         : " + Page);
               writer.WriteLine("FunctionName : " + FunctionName);
               writer.Write("Exception    : " + Exception);
               writer.WriteLine("");
               writer.WriteLine("===================================");
               writer.Close();
               return true;
           }
           catch
           {
               return false;
           }
       }
    }
}
