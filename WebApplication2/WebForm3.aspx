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
            ID:<asp:TextBox runat="server"></asp:TextBox><br/>
           <asp:Label ID="Label1" runat="server"></asp:Label>
           <br/>
           <asp:Label ID="Label2" runat="server"></asp:Label>
           <br/>
             
          <asp:Button runat="server" Text="註冊" OnClick="Unnamed2_Click"></asp:Button>
        </div>
    </form>
</body>
</html>
