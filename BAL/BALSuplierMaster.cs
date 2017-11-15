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
    public class BALSuplierMaster
    {
        CommonFunctions commonFunction = new CommonFunctions();

        public DataTable getSupliers(DALSuplierMaster dalSuplier)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[2];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = dalSuplier.Flag;
            SqlPara[1] = new SqlParameter("@SuplierId", DbType.String);
            SqlPara[1].Value = dalSuplier.SuplierId;
            Dt = commonFunction.SelectRecords("SELECT_SuplierMaster", SqlPara);
            return Dt;
        }

        public DataTable getStates(DALSuplierMaster dalSuplier)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[1];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = dalSuplier.Flag;

            Dt = commonFunction.SelectRecords("SELECT_StateMaster", SqlPara);
            return Dt;
        }

        public Int32 InsertSuplier(DALSuplierMaster dalSuplier)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[18];
            SqlPara[0] = new SqlParameter("@SuplierId", DbType.String);
            SqlPara[0].Value = dalSuplier.SuplierId;
            SqlPara[1] = new SqlParameter("@SuplierCode", DbType.String);
            SqlPara[1].Value = dalSuplier.SuplierCode;
            SqlPara[2] = new SqlParameter("@SuplierName", DbType.String);
            SqlPara[2].Value = dalSuplier.SuplierName;
            SqlPara[3] = new SqlParameter("@Address", DbType.String);
            SqlPara[3].Value = dalSuplier.Address;
            SqlPara[4] = new SqlParameter("@ContactNumber", DbType.String);
            SqlPara[4].Value = dalSuplier.ContactNumber;
            SqlPara[5] = new SqlParameter("@Email", DbType.String);
            SqlPara[5].Value = dalSuplier.Email;
            SqlPara[6] = new SqlParameter("@ContactPerson", DbType.String);
            SqlPara[6].Value = dalSuplier.ContactPerson;
            SqlPara[7] = new SqlParameter("@GSTIN", DbType.String);
            SqlPara[7].Value = dalSuplier.GSTIN;
            SqlPara[8] = new SqlParameter("@StateId", DbType.String);
            SqlPara[8].Value = dalSuplier.StateId;
            SqlPara[9] = new SqlParameter("@AccLedgerName", DbType.String);
            SqlPara[9].Value = dalSuplier.AccLedgerName;
            SqlPara[10] = new SqlParameter("@CreditDays", DbType.String);
            SqlPara[10].Value = dalSuplier.CreditDays;
            SqlPara[11] = new SqlParameter("@ECCno", DbType.String);
            SqlPara[11].Value = dalSuplier.ECCno;
            SqlPara[12] = new SqlParameter("@Range", DbType.String);
            SqlPara[12].Value = dalSuplier.Range;
            SqlPara[13] = new SqlParameter("@Division", DbType.String);
            SqlPara[13].Value = dalSuplier.Division;
            SqlPara[14] = new SqlParameter("@Colloctorate", DbType.String);
            SqlPara[14].Value = dalSuplier.Colloctorate;
            SqlPara[15] = new SqlParameter("@PartyType", DbType.String);
            SqlPara[15].Value = dalSuplier.PartyType;
            SqlPara[16] = new SqlParameter("@CreatedById", DbType.String);
            SqlPara[16].Value = dalSuplier.CreatedById;
            SqlPara[17] = new SqlParameter("@CreatedDate", DbType.String);
            SqlPara[17].Value = dalSuplier.CreatedDate;

            return commonFunction.InsertRecord("INSERT_SuplierMaster", SqlPara);

        }

        public Int32 UpdateSuplier(DALSuplierMaster dalSuplier)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[18];
            SqlPara[0] = new SqlParameter("@SuplierId", DbType.String);
            SqlPara[0].Value = dalSuplier.SuplierId;
            SqlPara[1] = new SqlParameter("@SuplierCode", DbType.String);
            SqlPara[1].Value = dalSuplier.SuplierCode;
            SqlPara[2] = new SqlParameter("@SuplierName", DbType.String);
            SqlPara[2].Value = dalSuplier.SuplierName;
            SqlPara[3] = new SqlParameter("@Address", DbType.String);
            SqlPara[3].Value = dalSuplier.Address;
            SqlPara[4] = new SqlParameter("@ContactNumber", DbType.String);
            SqlPara[4].Value = dalSuplier.ContactNumber;
            SqlPara[5] = new SqlParameter("@Email", DbType.String);
            SqlPara[5].Value = dalSuplier.Email;
            SqlPara[6] = new SqlParameter("@ContactPerson", DbType.String);
            SqlPara[6].Value = dalSuplier.ContactPerson;
            SqlPara[7] = new SqlParameter("@GSTIN", DbType.String);
            SqlPara[7].Value = dalSuplier.GSTIN;
            SqlPara[8] = new SqlParameter("@StateId", DbType.String);
            SqlPara[8].Value = dalSuplier.StateId;
            SqlPara[9] = new SqlParameter("@AccLedgerName", DbType.String);
            SqlPara[9].Value = dalSuplier.AccLedgerName;
            SqlPara[10] = new SqlParameter("@CreditDays", DbType.String);
            SqlPara[10].Value = dalSuplier.CreditDays;
            SqlPara[11] = new SqlParameter("@ECCno", DbType.String);
            SqlPara[11].Value = dalSuplier.ECCno;
            SqlPara[12] = new SqlParameter("@Range", DbType.String);
            SqlPara[12].Value = dalSuplier.Range;
            SqlPara[13] = new SqlParameter("@Division", DbType.String);
            SqlPara[13].Value = dalSuplier.Division;
            SqlPara[14] = new SqlParameter("@Colloctorate", DbType.String);
            SqlPara[14].Value = dalSuplier.Colloctorate;
            SqlPara[15] = new SqlParameter("@PartyType", DbType.String);
            SqlPara[15].Value = dalSuplier.PartyType;
            SqlPara[16] = new SqlParameter("@UpdatedById", DbType.String);
            SqlPara[16].Value = dalSuplier.UpdatedById;
            SqlPara[17] = new SqlParameter("@UpdatedDate", DbType.String);
            SqlPara[17].Value = dalSuplier.UpdatedDate;

            return commonFunction.UpdateRecord("UPDATE_SuplierMaster", SqlPara);

        }

        public Int32 DeletetSuplier(DALSuplierMaster dalSuplier)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[3];
            SqlPara[0] = new SqlParameter("@SuplierId", DbType.String);
            SqlPara[0].Value = dalSuplier.SuplierId;
            SqlPara[1] = new SqlParameter("@DeletedById", DbType.String);
            SqlPara[1].Value = dalSuplier.DeletedById;
            SqlPara[2] = new SqlParameter("@DeletedDate", DbType.String);
            SqlPara[2].Value = dalSuplier.DeletedDate;

            return commonFunction.InsertRecord("DELETE_SuplierMaster", SqlPara);

        }
    }
}
