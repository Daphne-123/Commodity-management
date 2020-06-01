<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderQuery.aspx.cs" Inherits="Store.orderQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/tableCSS.css" rel="stylesheet" />
     <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <style>
        .cheader {
            margin: 0 auto;
            padding-top: 50px;
            padding-bottom: 10px;
            text-align: center;
        }

        .ctitle {
            margin: 0 100px;
        }

        .cbtn {
            margin: 0 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div class="cheader col-md-9">
            <span class="text-center h2 font-weight-bold ctitle">订 单 信 息</span>
            <asp:Button ID="Button1" runat="server" class="btn btn-success cbtn" OnClick="Button1_Click" Text="导  出" />
            <input type="button" id="code" onclick="printer()" class="btn btn-warning cbtn" value="打  印" />
            <button type="button" class="btn btn-info cbtn" data-toggle="modal" data-target="#exampleModal">添  加 </button>
        </div>
        <div id="PrintArea">
        <asp:GridView ID="OrderGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="orderId" HeaderText="订单编号" />
                <asp:BoundField DataField="cName" HeaderText="商品名字" />
                <asp:BoundField DataField="cNumber" HeaderText="商品数量" />
                <asp:BoundField DataField="orderDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="订单日期" />
                <asp:BoundField DataField="orderAddress" HeaderText="订单地址" />
                <asp:TemplateField HeaderText="操 作">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# DeleteOrder(Eval("orderId")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
      </div>
    </form>
      <!-- 添加 -->
    <div class="modal fade my-modal add-modal" id="exampleModal">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <h4 class="modal-title">添加新订单</h4>
                    <button type="button" class="close" data-dismiss="modal">
                        &times;
                    </button>
                </div>

                <div class="modal-body">
                    <form
                        action="./InsertOrderHandler.ashx"
                        method="POST"
                        id="addForm"
                        accept-charset="UTF-8">
                        <div class="form-group">
                            <label for="cName" class="col-form-label">商品名字:</label>
                            <select name="cName" class="form-control" id="cName"> <%=ops %></select>
                        </div>
                        <div class="form-group">
                            <label for="cNumber" class="col-form-label">商品数量:</label>
                            <input
                                name="cNumber"
                                type="text"
                                class="form-control"
                                id="cNumber" />
                        </div>
                        <div class="form-group">
                            <label for="orderDate" class="col-form-label">订单日期:</label>
                            <input
                                name="orderDate"
                                type="date"
                                class="form-control"
                                id="orderDate" />
                        </div>
                        <div class="form-group">
                            <label for="orderAddress" class="col-form-label">订单地址:</label>
                            <input
                                name="orderAddress"
                                type="text"
                                class="form-control"
                                id="orderAddress" />
                        </div>
                    </form>
                </div>

                <div class="modal-footer">
                    <button
                        type="button"
                        class="btn btn-info btn-sm"
                        data-dismiss="modal"
                        id="sendAddBtn">
                        添加
                    </button>
                </div>
            </div>
        </div>
    </div>


</body>
</html>
<script type="text/javascript">
    function doDeleteOrder(orderId) {
        if (confirm("你真的要删除id为：" + orderId + "的订单信息？")) {
            window.location = "DeleteOrderHandler.ashx?orderId=" + orderId;
        }
    }
    ///打印VipGridView功能
    function printer() {

        beforeprint();
        window.focus();
        window.print()
        afterprint();
    }
    function beforeprint() {
        for (i = 0; i < document.all.length; i++) {
            if ((document.all(i).id.indexOf("PrintArea") != -1) && document.all(i).tagName == "TABLE") {
                document.all(i).style.display = "none";
            }
        }
    }
    function afterprint() {
        for (i = 0; i < document.all.length; i++) {
            if ((document.all(i).id.indexOf("PrintArea") != -1) && document.all(i).tagName == "TABLE") {
                document.all(i).style.display = "block";
            }
        }
    }
     $('#sendAddBtn').on('click', function () {
        $('#addForm').submit();
    });
</script>