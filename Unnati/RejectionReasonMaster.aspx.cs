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
    public partial class RejectionReasonMaster : System.Web.UI.Page
    {
        public static string UserName = "";
        public static string UserId = "";

        DALReasonMaster dalReason = new DALReasonMaster();
        BALReason balReason = new BALReason();

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
            txtRejectionCode.Text = "";
            txtRejectionReason.Text = "";

        }

        private void FillGrid()
        {
            try
            {
                grdSearch.DataSource = null;
                grdSearch.DataBind();

                dalReason.Flag = "FillGrid";

                DataTable dt = new DataTable();
                dt = balReason.getReason(dalReason);
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
                dalReason.ReasonCode = txtRejectionCode.Text.ToString().Trim();
                dalReason.Reason = txtRejectionReason.Text.ToString().Trim();

                if (hdnMode.Value == "I")
                {
                    dalReason.CreatedById = Session["UserId"].ToString();
                    dalReason.CreatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balReason.InsertReason(dalReason);
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
                    dalReason.ReasonId = hdnID.Value.ToString();
                    dalReason.UpdatedById = Session["UserId"].ToString();
                    dalReason.UpdatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balReason.UpdateReason(dalReason);
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
                    dalReason.ReasonId = ID;
                    hdnID.Value = ID;
                    dalReason.Flag = "SelectOne";
                    DataTable dt = new DataTable();
                    dt = balReason.getReason(dalReason);
                    if (dt.Rows.Count > 0)
                    {
                        hdnID.Value = ID.ToString();
                        hdnMode.Value = "U";
                        txtRejectionCode.Text = dt.Rows[0]["ReasonCode"].ToString();
                        txtRejectionReason.Text = dt.Rows[0]["Reason"].ToString();
                    }
                    DivData.Visible = true;
                    DivSearch.Visible = false;

                }

                else if (e.CommandName.Equals("Delete"))
                {

                    string ID = e.CommandArgument.ToString();
                    hdnID.Value = ID;
                    dalReason.ReasonId = ID;
                    dalReason.DeletedById = Session["UserId"].ToString();
                    dalReason.DeletedDate = System.DateTime.Today.Date.ToShortDateString();

                    int count = balReason.DeletetReason(dalReason);

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