<%@ Page Title="" Language="C#" MasterPageFile="~/stu/MasterPage.master" AutoEventWireup="true" CodeBehind="WorkTuanDuiInfo.aspx.cs" Inherits="studentManage.stu.WorkTuanDuiInfo" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        .uploaded-image {
            display: block;
            margin-top: 10px;
        }
        .inline-container {
            display: flex;
            align-items: center;
        }
        .inline-container .input-text {
            flex:1;
            margin-right: 10px;
        }
        .inline-container .btn {
            width:40%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <h3>团队作品信息</h3>
        <div class="form-group">
            <label for="txttdmc">团队名称：</label>
            <asp:TextBox ID="txttdmc" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtWorkName">作品名称：</label>
            <asp:TextBox ID="txtWorkName" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>作品分类：</label>
            <span>团队作品</span>
        </div>
        <div class="form-group">
            <label for="WorkContent">作品描述：</label>
            <textarea id="WorkContent" runat="server" cols="20" rows="2" class="textarea"></textarea>
        </div>
        <div class="form-group">
            <label for="txtWorkTime">当前系统时间：</label>
            <asp:TextBox ID="txtWorkTime" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="FileUploadVideo">上传作品：<small>视频格式：mp4</small></label>
            <div class="file-upload-container">
                <asp:FileUpload ID="FileUploadVideo" runat="server" CssClass="file-upload" />
                <asp:Button ID="btnUploadVideo" runat="server" Text="上传" OnClick="btnUploadVideo_Click" CssClass="btn" />
            </div>
        </div>
        <div class="form-group">
            <label for="txtWorkVideoUrl">作品视频URL：</label>
            <asp:TextBox ID="txtWorkVideoUrl" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="FileUploadPic">作品图片：<small>图片格式：JPG, GIF, PNG</small></label>
            <div class="file-upload-container">
                <asp:FileUpload ID="FileUploadPic" runat="server" CssClass="file-upload" />
                <asp:Button ID="btnUploadPic" runat="server" Text="上传" OnClick="btnUploadPic_Click" CssClass="btn" />
            </div>
        </div>
        <div class="form-group">
            <label for="txtWorkPicUrl">作品图片URL：</label>
            <asp:TextBox ID="txtWorkPicUrl" runat="server" CssClass="input-text"></asp:TextBox>
            <asp:Image ID="imgsrc" runat="server" Width="20%" Height="20%" CssClass="uploaded-image"/>
        </div>
        <div class="form-group">
            <label for="txtUser1">团队成员（1）【团队组长】：</label>
            <asp:TextBox ID="txtUser1" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group inline-container">
            <label for="txtUser1ID">学号：</label><br />
            <asp:TextBox ID="txtUser1ID" runat="server" CssClass="input-text"></asp:TextBox>
            <asp:Button ID="btnSearch1" runat="server" Text="查询" OnClick="btnSearch1_Click" CssClass="btn" />
        </div>
        <div class="form-group">
            <label for="txtUser1Des">该成员负责模块介绍（1）：</label>
            <asp:TextBox ID="txtUser1Des" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtUser2">团队成员（2）：</label>
            <asp:TextBox ID="txtUser2" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group inline-container">
            <label for="txtUser2ID">学号：</label><br />
            <asp:TextBox ID="txtUser2ID" runat="server" CssClass="input-text"></asp:TextBox>
            <asp:Button ID="btnSearch2" runat="server" Text="查询" OnClick="btnSearch2_Click" CssClass="btn" />
        </div>
        <div class="form-group">
            <label for="txtUser2Des">该成员负责模块介绍（2）：</label>
            <asp:TextBox ID="txtUser2Des" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtUser3">团队成员（3）：</label>
            <asp:TextBox ID="txtUser3" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group inline-container">
            <label for="txtUser3ID">学号：</label><br />
            <asp:TextBox ID="txtUser3ID" runat="server" CssClass="input-text"></asp:TextBox>
            <asp:Button ID="btnSearch3" runat="server" Text="查询" OnClick="btnSearch3_Click" CssClass="btn" />
        </div>
        <div class="form-group">
            <label for="txtUser3Des">该成员负责模块介绍（3）：</label>
            <asp:TextBox ID="txtUser3Des" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnOK" runat="server" Text="提交" OnClick="btnOK_Click" CssClass="btn" />
        </div>
    </div>
</asp:Content>
