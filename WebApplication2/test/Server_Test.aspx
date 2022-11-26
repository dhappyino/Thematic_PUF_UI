<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Server_Test.aspx.cs" Inherits="WebApplication2.test.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="U_ID">
                <Columns>
                    <asp:BoundField DataField="U_ID" HeaderText="U_ID" ReadOnly="True" SortExpression="U_ID"></asp:BoundField>
                    <asp:BoundField DataField="Blockchain_ID" HeaderText="Blockchain_ID" SortExpression="Blockchain_ID"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:test1ConnectionString %>" SelectCommand="SELECT * FROM [UserInfo]"></asp:SqlDataSource>
            <asp:Button ID="Button1" runat="server" Text="Connect" OnClick="Button1_Click" /><br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
