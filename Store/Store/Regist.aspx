<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Regist.aspx.cs" Inherits="Store.Regist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>注册</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <style>
     *{
        margin: 0;
        padding: 0;
    }
    body{
        background-image: url("../image/3.jpg");
        background-size: 100%;
        background-repeat: no-repeat;
    }
    .reg {
        padding: 0 50px;
        width: 600px;
        height: 75vh;
        margin: auto;
        position: relative;
        top: 10vh;
        background-color: rgba(240, 255, 255, 0.5);
    }
    .reg .title {
        text-align: center;
        padding-top: 3vh;
    }
    .reg .worning {
        color: red;
        display: none;
    }
    .reg .verification-Code {
       cursor:pointer;
    }
    .reg .reg-verification {
        margin-top: 20px;
        width: 500px;
        font-size: 20px;
    }
    </style>
</head>
<body>
    <form  method="post" action="Regist.aspx">
        <div class="reg">
            <div class="title">
			    <h6 class="text-secondary">欢迎进入</h6>
			    <h3>创建你的用户</h3>
		    </div>
            
            <div class="form-group">
		        <label for="exampleInputEmail1">用户名:</label><br />
                <input class="form-control username" id="username" name="username" type="text"   onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5]/g,'')" onpaste="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5]/g,'')" oncontextmenu = "value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5]/g,'')" placeholder="请输入用户名"/>        
		        <small  class="form-text text-muted">请输入1-8字符，可使用汉字，字母或数字</small>
		        <small class="worning" id="empWorning">⚠：用户名长度只能是1-8</small>
		    </div>
            <div class="form-group">
		        <label for="exampleInputPassword1">密码:</label><br />
                <input type="password" name="pwd"  class="form-control" id="password" placeholder="请设置您的密码"  onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')" onpaste="value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')" oncontextmenu = "value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')"/>             
		        <small id="emailHelp" class="form-text text-muted">密码长度为3~10字符，可使用字母或数字</small>
		    </div>
		    <div class="form-group">
		        <label for="exampleInputPassword2">确认密码:</label>
		        <input type="password" name="cfpwd" class="form-control" id="cfmpwd" onchange="myFunction()" placeholder="请重新输入密码" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')"  oncontextmenu = "value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')" />		        
                  <small class="worning" id="pwdWorning">⚠：前后两次密码输入不一样，请重新输入！</small>
            </div>
            <div class="form-group">
		        <label for="exampleInputEmail2">验证码:</label><br/>
		        <div class="container">
		    	    <div class="row">
		    		    <input type = "text" id = "txtVcode" name="txtVcode" class="form-control col-sm-8" placeholder="请输入验证码"/> 
		    		    <div class="col-sm-1"></div>
		    	        <img id="vCodeImg" src="ValidateView.ashx?num=1" class="verification-Code col-sm-3 verification-Code" />
                    </div>
		        </div>
		    </div>
            <input type ="submit" class="btn btn-primary reg-verification"  value="注册"/>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function $(id)
    {
        return document.getElementById(id);
    }
    $("username").onblur = function () {
        var usertext = this.value;
        if (usertext.length < 0 || usertext.length > 8) {
            $('empWorning').style.display = "block";
        }
        else {
            $('empWorning').style.display = "none";
        }
    }
    function myFunction(){
     	var password=document.getElementById("password").value;
		var cfmpwd=document.getElementById("cfmpwd").value;
        if (password != cfmpwd) {
            $('pwdWorning').style.display = "block";
        }
        else {
            $('pwdWorning').style.display = "none";
        }
    }
    $('vCodeImg').onclick = function () {
            this.src = this.src+"1";
        }
</script>

