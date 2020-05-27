<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Store.Login" %>

<!DOCTYPE html>
<html >
<head>
    <meta charset="UTF-8">
    <title>login</title>
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <style type="text/css">
    *{
        margin: 0;
        padding: 0;
    }
    body{
        background-image: url("image/1.jpg");
        background-size: 100%;
        background-repeat: no-repeat;
    }
    .reg{
        padding: 0 50px;
        width: 600px;
        height: 55vh;
        margin:auto;
        position: relative;
        top: 15vh;
        background-color: rgba(240, 255, 255, 0.5);
    }
    .reg .title{
        text-align: center;
        padding-top: 3vh;
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
<body onload='createCode()'>
    <div class="reg">
        <div class="title">
            <h3>请登录</h3>
        </div>
        <form runat="server">
          <div class="form-group">
            <label for="exampleInputEmail1">用户名:</label><br />
            <asp:TextBox class="form-control username" id="username" aria-describedby="emailHelp" placeholder="请输入您的用户名"  runat="server" ></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="exampleInputPassword1">密码:</label><br />
              <asp:TextBox class="form-control" id="password" placeholder="请输入您的密码"  runat="server"></asp:TextBox>
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
            
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" class="btn btn-primary reg-verification" Text="登&emsp;&emsp;录" />
          
        </form>
            </div>

</body>
</html>