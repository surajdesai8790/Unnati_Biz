<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SuplierMaster.aspx.cs" Inherits="Unnati.SuplierMaster" %>

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
                        <h2>SUPLIER MASTER
                        </h2>
                    </div>
                    <div class="body">
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtSuplierCode">Suplier Code</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtSuplierCode" class="form-control" placeholder="Suplier Code"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtSuplierName">Suplier Name</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtSuplierName" class="form-control" placeholder="Suplier Name"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtSuplierAddress">Address</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" TextMode="MultiLine" ID="txtSuplierAddress" class="form-control" placeholder="Suplier Address"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtSuplierPhone">Phone Number</label>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="material-icons">phone</i>
                                    </span>
                                    <div class="form-line">
                                        <asp:TextBox runat="server" ID="txtSuplierPhone" type="text" class="form-control" placeholder="Phone Number(s)"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtSuplierEmail">Email</label>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="material-icons">email</i>
                                    </span>
                                    <div class="form-line">
                                        <asp:TextBox runat="server" ID="txtSuplierEmail" type="text" class="form-control" placeholder="Email"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtContactPerson">Contact Person</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtContactPerson" class="form-control" placeholder="Contact Person"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtGstin">GSTIN </label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtGstin" class="form-control" placeholder="GSTIN"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="clearfix"></div>
                                <label for="drpState">State</label>
                                <asp:DropDownList runat="server" ID="drpState" class="form-control show-tick">
                                    <asp:ListItem>-- Select State--</asp:ListItem>
                                    
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtAccLedgerName">Acc. Ledger Name </label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtAccLedgerName" class="form-control" placeholder="Acc. Ledger Name"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtCreditDays">Credit Days</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtCreditDays" class="form-control" placeholder="Credit Days"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtEccNo">ECC No</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtEccNo" class="form-control" placeholder="ECC No."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtRange">Range</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtRange" class="form-control" placeholder="Range"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtDivision">Division</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtDivision" class="form-control" placeholder="Division"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtCollectorate">Collectorate</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtCollectorate" class="form-control" placeholder="Collectorate"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="clearfix"></div>
                                <label for="drpPartyType">Party Type</label>
                                <asp:DropDownList runat="server" ID="drpPartyType" class="form-control show-tick">
                                    <asp:ListItem>-- Select Party type--</asp:ListItem>
                                    <asp:ListItem>Manufaturar</asp:ListItem>
                                </asp:DropDownList>

                            </div>

                        </div>
                        <br />
                        <asp:Button runat="server"  class="btn btn-primary m-t-15 waves-effect" Text="SAVE" OnClick="btnSave_Click"/>
                        <asp:Button runat="server"  class="btn btn-default m-t-15 waves-effect" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row clearfix" id="DivSearch" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <div class="row">
                            <h2>SUPLIER LIST</h2>
                            <div class="pull-right">

                                <asp:LinkButton runat="server" class="btn btn-primary m-t-15 waves-effect" ID="btnNew" OnClick="btnNew_Click"><i class="fa fa-plus"></i> Add New Suplier</asp:LinkButton>
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
                                <asp:BoundField HeaderText="Suplier Code" DataField="SuplierCode" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Suplier Name" DataField="SuplierName" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Address" DataField="Address" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Contact Number" DataField="ContactNumber" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Email" DataField="Email" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Contact Person" DataField="ContactPerson" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="/images/Edit.png" runat="server" ID="LinkButtonEdit" CommandName="Edit" CommandArgument='<%# Eval("SuplierId") %>'
                                            Text="Edit" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="/images/Delete.png" runat="server" ID="LinkButtonDelete" CommandName="Delete" CommandArgument='<%# Eval("SuplierId") %>'
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
