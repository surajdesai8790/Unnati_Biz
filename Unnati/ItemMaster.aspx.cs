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
    public partial class ItemMaster : System.Web.UI.Page
    {

        public static string UserName = "";
        public static string UserId = "";
        DALItemMaster _dalitem = new DALItemMaster();
        BALItemMaster _balitem = new BALItemMaster();
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
                    commonFunction.FillDropDownList(drpUnit , "Unit_Id", "Unit_Name", "TblUnit_Master", "IsDeleted=0");
                    commonFunction.FillDropDownList(drpHSN, "HsnId", "HsnCode", "HsnCodeMaster", "IsDeleted=0");

                }


            }
        }

        private void FillGrid()
        {
            try
            {
                grdSearch.DataSource = null;
                grdSearch.DataBind();
                _dalitem.Flag = "FillGrid";
                DataTable dt = new DataTable();
                dt = _balitem.GETRecord(_dalitem);
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
            txtDrawingNo.Text = "";
            txtFinishRate.Text = "0.00";
            txtItemCode.Text ="";
            txtItemName .Text ="";
            txtLevel.Text ="";
            txtMetalSpesification .Text ="";
            txtNetWeight .Text ="0.00";
            txtPack.Text ="0.00";
            txtQTy.Text ="0.00";
            txtRevNo.Text = "";
            txtWipRate.Text = "0.00";
            drpGroup.ClearSelection();
            drpCategory.ClearSelection();
            drpHSN.ClearSelection();
            drpUnit.ClearSelection();
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
                    _dalitem.Item_Id = Convert.ToInt32(ID);
                    hdnID.Value = ID;
                    _dalitem.Flag = "SelectOne";
                    DataTable dt = new DataTable();
                    dt = _balitem.GETSINGLERECORD(_dalitem);
                    if (dt.Rows.Count > 0)
                    {
                        hdnID.Value = ID.ToString();
                        hdnMode.Value = "U";
                        commonFunction.FillDropDownList(drpGroup, "Group_Id", "Group_Name", "TblGroup_Master", "IsDeleted=0");
                        commonFunction.FillDropDownList(drpUnit, "Unit_Id", "Unit_Name", "TblUnit_Master", "IsDeleted=0");
                        commonFunction.FillDropDownList(drpHSN, "HsnId", "HsnCode", "HsnCodeMaster", "IsDeleted=0");
                        txtItemName.Text = dt.Rows[0]["Item_Name"].ToString();
                        drpGroup.SelectedValue = dt.Rows[0]["Group_Id"].ToString();
                        commonFunction.FillDropDownList(drpCategory , "Category_Id", "Category_Name", "TblCategory_Master", "IsDeleted=0 and Group_Id="+drpGroup.SelectedValue +"");
                        txtDrawingNo.Text = dt.Rows[0]["Drawing_No"].ToString();
                        txtFinishRate.Text = dt.Rows[0]["Finish_Rate"].ToString();
                        txtItemCode.Text = dt.Rows[0]["Item_Code"].ToString();
                        txtLevel.Text = dt.Rows[0]["Item_Level"].ToString();
                        txtMetalSpesification.Text = dt.Rows[0]["Metel_Sec"].ToString();
                        txtNetWeight.Text = dt.Rows[0]["Net_Weight"].ToString();
                        txtPack.Text = dt.Rows[0]["Qty_Pack"].ToString();
                        txtQTy.Text = dt.Rows[0]["Qty"].ToString();
                        txtRevNo.Text = dt.Rows[0]["Rev_No"].ToString();
                        txtWipRate.Text = dt.Rows[0]["WIP_Rate"].ToString();
                        drpCategory.SelectedValue = dt.Rows[0]["Category_Id"].ToString();
                        drpHSN.SelectedValue = dt.Rows[0]["HSN_Code"].ToString();
                        drpUnit.SelectedValue = dt.Rows[0]["Unit_Id"].ToString();
                        txtItemName.Enabled = false;
                    }
                    DivData.Visible = true;
                    DivSearch.Visible = false;

                }

                else if (e.CommandName.Equals("Delete"))
                {

                    string ID = e.CommandArgument.ToString();
                    hdnID.Value = ID;
                    _dalitem.Item_Id = Convert.ToInt32(ID);
                    _dalitem.Flag = "Delete";
                    _dalitem.DeletedByID = Convert.ToInt32(Session["UserId"].ToString());
                    _dalitem.DeletedDate = System.DateTime.Today.Date.ToShortDateString();
                    int count = _balitem.DeleteRecord(_dalitem);
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
              
                    _dalitem.Item_Name = txtItemName.Text.ToString().Trim();
                    _dalitem.Group_Id = Convert.ToInt32(drpGroup.SelectedValue);
                    _dalitem.Category_Id = Convert.ToInt32(drpCategory.SelectedValue);
                    _dalitem.Item_Code = txtItemCode.Text.Trim();
                    _dalitem.Drawing_No = txtDrawingNo.Text.Trim();
                    _dalitem.Rev_No = txtRevNo.Text.Trim();
                    _dalitem.Unit_Id = Convert.ToInt32(drpUnit.SelectedValue );
                    _dalitem.HSN_Code = Convert.ToInt32(drpHSN.SelectedValue);
                    _dalitem.WIP_Rate =commonFunction.CheckIsNull (txtWipRate.Text);
                    _dalitem.Finish_Rate = commonFunction.CheckIsNull(txtFinishRate.Text);
                    _dalitem.Net_Weight = commonFunction.CheckIsNull(txtNetWeight.Text);
                    _dalitem.Item_Level = txtLevel.Text;
                    _dalitem.Metel_Sec = txtMetalSpesification.Text;
                    _dalitem.Qty = commonFunction.CheckIsNull(txtQTy.Text);
                    _dalitem.Qty_Pack = commonFunction.CheckIsNull(txtPack.Text);

                    if (hdnMode.Value == "I")
                    {

                        _strisexist = commonFunction.IsExist("TblItem_Master", "IsDeleted=0 and Item_Name='" + txtItemName.Text + "'  and  Group_Id=" + drpGroup.SelectedValue + " and Category_Id=" + drpCategory.SelectedValue + " ");
                        if (_strisexist == 0)
                        {
                        _dalitem.CreatedByID = Convert.ToInt32(Session["UserId"].ToString());
                        _dalitem.CreatedDate = System.DateTime.Today.Date.ToShortDateString();
                        _dalitem.Flag = "Insert";
                        int count = _balitem.InsertRecord(_dalitem);
                        if (count > 0)
                        {
                            FillGrid();
                            ClearText();
                            ClientScript.RegisterStartupScript(this.GetType(), "showErrorToast", "showSuccessToast('" + "Branch Updated Successfully..." + "');", true);
                            DivData.Visible = false;
                            DivSearch.Visible = true;
                        }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "showErrorToast", "showSuccessToast('" + "Branch Name allready Exist..." + "');", true);
                        }
                    }
                    else if (hdnMode.Value == "U")
                    {
                        _dalitem.Item_Id = Convert.ToInt32(hdnID.Value.ToString());
                        _dalitem.UpdatedByID = Convert.ToInt32(Session["UserId"].ToString());
                        _dalitem.UpdatedDate = System.DateTime.Today.Date.ToShortDateString();
                        _dalitem.Flag = "Update";
                        int count = _balitem.UpdateRecord(_dalitem);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void drpGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpCategory.ClearSelection();
            drpCategory.DataSource = null;
            drpCategory.DataBind();
            drpCategory.Items.Insert(0, "Select");
            drpCategory.SelectedIndex = 0;
            if (drpGroup.SelectedIndex > 0)
            {
                commonFunction.FillDropDownList(drpCategory, "Category_Id", "Category_Name", "TblCategory_Master", "IsDeleted=0 and Group_Id=" + drpGroup.SelectedValue + "");
            }
        }
    }
}