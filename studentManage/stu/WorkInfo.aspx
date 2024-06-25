<%@ Page Title="" Language="C#" MasterPageFile="~/stu/MasterPage.master" AutoEventWireup="true" CodeBehind="WorkInfo.aspx.cs" Inherits="studentManage.stu.WorkInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <h3>作品信息</h3>
        <div class="form-group">
            <label for="txtWorkName">作品名称：</label>
            <asp:TextBox ID="txtWorkName" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="workCategory">作品分类：</label>
            <span id="workCategory">个人作品</span>
        </div>
        <div class="form-group">
            <label for="WorkContent">作品描述：</label>
            <textarea id="WorkContent" runat="server" cols="20" rows="2" class="input-textarea"></textarea>
        </div>
        <div class="form-group">
            <label for="txtWorkTime">当前系统时间：</label>
            <asp:TextBox ID="txtWorkTime" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="FileUploadVideo">上传作品：</label>
            <div class="file-upload-container">
                <asp:FileUpload ID="FileUploadVideo" runat="server" CssClass="file-upload" />
                <asp:Button ID="btnUploadVideo" runat="server" Text="上传" OnClick="btnUploadVideo_Click" CssClass="btn" />
            </div>
            <small>视频格式：mp4</small>
        </div>
        <div class="form-group">
            <label for="txtWorkVideoUrl">视频URL：</label>
            <asp:TextBox ID="txtWorkVideoUrl" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="FileUploadPic">作品图片：</label>
            <div class="file-upload-container">
                <asp:FileUpload ID="FileUploadPic" runat="server" CssClass="file-upload" />
                <asp:Button ID="btnUploadPic" runat="server" Text="上传" OnClick="btnUploadPic_Click" CssClass="btn" />
            </div>
            <small>图片格式：JPG, GIF, PNG</small>
        </div>
        <div class="form-group">
            <label for="txtWorkPicUrl">图片URL：</label>
            <asp:TextBox ID="txtWorkPicUrl" runat="server" CssClass="input-text"></asp:TextBox>
            <asp:Image ID="imgsrc" runat="server" Width="20%" Height="20%" CssClass="uploaded-image" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnOK" runat="server" Text="提交" OnClick="btnOK_Click" CssClass="btn" />
        </div>
    </div>
</asp:Content>
