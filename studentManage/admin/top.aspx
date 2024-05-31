<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="studentManage.admin.top" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学生信息管理系统</title>
    <%--<link rel="stylesheet" href="res/css/top.css" />--%>
    <style>
        body {
            background: linear-gradient(to right, #4800ff, #6FB1FC);
            height: 100vh;
            margin: 0;
        }
        #container {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 16px 20px;
            border-radius: 10px;
        }
        #title{
            font-weight:bold;
            font-size: 25px;  
            color:white;
        }
        #account {
            color:white;
            position: relative;
            display: flex;
            align-items: center;
            cursor: pointer;
        }
        #accountDropdown {
            display: none;
        }
        #btnExit, #btnLoginOut{
            color: white;
            text-decoration: none;
            display: inline-block;
            padding: 5px 10px;
            border-radius: 5px;
        }
        #btnExit:hover {
            background-color: white;
            color:dodgerblue;
        }
         #btnLoginOut:hover {
            background-color: white;
            color:dodgerblue;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container" runat="server">
            <span id="title">学生信息管理系统</span>
            <div id="account" onclick="toggleDropdown()">
                <div>
                    <asp:Label ID="Label1" runat="server" Text="用户"></asp:Label>
                    <span>>>></span>
                </div>
                <span id="accountDropdown" runat="server">
                    <asp:LinkButton ID="btnExit" runat="server" OnClick="btnExit_Click" Text="退出"></asp:LinkButton>
                    <asp:LinkButton ID="btnLoginOut" runat="server" OnClick="btnLoginOut_Click" Text="注销"></asp:LinkButton>
                </span>
            </div>
        </div>
    </form>
    <script>
       function toggleDropdown() {
            var dropdown = document.getElementById("accountDropdown");
            if (dropdown.style.display === "none" || dropdown.style.display === "") {
                dropdown.style.display = "block";
            } else {
                dropdown.style.display = "none";
            }
        }
        // 点击页面其他地方时隐藏下拉列表
        document.addEventListener("click", function(event) {
            var account = document.getElementById("account");
            var dropdown = document.getElementById("accountDropdown");
            if (!account.contains(event.target)) {
                dropdown.style.display = "none";
            }
        });
    </script>
</body>
</html>
