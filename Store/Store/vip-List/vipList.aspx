<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vipList.aspx.cs" Inherits="Store.vipList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link  href="css/tableCSS.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">

        <asp:GridView ID="VipGridView" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
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

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="导  出" />

    </form>
</body>
</html>
