<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckFiles.aspx.cs" Inherits="studentManage.admin.CheckFiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; /* 使用更现代的字体 */
        background-color: #f0f4f8; /* 设定一个更柔和的背景色 */
        color: #333; /* 文字颜色设置为深灰色，增强可读性 */
        margin: 0;
        padding: 15px; /* 增加页面的内边距 */
        text-align: center; /* 文字居中显示 */
    }

    #form1 {
        background-color: white; /* 表单背景颜色 */
        width: 80%; /* 表单宽度 */
        margin: 0 auto; /* 居中显示 */
        padding: 20px; /* 表单内边距 */
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); /* 添加阴影效果 */
        border-radius: 8px; /* 边角圆滑处理 */
    }

    p {
        font-size: 16px; /* 设置字体大小 */
        color: black; /* 字体颜色 */
        line-height: 1.6; /* 行间距 */
    }

    a {
        color: darkblue; /* 链接颜色 */
        text-decoration: none; /* 去除下划线 */
    }

    a:hover {
        text-decoration: underline; /* 鼠标悬停时显示下划线 */
    }

    .blue {
        color: darkblue; /* 特别强调的蓝色字体 */
    }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>友情提醒</p>
            <p>
                <asp:Label ID="PlayOnline" runat="server"></asp:Label><br />
                <asp:Label ID="Download" runat="server" Text="Label"></asp:Label><br />
                <a href="javascript:history.back(-1)" target="mainFrame">返回</a>
            </p>
        </div>
    </form>
</body>
</html>
