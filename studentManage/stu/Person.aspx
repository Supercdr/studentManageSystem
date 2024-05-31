<%@ Page Title="" Language="C#" MasterPageFile="~/stu/MasterPage.master" AutoEventWireup="true" CodeBehind="Person.aspx.cs" Inherits="studentManage.stu.Person" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <h3>查看当前学生信息</h3>
        <div class="form-group">
            <label for="txtUserName">学生姓名：</label>
            <asp:TextBox ID="txtUserName" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtUserSex">性别：</label>
            <asp:TextBox ID="txtUserSex" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtUserNumber">学生学号：</label>
            <asp:TextBox ID="txtUserNumber" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtUserPass">登录密码：</label>
            <asp:TextBox ID="txtUserPass" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtXy">所属院系：</label>
            <asp:TextBox ID="txtXy" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtZy">所属专业：</label>
            <asp:TextBox ID="txtZy" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtBj">所属班级：</label>
            <asp:TextBox ID="txtBj" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtTime">注册时间：</label>
            <asp:TextBox ID="txtTime" runat="server" CssClass="input-text"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnEdit" runat="server" Text="修改" OnClick="btnEdit_Click" CssClass="btn" />
        </div>
    </div>
</asp:Content>
