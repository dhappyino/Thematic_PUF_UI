<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>:</title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
           簽章上傳:<br />
           ID:<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> <br />
             PUFcode:<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br /><asp:Label runat="server" Text="Label"></asp:Label>
            <br />
            <br />
           
            

            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

        </div>
    </form>
</body>
</html>
