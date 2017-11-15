<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CategoryMaster.aspx.cs" Inherits="Unnati.CategoryMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="container-fluid">
        <div class="block-header">
            <h2>MASTERS</h2>
        </div>
        <div class="row clearfix" id="DivData" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <h2>CATEGORY MASTER
                        </h2>
                    </div>
                    <div class="body">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="clearfix"></div>
                                <label for="drpGroup">Group Name</label>
                                <asp:DropDownList runat="server" ID="drpGroup" class="form-control show-tick">
                                                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage ="Select Group Name" ControlToValidate="drpGroup" InitialValue ="Select" ForeColor ="Red"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-md-6">
                                <label for="txtCategoryName">Category Name</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtCategoryName" class="form-control" placeholder="Category Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ControlToValidate="txtCategoryName" ErrorMessage ="Enter Category Name" ForeColor ="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <br />
                        <asp:Button runat="server" ID="btnSave"  OnClick ="btnSave_Click" class="btn btn-primary m-t-15 waves-effect" Text="SAVE" />
                        <asp:Button runat="server" ID="btnCancel"  OnClick ="btnCancel_Click"  class="btn btn-default m-t-15 waves-effect" Text="Cancel" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row clearfix" id="DivSearch" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <div class="row">
                            <h2>GROUP LIST</h2>
                            <div class="pull-right">
                                <%--<asp:Button runat="server" ID="btnNew" class="btn btn-primary m-t-15 waves-effect"   Text="New Tax" />--%>
                                <asp:LinkButton runat="server" class="btn btn-primary m-t-15 waves-effect" OnClick ="btnNew_Click"  ID="btnNew"><i class="fa fa-plus"></i> Add New Category</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="body">
                        <asp:GridView ID="grdSearch" runat="server" CssClass="table table-bordered table-striped table-hover dataTable js-exportable" AutoGenerateColumns="false" 
                            OnPageIndexChanging="grdSearch_PageIndexChanging" OnRowDeleting="grdSearch_RowDeleting" OnRowEditing="grdSearch_RowEditing" OnRowCommand="grdSearch_RowCommand" EmptyDataText="Records Not Found">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. No">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:BoundField HeaderText="Group Name" DataField="Group_Name" ItemStyle-HorizontalAlign="Center">
                                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                <asp:BoundField HeaderText="Category Name" DataField="Category_Name" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="/images/Edit.png" runat="server" ID="LinkButtonEdit" CommandName="Edit" CommandArgument='<%# Eval("Category_Id") %>'
                                            Text="Edit" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="/images/Delete.png" runat="server" ID="LinkButtonDelete" CommandName="Delete" CommandArgument='<%# Eval("Category_Id") %>'
                                            Text="Delete" OnClientClick="if ( !confirm('Are you sure you want to delete ?')) return false;" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>



                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <asp:HiddenField ID="hdnID" runat="server" />
                <asp:HiddenField ID="hdnMode" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
