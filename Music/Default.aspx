<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="无标题页" %>

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
                    <asp:Button ID="Button3" runat="server" Text="搜索" onclick="Button3_Click" />
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="歌曲数"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID" DataSourceID="SqlDataSource1" 
            EnableModelValidation="True" onrowcommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="编号" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="歌曲" SortExpression="Name" />
                <asp:BoundField DataField="Who" HeaderText="演唱者" SortExpression="Who" />
                <asp:BoundField DataField="Date" HeaderText="发布日期" SortExpression="Date" />
                <asp:ButtonField CommandName="play" Text="播放" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MusicConnectionString %>" 
            SelectCommand="SELECT [ID], [Name], [Who], [Date] FROM [Music]">
        </asp:SqlDataSource>
        
        <table class="style1">
            <tr>
                <td>
                <audio id="music" controls></audio>
                    <asp:Label ID="Label8" runat="server">歌曲</asp:Label>
                  </td>
            </tr>
        </table>
        
</div>
<div>
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="用户名："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server">hao</asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="密码："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:DropDownList ID="dpExpires" runat="server">
                    <asp:ListItem Value="0">不保存</asp:ListItem>
                    <asp:ListItem Value="1">保存一天</asp:ListItem>
                    <asp:ListItem Value="30">保存一个月</asp:ListItem>
                    <asp:ListItem Value="365">保存一年</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:CheckBox ID="CheckBox4" runat="server" Text="记住密码" />
            </td>
            <td>
                <asp:Button ID="Button4" runat="server" Text="登录" onclick="Button4_Click" />
            </td>
            <td>
                <asp:Button ID="Button5" runat="server" Text="注册" onclick="Button5_Click" />
            </td>
        </tr>
    </table>
</div>
</asp:Content>

