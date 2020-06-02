<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="First.aspx.cs" Inherits="Store.First" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>首页</title>
    <!-- 引入 echarts.js -->
    <script src="js/echarts.min.js"></script>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <style>
        .chart-wrap {
            display: flex;
            justify-content: space-between;
            padding: 1rem;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="card">
            <div class="card-header" id="headingOne">
                商家详情
            </div>
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
        <div class="card">
            <div class="card-header" id="headingTwo">
                数据图
            </div>
            <!-- 为ECharts准备一个具备大小（宽高）的Dom -->
            <div class="chart-wrap">
                <div id="main" style="width: 600px; height: 400px;">assd</div>
                <div id="pie" style="width: 600px; height: 400px;">assd</div>
            </div>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    // 基于准备好的dom，初始化echarts实例
    var myChart = echarts.init(document.getElementById('main'));

    // 指定图表的配置项和数据
    option = {
        title: {
            text: '商品交易表',
        },
        xAxis: {
            type: 'category',
            data: [<%
    foreach (var item in GetDate())
    {
        Response.Write("'" + item + "',");
    }
    %>],
            name: '日期'
        },
        yAxis: {
            type: 'value',
            name: '商品交易量'
        },
        series: [{
            data: [<% 
    foreach (var item in GetGoodsNum())
    {
        Response.Write(item + ",");
    }
    %>],
            type: 'line'
        }]
    };


    // 使用刚指定的配置项和数据显示图表。
    myChart.setOption(option);


    var pieChart = echarts.init(document.getElementById('pie'));

    option = {
        title: {
            text: '会员年龄分布',
        },
        legend: {
            type: 'scroll',
            orient: 'vertical',
            right: 10,
            top: 20,
            bottom: 20
        },
        tooltip: {
            trigger: 'item',
        },
        series: [
            {
                name: '姓名',
                type: 'pie',
                radius: '55%',
                center: ['40%', '50%'],
                data: <%=GetVipAge() %>
                    //[
                    //    { name: '0-20', value: 1 },
                    //    { name: '21-40', value: 2 },
                    //    { name: '41-60', value: 2 },
                    //    { name: '61及以上', value: 2 }
                    //]
                ,
                emphasis: {
                    itemStyle: {
                        shadowBlur: 10,
                        shadowOffsetX: 0,
                        shadowColor: 'rgba(0, 0, 0, 0.5)'
                    }
                }
            }
        ]
    };
    pieChart.setOption(option);

</script>
