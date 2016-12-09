<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="航班延误预测系统.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>航班延误预测判断</title>
    <link href="easy%20ui/themes/default/easyui.css" rel="stylesheet" />
    <script src="easy%20ui/jquery.min.js"></script>
    <script src="easy%20ui/jquery.easyui.min.js"></script>
    <script src="easy%20ui/easyui-lang-zh_CN.js"></script>
    <style type="text/css">
        p {
            font-family: "楷体";
            font-size: 16px;
        }
    
    </style>
    <script type="text/javascript">
        var first = true;
        var obj = {
            getResult: function () {
                var time = $.trim($('#xzdate').datebox('getValue'));
                var flightno = $.trim($('#flightNo').combobox('getValue'));
                var depair = $.trim($('#depAir').combobox('getValue'));
                var arrair = $.trim($('#arrAir').combobox('getValue'));
                var urlstr = "../command/GetResult.ashx?time=" + time + "&flightno=" 
                    + flightno + "&depair=" + depair + "&arrair=" + arrair;
                if (first) {
                    $('#result').datagrid({
                        loadMsg: '正在加载，请稍后...',
                        url: urlstr,
                        striped: true,
                        
                       
                        columns: [[
                            { field: 'flight_no', title: '航班号', width: 100 },
                            { field: 'plan_dep_date', title: '计划起飞日期', width: 100 },
                            { field: 'plan_arv_date', title: '计划到达日期', width: 100 },
                            { field: 'plan_dep_time', title: '计划起飞时刻', width: 100 },
                            { field: 'plan_arv_time', title: '计划到达时刻', width: 100 },
                            { field: 'fcst_dep_date', title: '预测起飞日期', width: 100 },
                            { field: 'fcst_arv_date', title: '预测到达日期', width: 100 },
                            { field: 'fcst_dep_time', title: '预测起飞时刻', width: 100 },
                            { field: 'fcst_arv_time', title: '预测到达时刻', width: 100 },
                            { field: 'is_delayed', title: '是否延误', width: 100 },
                        ]],
                        rownumbers: false,
                        pagination: false,
                    });
                    first = false;
                }
                else {
                    $('#result').datagrid({url: urlstr});
                }
            }
        };

        $(function () {

            $("#xzdate").datebox({
                onSelect: function (date) {
                    // var v = $('#xzdate').datebox('getValue');
                    var d = new Date(date)
                    var nowStr = d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate();
                    $('#flightNo').combobox({
                        valueField: 'FlightNo',
                        textField: 'FlightNo',
                        editable: true,
                        panelHeight: '300',
                        required: true,
                        url: 'command/flightNo.ashx?id=1&date=' + nowStr
                    });
                }
            })
            $('#depAir').combobox({
                valueField: 'DepAirport',
                textField: 'DepAirport',
                editable: true,
                panelHeight: '300',
                required: true,
                url: 'command/flightNo.ashx?id=2',
            });

            $('#arrAir').combobox({
                valueField: 'ArrAirport',
                textField: 'ArrAirport',
                editable: true,
                panelHeight: '300',
                required: true,
                url: 'command/flightNo.ashx?id=3',
            });
            

        })
    </script>
</head>
<body style="padding: 0; margin: 0;  background-color:rgb(242,242,242);">
    <form id="form1" runat="server">
        <div>
            <div style="width: 100%; height: 100px;">

                <div style="width: 500px; height: 100px; margin: auto auto;">
                    <p style="font-size: 50px; font-weight: bold;">航班延误预测系统</p>
                </div>
            </div>
            <div class="easyui-layout" style="width: 100%; height: 390px;  ">
                <div  data-options="region:'west'" title="输入" style="width: 25%; padding: 10px ;background-color:rgb(242,242,242);">
                    <div style="margin:10px auto auto 30px;" >
                        <p>请选择出发日期：</p>
                        <input class="easyui-datebox" type="text" id="xzdate" required="true" style="width: 170px;" />
                        <p>请输入航班号：</p>
                        <select  class="easyui-combobox" id="flightNo" name="state" required="true" style="width: 170px;">
                            
                        </select>
                        <p>请输入出发机场三字码：</p>
                       <select  class="easyui-combobox" id="depAir" name="state" required="true" style="width: 170px;">
                            
                        </select>
                        <p>请输入到达机场三字码：</p>
                         <select  class="easyui-combobox" id="arrAir" name="state" required="true" style="width: 170px;">
                            
                        </select>
                        <p><a href="#" id="yuce" class="easyui-linkbutton" onclick="obj.getResult()">预测结果</a></p>
                    </div>

                </div>

                <div data-options="region:'center'" title="结果" style=" background-color:rgb(242,242,242);">
                    <table id="result"></table>
                </div>

            </div>
            <p>
                <center><font color="red">@copyright极岛</font></center>
            </p>
        </div>
    </form>
</body>
</html>
