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
    public class BALTaxMaster
    {
        CommonFunctions commonFunction = new CommonFunctions();

        public DataTable getTaxes(DALTaxMaster dalTax)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[2];
            SqlPara[0] = new SqlParameter("@Flag", DbType.String);
            SqlPara[0].Value = dalTax.Flag;
            SqlPara[1] = new SqlParameter("@TaxId", DbType.String);
            SqlPara[1].Value = dalTax.TaxId;
            Dt = commonFunction.SelectRecords("SELECT_TaxMaster", SqlPara);
            return Dt;
        }

        public Int32 InsertTax(DALTaxMaster dalTax)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[3];
            SqlPara[0] = new SqlParameter("@TaxName", DbType.String);
            SqlPara[0].Value = dalTax.TaxName;
            SqlPara[1] = new SqlParameter("@CreatedById", DbType.String);
            SqlPara[1].Value = dalTax.CreatedById;
            SqlPara[2] = new SqlParameter("@CreatedDate", DbType.String);
            SqlPara[2].Value = dalTax.CreatedDate;

            return commonFunction.InsertRecord("INSERT_TaxMaster", SqlPara);
             
        }

        public Int32 UpdateTax(DALTaxMaster dalTax)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[4];
            SqlPara[0] = new SqlParameter("@TaxName", DbType.String);
            SqlPara[0].Value = dalTax.TaxName;
            SqlPara[1] = new SqlParameter("@UpdatedById", DbType.String);
            SqlPara[1].Value = dalTax.UpdatedById;
            SqlPara[2] = new SqlParameter("@UpdatedDate", DbType.String);
            SqlPara[2].Value = dalTax.UpdatedDate;
            SqlPara[3] = new SqlParameter("@TaxId", DbType.String);
            SqlPara[3].Value = dalTax.TaxId;
            return commonFunction.InsertRecord("UPDATE_TaxMaster", SqlPara);

        }

        public Int32 DeletetTax(DALTaxMaster dalTax)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] SqlPara = new SqlParameter[3];
            SqlPara[0] = new SqlParameter("@TaxId", DbType.String);
            SqlPara[0].Value = dalTax.TaxId;
            SqlPara[1] = new SqlParameter("@DeletedById", DbType.String);
            SqlPara[1].Value = dalTax.DeletedById;
            SqlPara[2] = new SqlParameter("@DeletedDate", DbType.String);
            SqlPara[2].Value = dalTax.DeletedDate;

            return commonFunction.InsertRecord("DELETE_TaxMaster", SqlPara);

        }
    }
}
