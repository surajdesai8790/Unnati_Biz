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
    public partial class TaxMaster : System.Web.UI.Page
    {
        public static string UserName = "";
        public static string UserId = "";

        DALTaxMaster dalTax = new DALTaxMaster();
        BALTaxMaster balTax = new BALTaxMaster();

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
            txtTaxName.Text = "";
        }

        private void FillGrid()
        {
            try
            {
                grdSearch.DataSource = null;
                grdSearch.DataBind();

                dalTax.Flag = "FillGrid";

                DataTable dt = new DataTable();
                dt = balTax.getTaxes(dalTax);
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
                dalTax.TaxName = txtTaxName.Text.ToString().Trim();
               

                if (hdnMode.Value == "I")
                {
                    dalTax.CreatedById = Session["UserId"].ToString();
                    dalTax.CreatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balTax.InsertTax(dalTax);
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
                    dalTax.TaxId = hdnID.Value.ToString();
                    dalTax.UpdatedById = Session["UserId"].ToString();
                    dalTax.UpdatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balTax.UpdateTax(dalTax);
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
                    dalTax.TaxId = ID;
                    hdnID.Value = ID;
                    dalTax.Flag = "SelectOne";
                    DataTable dt = new DataTable();
                    dt = balTax.getTaxes(dalTax);
                    if (dt.Rows.Count > 0)
                    {
                        hdnID.Value = ID.ToString();
                        hdnMode.Value = "U";
                        txtTaxName.Text = dt.Rows[0]["TaxName"].ToString();
                    }
                    DivData.Visible = true;
                    DivSearch.Visible = false;
                    
                }

                else if (e.CommandName.Equals("Delete"))
                {

                    string ID = e.CommandArgument.ToString();
                    hdnID.Value = ID;
                    dalTax.TaxId = ID;
                    dalTax.DeletedById = Session["UserId"].ToString();
                    dalTax.DeletedDate = System.DateTime.Today.Date.ToShortDateString();

                    int count = balTax.DeletetTax(dalTax);
                    
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