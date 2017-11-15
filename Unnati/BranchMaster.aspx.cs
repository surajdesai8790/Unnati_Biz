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
    
    public partial class BranchMaster : System.Web.UI.Page
    {
        public static string UserName = "";
        public static string UserId = "";
        DALBranchMaster _dalbranch = new DALBranchMaster();
        BALBranchMaster _balbranch = new BALBranchMaster();
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
                    chkIsActive.Checked = true;

                }
                
                
            }
        }

        private void FillGrid()
        {
            try
            {
                grdSearch.DataSource = null;
                grdSearch.DataBind();
               _dalbranch.Flag = "FillGrid";
                DataTable dt = new DataTable();
                dt = _balbranch.GETBRANCH(_dalbranch);
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
            txtBranchName.Text = "";
            txtBranchAddress.Text = "";
            txtBranchContact.Text = "";
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
                    _dalbranch.Branch_Id = Convert .ToInt32 (ID);
                    hdnID.Value = ID;
                    _dalbranch.Flag = "SelectOne";
                    DataTable dt = new DataTable();
                    dt = _balbranch.GETSINGLEBRANCH(_dalbranch);
                    if (dt.Rows.Count > 0)
                    {
                        hdnID.Value = ID.ToString();
                        hdnMode.Value = "U";
                        txtBranchName.Text = dt.Rows[0]["Branch_Name"].ToString();
                        txtBranchAddress.Text = dt.Rows[0]["Branch_Address"].ToString();
                        txtBranchContact.Text = dt.Rows[0]["Contact_No"].ToString();
                        Boolean  _stractive =Convert.ToBoolean ( dt.Rows[0]["IsActive"]);
                        if (_stractive == true)
                        {
                            chkIsActive.Checked = true;
                        }
                        else{
                            chkIsActive.Checked = false;
                        }

                        
                    }
                    DivData.Visible = true;
                    DivSearch.Visible = false;
                    txtBranchName.Enabled = false;

                }

                else if (e.CommandName.Equals("Delete"))
                {

                    string ID = e.CommandArgument.ToString();
                    hdnID.Value = ID;
                    _dalbranch.Branch_Id = Convert.ToInt32(ID);
                    _dalbranch.Flag = "Delete";
                    _dalbranch.DeletedByID = Convert.ToInt32(Session["UserId"].ToString());
                    _dalbranch.DeletedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = _balbranch.DeleteBranch(_dalbranch);
                                        //  ClientScript.RegisterStartupScript(this.GetType(), "showErrorToast", "showSuccessToast('" + "Tax Deleted Successfully..." + "');", true);
                    ClearText();
                    FillGrid();


                }
            }
            catch (Exception Ex)
            {
                throw;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 _strisexist;
             
                    _dalbranch.Branch_Address = txtBranchAddress.Text.ToString().Trim();
                    _dalbranch.Branch_Name = txtBranchName.Text.ToString().Trim();
                    _dalbranch.Contact_No = txtBranchContact.Text.ToString().Trim();

                    if (hdnMode.Value == "I")
                    {
                        _strisexist = commonFunction.IsExist("TblBranch_Master", "IsDeleted=0 and Branch_Name='" + txtBranchName.Text + "'");
                        if (_strisexist == 0)
                        {
                        _dalbranch.CreatedByID = Convert.ToInt32(Session["UserId"].ToString());
                        _dalbranch.CreatedDate = System.DateTime.Today.Date.ToShortDateString();
                        _dalbranch.Flag = "Insert";
                        int count = _balbranch.InsertBranch(_dalbranch);
                        if (count > 0)
                        {
                            FillGrid();
                            ClearText();
                            ClientScript.RegisterStartupScript(this.GetType(), "showErrorToast", "showSuccessToast('" + "Branch Updated Successfully..." + "');", true);
                            DivData.Visible = false;
                            DivSearch.Visible = true;
                        }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "showErrorToast", "showSuccessToast('" + "Branch Name allready Exist..." + "');", true);
                        }
                    }
                    else if (hdnMode.Value == "U")
                    {
                        _dalbranch.Branch_Id = Convert.ToInt32(hdnID.Value.ToString());
                        _dalbranch.UpdatedByID = Convert.ToInt32(Session["UserId"].ToString());
                        _dalbranch.UpdatedDate = System.DateTime.Today.Date.ToShortDateString();
                        _dalbranch.Flag = "Update";
                        int count = _balbranch.UpdateBranch(_dalbranch);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}