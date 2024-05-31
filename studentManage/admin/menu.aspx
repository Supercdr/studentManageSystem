<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="studentManage.admin.menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%--<link rel="stylesheet" href="res/css/menu.css" />--%>
    <style>
        body {
            margin:0;
            padding:0;
            font-family: Arial, sans-serif;
        }
        .sidebar {
            width: 200px;
            background-color: white;
            position: fixed;
            color: black;
            height: 100%;
            overflow: auto;
            border-radius: 10px;
        }
        .sidebar a {
            display: block;
            color: black;
            padding: 16px;
            text-decoration: none;
            border-radius: 20px;
        }
        .sidebar a:hover {
            color: white;
            background-color: #4A50DB;
        }
        .sidebar .bitem {
            margin: 30px 0px;
        }
        .sidebar .bitem dt {
            background-color: white;
            padding: 15px;
            cursor: pointer;
            border-radius: 20px;
        }
        .sidebar .bitem dt:hover {
            color: white;
            background-color: #4A50DB;
        }
        .sidebar .bitem dd {
            display: none;
            background-color: white;
            margin: 0;
            padding: 0;
        }
        .sidebar .bitem dd ul {
            list-style-type: none;
            padding: 0;
        }
        .sidebar .bitem dd ul li {
            margin: 0;
        }
        .sidebar .active {
            color: white;
            background-color: #4A50DB;
        }
        .topbar {
            background-color: #2c3e50;
            color: black;
            padding: 15px;
            text-align: right;
        }
        #first{
            padding:0;
            font-weight:bold;
        }
    </style>
    <script type="text/javascript">
        function showHide(id) {
            var elem = document.getElementById(id);
            if (elem.style.display === 'none') {
                elem.style.display = 'block';
            } else {
                elem.style.display = 'none';
            }
        }

        document.addEventListener('DOMContentLoaded', function () {
            var menuItems = document.querySelectorAll('.sidebar a');
            menuItems.forEach(function (item) {
                item.addEventListener('click', function () {
                    menuItems.forEach(function (i) {
                        i.classList.remove('active');
                    });
                    item.classList.add('active');
                });
            });
        });
    </script>
</head>
<body>
    <div class="sidebar">

        <dl class="bitem">
            <dt id="first"> <a href="main.aspx" target="mainFrame">首页>></a></dt>
        </dl>
        <dl class="bitem">
            <dt onclick="showHide('items1_1')"><b>系统参数>></b></dt>
            <dd class="sitem" id="items1_1">
                <ul class="sitemu">
                    <li><a href="AdminInfo.aspx?action=Add" target="mainFrame">系统账号管理</a></li>
                </ul>
            </dd>
        </dl>
        <dl class="bitem">
            <dt onclick="showHide('items4_1')"><b>学生信息管理>></b></dt>
            <dd class="sitem" id="items4_1">
                <ul class="sitemu">
                    <li><a href="StudentInfo.aspx" target="mainFrame">学生列表</a></li>
                    <li><a href="StudentInfoAdd.aspx?action=Add" target="mainFrame">添加学生信息</a></li>
                </ul>
            </dd>
        </dl>
        <dl class="bitem">
            <dt onclick="showHide('items4_8')"><b>个人作品管理>></b></dt>
            <dd class="sitem" id="items4_8">
                <ul class="sitemu">
                    <li><a href="WorkPersonList.aspx" target="mainFrame">作品列表</a></li>
                </ul>
            </dd>
        </dl>
        <dl class="bitem">
            <dt onclick="showHide('items4_6')"><b>团队作品管理>></b></dt>
            <dd class="sitem" id="items4_6">
                <ul class="sitemu">
                    <li><a href="WorkTuanDuiList.aspx" target="mainFrame">作品列表</a></li>
                </ul>
            </dd>
        </dl>
    </div>
</body>
</html>
