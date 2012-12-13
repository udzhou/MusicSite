<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Download.aspx.cs" Inherits="Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" DataKeyNames="ID" 
            onrowcommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="歌曲编号" 
                SortExpression="ID" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField DataField="PurcID" HeaderText="订单号" SortExpression="PurcID" />
            <asp:BoundField DataField="Name" HeaderText="歌曲名" SortExpression="Name" />
            <asp:BoundField DataField="Price" HeaderText="价格" SortExpression="Price" />
            <asp:BoundField DataField="Buy" HeaderText="是否购买" SortExpression="Buy" />
            <asp:ButtonField CommandName="download" Text="下载" />
        </Columns>
    </asp:GridView>
</div>
<div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:MusicConnectionString4 %>" 
        
        SelectCommand="SELECT Music.ID,PurchaseItems.PurcID, Music.Name, Music.Price, PurchaseItems.Buy FROM PurchaseItems INNER JOIN Music ON PurchaseItems.ID = Music.ID WHERE (PurchaseItems.Buy = '是')">
    </asp:SqlDataSource>
</div>
</asp:Content>

