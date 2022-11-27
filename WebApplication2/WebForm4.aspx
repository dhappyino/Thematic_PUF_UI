<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="WebApplication2.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> </title>
</head>
<body  align="center" style=" background-color:lightgoldenrodyellow;">
    <form id="form1" runat="server">
               <header style="background-color:#FFE384"><font size="7" face="微軟正黑體">物理不可複製函數與區塊鏈技術之電子病例簽章</font></header>
        <%--<asp:Button ID="Button1" runat="server" Text="回首頁" BackColor="#87CEEB" BorderColor="White" ForeColor="White" OnClick="Button1_Click" />--%>
        <div style="width:25%; height:30%; padding-top:1%;padding-:1%;margin-left:37%;margin-top:15%;border-width:3px;border-style:groove;border-color:#FFAC55;background-color:cornsilk;border-radius: 10px;">
            驗簽章
            <br/>
            <asp:FileUpload ID="FileUpload1" runat="server"  Height="25px" Width="170px" BorderStyle="None" ForeColor="Red"></asp:FileUpload><br />
            ID:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label runat="server" ID="Label1"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
            <asp:Button runat="server" Text="Button" OnClick="Unnamed2_Click"  BackColor="#87CEEB" BorderColor="White" ForeColor="White"></asp:Button>
            <%--<asp:Button runat="server" Text="JSON"></asp:Button>--%>
        </div>
    </form>
</body>
</html>
