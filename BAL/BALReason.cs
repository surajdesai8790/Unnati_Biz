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
    public class BALReason
    {
        CommonFunctions commonFunction = new CommonFunctions();

        public DataTable getReason(DALReasonMaster dalReason)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[2];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = dalReason.Flag;
            SqlPara[1] = new SqlParameter("@ReasonId", DbType.String);
            SqlPara[1].Value = dalReason.ReasonId;
            Dt = commonFunction.SelectRecords("SELECT_RejectionReasonMaster", SqlPara);
            return Dt;
        }

        public Int32 InsertReason(DALReasonMaster dalReason)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[5];
            SqlPara[0] = new SqlParameter("@ReasonId", DbType.String);
            SqlPara[0].Value = dalReason.ReasonId;
            SqlPara[1] = new SqlParameter("@ReasonCode", DbType.String);
            SqlPara[1].Value = dalReason.ReasonCode;
            SqlPara[2] = new SqlParameter("@Reason", DbType.String);
            SqlPara[2].Value = dalReason.Reason;
            SqlPara[3] = new SqlParameter("@CreatedById", DbType.String);
            SqlPara[3].Value = dalReason.CreatedById;
            SqlPara[4] = new SqlParameter("@CreatedDate", DbType.String);
            SqlPara[4].Value = dalReason.CreatedDate;

            return commonFunction.InsertRecord("INSERT_RejectionReasonMaster", SqlPara);

        }

        public Int32 UpdateReason(DALReasonMaster dalReason)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[5];
            SqlPara[0] = new SqlParameter("@ReasonId", DbType.String);
            SqlPara[0].Value = dalReason.ReasonId;
            SqlPara[1] = new SqlParameter("@ReasonCode", DbType.String);
            SqlPara[1].Value = dalReason.ReasonCode;
            SqlPara[2] = new SqlParameter("@Reason", DbType.String);
            SqlPara[2].Value = dalReason.Reason;
            SqlPara[3] = new SqlParameter("@UpdatedById", DbType.String);
            SqlPara[3].Value = dalReason.UpdatedById;
            SqlPara[4] = new SqlParameter("@UpdatedDate", DbType.String);
            SqlPara[4].Value = dalReason.UpdatedDate;

            return commonFunction.InsertRecord("UPDATE_RejectionReasonMaster", SqlPara);

        }

        public Int32 DeletetReason(DALReasonMaster dalReason)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[3];
            SqlPara[0] = new SqlParameter("@ReasonId", DbType.String);
            SqlPara[0].Value = dalReason.ReasonId;
            SqlPara[1] = new SqlParameter("@DeletedById", DbType.String);
            SqlPara[1].Value = dalReason.DeletedById;
            SqlPara[2] = new SqlParameter("@DeletedDate", DbType.String);
            SqlPara[2].Value = dalReason.DeletedDate;

            return commonFunction.InsertRecord("DELETE_RejectionReasonMaster", SqlPara);

        }
    }
}
