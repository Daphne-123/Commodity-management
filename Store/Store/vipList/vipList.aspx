<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vipList.aspx.cs" Inherits="Store.vipList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link  href="../css/tableCSS.css" rel="stylesheet"/>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <style>
        .cheader{
           margin :0 auto;
           padding-top:50px;
           padding-bottom:10px;
           text-align:center;
        }
        .ctitle{
            margin:0 100px;
        }
        .cbtn{
            margin:0 20px;
        }
    </style>
      <script type="text/javascript">
        function doDeleteVip(id) {
            if (confirm("你真的要删除id为：" + id + "会员信息？")) {
                window.location = "DeleteVipListHandler.ashx?pId=" + id;
            }
          }
          ///打印VipGridView功能
          function printer()
        {
　　
            beforeprint();
            window.focus();
            window.print()
            afterprint();
        }
        function beforeprint()
        {
            for(i = 0; i < document.all.length; i++)
            {
                if ((document.all(i).id.indexOf("PrintArea")!=-1) && document.all(i).tagName=="TABLE")
       
                {
                    document.all(i).style.display="none";
                }
            }
        }
        function afterprint()
        {
            for(i = 0; i < document.all.length; i++)
            {
                if ((document.all(i).id.indexOf("PrintArea")!=-1) && document.all(i).tagName=="TABLE")
                {
                    document.all(i).style.display="block";
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cheader col-md-7">
            <span class="text-center h2 font-weight-bold ctitle">修改会员信息</span>
             <asp:Button ID="Button1" runat="server" class="btn btn-success cbtn" OnClick="Button1_Click" Text="导  出" />
            <input  type="button" id="code" onclick="printer()" class="btn btn-warning cbtn" value="打  印">
        </div>
       <div id="PrintArea">
        <asp:GridView ID="VipGridView" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="pId" HeaderText="会员编号" />
                <asp:BoundField DataField="pName" HeaderText="会员姓名" />
                <asp:BoundField DataField="pGender" HeaderText="会员性别" />
                <asp:BoundField DataField="pAge" HeaderText="会员年龄" />
                <asp:BoundField DataField="pJoinDate" HeaderText="入会日期" />

                <asp:TemplateField HeaderText="操  作">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# UpdateVipList(Eval("pId")) %>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" Text='<%# DeleteVipList(Eval("pId")) %>'></asp:Label>
                        <br />
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
</body>
</html>
