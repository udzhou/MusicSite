<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="LinqDataSource1" 
        EnableModelValidation="True">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Who" HeaderText="Who" SortExpression="Who" />
            <asp:BoundField DataField="Url" HeaderText="Url" SortExpression="Url" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
        </Columns>
    </asp:GridView>
    </div>
<div>
    <table class="style1">
        <tr>
            <td class="style3">
                歌曲名：</td>
            <td class="style3">
                <asp:TextBox ID="name" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                歌手：</td>
            <td class="style3">
                <asp:TextBox ID="who" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                文件上传：</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                </td>
            <td class="style3">
                <asp:Button ID="fbit" runat="server" onclick="fbit_Click" Text="上传" />
                <asp:Button ID="Cancel" runat="server" Text="取消" onclick="Cancel_Click" />
            </td>
        </tr>
    </table>
    </div>
<div>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="DataDataContext" EnableDelete="True" EnableInsert="True" 
        EnableUpdate="True" TableName="Music">
    </asp:LinqDataSource>
    </div>
</asp:Content>

