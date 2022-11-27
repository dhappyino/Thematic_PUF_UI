<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style=" background-color:lightgoldenrodyellow;" align="center">
    <form id="form1" runat="server">
               <header style="background-color:#FFE384"><font size="7" face="微軟正黑體">物理不可複製函數與區塊鏈技術之電子病例簽章</font></header>
        <%--<asp:Button runat="server" Text="回首頁" BackColor="#87CEEB" BorderColor="White" ForeColor="White" OnClick="Unnamed1_Click"></asp:Button>--%>

        <div style="width:75%; height:30%; padding-top:1%;padding-:1%;margin-left:12%;margin-top:15%;border-width:3px;border-style:groove;border-color:#FFAC55;background-color:cornsilk;border-radius: 10px;" id="LSing">
            ID:<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" Height="25px" Width="170px" BorderStyle="None" ForeColor="Red" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" BackColor="#87CEEB" BorderColor="White" ForeColor="White" Text="開始簽章1" AutoPostBack="false" UseSubmitBehavior="False" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" BackColor="#87CEEB" BorderColor="White" ForeColor="White" Text="開始簽章2" AutoPostBack="false"/>
            <br />
            <asp:Label ID="FileUploadStatus" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LSing" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="hash1" runat="server" ></asp:Label>
            <br />
            <br />
            <asp:Label ID="hash2" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            </div>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="SingID" Visible="False">
                <Columns>
                    <asp:BoundField DataField="SingID" HeaderText="SingID" ReadOnly="True" InsertVisible="False" SortExpression="SingID"></asp:BoundField>
                    <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID"></asp:BoundField>
                    <asp:BoundField DataField="c" HeaderText="c" SortExpression="c"></asp:BoundField>
                    <asp:BoundField DataField="EMR" HeaderText="EMR" SortExpression="EMR"></asp:BoundField>
                    <asp:BoundField DataField="Hex_R" HeaderText="Hex_R" SortExpression="Hex_R"></asp:BoundField>
                    <asp:BoundField DataField="Block_Hex1" HeaderText="Block_Hex1" SortExpression="Block_Hex1"></asp:BoundField>
                    <asp:BoundField DataField="Block_Hex2" HeaderText="Block_Hex2" SortExpression="Block_Hex2"></asp:BoundField>
                    <asp:BoundField DataField="Timestamp" HeaderText="Timestamp" SortExpression="Timestamp"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project2ConnectionString %>" SelectCommand="SELECT * FROM [Sing_Table]"></asp:SqlDataSource>
           
        
    </form>
</body>
</html>
