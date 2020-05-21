﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Store.Register" %>

<!DOCTYPE html>
<html>
<head>
	<meta charset="UTF-8">
	<title>Document</title>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
	<style type="text/css">
	*{
		margin: 0;
		padding: 0;
	}
	body{
		background-color: rgba(0, 0, 0, 0.1);
	}

	.reg{
		width: 500px;
		height: 30vh;
		margin:auto;
		position: relative;
		top: 50px;
	}
	.reg .title{
		text-align: center;
	}
	.reg .worning{
		color: red;
		display: none;
	}
	.reg .verification-Code{
		background-color: gold;
		font-family:Arial; 
        font-style:italic; 
        color:white;
        font-size:25px;          
        border:0; 
        letter-spacing:8px; 
        font-weight:bolder; 
	}
	.reg .reg-verification{
		margin-top: 20px;
        width: 500px;
        font-size: 20px;
    }
	</style>
	 <script type='text/javascript'> 
	 		function $(id){
	 			return document.getElementById(id);
	 		}
        var code;   

        function createCode(){ 
             code = "";    
             var codeLength = 4; 
             var checkCode = document.getElementById("code");    
             var random = new Array(2,3,4,5,6,7,8,9,'A','B','C','D','E','F','G','H','J','K','M','N','P','Q','R','S','T','U','V','W','X','Y','Z'); 
             for(var i = 0; i < codeLength; i++) {   
                var index = Math.floor(Math.random()*31);   
                code += random[index];
            }   
            checkCode.value = code;

             $("username").onblur=function(){
       		    var usertext = this.value;
                if (usertext.length < 0 || usertext.length > 8)
                {
       		        $('empWorning').style.display="block";
                }
                else
                {
       		        $('empWorning').style.display="none";
       	        }
            }
        }     
        function validate(){
            var password=$("password").value;
            var password1=$("password1").value;
            if(password!=password1){
                alert("密码前后不同！");
                return false;
            }
			else if (password.length<3){
				alert("密码至少为3位！");
				return false;
				}
            var inputCode = document.getElementById("input").value.toUpperCase();          
            if(inputCode.length <= 0) { 
                alert("请输入验证码！");   
            }
            else if (inputCode != code) {   
                alert("验证码输入错误！请重新输入");   
                createCode();  
                document.getElementById("input").value = ""; 
            }
            else {
                return true;
                
            } 
        } 
        </script> 
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
		    <input type="password" class="form-control" id="password1" placeholder="请重新输入密码" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')" onpaste="value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')" oncontextmenu = "value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')">
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
            <asp:Button ID="Button1" class="btn btn-primary reg-verification"  runat="server" Text="注&emsp;&emsp;册" OnClick="Button1_Click"  />
            <br>
	    	</div>
		</form>
    <p>
        &nbsp;</p>
</body>
</html>