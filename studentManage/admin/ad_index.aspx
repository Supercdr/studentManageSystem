<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ad_index.aspx.cs" Inherits="studentManage.admin.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理员主页面</title>
    <style>
        body {
            height: 100%;
            margin: 0;
            padding: 0;
            font-family: Arial, Helvetica, sans-serif;
        }
        #container {
            display: flex;
            flex-direction: column;
            height:100vh;
        }
        #topFrame{
            height:70px;
            width:100%;
            border:none;
        }
        #frame {
            display: flex;
            flex:1;
            width:100%;
        }
        #menuFrame {
            border: none;
            width: 200px;
            background-color: #f7f8fc;
        }
        #mainFrame {
            flex:1;
            border: none;
            background-color: #f7f8fc;
        }
        #noframebody{
            padding:20px;
            display:none;
        }
    </style>
</head>
<body>
     <form id="form1" runat="server">
        <div id="container" runat="server">
            <iframe src="top.aspx" id="topFrame" name="topFrame"></iframe>
            <div id="frame">
                <iframe src="menu.aspx" id="menuFrame" name="menuFrame"  ></iframe>
                <iframe src="main.aspx" id="mainFrame" name="mainFrame"  ></iframe>
            </div>
    
            <div id="noframebody">
                <span>您的浏览器不支持框架!！</span>
            </div>
        </div>
    </form>
</body>
</html>
