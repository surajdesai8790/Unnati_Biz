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
    public partial class ProcessMaster : System.Web.UI.Page
    {
        public static string UserName = "";
        public static string UserId = "";

        DALProcess dalProcess = new DALProcess();
        BALProscess balProcess = new BALProscess();

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
            txtProcessCode.Text = "";
            txtProcessName.Text = "";
        }

        private void FillGrid()
        {
            try
            {
                grdSearch.DataSource = null;
                grdSearch.DataBind();

                dalProcess.Flag = "FillGrid";

                DataTable dt = new DataTable();
                dt = balProcess.getProcess(dalProcess);
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
                dalProcess.ProcessCode = txtProcessCode.Text.ToString().Trim();
                dalProcess.ProcessName = txtProcessName.Text.ToString().Trim();

                if (hdnMode.Value == "I")
                {
                    dalProcess.CreatedById = Session["UserId"].ToString();
                    dalProcess.CreatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balProcess.InsertProcess(dalProcess);
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
                    dalProcess.ProcessId = hdnID.Value.ToString();
                    dalProcess.UpdatedById = Session["UserId"].ToString();
                    dalProcess.UpdatedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = balProcess.UpdateProcess(dalProcess);
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
                    dalProcess.ProcessId = ID;
                    hdnID.Value = ID;
                    dalProcess.Flag = "SelectOne";
                    DataTable dt = new DataTable();
                    dt = balProcess.getProcess(dalProcess);
                    if (dt.Rows.Count > 0)
                    {
                        hdnID.Value = ID.ToString();
                        hdnMode.Value = "U";
                        txtProcessCode.Text = dt.Rows[0]["ProcessCode"].ToString();
                        txtProcessName.Text = dt.Rows[0]["ProcessName"].ToString();
                    }
                    DivData.Visible = true;
                    DivSearch.Visible = false;

                }

                else if (e.CommandName.Equals("Delete"))
                {

                    string ID = e.CommandArgument.ToString();
                    hdnID.Value = ID;
                    dalProcess.ProcessId = ID;
                    dalProcess.DeletedById = Session["UserId"].ToString();
                    dalProcess.DeletedDate = System.DateTime.Today.Date.ToShortDateString();

                    int count = balProcess.DeletetProcess(dalProcess);

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