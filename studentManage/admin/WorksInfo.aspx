<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorksInfo.aspx.cs" Inherits="studentManage.admin.WorksInfo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学生作品编辑</title>
    <%--<link href="res/css/WorksInfo.css" rel="stylesheet" />--%>
    <style>
        body {
    font-family: Arial, sans-serif;
    background-color: #f7f8fc;
    margin: 0;
    padding: 20px;
}

.form-container {
    background-color: white;
    padding: 20px;
    border-radius: 10px;
    box-shadow: 0 0 10px rgba(0,0,0,0.1);
    max-width: 600px;
    margin: 0 auto;
}

.form-container h3 {
    margin-bottom: 20px;
}

.form-group {
    margin-bottom: 15px;
}
.form-group label {
    display: block;
    margin-bottom: 5px;
}

.form-group input, .form-group textarea, .form-group select {
    width: 90%;
    padding: 10px;
    border: 1px solid gray;
    border-radius: 10px;
}
.form-group #FileUploadVideo, #FileUploadPic {
        width: 50%;
    }

button, input[type="button"], input[type="submit"] {
    background: linear-gradient(to right, #4800ff, #6FB1FC);
    color: white;
    font-weight: bold;
    border: none;
    padding: 10px 20px;
    border-radius: 5px;
    cursor: pointer;
    margin-right: 10px;
    width:40%;
}

button, input[type="button"], input[type="submit"]:hover {
    background: linear-gradient(to right, #6FB1FC, #4800ff);
}
button, input[type="button"], input[type="submit"]:active{
    transform:scale(0.9);
}
.form-group img {
    display: block;
    margin-top: 10px;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h3>学生作品编辑</h3>
            <div class="form-group">
                <label for="txtWorkName">作品名称：</label>
                <asp:TextBox ID="txtWorkName" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="WorkContent">作品概述：</label>
                <textarea id="WorkContent" runat="server" cols="20" rows="2" name="S1"></textarea>
            </div>
            <div class="form-group">
                <label for="txtWorkTime">当前系统时间：</label>
                <asp:TextBox ID="txtWorkTime" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="FileUploadVideo">上传作品：</label>
                <asp:FileUpload ID="FileUploadVideo" runat="server" />
                <asp:Button ID="btnUploadVideo" runat="server" Text="上传" OnClick="btnUploadVideo_Click" CssClass="btn"/>
            </div>
            <div class="form-group">
                <label for="FileUploadPic">作品图片：</label>
                <asp:FileUpload ID="FileUploadPic" runat="server" />
                <asp:Button ID="btnUploadPic" runat="server" Text="上传" OnClick="btnUploadPic_Click" CssClass="btn"/>
            </div>
            <div class="form-group">
                <label for="txtWorkVideoUrl">视频URL：</label>
                <asp:TextBox ID="txtWorkVideoUrl" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtWorkPicUrl">图片URL：</label>
                <asp:TextBox ID="txtWorkPicUrl" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Image ID="imgsrc" runat="server" Width="30%" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnEdit" runat="server" Text="修改" OnClick="btnEdit_Click" CssClass="btn"/>
                <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="btn"/>
            </div>
        </div>
    </form>
</body>
</html>
