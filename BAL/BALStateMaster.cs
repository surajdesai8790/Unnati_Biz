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
    public class BALStateMaster
    {
        CommonFunctions commonFunction = new CommonFunctions();

        public DataTable getState(DALState dalState)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[2];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = dalState.Flag;
            SqlPara[1] = new SqlParameter("@StateId", DbType.String);
            SqlPara[1].Value = dalState.StateId;
            Dt = commonFunction.SelectRecords("SELECT_StateMaster", SqlPara);
            return Dt;
        }

        public Int32 InsertState(DALState dalState)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[5];
            SqlPara[0] = new SqlParameter("@StateId", DbType.String);
            SqlPara[0].Value = dalState.StateId;
            SqlPara[1] = new SqlParameter("@StateCode", DbType.String);
            SqlPara[1].Value = dalState.StateCode;
            SqlPara[2] = new SqlParameter("@StateName", DbType.String);
            SqlPara[2].Value = dalState.StateName;
            SqlPara[3] = new SqlParameter("@CreatedById", DbType.String);
            SqlPara[3].Value = dalState.CreatedById;
            SqlPara[4] = new SqlParameter("@CreatedDate", DbType.String);
            SqlPara[4].Value = dalState.CreatedDate;

            return commonFunction.InsertRecord("INSERT_StateMaster", SqlPara);

        }

        public Int32 UpdateState(DALState dalState)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[5];
            SqlPara[0] = new SqlParameter("@StateId", DbType.String);
            SqlPara[0].Value = dalState.StateId;
            SqlPara[1] = new SqlParameter("@StateCode", DbType.String);
            SqlPara[1].Value = dalState.StateCode;
            SqlPara[2] = new SqlParameter("@StateName", DbType.String);
            SqlPara[2].Value = dalState.StateName;
            SqlPara[3] = new SqlParameter("@UpdatedById", DbType.String);
            SqlPara[3].Value = dalState.UpdatedById;
            SqlPara[4] = new SqlParameter("@UpdatedDate", DbType.String);
            SqlPara[4].Value = dalState.UpdatedDate;

            return commonFunction.InsertRecord("UPDATE_StateMaster", SqlPara);

        }

        public Int32 DeletetState(DALState dalState)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[3];
            SqlPara[0] = new SqlParameter("@StateId", DbType.String);
            SqlPara[0].Value = dalState.StateId;
            SqlPara[1] = new SqlParameter("@DeletedById", DbType.String);
            SqlPara[1].Value = dalState.DeletedById;
            SqlPara[2] = new SqlParameter("@DeletedDate", DbType.String);
            SqlPara[2].Value = dalState.DeletedDate;

            return commonFunction.InsertRecord("DELETE_StateMaster", SqlPara);

        }
    }
}
