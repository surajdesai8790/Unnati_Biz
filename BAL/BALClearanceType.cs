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
    public class BALClearanceType
    {
        CommonFunctions commonFunction = new CommonFunctions();

        public DataTable getClearanceTypes(DALClearanceType dalClearnce)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[2];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = dalClearnce.Flag;
            SqlPara[1] = new SqlParameter("@ClearanceTypeId", DbType.String);
            SqlPara[1].Value = dalClearnce.ClearanceTypeId;
            Dt = commonFunction.SelectRecords("SELECT_ClearanceTypeMaster", SqlPara);
            return Dt;
        }

        public Int32 InsertClearanceType(DALClearanceType dalClearnce)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[8];
            SqlPara[0] = new SqlParameter("@ClearanceTypeId", DbType.String);
            SqlPara[0].Value = dalClearnce.ClearanceTypeId;
            SqlPara[1] = new SqlParameter("@ClearanceType", DbType.String);
            SqlPara[1].Value = dalClearnce.ClearanceType;
            SqlPara[2] = new SqlParameter("@CGSTPer", DbType.String);
            SqlPara[2].Value = dalClearnce.CGSTPer;
            SqlPara[3] = new SqlParameter("@SGSTPer", DbType.String);
            SqlPara[3].Value = dalClearnce.SGSTPer;
            SqlPara[4] = new SqlParameter("@IGSTPer", DbType.String);
            SqlPara[4].Value = dalClearnce.IGSTPer;
            SqlPara[5] = new SqlParameter("@Cess", DbType.String);
            SqlPara[5].Value = dalClearnce.Cess;
            SqlPara[6] = new SqlParameter("@CreatedById", DbType.String);
            SqlPara[6].Value = dalClearnce.CreatedById;
            SqlPara[7] = new SqlParameter("@CreatedDate", DbType.String);
            SqlPara[7].Value = dalClearnce.CreatedDate;

            return commonFunction.InsertRecord("Insert_ClearanceTypeMaster", SqlPara);

        }

        public Int32 UpdateClearanceType(DALClearanceType dalClearnce)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[8];
            SqlPara[0] = new SqlParameter("@ClearanceTypeId", DbType.String);
            SqlPara[0].Value = dalClearnce.ClearanceTypeId;
            SqlPara[1] = new SqlParameter("@ClearanceType", DbType.String);
            SqlPara[1].Value = dalClearnce.ClearanceType;
            SqlPara[2] = new SqlParameter("@CGSTPer", DbType.String);
            SqlPara[2].Value = dalClearnce.CGSTPer;
            SqlPara[3] = new SqlParameter("@SGSTPer", DbType.String);
            SqlPara[3].Value = dalClearnce.SGSTPer;
            SqlPara[4] = new SqlParameter("@IGSTPer", DbType.String);
            SqlPara[4].Value = dalClearnce.IGSTPer;
            SqlPara[5] = new SqlParameter("@Cess", DbType.String);
            SqlPara[5].Value = dalClearnce.Cess;
            SqlPara[6] = new SqlParameter("@UpdatedById", DbType.String);
            SqlPara[6].Value = dalClearnce.UpdatedById;
            SqlPara[7] = new SqlParameter("@UpdatedDate", DbType.String);
            SqlPara[7].Value = dalClearnce.UpdatedDate;

            return commonFunction.InsertRecord("Update_ClearanceTypeMaster", SqlPara);

        }

        public Int32 DeletetClearance(DALClearanceType dalClearnce)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[3];
            SqlPara[0] = new SqlParameter("@ClearanceTypeId", DbType.String);
            SqlPara[0].Value = dalClearnce.ClearanceTypeId;
            SqlPara[1] = new SqlParameter("@DeletedById", DbType.String);
            SqlPara[1].Value = dalClearnce.DeletedById;
            SqlPara[2] = new SqlParameter("@DeletedDate", DbType.String);
            SqlPara[2].Value = dalClearnce.DeletedDate;

            return commonFunction.InsertRecord("DELETE_ClearanceTypeMaster", SqlPara);

        }
    }
}
