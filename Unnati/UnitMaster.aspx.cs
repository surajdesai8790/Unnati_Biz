using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BAL;
using System.Data;

namespace Unnati
{
    public partial class UnitMaster : System.Web.UI.Page
    {
        public static string UserName = "";
        public static string UserId = "";
        DALUnitMaster _dalunit = new DALUnitMaster();
        BALUnitMaster _balunit = new BALUnitMaster();
        CommonFunctions commonFunction = new CommonFunctions();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["UserName"] == null && Session["UserId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    UserName = Session["UserName"].ToString();
                    UserId = Session["UserId"].ToString();
                    DivData.Visible = false;
                    DivSearch.Visible = true;
                    ClearText();
                    FillGrid();

                }


            }
        }

        private void FillGrid()
        {
            try
            {
                grdSearch.DataSource = null;
                grdSearch.DataBind();
                _dalunit.Flag = "FillGrid";
                DataTable dt = new DataTable();
                dt = _balunit.GETRecord(_dalunit);
                if (dt.Rows.Count > 0)
                {
                    grdSearch.DataSource = dt;
                    grdSearch.DataBind();
                    if (grdSearch.Rows.Count > 0)
                    {
                        grdSearch.UseAccessibleHeader = true;
                        grdSearch.HeaderRow.TableSection = TableRowSection.TableHeader;
                        grdSearch.FooterRow.TableSection = TableRowSection.TableFooter;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public void ClearText()
        {
            txtUnitName.Text = "";
            hdnID.Value = "";
            hdnMode.Value = "I";
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            DivData.Visible = true;
            DivSearch.Visible = false;
        }

        protected void grdSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSearch.PageIndex = e.NewPageIndex;
            FillGrid();
        }

        protected void grdSearch_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdSearch_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.NewEditIndex = -1;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FillGrid();
            ClearText();
            DivData.Visible = false;
            DivSearch.Visible = true;
        }

        protected void grdSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Edit"))
                {
                    string ID = e.CommandArgument.ToString();
                    _dalunit.Unit_Id = Convert.ToInt32(ID);
                    hdnID.Value = ID;
                    _dalunit.Flag = "SelectOne";
                    DataTable dt = new DataTable();
                    dt = _balunit.GETSINGLERECORD(_dalunit);
                    if (dt.Rows.Count > 0)
                    {
                        hdnID.Value = ID.ToString();
                        hdnMode.Value = "U";
                        txtUnitName.Text = dt.Rows[0]["Unit_Name"].ToString();

                    }
                    DivData.Visible = true;
                    DivSearch.Visible = false;

                }

                else if (e.CommandName.Equals("Delete"))
                {

                    string ID = e.CommandArgument.ToString();
                    hdnID.Value = ID;
                    _dalunit.Unit_Id = Convert.ToInt32(ID);
                    _dalunit.Flag = "Delete";
                    _dalunit.DeletedByID = Convert.ToInt32(Session["UserId"].ToString());
                    _dalunit.DeletedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = _balunit.DeleteRecord(_dalunit);
                    //  ClientScript.RegisterStartupScript(this.GetType(), "showErrorToast", "showSuccessToast('" + "Tax Deleted Successfully..." + "');", true);
                    ClearText();
                    FillGrid();


                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 _strisexist;
                _strisexist = commonFunction.IsExist("TblUnit_Master", "IsDeleted=0 and Unit_Name='" + txtUnitName.Text + "'");
                if (_strisexist == 0)
                {

                    _dalunit.Unit_Name = txtUnitName.Text.ToString().Trim();

                    if (hdnMode.Value == "I")
                    {
                        _dalunit.CreatedByID = Convert.ToInt32(Session["UserId"].ToString());
                        _dalunit.CreatedDate = System.DateTime.Today.Date.ToShortDateString();
                        _dalunit.Flag = "Insert";
                        int count = _balunit.InsertRecord(_dalunit);
                        if (count > 0)
                        {
                            FillGrid();
                            ClearText();
                            ClientScript.RegisterStartupScript(this.GetType(), "showErrorToast", "showSuccessToast('" + "Branch Updated Successfully..." + "');", true);
                            DivData.Visible = false;
                            DivSearch.Visible = true;
                        }
                    }
                    else if (hdnMode.Value == "U")
                    {
                        _dalunit.Unit_Id = Convert.ToInt32(hdnID.Value.ToString());
                        _dalunit.UpdatedByID = Convert.ToInt32(Session["UserId"].ToString());
                        _dalunit.UpdatedDate = System.DateTime.Today.Date.ToShortDateString();
                        _dalunit.Flag = "Update";
                        int count = _balunit.UpdateRecord(_dalunit);
                        if (count > 0)
                        {
                            FillGrid();
                            ClearText();
                            ClientScript.RegisterStartupScript(this.GetType(), "showErrorToast", "showSuccessToast('" + "Branch Updated Successfully..." + "');", true);
                            DivData.Visible = false;
                            DivSearch.Visible = true;
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "showErrorToast", "showSuccessToast('" + "Branch Name allready Exist..." + "');", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}