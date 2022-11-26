<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionForm.aspx.cs" Inherits="WebApplication2.TransactionForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" Text="Button"></asp:Button><asp:Button runat="server" Text="post" ID="Button1" OnClick="b2_Click"></asp:Button><br />
    <asp:Label runat="server" ID="Label2"></asp:Label>
        </div>
    </form>
</body>
</html>
