<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unlockforms.aspx.cs" Inherits="WebApplication2.unlockforms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" Text="Button" ID="b1"></asp:Button>
    <asp:Button runat="server" Text="post" ID="b2" OnClick="b2_Click"></asp:Button><br></br>
    <asp:Label runat="server" ID="Label1"></asp:Label>
        </div>
    </form>
</body>
</html>
