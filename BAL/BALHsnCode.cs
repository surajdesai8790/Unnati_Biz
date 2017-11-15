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
    public class BALHsnCode
    {
        CommonFunctions commonFunction = new CommonFunctions();

        public DataTable getHsnCodes(DALHsnCode dalHsnCode)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[2];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = dalHsnCode.Flag;
            SqlPara[1] = new SqlParameter("@HsnId", DbType.String);
            SqlPara[1].Value = dalHsnCode.HsnId;
            Dt = commonFunction.SelectRecords("SELECT_HsnCodeMaster", SqlPara);
            return Dt;
        }

        public Int32 InsertHsnCode(DALHsnCode dalHsnCode)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[7];
            SqlPara[0] = new SqlParameter("@HsnId", DbType.String);
            SqlPara[0].Value = dalHsnCode.HsnId;
            SqlPara[1] = new SqlParameter("@HsnCode", DbType.String);
            SqlPara[1].Value = dalHsnCode.HsnCode;
            SqlPara[2] = new SqlParameter("@Description", DbType.String);
            SqlPara[2].Value = dalHsnCode.Description;
            SqlPara[3] = new SqlParameter("@GstCategory", DbType.String);
            SqlPara[3].Value = dalHsnCode.GstCategory;
            SqlPara[4] = new SqlParameter("@IsActive", DbType.String);
            SqlPara[4].Value = dalHsnCode.IsActive;
            SqlPara[5] = new SqlParameter("@CreatedById", DbType.String);
            SqlPara[5].Value = dalHsnCode.CreatedById;
            SqlPara[6] = new SqlParameter("@CreatedDate", DbType.String);
            SqlPara[6].Value = dalHsnCode.CreatedDate;

            return commonFunction.InsertRecord("INSERT_HsnCodeMaster", SqlPara);

        }

        public Int32 UpdateHsnCode(DALHsnCode dalHsnCode)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[7];
            SqlPara[0] = new SqlParameter("@HsnId", DbType.String);
            SqlPara[0].Value = dalHsnCode.HsnId;
            SqlPara[1] = new SqlParameter("@HsnCode", DbType.String);
            SqlPara[1].Value = dalHsnCode.HsnCode;
            SqlPara[2] = new SqlParameter("@Description", DbType.String);
            SqlPara[2].Value = dalHsnCode.Description;
            SqlPara[3] = new SqlParameter("@GstCategory", DbType.String);
            SqlPara[3].Value = dalHsnCode.GstCategory;
            SqlPara[4] = new SqlParameter("@IsActive", DbType.String);
            SqlPara[4].Value = dalHsnCode.IsActive;
            SqlPara[5] = new SqlParameter("@UpdatedById", DbType.String);
            SqlPara[5].Value = dalHsnCode.UpdatedById;
            SqlPara[6] = new SqlParameter("@UpdatedDate", DbType.String);
            SqlPara[6].Value = dalHsnCode.UpdatedDate;

            return commonFunction.InsertRecord("UPDATE_HsnCodeMaster", SqlPara);

        }

        public Int32 DeletetHsnCode(DALHsnCode dalHsnCode)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[3];
            SqlPara[0] = new SqlParameter("@HsnId", DbType.String);
            SqlPara[0].Value = dalHsnCode.HsnId;
            SqlPara[1] = new SqlParameter("@DeletedById", DbType.String);
            SqlPara[1].Value = dalHsnCode.DeletedBy;
            SqlPara[2] = new SqlParameter("@DeletedDate", DbType.String);
            SqlPara[2].Value = dalHsnCode.DeletedDate;

            return commonFunction.InsertRecord("DELETE_HsnCodeMaster", SqlPara);

        }
    }
}
