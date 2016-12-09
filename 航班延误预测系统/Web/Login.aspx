<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="航班延误预测系统._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
    <script src="js/jquery-1.8.3.js"></script>
    <title></title>
     <script type="text/javascript">

         function gotFocus() {
             //得到用户名文本框
             if (document.getElementById("txtName").value == "请输入用户名") {
                 //清空文本框的内容
                 document.getElementById("txtName").value = "";
             }


         }
         function lostFocus() {
             if (document.getElementById("txtName").value == "") {
                 document.getElementById("txtName").value = "请输入用户名";
             }

         }

       
         //$("#submit").click(function () {
         //    $.ajax({
         //        url: "command/login.ashx",
         //        //type: "post",
         //        //data: { txtn: $('#txtName').val(), txtp: $('#txtPwd').val() },
         //        //datatype: "text",
         //        success: function (data) {
         //            if (data == "success")
         //                alert('登录成功！');
         //            else
         //                alert('登录失败！');
         //        }
         //    })
         //})
        
    </script>
<link rel="stylesheet" href="css/style.css" />
</head>
<body>
    
     <div class="login-container">
	<h1>航班延误预测系统</h1>
	
	<div class="connect">
		<p>@极岛</p>
	</div>
	
	<%--<form action="command/login.ashx" method="post" id="loginForm1">--%>
		<form action="command/login.ashx" method="post">
			<input id="txtName" name="txtn" onfocus="gotFocus()" onblur="lostFocus()" value="请输入用户名" type="text" class="username" placeholder="用户名" autocomplete="off"/>
		    <input id="txtPwd" name="txtp"  type="password"  class="password" placeholder="密码" oncontextmenu="return false" onpaste="return false" />
            <button id="submit" type="submit" >登 陆</button>
	    </form>
</div>

<script src="js/jquery.min.js"></script>
<script src="js/common.js"></script>
<!--背景图片自动更换-->
<script src="js/supersized.3.2.7.min.js"></script>
<script src="js/supersized-init.js"></script>
<!--表单验证-->
<script src="js/jquery.validate.min.js?var1.14.0"></script>
   
</body>
</html>
