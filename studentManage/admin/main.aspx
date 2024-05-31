<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="studentManage.admin.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>迁徙图</title>
    <%--<link href="res/css/main.css" rel="stylesheet" />--%>
    <script src="res/echarts/echarts.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="res/echarts/china.js"></script>
    <style>
        body{
            width:100%;
            height:90%;
            background-color:#f7f8fc;
            padding:10px;
        }
        #container{
            background-color:white;
            padding:20px;
            border-radius:20px;
            display:flex;
            flex-direction:column;
        }
        #BarChart{
            height:600px;
            width:800px;
            display:inline-block;
        }
        #XuRiChart {
            height:600px;
            width:600px;
            display:inline-block;
        }
        #MapChart{
            height:600px;
            width:1400px;
        }
    </style>
</head>
<body>
    <div id="container">
        <div>
            <div id="BarChart"></div>
            <div id="XuRiChart"></div>
        </div>
        <div id="MapChart"></div>
    </div>

    <script>
        var colors = ['#ccccff', '#ff9999', '#ffd633', '#66ffc2', '#e6b3ff', '#80b3ff']; 
        var MapChart = echarts.init(document.getElementById('MapChart'));
        var BarChart = echarts.init(document.getElementById('BarChart'));
        var XuRiChart = echarts.init(document.getElementById('XuRiChart'));
        $.ajax({
                url: "../Handler.ashx?type=MapData", 
                dataType: 'json',
                success: function (data) {
                    //console.log(data);
                    function getCityNameFromChineseAddress(address) {
                        const regex = /^(?<province>.+?(省|自治区|市))?(?<city>[^市]+市)/;
                        const match = address.match(regex);
 
                        if (match && match.groups.city) {
                            return match.groups.city.replace("市", "");
                        }
                        return null;
                    }
                    
                var processedData = data.map(function (item) {
                    var cityName = getCityNameFromChineseAddress(item.name);
                    return {
                        name: cityName || "未知城市", 
                        value: item.value,
                        stuname: item.stuname
                    };
                });
                //console.log(processedData);
                    var geoCoordMap = {
                    "拉萨":[91.132212,29.660361],
                    "阜阳": [115.819729, 32.896969],
                    "芜湖": [118.376451, 31.326319],
                    "金昌": [102.188043, 38.520089],
                    "佛山": [113.122717, 23.028762],
                    "汕头": [116.708463, 23.37102],
                    "深圳": [114.057868, 22.543099],
                    "南宁": [108.320004, 22.82402],
                    "毕节": [105.28501, 27.301693],
                    "遵义": [106.937265, 27.706626],
                    "廊坊": [116.704441, 39.523927],
                    "信阳": [114.075031, 32.123274],
                    "郑州": [113.665412, 34.757975],
                    "周口": [114.649653, 33.620357],
                    "黑河": [127.528293, 50.245329],
                    "孝感": [113.926655, 30.926423],
                    "常德": [111.691347, 29.040225],
                    "长春": [125.3245, 43.886841],
                    "无锡": [120.301663, 31.574729],
                    "赣州": [114.940278, 25.85097],
                    "上饶": [117.971185, 28.44442],
                    "乌兰察布": [113.114543, 41.034126],
                    "固原": [106.285241, 36.004561],
                    "滨州": [118.016974, 37.383542],
                    "阳泉": [113.583285, 37.861188],
                    "西安": [108.948024, 34.263161],
                    "上海": [121.472644, 31.231706],
                    "达州": [107.502262, 31.209484],
                    "泸州": [105.443348, 28.889138],
                    "昆明": [102.712251, 25.040609],
                    "临沧": [100.08697, 23.886567],
                    "慈溪": [121.248052, 30.177142],
                    "杭州": [120.153576, 30.287459],
                    "嘉兴": [120.750865, 30.762653],
                    "宁波": [121.549792, 29.868388],
                    "衢州": [118.87263, 28.941708],
                    "绍兴": [120.582112, 29.997117],
                    "重庆": [106.504962, 29.533155]
                };

                var convertData = function (data) {
                    var res = [];
                    data.forEach(item => {
                        var fromCoord = geoCoordMap[item.name]; 
                        var toCoord = geoCoordMap["杭州"];
                        if (fromCoord && toCoord) {
                            res.push({
                                fromName: item.name,
                                toName: "杭州",
                                coords: [fromCoord, toCoord],
                                value: item.value,
                                stuname: item.stuname,
                                name:item.name
                            });
                        }
                    });
                    return res;
                };
                var succeedData = convertData(processedData);
                //console.log(succeedData);
                const convertScatterData=function(data){
				        var res=[];
				        var temp=[];
				        for(var i=0;i<data.length;i++){
					        var endCity=data[i].fromName,
						        size=data[i].value;
                            var geoCoord=geoCoordMap[endCity];
                            if(geoCoord){
                              var index=temp.indexOf(endCity);
                              if(index===-1)
                              {
                                res.push({
                                  name:endCity,
                                  value:geoCoord.concat(size),
                                  symbolSize:Math.sqrt(size)*4.3,
                                  stuname: data[i].stuname,
                                  coords: data[i].coords,
                                });
                                temp.push(endCity);
                              }
                            }
				        }
                      return res;
                };
                
                //console.log(convertScatterData(succeedData));
                var planePath='path://M563.4 623.8c0.8-13.8 16.6-9 16.6-9l124 25.2 256 97.4c0-48-7.6-53-18.8-61.4L576 414c0 0-9.8-120-9.8-225.8 0-49-23.6-156.2-54.2-156.2s-54.2 108.8-54.2 156.2c0 100.4-9.8 225.8-9.8 225.8L82.8 676c-14.2 10-18.8 15.4-18.8 61.4L320 640l123.8-25.2c0 0 15.8-4.8 16.6 9 0.8 13.8-2.4 138.2 11.8 204.2 1.8 8.8-5 9.4-9.6 14.8l-103.8 65.6c-3.4 3.8-5 14.6-5 14.6l-2 37 136-32 24 64 24-64 136 32-2-37c0.2 0-1.4-10.8-4.8-14.6l-103.8-65.6c-4.6-5.4-11.4-6-9.6-14.8C565.4 762 562.6 637.6 563.4 623.8z';
                var MapOption = {
                    title: {
                        text: '21软工2班上学迁徙图',
                        left: 'center'
                    },
                    tooltip: {
                        trigger: 'item',
                        //formatter: function(params) {
                        //   return `${params.data.stuname}&nbsp;家庭地址: ${params.data.name} <br/> ${params.data.coords}`;
                        //}
                    },
                    geo: {
                        map: 'china',
                        //roam: true, 
                        label: {
                            emphasis: {
                                show: false,
                            }
                        },
                        itemStyle: {
                            normal: {
                                areaColor:'black', // 地图区域的颜色
                                borderColor: '#0692a4', // 边界线颜色
                            },
                            emphasis: {
                                areaColor: '#2a333d'
                            }
                        }
                    },
                    series: [
                        {
                            name: '上学',
                            type: 'lines',
                            coordinateSystem: 'geo',
                            data: succeedData,
                            zlevel: 2,
                            large: true,
                            effect:{
					            show:true,
					            period:5,
					            trailLength:0.2,
                                symbol:planePath,
                                symbolRotate:0,
					            symbolSize:14,
					            loop:true,
				            },
                            lineStyle: {
                                width: 2,
                                opacity:0.2,
                                 color: function(params) {
                                    return colors[Math.floor(Math.random() * colors.length)]; 
                                },
                                curveness: 0.2
                            },
                            label:{
                              show:true,
                              position:'inside',
                              color:'#fd666d'
                            }
                        },
                        {
                            name: '家庭地址',
                            type: 'effectScatter',
                            coordinateSystem: 'geo',
                            data:convertScatterData(succeedData),
                            rippleEffect:{
                              brushType:'stroke'
                            },
                            label:{
                              formatter:'{b}',
                              show:true,
                              color:'white',
                              position:'top'
                            },
                            zlevel:1
                        }
                    ]
                };
                MapChart.setOption(MapOption);
            }
        });

        $.ajax({
            url: "../Handler.ashx?type=BarChart",
            dataType: 'json',
            success: function (data) {
                //console.log(data);
                var grades = ["2020", "2021", "2022", "2023"];
                var MajorData = data.reduce((prev, item) => {
                    if (!prev[item.Major]) {
                        prev[item.Major] = new Array(grades.length).fill(0);
                    }
                    var index = grades.indexOf(item.Grade);
                    if (index !== -1) {
                        prev[item.Major][index] += item.NumOfStu;
                    }
                    return prev;
                }, {});
                //console.log(MajorData);
                var seriesData = Object.keys(MajorData).map(major => ({
                    name: major,
                    type: 'bar',
                    stack: 'total',
                    data: MajorData[major],
                    emphasis: { focus: 'series' }
                }));
                //console.log(seriesData);

                var BarOption = {
                    title: {
                        text: '2020-2023各年级专业人数分布',
                        left: 'left'
                    },
                    tooltip: {
                        trigger: 'axis',
                        axisPointer: {
                            type: 'shadow'
                        }
                    },
                    legend: {
                        orient: 'vertical',
                        left: 'right',
                        top:'2%',
                        data: Object.keys(MajorData)
                    },
                    grid: {
                        left: '3%',
                        right: '17%',
                        bottom: '3%',
                        containLabel: true
                    },
                    xAxis: {
                        type: 'value'
                    },
                    yAxis: {
                        type: 'category',
                        data: grades
                    },
                    series: seriesData
                };

                BarChart.setOption(BarOption);

                function getXuRiData(year) {
                      $.ajax({
                            url: "../Handler.ashx",
                            dataType: 'json',
                            data: {
                                type: 'XuRiChart',
                                year: year
                            },
                            success: function (data) {
                                //console.log(data);
                                var total = data.reduce((sum, item) => sum + item.NumOfStu, 0);
                                var ClassData = data.reduce((result, item) => {
                                    if (!result[item.Major]) {
                                        result[item.Major] = {
                                            name: item.Major,
                                            //itemStyle: {
                                            //    color: colors[Math.floor(Math.random() * colors.length)],
                                            //},
                                            children: []
                                        };
                                    }
                                    result[item.Major].children.push({
                                        name: item.StuClass,
                                        value: item.NumOfStu,
                                        //itemStyle: {
                                        //    color: colors[Math.floor(Math.random() * colors.length)],
                                        //},
                                    });
                                    return result;
                                }, {});
                                //console.log(ClassData);
                                var Data = Object.values(ClassData);
                                //console.log(Data);

                                XuRiChart.setOption({
                                    title: {
                                        text: year+'年各专业班级人数分布图 ',
                                        textStyle: {
                                            align: 'left'
                                        },
                                        left: '3%',
                                    },
                                    tooltip: {
                                        trigger: 'item',
                                        formatter: function (params) {
                                            var percent = ((params.value / total) * 100).toFixed(2);
                                            return params.name + ': ' + params.value + '人 (' + percent + '%)';
                                        }
                                    },
                                    legend: {
                                        orient: 'vertical',
                                        left: 'right',
                                        data: Data.map(item=>item.name)
                                    },
                                    series: [{
                                        type: 'sunburst',
                                        data: Data,
                                        radius: [0, '95%'],
                                        sort: undefined,
                                        emphasis: {
                                            focus: 'ancestor'
                                        },
                                        levels: [
                                            { },
                                            {
                                                r0: '10%',
                                                r: '45%',
                                                itemStyle: {
                                                    borderWidth: 2
                                                },
                                                label: {
                                                    align: 'left',
                                                }
                                            },
                                            {
                                                r0: '30%',
                                                r: '70%',
                                                label: {
                                                    align:'left',
                                                    // textShadowBlur: 5,
                                                    //textShadowColor: '#3333ff',
                                                    padding: 13,
                                                    silent: false
                                                },
                                                itemStyle: {
                                                    borderWidth: 1.5
                                                }
                                            }]
                                    }]
                                }, true);
                            },
                      });
                }
                $(document).ready(function() {
                    getXuRiData('2021');
                });

                BarChart.on('mouseover', function (params) {
                    if (params.componentType === 'series') {
                        var yearIndex = params.dataIndex;
                        var year = grades[yearIndex];
                        getXuRiData(year);
                    }
                });
            }
        })
            
    </script>
</body>
</html>
