<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Store.proList.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <title></title>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <style>
        body {
            padding: 2rem;
        }
    </style>
</head>
<body>
    <form id="addForm" action="AddProduct.aspx" method="post">
        <div class="form-group">
            <label for="cName">商品名</label>
            <input type="text" name="cName" class="form-control" id="cName" required />
        </div>
        <div class="form-group">
            <label for="cNumber">商品数量</label>
            <input type="number" name="cNumber" class="form-control" id="cNumber" required />
        </div>
        <div class="form-group">
            <label for="cTime">添加日期</label>
            <input type="date" name="cTime" class="form-control" id="cTime" required />
        </div>
        <div class="form-group">
            <label for="cDeptId">供应商</label>
            <select class="form-control" name="cDeptId" id="cDeptId" required>
                <%=GetFactoryList() %>
            </select>
        </div>
        <div class="form-group">
            <label for="cPrice">定价</label>
            <input type="text" class="form-control" name="cPrice" id="cPrice" required />
        </div>
        <div class="form-group">
            <label for="cImgUrl">商品图片</label>
            <input type="file" name="cImgUrl" id="cImgUrl" />
        </div>
        <input type="submit" class="btn btn-primary" value="添加"/>
    </form>
</body>
</html>
<script>
    $(function () {
        $('#cPrice').on('input propertychange', function (e) {
            //如果输入非数字，则替换为''
            this.value = this.value.replace(/[^\d\.]/g, '');
            //必须保证第一个为数字而不是.     
            this.value = this.value.replace(/^\./g, '');
            //保证只有出现一个.而没有多个.     
            this.value = this.value.replace(/\.{2,}/g, '.');
            //保证.只出现一次，而不能出现两次以上     
            this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
            //只能输入两位小数
            this.value = this.value.replace(/^(\-)*(\d+)\.(\d\d).*$/, '$1$2.$3');
        });
    })
</script>
