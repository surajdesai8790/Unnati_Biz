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
    public partial class SuplierMaster : System.Web.UI.Page
    {
        public static string UserName = "";
        public static string UserId = "";

        DALSuplierMaster dalSuplier = new DALSuplierMaster();
        BALSuplierMaster balSuplier = new BALSuplierMaster();

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
                    FillStateList();

                }

            }
        }

        private void FillStateList()
        {
            try
            {
                dalSuplier.Flag = "GetList";

                DataTable dt = new DataTable();
                dt = balSuplier.getStates(dalSuplier);

                DataRow dr = dt.NewRow();
                dr[0] = 0;
                dr[1] = "";
                dr[2] = "-- Select State --";

                dt.Rows.InsertAt(dr, 0);

                if (dt.Rows.Count > 0)
                {
                    drpState.DataSource = dt;
                    drpState.DataTextField = "StateName";
                    drpState.DataValueField = "StateId";
                    drpState.DataBind();
                    dt.Dispose();
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private void ClearControl()
        {
            hdnID.Value = "";
            hdnMode.Value = "I";

            txtAccLedgerName.Text = "";
            txtCollectorate.Text = "";
            txtContactPerson.Text = "";
            txtCreditDays.Text = "";
            txtDivision.Text = "";
            txtEccNo.Text = "";
            txtGstin.Text = "";
            txtRange.Text = "";
            drpState.SelectedIndex = 0;
            txtSuplierAddress.Text = "";
            txtSuplierCode.Text = "";
            txtSuplierEmail.Text = "";
            txtSuplierName.Text = "";
            txtSuplierPhone.Text = "";

            drpPartyType.SelectedIndex = 0;

        }

        private void FillGrid()
        {
            try
            {
                dalSuplier.Flag = "FillGrid";

                DataTable dt = new DataTable();
                dt = balSuplier.getSupliers(dalSuplier);
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
                dalSuplier.AccLedgerName = txtAccLedgerName.Text.ToString().Trim();
                dalSuplier.Address = txtSuplierAddress.Text.ToString().Trim();
                dalSuplier.Colloctorate = txtCollectorate.Text.ToString().Trim();
                dalSuplier.ContactNumber = txtSuplierPhone.Text.ToString().Trim();
                dalSuplier.ContactPerson = txtContactPerson.Text.ToString().Trim();
                dalSuplier.CreditDays = txtCreditDays.Text.ToString().Trim();
                dalSuplier.Division = txtDivision.Text.ToString().Trim();
                dalSuplier.ECCno = txtEccNo.Text.ToString().Trim();
                dalSuplier.Email = txtSuplierEmail.Text.ToString().Trim();
                dalSuplier.GSTIN = txtGstin.Text.ToString().Trim();
                dalSuplier.PartyType = drpPartyType.Text.ToString().Trim();
                dalSuplier.Range = txtRange.Text.ToString().Trim();
                dalSuplier.StateId = drpState.SelectedValue.ToString().Trim();
                dalSuplier.SuplierCode = txtSuplierCode.Text.ToString().Trim();
                dalSuplier.SuplierName = txtSuplierName.Text.ToString().Trim();


                if (hdnMode.Value == "I")
                {
                    dalSuplier.CreatedById = Session["UserId"].ToString();
                    dalSuplier.CreatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balSuplier.InsertSuplier(dalSuplier);
                    if (count <= 0)
                    {
                        FillGrid();
                        FillStateList();
                        ClearControl();
                        // ClientScript.RegisterStartupScript(this.GetType(), "showErrorToast", "showSuccessToast('" + "Tax Inserted Successfully..." + "');", true);
                        DivData.Visible = false;
                        DivSearch.Visible = true;
                    }
                }
                else if (hdnMode.Value == "U")
                {
                    dalSuplier.SuplierId = hdnID.Value.ToString();
                    dalSuplier.UpdatedById = Session["UserId"].ToString();
                    dalSuplier.UpdatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balSuplier.UpdateSuplier(dalSuplier);
                    if (count <= 0)
                    {
                        FillGrid();
                        ClearControl();
                        FillStateList();
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
                    dalSuplier.SuplierId = ID;
                    hdnID.Value = ID;
                    dalSuplier.Flag = "SelectOne";
                    DataTable dt = new DataTable();
                    dt = balSuplier.getSupliers(dalSuplier);
                    if (dt.Rows.Count > 0)
                    {
                        hdnID.Value = ID.ToString();
                        hdnMode.Value = "U";
                        txtAccLedgerName.Text = dt.Rows[0]["AccLedgerName"].ToString();
                        txtCollectorate.Text = dt.Rows[0]["Colloctorate"].ToString();
                        txtContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
                        txtCreditDays.Text = dt.Rows[0]["CreditDays"].ToString();
                        txtDivision.Text = dt.Rows[0]["Division"].ToString();
                        txtEccNo.Text = dt.Rows[0]["ECCno"].ToString();
                        txtGstin.Text = dt.Rows[0]["GSTIN"].ToString();
                        txtRange.Text = dt.Rows[0]["Range"].ToString();
                        drpState.SelectedValue = dt.Rows[0]["StateId"].ToString();
                        txtSuplierAddress.Text = dt.Rows[0]["Address"].ToString();
                        txtSuplierCode.Text = dt.Rows[0]["SuplierCode"].ToString();
                        txtSuplierEmail.Text = dt.Rows[0]["Email"].ToString();
                        txtSuplierName.Text = dt.Rows[0]["SuplierName"].ToString();
                        txtSuplierPhone.Text = dt.Rows[0]["ContactNumber"].ToString();
                        drpPartyType.Text = dt.Rows[0]["PartyType"].ToString();
                    }
                    DivData.Visible = true;
                    DivSearch.Visible = false;

                }

                else if (e.CommandName.Equals("Delete"))
                {

                    string ID = e.CommandArgument.ToString();
                    hdnID.Value = ID;
                    dalSuplier.SuplierId = ID;
                    dalSuplier.DeletedById = Session["UserId"].ToString();
                    dalSuplier.DeletedDate = System.DateTime.Today.Date.ToShortDateString();

                    int count = balSuplier.DeletetSuplier(dalSuplier);

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