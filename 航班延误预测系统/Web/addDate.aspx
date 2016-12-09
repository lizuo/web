<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addDate.aspx.cs" Inherits="航班延误预测系统.addDate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #Select1 {
            width: 57px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        请选择要上传的文件：
        <asp:FileUpload ID="CsvUpload" runat="server" /><br />
        请选择文件名：
        <asp:DropDownList ID="TableID" runat="server" Height="20px" Width="160px">
            <asp:ListItem Value="flight_sample">flight_sample</asp:ListItem>
            <asp:ListItem>histweather_sample</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:Button ID="btnUpload" runat="server" Text="上传" OnClick="btnUpload_Click" />
        <br />
        <asp:Button ID="addFlight" runat="server" OnClick="addFlight_Click" Text="导入flight数据" />
&nbsp;
        <asp:Button ID="addWeather" runat="server" OnClick="addWeather_Click" Text="导入weather数据" />
        <br />
        数据分析：<asp:Button ID="Data_Check" runat="server" Text="开始分析" OnClick="Data_Check_Click1" />
    </div>
    </form>
</body>
</html>
