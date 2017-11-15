using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BAL
{
    public class BALCustomerMaster
    {
        CommonFunctions commonFunction = new CommonFunctions();

        public DataTable getCustomers(DALCustomerMaster dalCustomer)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[2];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = dalCustomer.Flag;
            SqlPara[1] = new SqlParameter("@CustomerId", DbType.String);
            SqlPara[1].Value = dalCustomer.CustomerId;
            Dt = commonFunction.SelectRecords("SELECT_CustomerMaster", SqlPara);
            return Dt;
        }

        public DataTable getStates(DALCustomerMaster dalCustomer)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[1];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = dalCustomer.Flag;

            Dt = commonFunction.SelectRecords("SELECT_StateMaster", SqlPara);
            return Dt;
        }

        public Int32 InsertCustomer(DALCustomerMaster dalCustomer)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[18];
            SqlPara[0] = new SqlParameter("@CustomerId", DbType.String);
            SqlPara[0].Value = dalCustomer.CustomerId;
            SqlPara[1] = new SqlParameter("@CustomerCode", DbType.String);
            SqlPara[1].Value = dalCustomer.CustomerCode;
            SqlPara[2] = new SqlParameter("@CustomerName", DbType.String);
            SqlPara[2].Value = dalCustomer.CustomerName;
            SqlPara[3] = new SqlParameter("@Address", DbType.String);
            SqlPara[3].Value = dalCustomer.Address;
            SqlPara[4] = new SqlParameter("@ContactNumber", DbType.String);
            SqlPara[4].Value = dalCustomer.ContactNumber;
            SqlPara[5] = new SqlParameter("@Email", DbType.String);
            SqlPara[5].Value = dalCustomer.Email;
            SqlPara[6] = new SqlParameter("@ContactPerson", DbType.String);
            SqlPara[6].Value = dalCustomer.ContactPerson;
            SqlPara[7] = new SqlParameter("@GSTIN", DbType.String);
            SqlPara[7].Value = dalCustomer.GSTIN;
            SqlPara[8] = new SqlParameter("@StateId", DbType.String);
            SqlPara[8].Value = dalCustomer.StateId;
            SqlPara[9] = new SqlParameter("@AccLedgerName", DbType.String);
            SqlPara[9].Value = dalCustomer.AccLedgerName;
            SqlPara[10] = new SqlParameter("@CreditDays", DbType.String);
            SqlPara[10].Value = dalCustomer.CreditDays;
            SqlPara[11] = new SqlParameter("@ECCno", DbType.String);
            SqlPara[11].Value = dalCustomer.ECCno;
            SqlPara[12] = new SqlParameter("@Range", DbType.String);
            SqlPara[12].Value = dalCustomer.Range;
            SqlPara[13] = new SqlParameter("@Division", DbType.String);
            SqlPara[13].Value = dalCustomer.Division;
            SqlPara[14] = new SqlParameter("@Collectorate", DbType.String);
            SqlPara[14].Value = dalCustomer.Collectorate;
            SqlPara[15] = new SqlParameter("@PartyType", DbType.String);
            SqlPara[15].Value = dalCustomer.PartyType;
            SqlPara[16] = new SqlParameter("@CreatedById", DbType.String);
            SqlPara[16].Value = dalCustomer.CreatedById;
            SqlPara[17] = new SqlParameter("@CreatedDate", DbType.String);
            SqlPara[17].Value = dalCustomer.CreatedDate;

            return commonFunction.InsertRecord("INSERT_CustomerMaster", SqlPara);

        }

        public Int32 UpdateCustomer(DALCustomerMaster dalCustomer)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[18];
            SqlPara[0] = new SqlParameter("@CustomerId", DbType.String);
            SqlPara[0].Value = dalCustomer.CustomerId;
            SqlPara[1] = new SqlParameter("@CustomerCode", DbType.String);
            SqlPara[1].Value = dalCustomer.CustomerCode;
            SqlPara[2] = new SqlParameter("@CustomerName", DbType.String);
            SqlPara[2].Value = dalCustomer.CustomerName;
            SqlPara[3] = new SqlParameter("@Address", DbType.String);
            SqlPara[3].Value = dalCustomer.Address;
            SqlPara[4] = new SqlParameter("@ContactNumber", DbType.String);
            SqlPara[4].Value = dalCustomer.ContactNumber;
            SqlPara[5] = new SqlParameter("@Email", DbType.String);
            SqlPara[5].Value = dalCustomer.Email;
            SqlPara[6] = new SqlParameter("@ContactPerson", DbType.String);
            SqlPara[6].Value = dalCustomer.ContactPerson;
            SqlPara[7] = new SqlParameter("@GSTIN", DbType.String);
            SqlPara[7].Value = dalCustomer.GSTIN;
            SqlPara[8] = new SqlParameter("@StateId", DbType.String);
            SqlPara[8].Value = dalCustomer.StateId;
            SqlPara[9] = new SqlParameter("@AccLedgerName", DbType.String);
            SqlPara[9].Value = dalCustomer.AccLedgerName;
            SqlPara[10] = new SqlParameter("@CreditDays", DbType.String);
            SqlPara[10].Value = dalCustomer.CreditDays;
            SqlPara[11] = new SqlParameter("@ECCno", DbType.String);
            SqlPara[11].Value = dalCustomer.ECCno;
            SqlPara[12] = new SqlParameter("@Range", DbType.String);
            SqlPara[12].Value = dalCustomer.Range;
            SqlPara[13] = new SqlParameter("@Division", DbType.String);
            SqlPara[13].Value = dalCustomer.Division;
            SqlPara[14] = new SqlParameter("@Collectorate", DbType.String);
            SqlPara[14].Value = dalCustomer.Collectorate;
            SqlPara[15] = new SqlParameter("@PartyType", DbType.String);
            SqlPara[15].Value = dalCustomer.PartyType;
            SqlPara[16] = new SqlParameter("@UpdatedById", DbType.String);
            SqlPara[16].Value = dalCustomer.UpdatedById;
            SqlPara[17] = new SqlParameter("@UpdatedDate", DbType.String);
            SqlPara[17].Value = dalCustomer.UpdatedDate;

            return commonFunction.UpdateRecord("UPDATE_CustomerMaster", SqlPara);

        }

        public Int32 DeletetCustomer(DALCustomerMaster dalCustomer)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[3];
            SqlPara[0] = new SqlParameter("@CustomerId", DbType.String);
            SqlPara[0].Value = dalCustomer.CustomerId;
            SqlPara[1] = new SqlParameter("@DeletedById", DbType.String);
            SqlPara[1].Value = dalCustomer.DeletedById;
            SqlPara[2] = new SqlParameter("@DeletedDate", DbType.String);
            SqlPara[2].Value = dalCustomer.DeletedDate;

            return commonFunction.InsertRecord("DELETE_CustomerMaster", SqlPara);

        }
    }
}
