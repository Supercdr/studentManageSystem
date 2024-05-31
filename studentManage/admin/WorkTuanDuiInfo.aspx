<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkTuanDuiInfo.aspx.cs" Inherits="studentManage.admin.WorkTuanDuiInfo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>团队学生作品编辑</title>
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
            max-width: 800px;
            margin: 0 20px;
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
        .form-group input, .form-group textarea, .form-group select, .form-group .file-upload-container {
            width: 96%;
            padding: 10px;
            border: 1px solid gray;
            border-radius: 5px;
        }
        button, input[type="button"], input[type="submit"]  {
            background: linear-gradient(to right, #4800ff, #6FB1FC);
            color: white;
            font-weight: bold;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            margin:0 10px;
            width:40%;
        }
        button, input[type="button"], input[type="submit"]:hover {
            background: linear-gradient(to right, #6FB1FC, #4800ff);
        }
        button, input[type="button"], input[type="submit"]:active {
            transform: scale(0.9);
        }
        .form-group img {
            display: block;
            margin-top: 10px;
        }
        .file-upload-container {
            display: flex;
            align-items: center;
        }
        .upload input, .upload button {
            border:none !important;
        }
        .file-upload-container input[type="file"] {
            flex: 1;
        }
        .file-upload-container button {
            margin-left: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h3>团队学生作品编辑</h3>
            <div class="form-group">
                <label for="txttdmc">团队名称</label>
                <asp:TextBox ID="txttdmc" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtWorkName">作品名称</label>
                <asp:TextBox ID="txtWorkName" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="WorkContent">作品描述</label>
                <textarea id="WorkContent" runat="server" cols="20" rows="2"></textarea>
            </div>
            <div class="form-group">
                <label for="txtTime">当前系统时间</label>
                <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="FileUploadVideo">上传作品</label>
                <div class="file-upload-container upload">
                    <asp:FileUpload ID="FileUploadVideo" runat="server" />
                    <asp:Button ID="btnUploadVideo" runat="server" Text="上传" OnClick="btnUploadVideo_Click" CssClass="btn"/>
                </div>
                <small>视频格式：MP4</small>
            </div>
            <div class="form-group">
                <label for="txtWorkVideoUrl">视频URL</label>
                <asp:TextBox ID="txtWorkVideoUrl" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="FileUploadPic">作品图片</label>
                <div class="file-upload-container upload">
                    <asp:FileUpload ID="FileUploadPic" runat="server" />
                    <asp:Button ID="btnUploadPic" runat="server" Text="上传" OnClick="btnUploadPic_Click" CssClass="btn"/>
                </div>
                <small>图片格式：jpg, gif, png</small>
            </div>
            <div class="form-group">
                <label for="txtWorkPicUrl">图片URL</label>
                <asp:TextBox ID="txtWorkPicUrl" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Image ID="imgsrc" runat="server" Width="20%"/>
            </div>
            <div class="form-group">
                <label for="txtUser1">团队成员（1）【团队组长】</label>
                <div class="file-upload-container">
                    <asp:TextBox ID="txtUser1" runat="server"></asp:TextBox>
                    <asp:Button ID="BtnSearch1" runat="server" Text="查询" OnClick="BtnSearch1_Click" CssClass="btn"/>
                </div>
                <label for="txtUserID1">学号</label>
                <asp:TextBox ID="txtUserID1" runat="server"></asp:TextBox>
                <label for="txtUserID1Des">该成员负责模块介绍（1）</label>
                <asp:TextBox ID="txtUserID1Des" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtUser2">团队成员（2）</label>
                <div class="file-upload-container">
                    <asp:TextBox ID="txtUser2" runat="server"></asp:TextBox>
                    <asp:Button ID="BtnSearch2" runat="server" Text="查找" OnClick="BtnSearch2_Click" CssClass="btn"/>
                </div>
                <label for="txtUserID2">学号</label>
                <asp:TextBox ID="txtUserID2" runat="server"></asp:TextBox>
                <label for="txtUserID2Des">该成员负责模块介绍（2）</label>
                <asp:TextBox ID="txtUserID2Des" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtUser3">团队成员（3）</label>
                <div class="file-upload-container">
                    <asp:TextBox ID="txtUser3" runat="server"></asp:TextBox>
                    <asp:Button ID="BtnSearch3" runat="server" Text="查找" OnClick="BtnSearch3_Click" CssClass="btn"/>
                </div>
                <label for="txtUserID3">学号</label>
                <asp:TextBox ID="txtUserID3" runat="server"></asp:TextBox>
                <label for="txtUserID3Des">该成员负责模块介绍（3）</label>
                <asp:TextBox ID="txtUserID3Des" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnEdit" runat="server" Text="编辑" OnClick="btnEdit_Click" CssClass="btn"/>
                <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="btn"/>
            </div>
        </div>
    </form>
</body>
</html>
