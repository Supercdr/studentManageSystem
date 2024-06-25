<%@ Page Title="" Language="C#" MasterPageFile="~/stu/MasterPage.master" AutoEventWireup="true" CodeBehind="stu_index.aspx.cs" Inherits="studentManage.stu.stu_index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <title>Echarts</title>
    <script src="https://cdn.bootcdn.net/ajax/libs/echarts/5.3.3/echarts.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <style>
        body{
            width:100%;
            height:90%;
            background-color:#f7f8fc;
            padding:10px;
            background-color: #f4f4f9;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: #333;
        }
        #Content2{
            background-color:white;
            padding:10px;
            border-radius:20px;
            flex-direction:column;
        }
        #content {
            display: flex;
            flex-wrap: wrap;
            justify-content: space-around; /* 平均分配子元素间距 */
            align-items: flex-start; /* 对齐子元素的顶部 */
        }
        #box, #pie, #date, #phb {
            box-shadow: 0 4px 8px rgba(0,0,0,0.1); /* 添加阴影 */
            border: 1px solid #ddd; /* 边框 */
            background-color: white; /* 背景颜色 */
            padding: 15px;
            margin: 10px;
            border-radius: 10px; /* 圆角 */
            height:347px;
            width:600px;
            display:inline-block;
        }
        @media (max-width: 768px) {
            #content {
                flex-direction: column;
            }

            #box, #pie, #date, #phb {
                width: 100%; /* 让每个容器在小屏幕上宽度为100% */
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div id="content">
        <div>
            <div id="date" ></div>
            <div id="box"  ></div>
        </div>
        <div>
            <div id="phb" ></div>
            <div id="pie" ></div>
        </div>
        
    </div>


    <script type="text/javascript">
        var xAxis_Data = []; 
        var series_Data = [];
        $.ajax({/*ajax请求*/
            url: "../Handler.ashx?type=bubbling",/*一般处理程序*/
            dataType: 'json',/*文件类型*/
            success: function (data1) {
                $.each(data1, function (index, item) {/*相当于for循环一步一步把里面的数据取出来放在数组里*/
                    xAxis_Data.push(item.name);
                    series_Data.push(item.value);
                })
                var myChartbar = echarts.init(document.getElementById('box'));
                var colors = ['#e27386', 'RGB(155, 197, 61)', 'rgb(243, 221, 242)', 'RGB(104, 195, 226)', 'RGB(197, 152, 215)', 'RGB(255, 228, 110)', 'rgb(251,222,224)', 'rgb(207, 231, 236)', 'rgb(215, 236, 188)', 'rgb(251, 242, 176)'];
                var option1 = {      
                    title: {
                        text:'学生作品数量排行榜',
                        left:'25%',
                    },
                    tooltip: {},
                    legend: {
                        data: ['学生']
                    },
                    xAxis: {
                        data: xAxis_Data, 
                        axisLabel: {
                            fontSize:'9'
                        }
                    },
                    yAxis: {
                    },
                    series: [{
                        name: '作品数',
                        type: 'bar',
                        data: series_Data,

                    }],
                    dataZoom: [{ // dataZoom组件，默认控制x轴。
                        type: 'slider', // 这个 dataZoom 组件是 slider 型 dataZoom 组件
                        start: 0,      // 左边在 0% 的位置。
                        end: 100       // 右边在 100% 的位置。
                    }]
                };

                myChartbar.setOption(option1);
                async function bubbling(arr, labels){
                for(var i = 0; i < arr.length - 1; i++){
                    for(var j = 0; j < arr.length - i - 1; j++){
                        if(arr[j] > arr[j + 1]){
                            // 交换柱状图的数据
                            var temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;

                            // 同时交换x轴的标签
                            var tempLabel = labels[j];
                            labels[j] = labels[j + 1];
                            labels[j + 1] = tempLabel;

                            // 更新图表
                            myChartbar.setOption({
                                xAxis: {
                                    data: labels
                                },
                                series: [{
                                    data: arr,
                                    itemStyle: {
                                        color: function(params) {
                                            if(params.dataIndex == j) {
                                                return '#BDB76B';
                                            } else if(params.dataIndex == j+1) {
                                                return '#8FBC8F';
                                            } else if(params.dataIndex >= arr.length - i) {
                                                return '#B0C4DE';
                                            } else {
                                                return '#C0C0C0';
                                            }
                                        }
                                    }
                                }]
                            });

                            // 延迟以便动态显示过程
                            await new Promise(r => setTimeout(r, 800));
                        }
                    }
                }
                // 最终更新以显示所有柱子的颜色为灰色
                myChartbar.setOption({
                    xAxis:{
                        data: labels
                    },
                    series:[{
                        data: arr,
                        type: 'bar',
                        itemStyle: {
                            color: '#B0C4DE'
                        }
                    }]
                });
            };
                bubbling(series_Data, xAxis_Data);
            }
        });
