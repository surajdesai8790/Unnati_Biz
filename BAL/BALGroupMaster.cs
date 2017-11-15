using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace BAL
{
   public  class BALGroupMaster
    {

        CommonFunctions commonFunction = new CommonFunctions();
        DataTable _Branchdt = new DataTable();
       
        public DataTable GETRecord(DALGroupMaster _objgroup)
        {
            SqlParameter[] SqlPara = new SqlParameter[1];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = _objgroup.Flag;
            _Branchdt = commonFunction.SelectRecords("SP_INSERTGROUPMASTER", SqlPara);
            return _Branchdt;
        }
        public DataTable GETSINGLERECORD(DALGroupMaster  _objgroup)
        {
            SqlParameter[] SqlPara = new SqlParameter[2];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = _objgroup.Flag;
            SqlPara[1] = new SqlParameter("@Group_Id", DbType.Int32);
            SqlPara[1].Value = _objgroup.Group_Id;
            _Branchdt = commonFunction.SelectRecords("SP_INSERTGROUPMASTER", SqlPara);
            return _Branchdt;
        }

        public Int32 InsertRecord(DALGroupMaster _objgroup)
        {
            SqlParameter[] SqlPara = new SqlParameter[4];
            SqlPara[0] = new SqlParameter("@Group_Name", DbType.String);
            SqlPara[0].Value = _objgroup.Group_Name;
            SqlPara[1] = new SqlParameter("@CreatedByID", DbType.Int32);
            SqlPara[1].Value = _objgroup.CreatedByID;
            SqlPara[2] = new SqlParameter("@CreatedDate", DbType.String);
            SqlPara[2].Value = _objgroup.CreatedDate;
            SqlPara[3] = new SqlParameter("@Flag", DbType.String);
            SqlPara[3].Value = _objgroup.Flag;
            return commonFunction.InsertRecord("SP_INSERTGROUPMASTER", SqlPara);
        }

        public Int32 UpdateRecord(DALGroupMaster _objgroup)
        {
            SqlParameter[] SqlPara = new SqlParameter[5];
            SqlPara[0] = new SqlParameter("@Group_Name", DbType.String);
            SqlPara[0].Value = _objgroup.Group_Name;
            SqlPara[1] = new SqlParameter("@UpdatedByID", DbType.Int32);
            SqlPara[1].Value = _objgroup.UpdatedByID;
            SqlPara[2] = new SqlParameter("@UpdatedDate", DbType.String);
            SqlPara[2].Value = _objgroup.UpdatedDate;
            SqlPara[3] = new SqlParameter("@Flag", DbType.String);
            SqlPara[3].Value = _objgroup.Flag;
            SqlPara[4] = new SqlParameter("@Group_Id", DbType.Int32);
            SqlPara[4].Value = _objgroup.Group_Id;
            return commonFunction.InsertRecord("SP_INSERTGROUPMASTER", SqlPara);
        }

        public Int32 DeleteRecord(DALGroupMaster _objgroup)
        {
            SqlParameter[] SqlPara = new SqlParameter[4];
            SqlPara[0] = new SqlParameter("@DeletedByID", DbType.Int32);
            SqlPara[0].Value = _objgroup.DeletedByID;
            SqlPara[1] = new SqlParameter("@DeletedDate", DbType.String);
            SqlPara[1].Value = _objgroup.DeletedDate;
            SqlPara[2] = new SqlParameter("@Flag", DbType.String);
            SqlPara[2].Value = _objgroup.Flag;
            SqlPara[3] = new SqlParameter("@Group_Id", DbType.Int32);
            SqlPara[3].Value = _objgroup.Group_Id;
            return commonFunction.InsertRecord("SP_INSERTGROUPMASTER", SqlPara);
        }
    }
}
