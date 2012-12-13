<%@ Page Title="" Language="C#" Debug=true MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Purchase.aspx.cs" Inherits="purchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table class="style1">
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="歌曲名："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="歌手："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CheckBox3" runat="server" Text="模糊搜索" />
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="搜索" />
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="歌曲数"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID" DataSourceID="SqlDataSource1" EnableModelValidation="True" 
            >
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="编号" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="歌曲" SortExpression="Name" />
                <asp:BoundField DataField="Who" HeaderText="演唱者" SortExpression="Who" />
                <asp:BoundField DataField="Date" HeaderText="发布日期" SortExpression="Date" />
                <asp:BoundField DataField="Price" HeaderText="价格" SortExpression="Price" />
                <asp:BoundField DataField="album" HeaderText="所属专辑" SortExpression="album" />
                <asp:TemplateField HeaderText="购买">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox4" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
    
    <div align="right">
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MusicConnectionString2 %>" 
            SelectCommand="SELECT [ID], [Name], [Who], [Date], [Price], [album] FROM [Music]">
        </asp:SqlDataSource>
    
        <asp:Label ID="Label9" runat="server" Visible="False"></asp:Label>
    
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/cart.gif" 
            onclick="ImageButton1_Click" />
    
        <asp:Label ID="Label8" runat="server"></asp:Label>
    
    </div>
    <div>
    
    </div>
</asp:Content>

