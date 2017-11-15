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
  public   class BALItemMaster
    {
        CommonFunctions commonFunction = new CommonFunctions();
        DataTable _Branchdt = new DataTable();

        public DataTable GETRecord(DALItemMaster _objtable)
        {
            SqlParameter[] SqlPara = new SqlParameter[1];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = _objtable.Flag;
            _Branchdt = commonFunction.SelectRecords("SP_INSERTITEMMASTER", SqlPara);
            return _Branchdt;
        }
        public DataTable GETSINGLERECORD(DALItemMaster _objtable)
        {
            SqlParameter[] SqlPara = new SqlParameter[2];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = _objtable.Flag;
            SqlPara[1] = new SqlParameter("@Item_Id", DbType.Int32);
            SqlPara[1].Value = _objtable.Item_Id;
            _Branchdt = commonFunction.SelectRecords("SP_INSERTITEMMASTER", SqlPara);
            return _Branchdt;
        }

        public Int32 InsertRecord(DALItemMaster _objtable)
        {
            SqlParameter[] SqlPara = new SqlParameter[18];
            SqlPara[0] = new SqlParameter("@Item_Name", DbType.String);
            SqlPara[0].Value = _objtable.Item_Name;
            SqlPara[1] = new SqlParameter("@CreatedByID", DbType.Int32);
            SqlPara[1].Value = _objtable.CreatedByID;
            SqlPara[2] = new SqlParameter("@CreatedDate", DbType.String);
            SqlPara[2].Value = _objtable.CreatedDate;
            SqlPara[3] = new SqlParameter("@Flag", DbType.String);
            SqlPara[3].Value = _objtable.Flag;
            SqlPara[4] = new SqlParameter("@Group_Id", DbType.Int32);
            SqlPara[4].Value = _objtable.Group_Id;
            SqlPara[5] = new SqlParameter("@Category_Id", DbType.Int32);
            SqlPara[5].Value = _objtable.Category_Id;
            SqlPara[6] = new SqlParameter("@Item_Code", DbType.String);
            SqlPara[6].Value = _objtable.Item_Code;
            SqlPara[7] = new SqlParameter("@Drawing_No", DbType.String);
            SqlPara[7].Value = _objtable.Drawing_No;
            SqlPara[8] = new SqlParameter("@Rev_No", DbType.String);
            SqlPara[8].Value = _objtable.Rev_No;
            SqlPara[9] = new SqlParameter("@Unit_Id", DbType.Int32);
            SqlPara[9].Value = _objtable.Unit_Id;
            SqlPara[10] = new SqlParameter("@HSN_Code", DbType.Int32);
            SqlPara[10].Value = _objtable.HSN_Code;
            SqlPara[11] = new SqlParameter("@WIP_Rate", DbType.Decimal);
            SqlPara[11].Value = _objtable.WIP_Rate;
            SqlPara[12] = new SqlParameter("@Finish_Rate", DbType.Decimal);
            SqlPara[12].Value = _objtable.Finish_Rate;
            SqlPara[13] = new SqlParameter("@Net_Weight", DbType.Decimal);
            SqlPara[13].Value = _objtable.Net_Weight;
            SqlPara[14] = new SqlParameter("@Item_Level", DbType.String);
            SqlPara[14].Value = _objtable.Item_Level;
            SqlPara[15] = new SqlParameter("@Metel_Sec", DbType.String);
            SqlPara[15].Value = _objtable.Metel_Sec;
            SqlPara[16] = new SqlParameter("@Qty", DbType.Decimal);
            SqlPara[16].Value = _objtable.Qty;
            SqlPara[17] = new SqlParameter("@Qty_Pack", DbType.Decimal);
            SqlPara[17].Value = _objtable.Qty_Pack;
            return commonFunction.InsertRecord("SP_INSERTITEMMASTER", SqlPara);
        }

        public Int32 UpdateRecord(DALItemMaster _objtable)
        {
            SqlParameter[] SqlPara = new SqlParameter[19];
            SqlPara[0] = new SqlParameter("@Item_Name", DbType.String);
            SqlPara[0].Value = _objtable.Item_Name;
            SqlPara[1] = new SqlParameter("@UpdatedByID", DbType.Int32);
            SqlPara[1].Value = _objtable.UpdatedByID;
            SqlPara[2] = new SqlParameter("@UpdatedDate", DbType.String);
            SqlPara[2].Value = _objtable.UpdatedDate;
            SqlPara[3] = new SqlParameter("@Flag", DbType.String);
            SqlPara[3].Value = _objtable.Flag;
            SqlPara[4] = new SqlParameter("@Group_Id", DbType.Int32);
            SqlPara[4].Value = _objtable.Group_Id;
            SqlPara[5] = new SqlParameter("@Category_Id", DbType.Int32);
            SqlPara[5].Value = _objtable.Category_Id;
            SqlPara[6] = new SqlParameter("@Item_Code", DbType.String);
            SqlPara[6].Value = _objtable.Item_Code;
            SqlPara[7] = new SqlParameter("@Drawing_No", DbType.String);
            SqlPara[7].Value = _objtable.Drawing_No;
            SqlPara[8] = new SqlParameter("@Rev_No", DbType.String);
            SqlPara[8].Value = _objtable.Rev_No;
            SqlPara[9] = new SqlParameter("@Unit_Id", DbType.Int32);
            SqlPara[9].Value = _objtable.Unit_Id;
            SqlPara[10] = new SqlParameter("@HSN_Code", DbType.Int32);
            SqlPara[10].Value = _objtable.HSN_Code;
            SqlPara[11] = new SqlParameter("@WIP_Rate", DbType.Decimal);
            SqlPara[11].Value = _objtable.WIP_Rate;
            SqlPara[12] = new SqlParameter("@Finish_Rate", DbType.Decimal);
            SqlPara[12].Value = _objtable.Finish_Rate;
            SqlPara[13] = new SqlParameter("@Net_Weight", DbType.Decimal);
            SqlPara[13].Value = _objtable.Net_Weight;
            SqlPara[14] = new SqlParameter("@Item_Level", DbType.String);
            SqlPara[14].Value = _objtable.Item_Level;
            SqlPara[15] = new SqlParameter("@Metel_Sec", DbType.String);
            SqlPara[15].Value = _objtable.Metel_Sec;
            SqlPara[16] = new SqlParameter("@Qty", DbType.Decimal);
            SqlPara[16].Value = _objtable.Qty;
            SqlPara[17] = new SqlParameter("@Qty_Pack", DbType.Decimal);
            SqlPara[17].Value = _objtable.Qty_Pack;
            SqlPara[18] = new SqlParameter("@Item_Id", DbType.Int32);
            SqlPara[18].Value = _objtable.Item_Id;
            return commonFunction.InsertRecord("SP_INSERTITEMMASTER", SqlPara);
        }

        public Int32 DeleteRecord(DALItemMaster _objtable)
        {
            SqlParameter[] SqlPara = new SqlParameter[4];
            SqlPara[0] = new SqlParameter("@DeletedByID", DbType.Int32);
            SqlPara[0].Value = _objtable.DeletedByID;
            SqlPara[1] = new SqlParameter("@DeletedDate", DbType.String);
            SqlPara[1].Value = _objtable.DeletedDate;
            SqlPara[2] = new SqlParameter("@Flag", DbType.String);
            SqlPara[2].Value = _objtable.Flag;
            SqlPara[3] = new SqlParameter("@Item_Id", DbType.Int32);
            SqlPara[3].Value = _objtable.Item_Id;
            return commonFunction.InsertRecord("SP_INSERTITEMMASTER", SqlPara);
        }

    }
}
