<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aegis.Admin._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">
            <div class="col-md-12">
                Username:
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            </div>
            <br />
            <div class="col-md-12">
                Password:
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="col-md-12">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>
            </div>
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="#dd3131"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
