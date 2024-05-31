<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="studentManage.admin.StudentInfo" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学生信息管理</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f7f8fc;
            margin: 0;
            padding: 20px;
        }
        .form-container{
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: inline-block;
            width: 50px;
            margin-right: 10px;
        }
        .form-group input, .form-group button, .form-group select {
            padding: 13px;
            border: 1px solid gray;
            border-radius: 5px;
            margin-right: 10px;
            width:30%;
        }
        button, input[type="button"], input[type="submit"] {
            background: linear-gradient(to right, #4800ff, #6FB1FC);
            color: white;
            font-weight: bold;
            border: none;
            padding: 10px 20px;
            border-radius: 10px;
            cursor: pointer;
            margin: 10px;
            width:130px;
        }

        button, input[type="button"], input[type="submit"]:hover {
            background: linear-gradient(to right, #6FB1FC, #4800ff);
        }

        button, input[type="button"], input[type="submit"]:active{
            transform:scale(0.9);
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        table, th, td {
            border: 1px solid #dddddd;
        }
        th, td {
            text-align: left;
            padding: 8px;
        }
        th {
            background-color: #f2f2f2;
        }
        #gdvWishList img {
            width: 20px;
            cursor: pointer;
        }
        .pager {
            margin-top: 20px;
            text-align: center;
        }
        #CheckBox1{
            width:30px;
        }
    </style>
    <script type="text/javascript">
        function confirmDelete() {
            return confirm('确认删除吗？');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <div class="form-group">
                <label for="txtUserNameSearch">姓名：</label>
                <asp:TextBox ID="txtUserNameSearch" runat="server" CssClass="input-text"></asp:TextBox>
                <asp:Button ID="btnSearchByName" runat="server" Text="查询" OnClick="btnSearchByName_Click" CssClass="btn" />
            </div>
            <div class="form-group">
                <label for="txtUserXySearch">学院：</label>
                <asp:TextBox ID="txtUserXySearch" runat="server" CssClass="input-text"></asp:TextBox>
                <asp:Button ID="btnSearchByXy" runat="server" Text="查询" OnClick="btnSearchByXy_Click" CssClass="btn" />
                <asp:Button ID="btnShowAll" runat="server" Text="显示全部" OnClick="btnShowAll_Click" CssClass="btn" />
            </div>
            <asp:GridView ID="gdvWishList" runat="server" AutoGenerateColumns="False" OnRowDataBound="gdvWishList_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkSelected" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="编号" ReadOnly="true" />
                    <asp:BoundField DataField="UserName" HeaderText="会员名" />
                    <asp:BoundField DataField="UserNumber" HeaderText="学号" />
                    <asp:BoundField DataField="UserPass" HeaderText="登录密码" />
                    <asp:BoundField DataField="UserSex" HeaderText="会员性别" />
                    <asp:BoundField DataField="UserXy" HeaderText="所属院系" />
                    <asp:BoundField DataField="UserZy" HeaderText="所属专业" />
                    <asp:BoundField DataField="UserBj" HeaderText="所属班级" />
                    <asp:BoundField DataField="UserAddTime" HeaderText="注册时间" />
                    <asp:TemplateField HeaderText="编辑">
                        <ItemTemplate>
                            <a href='StudentInfoAdd.aspx?id=<%#Eval("UserID") %>&action=Edit' title="编辑">
                               <img src="../images/edit.png" border="0" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除">
                        <ItemTemplate>
                            <a href='sqlDel.aspx?id=<%#Eval("UserID") %>&action=DelStudent' title="删除" onclick="return confirmDelete()">
                                <img src="../images/delete.png" border="0" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <div class="form-group">
                <span id="all"><asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Text="全选" /></span>
                <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" CssClass="btn" />
                <asp:Button ID="btnCancle" runat="server" Text="取消" OnClick="btnCancle_Click" CssClass="btn" />
            </div>

            <div class="pager">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="anpager" CurrentPageButtonClass="cpb" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging"
                    AlwaysShow="true" PageIndexBoxType="DropDownList" PageSize="10" PrevPageText="上一页" ShowMoreButtons="False" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
