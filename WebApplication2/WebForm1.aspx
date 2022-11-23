<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

             <br />
            會員登入<br />
            <br />
            帳號:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            密碼:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Button ID="Button1" runat="server" Text="確定" OnClick="Button1_Click" ValidateRequestMode="Disabled" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="清除" OnClick="Button2_Click" />

        </div>
    </form>
</body>
</html>
