<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="航班延误预测系统.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        日期：&nbsp; 
        <asp:TextBox ID="txtDate" runat="server">2016/4/1</asp:TextBox>
        <br />
        <br />
        航班号：<asp:TextBox ID="txtFlightno" runat="server">CA1167</asp:TextBox>
        <br />
        <br />
        出发机场三字码：<asp:TextBox ID="txtDepAir" runat="server">TNA</asp:TextBox>
        <br />
        <br />
        目的机场三字码：<asp:TextBox ID="txtArrAir" runat="server">SHA</asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnYuce" runat="server" OnClick="btnYuce_Click" Text="预测结果" />
    
    </div>
    </form>
</body>
</html>
