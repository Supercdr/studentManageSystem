<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentInfoAdd.aspx.cs" Inherits="studentManage.admin.StudentInfoAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>添加学生信息</title>
    <link href="res/css/StudentInfoAdd.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <div class="form-group">
                <label for="txtUserName">学生姓名：</label>
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="DDLSex">性别：</label>
                <asp:DropDownList ID="DDLSex" runat="server">
                    <asp:ListItem Value="1">男</asp:ListItem>
                    <asp:ListItem Value="2">女</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtUserNumber">学号：</label>
                <asp:TextBox ID="txtUserNumber" runat="server"></asp:TextBox>
                <asp:Button ID="btnCheck" runat="server" Text="检查是否重复" OnClick="btnCheck_Click" CssClass="btn"/>
            </div>
            <div class="form-group">
                <label for="txtUserPass">登录密码：</label>
                <asp:TextBox ID="txtUserPass" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtUserXy">所属学院(系别)：</label>
                <asp:TextBox ID="txtUserXy" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtUserZy">所学专业：</label>
                <asp:TextBox ID="txtUserZy" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtUserBj">所属班级：</label>
                <asp:TextBox ID="txtUserBj" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtUserBj">户口所在地(精确到市)：</label>
                <asp:TextBox ID="txtUserAddress" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtUserAddTime">当前系统时间：</label>
                <asp:TextBox ID="txtUserAddTime" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnOK" runat="server" Text="添加" OnClick="btnOK_Click" CssClass="btn"/>
                <asp:Button ID="btnEdit" runat="server" Text="修改" OnClick="btnEdit_Click" CssClass="btn"/>
            </div>
            <div class="note">
                <asp:Label ID="Label1" runat="server" Text="说明：为了系统便于统一管理，请按照学校相关规定，对学校名称、专业名称、班级名称统一编排。<br/> 系统默认学生登录密码：123456。学生登录系统后，请自行修改默认登录密码！"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
