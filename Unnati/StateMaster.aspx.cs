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
    public partial class StateMaster : System.Web.UI.Page
    {
        public static string UserName = "";
        public static string UserId = "";

        DALState dalState = new DALState();
        BALStateMaster balState = new BALStateMaster();

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
            txtStateCode.Text = "";
            txtStateName.Text = "";
        }

        private void FillGrid()
        {
            try
            {
                grdSearch.DataSource = null;
                grdSearch.DataBind();

                dalState.Flag = "FillGrid";

                DataTable dt = new DataTable();
                dt = balState.getState(dalState);
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
                dalState.StateCode = txtStateCode.Text.ToString().Trim();
                dalState.StateName = txtStateName.Text.ToString().Trim();

                if (hdnMode.Value == "I")
                {
                    dalState.CreatedById = Session["UserId"].ToString();
                    dalState.CreatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balState.InsertState(dalState);
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
                    dalState.StateId = hdnID.Value.ToString();
                    dalState.UpdatedById = Session["UserId"].ToString();
                    dalState.UpdatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balState.UpdateState(dalState);
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
                    dalState.StateId = ID;
                    hdnID.Value = ID;
                    dalState.Flag = "SelectOne";
                    DataTable dt = new DataTable();
                    dt = balState.getState(dalState);
                    if (dt.Rows.Count > 0)
                    {
                        hdnID.Value = ID.ToString();
                        hdnMode.Value = "U";
                        txtStateCode.Text = dt.Rows[0]["StateCode"].ToString();
                        txtStateName.Text = dt.Rows[0]["StateName"].ToString();
                    }
                    DivData.Visible = true;
                    DivSearch.Visible = false;

                }

                else if (e.CommandName.Equals("Delete"))
                {

                    string ID = e.CommandArgument.ToString();
                    hdnID.Value = ID;
                    dalState.StateId = ID;
                    dalState.DeletedById = Session["UserId"].ToString();
                    dalState.DeletedDate = System.DateTime.Today.Date.ToShortDateString();

                    int count = balState.DeletetState(dalState);

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