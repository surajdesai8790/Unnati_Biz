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
    public partial class HsnSacMaster : System.Web.UI.Page
    {
        public static string UserName = "";
        public static string UserId = "";

        DALHsnCode dalHsn = new DALHsnCode();
        BALHsnCode balHsn = new BALHsnCode();

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

                    ClearControl();
                    FillGrid();

                }

            }
        }

        private void ClearControl()
        {
            hdnID.Value = "";
            hdnMode.Value = "I";
            txtDescription.Text = "";
            txtGSTCategory.Text = "";
            txtHSNCode.Text = "";
            chkIsActive.Checked = false;
        }

        private void FillGrid()
        {
            try
            {
                grdSearch.DataSource = null;
                grdSearch.DataBind();

                dalHsn.Flag = "FillGrid";

                DataTable dt = new DataTable();
                dt = balHsn.getHsnCodes(dalHsn);
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

        protected void btnNew_Click(object sender, EventArgs e)
        {
            DivData.Visible = true;
            DivSearch.Visible = false;
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FillGrid();
            ClearControl();
            DivData.Visible = false;
            DivSearch.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dalHsn.HsnCode = txtHSNCode.Text.ToString().Trim();
                dalHsn.Description = txtDescription.Text.ToString().Trim();
                dalHsn.GstCategory = txtGSTCategory.Text.ToString().Trim();
                if (chkIsActive.Checked == true)
                {
                    dalHsn.IsActive = "True";
                }
                else
                {
                    dalHsn.IsActive = "False";
                }
                if (hdnMode.Value == "I")
                {
                    dalHsn.CreatedById = Session["UserId"].ToString();
                    dalHsn.CreatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balHsn.InsertHsnCode(dalHsn);
                    if (count <= 0)
                    {
                        FillGrid();
                        ClearControl();
                        // ClientScript.RegisterStartupScript(this.GetType(), "showErrorToast", "showSuccessToast('" + "Tax Inserted Successfully..." + "');", true);
                        DivData.Visible = false;
                        DivSearch.Visible = true;
                    }
                }
                else if (hdnMode.Value == "U")
                {
                    dalHsn.HsnId = hdnID.Value.ToString();
                    dalHsn.UpdatedById = Session["UserId"].ToString();
                    dalHsn.UpdatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balHsn.UpdateHsnCode(dalHsn);
                    if (count <= 0)
                    {
                        FillGrid();
                        ClearControl();
                        // ClientScript.RegisterStartupScript(this.GetType(), "showErrorToast", "showSuccessToast('" + "Tax Updated Successfully..." + "');", true);
                        DivData.Visible = false;
                        DivSearch.Visible = true;
                    }
                }
            }
            catch (Exception)
            {

            }
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

        protected void grdSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Edit"))
                {
                    string ID = e.CommandArgument.ToString();
                    dalHsn.HsnId  = ID;
                    hdnID.Value = ID;
                    dalHsn.Flag = "SelectOne";
                    DataTable dt = new DataTable();
                    dt = balHsn.getHsnCodes(dalHsn);
                    if (dt.Rows.Count > 0)
                    {
                        hdnID.Value = ID.ToString();
                        hdnMode.Value = "U";
                        txtDescription.Text = dt.Rows[0]["Description"].ToString();
                        txtGSTCategory.Text = dt.Rows[0]["GstCategory"].ToString();
                        txtHSNCode.Text = dt.Rows[0]["HsnCode"].ToString();
                        chkIsActive.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    }
                    DivData.Visible = true;
                    DivSearch.Visible = false;

                }

                else if (e.CommandName.Equals("Delete"))
                {

                    string ID = e.CommandArgument.ToString();
                    hdnID.Value = ID;
                    dalHsn.HsnId = ID;
                    dalHsn.DeletedBy = Session["UserId"].ToString();
                    dalHsn.DeletedDate = System.DateTime.Today.Date.ToShortDateString();

                    int count = balHsn.DeletetHsnCode(dalHsn);

                    //  ClientScript.RegisterStartupScript(this.GetType(), "showErrorToast", "showSuccessToast('" + "Tax Deleted Successfully..." + "');", true);
                    ClearControl();
                    FillGrid();


                }
            }
            catch (Exception Ex)
            {
                throw;
            }
        }
    }
}