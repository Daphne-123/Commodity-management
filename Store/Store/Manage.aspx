<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Store.Manage" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>后台管理界面</title>
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <style>
      *{
        margin: 0;
        padding: 0;	
      }
      .head{
        height: 10vh;
        background-color: rgb(36, 47, 66);
      }
      .head-left{
        float: left;
      }
      .head-left img{
        width: 50px;
        height: 50px;
        margin-left: 30px;
        position: relative;
        bottom: 5px;
      }
      .head span{
        color: #fff;
        font-weight: 600;
        font-size: 20px;
        line-height: 10vh;
      }
      .head-right{
        float: right;
      }
      .head-right span{
        font-size: 16px;
        padding-right: 30px;
      }
      aside{
        padding-left: 0 !important;
        padding-right: 0 !important;
        height: 90vh;
        background-color: rgb(50, 65,87);
      }
      aside .Navigation{
        width: 100%;
        padding: 0;
        text-align: center;
      }
      aside .Navigation button{
        color: #fff;
        font-weight: 600;
      }
      aside .Navigation button:hover{
        color: #fff;  
      }
      aside .Navigation .Navigation-option{
        background-color:#fff;
        font-weight: 600;
        cursor: pointer;
      }
      aside .ops{
          width:100%;
          border:0;
          border-bottom:1px solid rgb(50, 65,87);
      }
      main{ 
        padding-left: 0 !important;
        padding-right: 0 !important;
      }
      main .iframe-class{
          width:100%;
          height:100%;
      }
    </style>
</head>
<body>
    <header>
        <div class="head container-fluid">
           <div class="head-left">
               <img src="../image/logo.png" alt="">
               <span>商家后台管理系统</span>
           </div>
           <div class="head-right">
             <span>当前用户：胡欣哲</span>
           </div>
        </div>
    </header>
    <div class="container-fluid">
      <div class="row">
    <aside class="col-sm-2">
      <div class="accordion" id="accordionExample">
        <div class="Navigation">
          <div class="card-header  Navigation-title" id="headingOne">
              <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne"  onclick=" iframe.location='First.aspx'">
                首页
              </button>
          </div>
        </div>
        <div class="Navigation">
          <div class="card-header Navigation-title" id="headingTwo">
              <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                商品管理
              </button>
          </div>
          <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
               <input type=button value="商品列表" onclick=" iframe.location='ProductList.ashx'" class="card-body Navigation-option  ops"/>
          </div>
        </div>
        <div class="Navigation">
          <div class="card-header Navigation-title" id="headingThree">
              <button class="btn btn-link collapsed " type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
               订单管理
              </button>
          </div>
          <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
            <input type=button value="订单查询" onclick=" iframe.location='orderQuery.aspx'" class="card-body Navigation-option ops"/>

              <input type=button value="删除订单" onclick=" iframe.location='orderDel.aspx'" class="card-body Navigation-option ops"/>
          </div>
        </div>
        <div class="Navigation">
          <div class="card-header Navigation-title" id="headingFour">
              <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
               会员管理
              </button>
          </div>
          <div id="collapseFour" class="collapse" aria-labelledby="headingFour" data-parent="#accordionExample">
             <input type=button value="会员列表" onclick=" iframe.location='vipList.aspx'" class="card-body Navigation-option ops"/> 
          </div>
        </div>
        <div class="Navigation">
          <div class="card-header Navigation-title" id="headingFive">
              <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseFive" aria-expanded="false" aria-controls="collapseFive"  onclick=" iframe.location='PhoneListHandler.ashx'">
               投诉电话
              </button>
              
          </div>
        </div>
      </div>
  </aside>
  <main class="col-sm-10">
       <iframe name="iframe" class="iframe-class" src="First.aspx" ></iframe>
      <br>
  </main>
</div>
</div>
</body>
</html>
