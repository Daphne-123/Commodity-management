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
        cursor:pointer;
    }
    .reg .reg-verification{
        margin-top: 20px;
        width: 500px;
        font-size: 20px;
    }
    </style>
    
</head>
<body>
<form  method="post" action="Login.aspx">
        <div class="reg">
            <div class="title">
                <h3>请登录</h3>
            </div>
       
              <div class="form-group">
                <label for="exampleInputEmail1">用户名:</label><br />
                <input class="form-control username" id="username" name="username" type="text"  placeholder="请输入您的用户名"/>  
              </div>
              <div class="form-group">
                <label for="exampleInputPassword1">密码:</label><br />
                   <input type="password" name="password"  class="form-control" id="password" placeholder="请输入您的密码" />
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
                <br />
               <input type ="submit" class="btn btn-primary reg-verification" value="登  录"/>
        </div>
    </form>
    </body>
</html>
 <script type='text/javascript'> 
     function $(id){
        return document.getElementById(id);
     }  
     $('vCodeImg').onclick = function () {
            this.src = this.src+"1";
     }

</script> 