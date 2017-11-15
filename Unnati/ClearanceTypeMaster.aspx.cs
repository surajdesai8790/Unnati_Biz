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
    public partial class ClearanceTypeMaster : System.Web.UI.Page
    {
        public static string UserName = "";
        public static string UserId = "";

        DALClearanceType dalClearance = new DALClearanceType();
        BALClearanceType balClearance = new BALClearanceType();

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

        private void FillGrid()
        {
            try
            {
                grdSearch.DataSource = null;
                grdSearch.DataBind();

                dalClearance.Flag = "FillGrid";

                DataTable dt = new DataTable();
                dt = balClearance.getClearanceTypes(dalClearance);
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

        private void ClearControl()
        {
            hdnID.Value = "";
            hdnMode.Value = "I";

            txtClearanceType.Text = "";
            txtCess.Text = "";
            txtCgstPer.Text = "";
            txtIGSTPer.Text = "";
            txtSGSTPer.Text = "";
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
                dalClearance.ClearanceType = txtClearanceType.Text.ToString().Trim();
                dalClearance.Cess = txtCess.Text.ToString().Trim();
                dalClearance.CGSTPer = txtCgstPer.Text.ToString().Trim();
                dalClearance.IGSTPer = txtIGSTPer.Text.ToString().Trim();
                dalClearance.SGSTPer = txtSGSTPer.Text.ToString().Trim();

                if (hdnMode.Value == "I")
                {
                    dalClearance.CreatedById = Session["UserId"].ToString();
                    dalClearance.CreatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balClearance.InsertClearanceType(dalClearance);
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
                    dalClearance.ClearanceTypeId = hdnID.Value.ToString();
                    dalClearance.UpdatedById = Session["UserId"].ToString();
                    dalClearance.UpdatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balClearance.UpdateClearanceType(dalClearance);
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
                    dalClearance.ClearanceTypeId = ID;
                    hdnID.Value = ID;
                    dalClearance.Flag = "SelectOne";
                    DataTable dt = new DataTable();
                    dt = balClearance.getClearanceTypes(dalClearance);
                    if (dt.Rows.Count > 0)
                    {
                        hdnID.Value = ID.ToString();
                        hdnMode.Value = "U";
                        txtCess.Text = dt.Rows[0]["Cess"].ToString();
                        txtCgstPer.Text = dt.Rows[0]["CGSTPer"].ToString();
                        txtClearanceType.Text = dt.Rows[0]["ClearanceType"].ToString();
                        txtIGSTPer.Text = dt.Rows[0]["IGSTPer"].ToString();
                        txtSGSTPer.Text = dt.Rows[0]["SGSTPer"].ToString();
                    }
                    DivData.Visible = true;
                    DivSearch.Visible = false;

                }

                else if (e.CommandName.Equals("Delete"))
                {

                    string ID = e.CommandArgument.ToString();
                    hdnID.Value = ID;
                    dalClearance.ClearanceTypeId = ID;
                    dalClearance.DeletedById = Session["UserId"].ToString();
                    dalClearance.DeletedDate = System.DateTime.Today.Date.ToShortDateString();

                    int count = balClearance.DeletetClearance(dalClearance);

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