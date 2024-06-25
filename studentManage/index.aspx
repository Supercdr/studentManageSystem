
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="studentManage.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学生信息管理系统登录</title>
    <%--<link href="res/css/login.css" rel="stylesheet" />--%>
    <style>
        body {
            background: linear-gradient(to right, #4800ff, #6FB1FC);
            font-family: Arial, sans-serif;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
            margin: 0;
        }

        .login-container {
            width: 500px;
            padding: 20px;
            background-color: #F4F4F9;
            border-radius: 10px;
            text-align: center;
        }

            .login-container h2 {
                margin-bottom: 20px;
                color: #2E85EB;
            }

            .login-container input[type="text"], .login-container input[type="password"] {
                width: 80%;
                height: 30px;
                padding: 10px;
                margin: 10px 0;
                border: 1px solid #CCC;
                border-radius: 5px;
            }

            .login-container input[type="radio"] {
                margin: 0 5px;
            }

        #Button1 {
            width: 80%;
            margin-top: 20px;
            margin-bottom: 20px;
            padding: 14px;
            letter-spacing: 20px;
            font-size: 17px;
            border: none;
            border-radius: 5px;
            background: linear-gradient(to right, #4800ff, #6FB1FC);
            color: white;
            cursor: pointer;
        }
            #Button1:hover {
                background: linear-gradient(to right, #6FB1FC, #4800ff);
            }

            #Button1:active {
                transform: scale(0.9);
            }
        #roleContainer {
            display: flex;
            margin-top: 20px;
            justify-content: space-around;
        }

    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="login-container">
            <h2>学生信息管理系统</h2>
            <asp:TextBox ID="txtUserName" runat="server" placeholder="用户名"></asp:TextBox>
            <asp:TextBox ID="txtUserPass" runat="server" TextMode="Password" placeholder="密码"></asp:TextBox>
            <div id="roleContainer">
                <span><asp:RadioButton ID="rblRoleAdmin" runat="server" GroupName="Role" Text="管理员" Checked="True" /></span>
                <span><asp:RadioButton ID="rblRoleStudent" runat="server" GroupName="Role" Text="学生" /></span>
            </div>
            <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
