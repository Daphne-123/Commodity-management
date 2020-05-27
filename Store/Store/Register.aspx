<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Store.Register" %>

<!DOCTYPE html>
<html>
<head>
	<meta charset="UTF-8">
	<title>Document</title>
    <link rel="stylesheet" href="css/bootstrap.min.css">
	 <link rel="stylesheet" href="css/Regitster.css" />

    <script type="text/javascript" src="js/Regitster.js"></script>
</head>
<body  onload='createCode()'>
	<div class="reg">
		<div class="title">
			<h6 class="text-secondary">欢迎进入</h6>
			<h3>创建你的用户</h3>
		</div>
		<form runat="server">
		  <div class="form-group">
		    <label for="exampleInputEmail1">用户名:</label><br />
            <asp:TextBox class="form-control username" id="username" aria-describedby="emailHelp" placeholder="请输入用户名"  onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5]/g,'')" onpaste="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5]/g,'')" oncontextmenu = "value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5]/g,'')" runat="server"></asp:TextBox>
		    <small  class="form-text text-muted">请输入1-8字符，可使用汉字，字母或数字</small>
		    <small class="worning" id="empWorning">⚠：用户名长度只能是1-8</small>
		  </div>
		  <div class="form-group">
		    <label for="exampleInputPassword1">密码:</label><br />
              <asp:TextBox class="form-control" id="password" placeholder="请设置您的密码" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')" onpaste="value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')" oncontextmenu = "value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')" runat="server" TextMode="Password"></asp:TextBox>
		    <small id="emailHelp" class="form-text text-muted">密码长度为3~10字符，可使用字母或数字</small>
		  </div>
		  <div class="form-group">
		    <label for="exampleInputPassword2">确认密码:</label>
		    <input type="password" class="form-control" id="password1" placeholder="请重新输入密码" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')"  oncontextmenu = "value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')">
		  </div>
		   <div class="form-group">
		    <label for="exampleInputEmail2">验证码:</label><br>
		    <div class="container">
		    	<div class="row">
		    		<input type = "text" id = "input" class="form-control col-sm-8"  placeholder="请输入验证码"/> 
		    		<div class="col-sm-1"></div>
            		<input type="button" id="code" onclick="createCode()" class="verification-Code col-sm-3 verification-Code" style="left: 0px; top: 0px; width: 100%" /> 
		    	</div>
		    </div>
		  </div>
            <asp:Button ID="Button1" class="btn btn-primary reg-verification"  runat="server" Text="注&emsp;&emsp;册"  OnClick="Button1_Click"  />
            <br>
		</form>
	    	</div>
</body>
</html>