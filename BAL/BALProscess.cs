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
    public class BALProscess
    {
        CommonFunctions commonFunction = new CommonFunctions();

        public DataTable getProcess(DALProcess dalProcess)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[2];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = dalProcess.Flag;
            SqlPara[1] = new SqlParameter("@ProcessId", DbType.String);
            SqlPara[1].Value = dalProcess.ProcessId;
            Dt = commonFunction.SelectRecords("SELECT_ProcessMaster", SqlPara);
            return Dt;
        }

        public Int32 InsertProcess(DALProcess dalProcess)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[5];
            SqlPara[0] = new SqlParameter("@ProcessId", DbType.String);
            SqlPara[0].Value = dalProcess.ProcessId;
            SqlPara[1] = new SqlParameter("@ProcessCode", DbType.String);
            SqlPara[1].Value = dalProcess.ProcessCode;
            SqlPara[2] = new SqlParameter("@ProcessName", DbType.String);
            SqlPara[2].Value = dalProcess.ProcessName;
            SqlPara[3] = new SqlParameter("@CreatedById", DbType.String);
            SqlPara[3].Value = dalProcess.CreatedById;
            SqlPara[4] = new SqlParameter("@CreatedDate", DbType.String);
            SqlPara[4].Value = dalProcess.CreatedDate;

            return commonFunction.InsertRecord("INSERT_ProcessMaster", SqlPara);

        }

        public Int32 UpdateProcess(DALProcess dalProcess)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[5];
            SqlPara[0] = new SqlParameter("@ProcessId", DbType.String);
            SqlPara[0].Value = dalProcess.ProcessId;
            SqlPara[1] = new SqlParameter("@ProcessCode", DbType.String);
            SqlPara[1].Value = dalProcess.ProcessCode;
            SqlPara[2] = new SqlParameter("@ProcessName", DbType.String);
            SqlPara[2].Value = dalProcess.ProcessName;
            SqlPara[3] = new SqlParameter("@UpdatedById", DbType.String);
            SqlPara[3].Value = dalProcess.UpdatedById;
            SqlPara[4] = new SqlParameter("@UpdatedDate", DbType.String);
            SqlPara[4].Value = dalProcess.UpdatedDate;


            return commonFunction.InsertRecord("UPDATE_ProcessMaster", SqlPara);

        }

        public Int32 DeletetProcess(DALProcess dalProcess)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[3];
            SqlPara[0] = new SqlParameter("@ProcessId", DbType.String);
            SqlPara[0].Value = dalProcess.ProcessId;
            SqlPara[1] = new SqlParameter("@DeletedById", DbType.String);
            SqlPara[1].Value = dalProcess.DeletedById;
            SqlPara[2] = new SqlParameter("@DeletedDate", DbType.String);
            SqlPara[2].Value = dalProcess.DeletedDate;

            return commonFunction.InsertRecord("DELETE_ProcessMaster", SqlPara);

        }
    }
}
