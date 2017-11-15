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
    public partial class CategoryMaster : System.Web.UI.Page
    {

        public static string UserName = "";
        public static string UserId = "";
        DALCategoryMaster _dalcategory = new DALCategoryMaster();
        BALCategoryMaster _balcategory = new BALCategoryMaster();
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
                    commonFunction.FillDropDownList(drpGroup, "Group_Id", "Group_Name", "TblGroup_Master", "IsDeleted=0");
                }


            }
        }
       
        private void FillGrid()
        {
            try
            {
                grdSearch.DataSource = null;
                grdSearch.DataBind();
                _dalcategory.Flag = "FillGrid";
                DataTable dt = new DataTable();
                dt = _balcategory.GETRecord(_dalcategory);
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
            txtCategoryName.Text = "";
            drpGroup.ClearSelection();
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
                    _dalcategory.Category_Id = Convert.ToInt32(ID);
                    hdnID.Value = ID;
                    _dalcategory.Flag = "SelectOne";
                    DataTable dt = new DataTable();
                    dt = _balcategory.GETSINGLERECORD(_dalcategory);
                    if (dt.Rows.Count > 0)
                    {
                        hdnID.Value = ID.ToString();
                        hdnMode.Value = "U";
                        commonFunction.FillDropDownList(drpGroup, "Group_Id", "Group_Name", "TblGroup_Master", "IsDeleted=0");
                        txtCategoryName.Text = dt.Rows[0]["Category_Name"].ToString();
                        drpGroup.SelectedValue = dt.Rows[0]["Group_Id"].ToString();

                    }
                    DivData.Visible = true;
                    DivSearch.Visible = false;

                }

                else if (e.CommandName.Equals("Delete"))
                {

                    string ID = e.CommandArgument.ToString();
                    hdnID.Value = ID;
                    _dalcategory.Category_Id = Convert.ToInt32(ID);
                    _dalcategory.Flag = "Delete";
                    _dalcategory.DeletedByID = Convert.ToInt32(Session["UserId"].ToString());
                    _dalcategory.DeletedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = _balcategory.DeleteRecord(_dalcategory);
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
                _strisexist = commonFunction.IsExist("TblCategory_Master", "IsDeleted=0 and Category_Name='" + txtCategoryName.Text + "'  and  Group_Id=" + drpGroup.SelectedValue  + " ");
                if (_strisexist == 0)
                {
                    _dalcategory.Category_Name= txtCategoryName.Text.ToString().Trim();
                    _dalcategory.Group_Id = Convert.ToInt32 (drpGroup.SelectedValue);

                    if (hdnMode.Value == "I")
                    {
                        _dalcategory.CreatedByID = Convert.ToInt32(Session["UserId"].ToString());
                        _dalcategory.CreatedDate = System.DateTime.Today.Date.ToShortDateString();
                        _dalcategory.Flag = "Insert";
                        int count = _balcategory.InsertRecord(_dalcategory);
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
                        _dalcategory.Category_Id = Convert.ToInt32(hdnID.Value.ToString());
                        _dalcategory.UpdatedByID = Convert.ToInt32(Session["UserId"].ToString());
                        _dalcategory.UpdatedDate = System.DateTime.Today.Date.ToShortDateString();
                        _dalcategory.Flag = "Update";
                        int count = _balcategory.UpdateRecord(_dalcategory);
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