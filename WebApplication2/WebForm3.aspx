<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication2.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>

<body align="center" style=" background-color:lightgoldenrodyellow; ">
    <form id="form1" runat="server">
        
             
       <header style="background-color:#FFE384"><font size="7" face="微軟正黑體">物理不可複製函數與區塊鏈技術之電子病例簽章</font></header>
        <%--<asp:Button ID="Button1" runat="server" Text="驗簽章" BackColor="#87CEEB" BorderColor="White" ForeColor="White" OnClick="Button1_Click" />--%>
            <div style="width:25%; height:30%; padding-top:1%;padding-:1%;margin-left:37%;margin-top:15%;border-width:3px;border-style:groove;border-color:#FFAC55;background-color:cornsilk;border-radius: 10px;" >
            <p>會員註冊</p>
            <br />
            <asp:TextBox runat="server" ID="TextBox1" placeholder="輸入ID" Width="40%"></asp:TextBox>
            <br/>
            <br/>
            
           <asp:Label ID="Label1" runat="server"></asp:Label>
           <br />
           <asp:Label ID="Label2" runat="server"></asp:Label>
           <br/>
          <asp:Button runat="server" Text="註冊" OnClick="Unnamed2_Click" BackColor="#87CEEB" BorderColor="White" ForeColor="White"></asp:Button>
                </div>
        <asp:GridView runat="server" DataSourceID="SqlDataSource1" ID="ctl08" AutoGenerateColumns="False" DataKeyNames="UserID" Visible="False">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" SortExpression="UserID"></asp:BoundField>
                    <asp:BoundField DataField="BlockChainID" HeaderText="BlockChainID" SortExpression="BlockChainID"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:Project2ConnectionString %>" SelectCommand="SELECT * FROM [User_Info]"></asp:SqlDataSource>
           <br/>
            <asp:GridView runat="server" DataSourceID="SqlDataSource2" ID="ctl09" AutoGenerateColumns="False" DataKeyNames="RcID" Visible="False">
                <Columns>
                    <asp:BoundField DataField="RcID" HeaderText="RcID" ReadOnly="True" InsertVisible="False" SortExpression="RcID"></asp:BoundField>
                    <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID"></asp:BoundField>
                    <asp:BoundField DataField="C0" HeaderText="C0" SortExpression="C0"></asp:BoundField>
                    <asp:BoundField DataField="Hex_R0" HeaderText="Hex_R0" SortExpression="Hex_R0"></asp:BoundField>
                    <asp:BoundField DataField="BlockChain_Hex" HeaderText="BlockChain_Hex" SortExpression="BlockChain_Hex"></asp:BoundField>
                    <asp:BoundField DataField="Timestamp" HeaderText="Timestamp" SortExpression="Timestamp"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:Project2ConnectionString %>" SelectCommand="SELECT * FROM [Rc_Table]"></asp:SqlDataSource>
            
          
            
        
    </form>
</body>
</html>
