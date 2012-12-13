<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pay.aspx.cs" Inherits="Pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div></div>
<div>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="付款" onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="稍后付款" onclick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="取消订单" onclick="Button3_Click" />
</div>
</asp:Content>

