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
  public  class BALBranchMaster
    {
        CommonFunctions commonFunction = new CommonFunctions();
        DataTable _Branchdt = new DataTable();
        public DataTable GETBRANCH(DALBranchMaster _objbranch)
        {
            SqlParameter[] SqlPara = new SqlParameter[1];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = _objbranch.Flag;
            _Branchdt = commonFunction.SelectRecords("SP_INSERTBRANCHMASTER", SqlPara);           
            return _Branchdt;
        }
        public DataTable GETSINGLEBRANCH(DALBranchMaster _objbranch)
        {
            SqlParameter[] SqlPara = new SqlParameter[2];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = _objbranch.Flag;
            SqlPara[1] = new SqlParameter("@Branch_Id", DbType.Int32);
            SqlPara[1].Value = _objbranch.Branch_Id;
            _Branchdt = commonFunction.SelectRecords("SP_INSERTBRANCHMASTER", SqlPara);
            return _Branchdt;
        }

        public Int32 InsertBranch(DALBranchMaster _objbranch)
        {
            SqlParameter[] SqlPara = new SqlParameter[6];
            SqlPara[0] = new SqlParameter("@Branch_Address", DbType.String);
            SqlPara[0].Value = _objbranch.Branch_Address;
            SqlPara[1] = new SqlParameter("@Branch_Name", DbType.String);
            SqlPara[1].Value = _objbranch.Branch_Name;
            SqlPara[2] = new SqlParameter("@Contact_No", DbType.String);
            SqlPara[2].Value = _objbranch.Contact_No;
            SqlPara[3] = new SqlParameter("@CreatedByID", DbType.Int32);
            SqlPara[3].Value = _objbranch.CreatedByID;
            SqlPara[4] = new SqlParameter("@CreatedDate", DbType.String);
            SqlPara[4].Value = _objbranch.CreatedDate;
            SqlPara[5] = new SqlParameter("@Flag", DbType.String);
            SqlPara[5].Value = _objbranch.Flag;
            return commonFunction.InsertRecord("SP_INSERTBRANCHMASTER", SqlPara);
        }

        public Int32 UpdateBranch(DALBranchMaster _objbranch)
        {
            SqlParameter[] SqlPara = new SqlParameter[7];
            SqlPara[0] = new SqlParameter("@Branch_Address", DbType.String);
            SqlPara[0].Value = _objbranch.Branch_Address;
            SqlPara[1] = new SqlParameter("@Branch_Name", DbType.String);
            SqlPara[1].Value = _objbranch.Branch_Name;
            SqlPara[2] = new SqlParameter("@Contact_No", DbType.String);
            SqlPara[2].Value = _objbranch.Contact_No;
            SqlPara[3] = new SqlParameter("@UpdatedByID", DbType.Int32);
            SqlPara[3].Value = _objbranch.UpdatedByID;
            SqlPara[4] = new SqlParameter("@UpdatedDate", DbType.String);
            SqlPara[4].Value = _objbranch.UpdatedDate;
            SqlPara[5] = new SqlParameter("@Flag", DbType.String);
            SqlPara[5].Value = _objbranch.Flag;
            SqlPara[6] = new SqlParameter("@Branch_Id", DbType.Int32);
            SqlPara[6].Value = _objbranch.Branch_Id;
            return commonFunction.InsertRecord("SP_INSERTBRANCHMASTER", SqlPara);
        }

        public Int32 DeleteBranch(DALBranchMaster _objbranch)
        {
            SqlParameter[] SqlPara = new SqlParameter[4];
            SqlPara[0] = new SqlParameter("@DeletedByID", DbType.Int32);
            SqlPara[0].Value = _objbranch.DeletedByID;
            SqlPara[1] = new SqlParameter("@DeletedDate", DbType.String);
            SqlPara[1].Value = _objbranch.DeletedDate;
            SqlPara[2] = new SqlParameter("@Flag", DbType.String);
            SqlPara[2].Value = _objbranch.Flag;
            SqlPara[3] = new SqlParameter("@Branch_Id", DbType.Int32);
            SqlPara[3].Value = _objbranch.Branch_Id;
            return commonFunction.InsertRecord("SP_INSERTBRANCHMASTER", SqlPara);
        }
    }
}
