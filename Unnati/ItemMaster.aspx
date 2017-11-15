<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ItemMaster.aspx.cs" Inherits="Unnati.ItemMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
     <script type="text/javascript">
         function isNumber(evt) {
             evt = (evt) ? evt : window.event;
             var charCode = (evt.which) ? evt.which : evt.keyCode;
             if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                 return false;
             }
             return true;

         }

         function isNumberKey(evt, obj) {

             var charCode = (evt.which) ? evt.which : event.keyCode
             var value = obj.value;
             var dotcontains = value.indexOf(".") != -1;
             if (dotcontains)
                 if (charCode == 46) return false;
             if (charCode == 46) return true;
             if (charCode > 31 && (charCode < 48 || charCode > 57))
                 return false;
             return true;
         }

    </script>
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
                        <h2>ITEM MASTER
                        </h2>
                    </div>
                    <div class="body">
                        <div class="row">
                            <div class="col-md-6">
                                <label for="drpGroup">Group Name</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:DropDownList runat="server" ID="drpGroup" class="form-control show-tick" AutoPostBack ="true" OnSelectedIndexChanged ="drpGroup_SelectedIndexChanged" ></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ControlToValidate="drpGroup" ErrorMessage ="Select Group Name" InitialValue ="Select" ForeColor ="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="drpCategory">Category</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:DropDownList runat="server" ID="drpCategory" class="form-control show-tick"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="drpCategory" ErrorMessage ="Select Category Name" InitialValue ="Select" ForeColor ="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtItemCode">Item Code</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtItemCode" class="form-control" placeholder="Item Code"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ControlToValidate="txtItemCode" ErrorMessage ="Enter Item Code"  ForeColor ="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtItemName">Item Name</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtItemName" class="form-control" placeholder="Item Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ControlToValidate="txtItemName" ErrorMessage ="Enter Item Name"  ForeColor ="Red"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtDrawingNo">Drawing No.</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtDrawingNo" class="form-control" placeholder="Drawing No."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtRevNo">Rev No.</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtRevNo" class="form-control" placeholder="Rev No."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="drpUnit">Unit Name</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:DropDownList runat="server" ID="drpUnit" class="form-control show-tick"></asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  ControlToValidate="drpUnit" ErrorMessage ="Select Unit Name" InitialValue ="Select" ForeColor ="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="drpHSN">HSN Code</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:DropDownList runat="server" ID="drpHSN" class="form-control show-tick"></asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  ControlToValidate="drpHSN" ErrorMessage ="Select HSN Code" InitialValue ="Select" ForeColor ="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtWipRate">WIP Rate</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtWipRate" class="form-control" placeholder="WIP Rate" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtFinishRate">Finish Rate</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtFinishRate" class="form-control" placeholder="Finish Rate" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtNetWeight">Net Weight</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtNetWeight" class="form-control" placeholder="Net Weight" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtLevel">Level</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtLevel" class="form-control" placeholder="Level"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtMetalSpesification">Metal Specification</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtMetalSpesification" class="form-control" placeholder="Metal Specification"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtQtyPerPact">Qty. / Pack</label>
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox runat="server" type="text" ID="txtQTy" class="form-control" placeholder="Quantity" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                        <asp:TextBox runat="server" type="text" ID="txtPack" class="form-control" placeholder="Packet" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <asp:Button runat="server" OnClick ="btnSave_Click"   class="btn btn-primary m-t-15 waves-effect" Text="SAVE" />
                        <asp:Button runat="server" OnClick ="btnCancel_Click"  class="btn btn-default m-t-15 waves-effect" Text="Cancel" UseSubmitBehavior ="false"/>
                    </div>
                </div>
            </div>
        </div>

        <div class="row clearfix" id="DivSearch" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <div class="row">
                            <h2>ITEM LIST</h2>
                            <div class="pull-right">

                                <asp:LinkButton runat="server" class="btn btn-primary m-t-15 waves-effect" ID="btnNew" OnClick ="btnNew_Click" ><i class="fa fa-plus"></i> Add New Item</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="body">
                        <asp:GridView ID="grdSearch" runat="server" CssClass="table table-bordered table-striped table-hover dataTable js-exportable" AutoGenerateColumns="false" 
                           OnPageIndexChanging="grdSearch_PageIndexChanging" OnRowDeleting="grdSearch_RowDeleting" OnRowEditing="grdSearch_RowEditing" OnRowCommand="grdSearch_RowCommand"  EmptyDataText ="Records Not Found">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. No">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Item Code" DataField="Item_Code" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                 <asp:BoundField HeaderText="Item Name" DataField="Item_Name" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="/images/Edit.png" runat="server" ID="LinkButtonEdit" CommandName="Edit" CommandArgument='<%# Eval("Item_Id") %>'
                                            Text="Edit" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="/images/Delete.png" runat="server" ID="LinkButtonDelete" CommandName="Delete" CommandArgument='<%# Eval("Item_Id") %>'
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
