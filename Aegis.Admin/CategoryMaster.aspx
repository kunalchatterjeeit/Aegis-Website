<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryMaster.aspx.cs" Inherits="Aegis.Admin.CategoryMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Add/Edit Product Category
                </div>
                <div class="panel-body">
                    <div class="col-lg-12">
                        <div class="form-group has-error">
                            Product Type
                        <asp:DropDownList ID="ddlProductType" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-group has-error">
                            Product Category Name
                                <asp:TextBox ID="txtProductCategoryName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-group has-error">
                            Product Category Description
                                <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-group has-error">
                            Seo Url
                                <asp:TextBox ID="txtSeoUrl" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-group">
                            <br />
                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-outline btn-success"
                                OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="gvCategory" runat="server" Width="100%" AutoGenerateColumns="false" class="table table-striped"
                GridLines="None" AllowPaging="false" CellPadding="0" CellSpacing="0" ForeColor="#333333" OnRowCommand="gvCategory_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="SL" ItemStyle-Width="15px">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" />     
                    <asp:BoundField DataField="ProductTypeName" HeaderText="Product Type" />              
                    <asp:TemplateField ItemStyle-Width="15px">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" class="btn btn-outline btn-success" Text="Edit" CommandName="Ed" CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="15px">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" class="btn btn-outline btn-success" Text="Delete" CommandName="Del" CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#5bb0de" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#379ed6" Font-Bold="True" ForeColor="White" />
                <RowStyle CssClass="RowStyle" BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <EmptyDataRowStyle CssClass="EditRowStyle" />
                <AlternatingRowStyle CssClass="AltRowStyle" BackColor="White" ForeColor="#284775" />
                <PagerSettings Mode="NumericFirstLast" PageButtonCount="12" FirstPageText="First"
                    LastPageText="Last" />
                <PagerStyle CssClass="PagerStyle" BackColor="#379ed6" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <EmptyDataTemplate>
                    No Record Found...
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
