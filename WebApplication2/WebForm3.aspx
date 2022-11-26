<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication2.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            會員註冊:
            <br/>
            ID:<asp:TextBox runat="server" ID="TextBox1" OnTextChanged="TextBox1_TextChanged"></asp:TextBox><br/>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="User_ID">
                <Columns>
                    <asp:BoundField DataField="User_ID" HeaderText="User_ID" ReadOnly="True" SortExpression="User_ID"></asp:BoundField>
                    <asp:BoundField DataField="BlockchainID" HeaderText="BlockchainID" SortExpression="BlockchainID"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:Project_DBConnectionString %>" SelectCommand="SELECT * FROM [UserInfo]"></asp:SqlDataSource>
            <br/>
           <asp:Label ID="Label1" runat="server"></asp:Label>
           <br/>
           <asp:Label ID="Label2" runat="server"></asp:Label>
           <br/>
          <asp:Button runat="server" Text="註冊" OnClick="Unnamed2_Click"></asp:Button>
            <asp:Button runat="server" Text="select" ID="b2" OnClick="b2_Click"></asp:Button>
        </div>
    </form>
</body>
</html>
