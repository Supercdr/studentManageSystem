<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminInfo.aspx.cs" Inherits="studentManage.admin.AdminInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%--<link href="res/css/AdminInfo.css" rel="stylesheet" />--%>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f7f8fc;
            margin: 0;
            padding: 18px;
        }

        #container {
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        #txtAdminName, #txtPwd{
            padding:10px;
            width:300px;
            border:1px solid gray;
            border-radius:15px;
        }
        #btnEdit, #btnAdd {
            color:white;
            font-weight:bold;
            border: none;
            padding: 10px 30px;
            border-radius: 10px;
            background: linear-gradient(to right, #4800ff, #6FB1FC);
        }
        button, input[type="button"], input[type="submit"]:hover {
            background: linear-gradient(to right, #6FB1FC, #4800ff);
        }

        #btnEdit, #btnAdd:active {
            transform: scale(0.9);
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

        .actions img {
            width:25px;
            cursor: pointer;
        }

        .form-group {
            display:inline-block;
            margin-bottom: 10px;
        }

        .form-group label {
            display: inline-block;
            width: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <h2>管理员账号编辑——添加管理员账号</h2>
            <div class="form-group">
                <label for="txtAdminName">管理员名称：</label>
                <asp:TextBox ID="txtAdminName" runat="server"></asp:TextBox>
            </div>
            <br />
            <div class="form-group">
                <label for="txtPwd">登录密码：</label>
                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnEdit" runat="server" Text="修改" OnClick="btnEdit_Click" />
                <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" />
            </div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>账户ID</th>
                                <th>账户名称</th>
                                <th>登录密码</th>
                                <th>修改</th>
                                <th>删除</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Container.ItemIndex + 1 %></td>
                        <td><%# Eval("AdminID") %></td>
                        <td><%# Eval("AdminName") %></td>
                        <td><%# Eval("AdminPass") %></td>
                        <td class="actions">
                            <a href='AdminInfo.aspx?id=<%# Eval("AdminID") %>&action=Edit' onclick="return confirm('确定要修改此管理员账号吗？')">
                                <img alt="Edit" src="../images/edit.png" border="0" />
                            </a>
                        </td>
                        <td class="actions">
                            <a href='sqlDel.aspx?id=<%# Eval("AdminID") %>&action=DelAdmin' onclick="return confirm('确定要删除此管理员账号吗？')">
                                <img alt="Delete" src="../images/delete.png" border="0" />
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