//日历图
        var stuTime = []; 
        var series_data = [];
        $.ajax({
            url: "../Handler.ashx?type=stuTime",
            dataType: 'json',
            success: function (data1) {
                $.each(data1, function (index, item) {                
                    series_data.push({
                        value: [item.time, 100] 
                    });
                });
        
                var myChartdate = echarts.init(document.getElementById('date'));
                var optionDate = {
                    calendar: {
                        left:'31%',
                        orient: 'vertical',
                        range: ["2024-05-01", "2024-07-01"],
                        cellSize: 30,
                        dayLabel: {
                            show: true,  
                            firstDay: 0,
                            margin: 10,
                        },
                        monthLabel: {
                            margin: 20,
                        },
                        yearLabel: {
                            margin: 30,
                        }
                    },
                    series: [{
                        coordinateSystem: 'calendar',
                        type: 'effectScatter',
                        symbolSize: function (data) {
                            return data[1] / 10; 
                        },
                        data: series_data,  
                        itemStyle: {
                            color: '#a00', 
                        },
                    }]
                };
                myChartdate.setOption(optionDate);
            }
        });
//排行榜
        var series_name = []; 
        var series_data = [];
        const typeSymbol = 'path://M503.9 642.5c-7.2 1.35-50.85 44.55-65.25 38.25-12.6-4.95 7.2-49.95-3.6-64.8-10.8-14.85-93.6 0.45-124.65 15.3-30.6 14.85-80.55 55.35-98.1 109.35-17.1 53.1-15.3 110.7 15.3 136.35 30.6 26.1 75.6 2.7 75.6 2.7s0.45 64.35 41.85 73.35c40.5 9 121.05-13.05 161.1-76.5 40.05-63 29.7-163.35 22.5-196.2-7.65-33.3-17.55-39.15-24.75-37.8zM861.2 623.6c-51.75-44.1-214.2-78.75-238.5-62.1-24.75 17.1 14.85 58.05 2.25 64.8-11.7 7.2-43.2-27.45-55.35-22.95-11.7 4.95-28.8 102.15-5.85 162 22.95 60.3 109.35 151.65 167.85 125.1 58.5-26.55 50.85-73.8 50.85-73.8s79.65 18 108.9-31.5c30.15-49.05 10.35-126.9-30.15-161.55zM584.45 444.05c10.35 8.1 49.5-9.45 59.4 0.45 9.45 10.35-51.3 40.95-32.85 64.35 18.45 22.5 168.75 37.8 232.2 13.05 57.15-22.05 108.45-77.85 98.1-145.35-9-56.25-89.55-71.1-89.55-71.1s20.25-61.65-27-85.05c-83.25-41.85-144.45 27-183.15 89.55-34.65 55.35-67.5 126.45-57.15 134.1zM523.25 70.55c-57.6-13.95-101.25 62.55-101.25 62.55s-57.6-10.35-95.4 25.2c-46.35 42.75-36.45 105.3 8.55 164.25 40.05 51.75 104.4 94.5 115.65 89.1 11.25-5.85 10.35-47.7 22.95-51.75 13.5-4.5 20.25 60.75 49.05 53.55 28.8-7.2 101.25-134.1 102.15-200.25 1.8-58.95-31.95-126-101.7-142.65zM262.25 622.25c64.35-18.45 144.45-42.3 144.9-64.8 0.45-21.6-67.5-33.75-61.65-59.85 3.6-13.05 69.3-2.7 73.8-31.05 4.05-21.6-46.8-81-112.05-113.4-54.45-27-143.55-42.3-182.7 14.85-32.85 47.7 0.45 100.35 0.45 100.35s-57.15 44.55-40.95 93.15c18.9 58.5 105.3 81.9 178.2 60.75z';
        const labelSetting = {
          show: true,
          position: 'right',
          offset: [10, 0],
          fontSize: 16
        };
        $.ajax({
            url: "../Handler.ashx?type=stuScore",
            dataType: 'json',
            success: function (data1) {
                //console.log(data1);
                $.each(data1, function (index, item) {
                    series_name.push(item.name); // 正确的数组名
                    series_data.push(item.value); // 正确的数组名
                });
                data1.sort(function (a, b) {
                    return b.value - a.value;
                });
                var top5Data = data1.slice(0, 5);
                var myChartphb = echarts.init(document.getElementById('phb'));
                function makeOption(type, symbol) {
                    return {
                        title: {
                            text:'21级第二课堂分排行榜'
                        },
                        tooltip: {
                          trigger: 'axis',
                          axisPointer: {
                            type: 'shadow'
                          }
                        },
                        grid: {
                            left: '1%',
                            right: '8%',
                            bottom: '3%',
                            containLabel: true
                        },
                        xAxis: {
                            boundaryGap: [0, 0.01],
                            show: false,
                            axisLine: { show: false },
                            axisLabel: { show: false },
                            axisTick: { show: false }
                        },
                        animationDurationUpdate: 500,
                        yAxis: {
                            data: top5Data.map(item => item.name),
                            axisLabel: {
                                margin: 30,
                                fontSize: 14
                            },
                            axisTick: { show: false },
                            axisLine: { show: false },
                            inverse: true,

                        },
                        series: [{
                            name: '数值',
                            type: type,
                            label: labelSetting,
                            symbolRepeat: true,
                            symbolSize: ['80%', '60%'],
                            color:'#CD8C95',
                            barCategoryGap: '40%',
                            universalTransition: {
                                enabled: true,
                                delay: function (idx, total) {
                                    return (idx / total) * 1000;
                                }
                            },

                            data: top5Data.map(item => ({
                                value: item.value,
                                name: item.name,
                                symbol: symbol||typeSymbol,
                            })),
                            label: {
                                show: true,
                                position: 'right', // 标签显示位置
                                formatter: '{c}' // 标签内容格式器
                            }
                        }]
                    };
                }

                const options = [
                  makeOption('pictorialBar'),
                  makeOption('bar'),
                  makeOption('pictorialBar', 'diamond')
                ];
                var optionIndex = 0;
                option = options[optionIndex];
                setInterval(function () {
                  optionIndex = (optionIndex + 1) % options.length;
                  myChartphb.setOption(options[optionIndex]);
                }, 2000);

                myChartphb.on('mouseover', function (params) {
                    if (params.componentType === 'series') {
                        var name = params.name;
                        getPhbname(name);                        
                    }
                });

                //var classData = ['日常生活劳动', '课外体育锻炼', '学术讲座', '读百部书看百部电影', '志愿服务', '其他'];
                var series_datapie = [];
                function getPhbname(name) {
                    $.ajax({
                        url: "../Handler.ashx",
                            dataType: 'json',
                            data: {
                                type: 'stuDetail',
                                name: name
                            },
                        success: function (data) {
                            console.log(data);
                            var total = 0;
                            
                            $.each(data, function (index, item) { 
                                total = [item.value1, item.value2, item.value3, item.value4, item.value5, item.value6]  
                                    .reduce(function(acc, val) { return acc + parseFloat(val || 0); }, 0);
                                series_datapie = [
                                    { value: item.value1 || 0, name: '日常生活劳动' },
                                    { value: item.value2 || 0, name: '课外体育锻炼' },
                                    { value: item.value3 || 0, name: '学术讲座' },
                                    { value: item.value4 || 0, name: '读百部书看百部电影' },
                                    { value: item.value5 || 0, name: '志愿服务' },
                                    { value: item.value6 || 0, name: '其他' }
                                ];
                                console.log(total);
                                 //console.log(series_datapie);   
                            });

                            var myChartpie = echarts.init(document.getElementById('pie'));
                            myChartpie.setOption({
                                legend: {
                                    top: 'bottom'
                                },
                            
                                tooltip: {
                                    trigger: 'item',
                                        formatter: function (params) {
                                            var percent = ((params.value / total) * 100).toFixed(2);
                                            return params.name + ': ' + params.value + '(' + percent + '%)';
                                        }
                                },
                                toolbox: {
                                    show: true,
                                    feature: {
                                        mark: { show: true },
                                        dataView: { show: true, readOnly: false },
                                        restore: { show: true },
                                        saveAsImage: { show: true }
                                    }
                                },
                            
                                series: [{
                                    name: '第二课堂分数占比',
                                    type: 'pie',
                                    radius: [50, 100],
                                    center: ['50%', '40%'],
                                    itemStyle: {
                                        borderRadius: 10,
					                    borderColor: '#fff',
					                    borderWidth: 2
                                    },
                                    label: {
                                        show: true
                                    },
                                    labelLine: {
                                        show: true
                                    },
                                    data: series_datapie,
                                }]
                            },true);
                        }
                    });
                    
                }

            }
        });
       

            
        </script>
</asp:Content>
