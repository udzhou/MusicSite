<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Orderquery.aspx.cs" Inherits="Orderquery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PurcID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="PurcID" HeaderText="订单号" InsertVisible="False" 
                ReadOnly="True" SortExpression="PurcID" />
            <asp:BoundField DataField="UserID" HeaderText="用户ID" 
                SortExpression="UserID" />
            <asp:BoundField DataField="Name" HeaderText="歌曲名" SortExpression="Name" />
            <asp:BoundField DataField="Price" HeaderText="价格" SortExpression="Price" />
            <asp:BoundField DataField="PurcDate" HeaderText="购买日期" 
                SortExpression="PurcDate" />
            <asp:BoundField DataField="Buy" HeaderText="是否付款" SortExpression="Buy" />
            <asp:TemplateField HeaderText="付款">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<div align="center">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:MusicConnectionString5 %>" 
        SelectCommand="SELECT Purchase.PurcID, Purchase.UserID, Purchase.PurcDate, PurchaseItems.Buy, Music.Name, Music.Price FROM Music INNER JOIN PurchaseItems ON Music.ID = PurchaseItems.ID INNER JOIN Purchase ON PurchaseItems.PurcID = Purchase.PurcID">
    </asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" Height="36px" onclick="Button1_Click" 
        Text="付款" Width="92px" />
</div>
</asp:Content>

