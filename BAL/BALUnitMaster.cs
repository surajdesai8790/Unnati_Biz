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
  public  class BALUnitMaster
    {
        CommonFunctions commonFunction = new CommonFunctions();
        DataTable _Branchdt = new DataTable();

        public DataTable GETRecord(DALUnitMaster _objunit)
        {
            SqlParameter[] SqlPara = new SqlParameter[1];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = _objunit.Flag;
            _Branchdt = commonFunction.SelectRecords("SP_INSERTUNITMASTER", SqlPara);
            return _Branchdt;
        }
        public DataTable GETSINGLERECORD(DALUnitMaster _objtable)
        {
            SqlParameter[] SqlPara = new SqlParameter[2];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = _objtable.Flag;
            SqlPara[1] = new SqlParameter("@Unit_Id", DbType.Int32);
            SqlPara[1].Value = _objtable.Unit_Id;
            _Branchdt = commonFunction.SelectRecords("SP_INSERTUNITMASTER", SqlPara);
            return _Branchdt;
        }

        public Int32 InsertRecord(DALUnitMaster _objtable)
        {
            SqlParameter[] SqlPara = new SqlParameter[4];
            SqlPara[0] = new SqlParameter("@Unit_Name", DbType.String);
            SqlPara[0].Value = _objtable.Unit_Name;
            SqlPara[1] = new SqlParameter("@CreatedByID", DbType.Int32);
            SqlPara[1].Value = _objtable.CreatedByID;
            SqlPara[2] = new SqlParameter("@CreatedDate", DbType.String);
            SqlPara[2].Value = _objtable.CreatedDate;
            SqlPara[3] = new SqlParameter("@Flag", DbType.String);
            SqlPara[3].Value = _objtable.Flag;
            return commonFunction.InsertRecord("SP_INSERTUNITMASTER", SqlPara);
        }

        public Int32 UpdateRecord(DALUnitMaster _objtable)
        {
            SqlParameter[] SqlPara = new SqlParameter[5];
            SqlPara[0] = new SqlParameter("@Unit_Name", DbType.String);
            SqlPara[0].Value = _objtable.Unit_Name;
            SqlPara[1] = new SqlParameter("@UpdatedByID", DbType.Int32);
            SqlPara[1].Value = _objtable.UpdatedByID;
            SqlPara[2] = new SqlParameter("@UpdatedDate", DbType.String);
            SqlPara[2].Value = _objtable.UpdatedDate;
            SqlPara[3] = new SqlParameter("@Flag", DbType.String);
            SqlPara[3].Value = _objtable.Flag;
            SqlPara[4] = new SqlParameter("@Unit_Id", DbType.Int32);
            SqlPara[4].Value = _objtable.Unit_Id;
            return commonFunction.InsertRecord("SP_INSERTUNITMASTER", SqlPara);
        }

        public Int32 DeleteRecord(DALUnitMaster _objtable)
        {
            SqlParameter[] SqlPara = new SqlParameter[4];
            SqlPara[0] = new SqlParameter("@DeletedByID", DbType.Int32);
            SqlPara[0].Value = _objtable.DeletedByID;
            SqlPara[1] = new SqlParameter("@DeletedDate", DbType.String);
            SqlPara[1].Value = _objtable.DeletedDate;
            SqlPara[2] = new SqlParameter("@Flag", DbType.String);
            SqlPara[2].Value = _objtable.Flag;
            SqlPara[3] = new SqlParameter("@Unit_Id", DbType.Int32);
            SqlPara[3].Value = _objtable.Unit_Id;
            return commonFunction.InsertRecord("SP_INSERTUNITMASTER", SqlPara);
        }


    }
}
