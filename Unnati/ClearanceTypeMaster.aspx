<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ClearanceTypeMaster.aspx.cs" Inherits="Unnati.ClearanceTypeMaster" %>

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
                        <h2>CLEARANCE TYPE MASTER
                        </h2>
                    </div>
                    <div class="body">
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtClearanceType">Clearance Type</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtClearanceType" class="form-control" placeholder="Clearance Type"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtCgstPer">CGST PER.</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtCgstPer"  class="form-control" placeholder="CGST PER."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtSGSTPer">SGST PER.</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtSGSTPer" class="form-control" placeholder="SGST PER."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtIGSTPer">IGST PER.</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtIGSTPer"  class="form-control" placeholder="IGST PER."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtCess">Cess.</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtCess" class="form-control" placeholder="CESS."></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <br />
                        <asp:Button runat="server" ID="btnSave"  class="btn btn-primary m-t-15 waves-effect" Text="SAVE" OnClick="btnSave_Click" />
                        <asp:Button runat="server" ID="btnCancel"  class="btn btn-default m-t-15 waves-effect" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row clearfix" id="DivSearch" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <div class="row">
                            <h2>CLEARANCE TYPE LIST</h2>
                            <div class="pull-right">
                                <asp:LinkButton runat="server" class="btn btn-primary m-t-15 waves-effect" ID="btnNew" OnClick="btnNew_Click"><i class="fa fa-plus"></i> Add New Clearance Type</asp:LinkButton>
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
                                <asp:BoundField HeaderText="Clearance Type" DataField="ClearanceType" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="CGST PER." DataField="CGSTPer" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="SGST PER." DataField="SGSTPer" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="IGST PER." DataField="IGSTPer" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="/images/Edit.png" runat="server" ID="LinkButtonEdit" CommandName="Edit" CommandArgument='<%# Eval("ClearanceTypeId") %>'
                                            Text="Edit" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="/images/Delete.png" runat="server" ID="LinkButtonDelete" CommandName="Delete" CommandArgument='<%# Eval("ClearanceTypeId") %>'
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
