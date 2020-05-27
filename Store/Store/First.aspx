<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="First.aspx.cs" Inherits="Store.First" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>首页</title>
     <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
   
</head>
<body>
    <form id="form1" runat="server">
       <div class="accordion" id="accordionExample">
          <div class="card">
            <div class="card-header" id="headingOne">
                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                  商家详情
                </button>
            </div>
            <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
              <div class="card-body">
               <div class="card-deck">
                 <div class="card text-white bg-warning mb-3" style="max-width: 20rem;">
                      <div class="card-header">
                          <h3 class="text-center">成交总金额</h3>
                      </div>
                      <div class="card-body">
                        <p class="card-body text-center h2">999，9999</p>
                      </div>
                  </div>
                 <div class="card text-white bg-primary mb-3" style="max-width: 20rem;">
                        <div class="card-header">
                          <h3 class="text-center">成交总比数</h3>
                      </div>
                      <div class="card-body">
                        <p class="card-body text-center h2">999，9999</p>
                      </div>
                  </div>
                 <div class="card text-white bg-success mb-3" style="max-width: 20rem;">
                   <div class="card-header">
                          <h3 class="text-center">新增客户数</h3>
                      </div>
                      <div class="card-body">
                        <p class="card-body text-center h2">999，9999</p>
                     </div>
                </div>
                </div>
              </div>
            </div>
          </div>
          <div class="card">
            <div class="card-header" id="headingTwo">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                 数据图
                </button>
            </div>
            <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
              <div class="card-body">
                  这是数据图
               </div>
            </div>
          </div>
        </div>
    </form>
</body>
</html>
