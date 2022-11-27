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
           ID: <br />
            <asp:GridView runat="server" OnSelectedIndexChanged="Unnamed2_SelectedIndexChanged"></asp:GridView>
            <asp:FileUpload runat="server"></asp:FileUpload>
            <br/>
             <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
              <br/>
            
            <br /><br />
             <br />
             <asp:Label ID="Label4" runat="server" Text="hash data"></asp:Label><br />
            <asp:Label ID="Label3" runat="server" Text="hash data"></asp:Label>
            <br />
            <br />
           
            

           

        </div>
    </form>
</body>
</html>
