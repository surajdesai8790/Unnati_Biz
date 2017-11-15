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
    public partial class CustomerMaster : System.Web.UI.Page
    {
        public static string UserName = "";
        public static string UserId = "";

        DALCustomerMaster dalCustomer = new DALCustomerMaster();
        BALCustomerMaster balCustomer = new BALCustomerMaster();

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

        private void ClearControl()
        {
            hdnID.Value = "";
            hdnMode.Value = "I";
            txtAccLedgerName.Text = "";
            txtCollectorate.Text = "";
            txtContactPerson.Text = "";
            txtCreditDays.Text = "";
            txtCustAddress.Text = "";
            txtCustCode.Text = "";
            txtCustEmail.Text = "";
            txtCustName.Text = "";
            txtCustPhone.Text = "";
            txtDivision.Text = "";
            txtEccNo.Text = "";
            txtGstin.Text = "";
            txtRange.Text = "";
            drpState.SelectedIndex = 0;
            drpPartyType.SelectedIndex = 0;
           
        }

        private void FillGrid()
        {
            try
            {
                dalCustomer.Flag = "FillGrid";

                DataTable dt = new DataTable();
                dt = balCustomer.getCustomers(dalCustomer);
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

        private void FillStateList()
        {
            try
            {
                dalCustomer.Flag = "GetList";

                DataTable dt = new DataTable();
                dt = balCustomer.getStates(dalCustomer);

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
                
                dalCustomer.AccLedgerName = txtAccLedgerName.Text.ToString().Trim();
                dalCustomer.Address = txtCustAddress.Text.ToString().Trim();
                dalCustomer.Collectorate = txtCollectorate.Text.ToString().Trim();
                dalCustomer.ContactNumber = txtCustPhone.Text.ToString().Trim();
                dalCustomer.ContactPerson = txtContactPerson.Text.ToString().Trim();
                dalCustomer.CreditDays = txtCreditDays.Text.ToString().Trim();
                dalCustomer.CustomerCode = txtCustCode.Text.ToString().Trim();
                dalCustomer.CustomerName = txtCustName.Text.ToString().Trim();
                dalCustomer.Division = txtDivision.Text.ToString().Trim();
                dalCustomer.ECCno = txtEccNo.Text.ToString().Trim();
                dalCustomer.Email = txtCustEmail.Text.ToString().Trim();
                dalCustomer.GSTIN = txtGstin.Text.ToString().Trim();
                dalCustomer.PartyType = drpPartyType.Text.ToString().Trim();
                dalCustomer.Range = txtRange.Text.ToString().Trim();
                dalCustomer.StateId = drpState.SelectedValue.ToString().Trim();
                

                if (hdnMode.Value == "I")
                {
                    dalCustomer.CreatedById = Session["UserId"].ToString();
                    dalCustomer.CreatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balCustomer.InsertCustomer(dalCustomer);
                    if (count <= 0)
                    {
                        FillGrid();
                        ClearControl();
                        FillStateList();
                        // ClientScript.RegisterStartupScript(this.GetType(), "showErrorToast", "showSuccessToast('" + "Tax Inserted Successfully..." + "');", true);
                        DivData.Visible = false;
                        DivSearch.Visible = true;
                    }
                }
                else if (hdnMode.Value == "U")
                {
                    dalCustomer.CustomerId = hdnID.Value.ToString();
                    dalCustomer.UpdatedById = Session["UserId"].ToString();
                    dalCustomer.UpdatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balCustomer.UpdateCustomer(dalCustomer);
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
                    dalCustomer.CustomerId = ID;
                    hdnID.Value = ID;
                    dalCustomer.Flag = "SelectOne";
                    DataTable dt = new DataTable();
                    dt = balCustomer.getCustomers(dalCustomer);
                    if (dt.Rows.Count > 0)
                    {
                        hdnID.Value = ID.ToString();
                        hdnMode.Value = "U";

                        txtAccLedgerName.Text = dt.Rows[0]["AccLedgerName"].ToString();
                        txtCollectorate.Text = dt.Rows[0]["Collectorate"].ToString();
                        txtContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
                        txtCreditDays.Text = dt.Rows[0]["CreditDays"].ToString();
                        txtCustAddress.Text = dt.Rows[0]["Address"].ToString();
                        txtCustCode.Text = dt.Rows[0]["CustomerCode"].ToString();
                        txtCustEmail.Text = dt.Rows[0]["Email"].ToString();
                        txtCustName.Text = dt.Rows[0]["CustomerName"].ToString();
                        txtCustPhone.Text = dt.Rows[0]["ContactNumber"].ToString();
                        txtDivision.Text = dt.Rows[0]["Division"].ToString();
                        txtEccNo.Text = dt.Rows[0]["ECCno"].ToString();
                        txtGstin.Text = dt.Rows[0]["GSTIN"].ToString();
                        txtRange.Text = dt.Rows[0]["Range"].ToString();
                        drpState.SelectedValue = dt.Rows[0]["StateId"].ToString();
                        drpPartyType.Text = dt.Rows[0]["PartyType"].ToString();
                    }
                    DivData.Visible = true;
                    DivSearch.Visible = false;

                }

                else if (e.CommandName.Equals("Delete"))
                {

                    string ID = e.CommandArgument.ToString();
                    hdnID.Value = ID;
                    dalCustomer.CustomerId = ID;
                    dalCustomer.DeletedById = Session["UserId"].ToString();
                    dalCustomer.DeletedDate = System.DateTime.Today.Date.ToShortDateString();

                    int count = balCustomer.DeletetCustomer(dalCustomer);

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