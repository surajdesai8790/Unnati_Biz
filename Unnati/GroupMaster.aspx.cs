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
    public partial class GroupMaster : System.Web.UI.Page
    {
        public static string UserName = "";
        public static string UserId = "";
        DALGroupMaster _dalgroup = new DALGroupMaster();
        BALGroupMaster _balgroup = new BALGroupMaster();
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
                _dalgroup.Flag = "FillGrid";
                DataTable dt = new DataTable();
                dt = _balgroup.GETRecord(_dalgroup);
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
            txtGroupName.Text = "";
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
                    _dalgroup.Group_Id = Convert.ToInt32(ID);
                    hdnID.Value = ID;
                    _dalgroup.Flag = "SelectOne";
                    DataTable dt = new DataTable();
                    dt = _balgroup.GETSINGLERECORD(_dalgroup);
                    if (dt.Rows.Count > 0)
                    {
                        hdnID.Value = ID.ToString();
                        hdnMode.Value = "U";
                        txtGroupName.Text = dt.Rows[0]["Group_Name"].ToString();
                       
                    }
                    DivData.Visible = true;
                    DivSearch.Visible = false;

                }

                else if (e.CommandName.Equals("Delete"))
                {

                    string ID = e.CommandArgument.ToString();
                    hdnID.Value = ID;
                    _dalgroup.Group_Id = Convert.ToInt32(ID);
                    _dalgroup.Flag = "Delete";
                    _dalgroup.DeletedByID = Convert.ToInt32(Session["UserId"].ToString());
                    _dalgroup.DeletedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = _balgroup.DeleteRecord(_dalgroup);
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
                _strisexist = commonFunction.IsExist("TblGroup_Master", "IsDeleted=0 and Group_Name='" + txtGroupName.Text + "'");
                if (_strisexist == 0)
                {
                    
                    _dalgroup.Group_Name = txtGroupName.Text.ToString().Trim();

                    if (hdnMode.Value == "I")
                    {
                        _dalgroup.CreatedByID = Convert.ToInt32(Session["UserId"].ToString());
                        _dalgroup.CreatedDate = System.DateTime.Today.Date.ToShortDateString();
                        _dalgroup.Flag = "Insert";
                        int count = _balgroup.InsertRecord(_dalgroup);
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
                        _dalgroup.Group_Id = Convert.ToInt32(hdnID.Value.ToString());
                        _dalgroup.UpdatedByID = Convert.ToInt32(Session["UserId"].ToString());
                        _dalgroup.UpdatedDate = System.DateTime.Today.Date.ToShortDateString();
                        _dalgroup.Flag = "Update";
                        int count = _balgroup.UpdateRecord(_dalgroup);
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