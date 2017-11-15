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
   public  class BALCategoryMaster
    {
        // 
        CommonFunctions commonFunction = new CommonFunctions();
        DataTable _Branchdt = new DataTable();

        public DataTable GETRecord(DALCategoryMaster _objgroup)
        {
            SqlParameter[] SqlPara = new SqlParameter[1];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = _objgroup.Flag;
            _Branchdt = commonFunction.SelectRecords("SP_INSERTCATEGORYMASTER", SqlPara);
            return _Branchdt;
        }
        public DataTable GETSINGLERECORD(DALCategoryMaster _objgroup)
        {
            SqlParameter[] SqlPara = new SqlParameter[2];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = _objgroup.Flag;
            SqlPara[1] = new SqlParameter("@Category_Id", DbType.Int32);
            SqlPara[1].Value = _objgroup.Category_Id;
            _Branchdt = commonFunction.SelectRecords("SP_INSERTCATEGORYMASTER", SqlPara);
            return _Branchdt;
        }

        public Int32 InsertRecord(DALCategoryMaster _objgroup)
        {
            SqlParameter[] SqlPara = new SqlParameter[5];
            SqlPara[0] = new SqlParameter("@Category_Name", DbType.String);
            SqlPara[0].Value = _objgroup.Category_Name;
            SqlPara[1] = new SqlParameter("@CreatedByID", DbType.Int32);
            SqlPara[1].Value = _objgroup.CreatedByID;
            SqlPara[2] = new SqlParameter("@CreatedDate", DbType.String);
            SqlPara[2].Value = _objgroup.CreatedDate;
            SqlPara[3] = new SqlParameter("@Flag", DbType.String);
            SqlPara[3].Value = _objgroup.Flag;
            SqlPara[4] = new SqlParameter("@Group_Id", DbType.Int32);
            SqlPara[4].Value = _objgroup.Group_Id;
            return commonFunction.InsertRecord("SP_INSERTCATEGORYMASTER", SqlPara);
        }

        public Int32 UpdateRecord(DALCategoryMaster _objgroup)
        {
            SqlParameter[] SqlPara = new SqlParameter[6];
            SqlPara[0] = new SqlParameter("@Category_Name", DbType.String);
            SqlPara[0].Value = _objgroup.Category_Name;
            SqlPara[1] = new SqlParameter("@UpdatedByID", DbType.Int32);
            SqlPara[1].Value = _objgroup.UpdatedByID;
            SqlPara[2] = new SqlParameter("@UpdatedDate", DbType.String);
            SqlPara[2].Value = _objgroup.UpdatedDate;
            SqlPara[3] = new SqlParameter("@Flag", DbType.String);
            SqlPara[3].Value = _objgroup.Flag;
            SqlPara[4] = new SqlParameter("@Group_Id", DbType.Int32);
            SqlPara[4].Value = _objgroup.Group_Id;
            SqlPara[5] = new SqlParameter("@Category_Id", DbType.Int32);
            SqlPara[5].Value = _objgroup.Category_Id;
            return commonFunction.InsertRecord("SP_INSERTCATEGORYMASTER", SqlPara);
        }

        public Int32 DeleteRecord(DALCategoryMaster  _objgroup)
        {
            SqlParameter[] SqlPara = new SqlParameter[4];
            SqlPara[0] = new SqlParameter("@DeletedByID", DbType.Int32);
            SqlPara[0].Value = _objgroup.DeletedByID;
            SqlPara[1] = new SqlParameter("@DeletedDate", DbType.String);
            SqlPara[1].Value = _objgroup.DeletedDate;
            SqlPara[2] = new SqlParameter("@Flag", DbType.String);
            SqlPara[2].Value = _objgroup.Flag;
            SqlPara[3] = new SqlParameter("@Category_Id", DbType.Int32);
            SqlPara[3].Value = _objgroup.Category_Id;
            return commonFunction.InsertRecord("SP_INSERTCATEGORYMASTER", SqlPara);
        }


    }
}
