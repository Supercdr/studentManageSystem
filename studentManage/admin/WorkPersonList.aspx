<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPersonList.aspx.cs" Inherits="studentManage.admin.WorkPersonList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>作品列表</title>
    <%--<link href="res/css/WorkPersonList.css" rel="stylesheet" />--%>
    <style>
        body {
    font-family: Arial, sans-serif;
    background-color: #f7f8fc;
    margin: 0;
    padding: 20px;
}

.table-container {
    background-color: white;
    padding: 20px;
    border-radius: 10px;
    box-shadow: 0 0 10px rgba(0,0,0,0.1);
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
    width: 25px;
    cursor: pointer;
}
#video{
    width:50px;
}
#pic{
     width:70px;
}
.pager {
    margin-top: 20px;
    text-align: center;
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
        <div class="table-container">
            <h3>个人作品</h3>
            <asp:Repeater ID="rpWorkPerson" runat="server">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>作品名称</th>
                                <th>作品分类</th>
                                <th>上传时间</th>
                                <th>作品图片</th>
                                <th>查看文件</th>
                                <th>上传人</th>
                                <th>修改</th>
                                <th>删除</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Container.ItemIndex + 1 %></td>
                        <td><%#Eval("WorkName") %></td>
                        <td><%#Eval("WorkCate") %></td>
                        <td><%#Eval("WorkTime") %></td>
                        <td>
                            <a href='CheckFiles.aspx?id=<%# Eval("WorkID") %>&action=WorkPerson'>
                            <img id="pic" src="<%# Eval("WorkPicUrl") %>" alt="播放" /></a>
                        </td>
                        <td><a href='CheckFiles.aspx?id=<%# Eval("WorkID") %>&action=WorkPerson'>
                            <img id="video" src="../images/video.png" alt="播放" /></a></td>
                        <td><%#Eval("UserName") %></td>
                        <td class="actions">
                            <a href='WorksInfo.aspx?id=<%#Eval("WorkID") %>&action=AdminEdit'>
                                <img alt="修改" src="../images/edit.png" />
                            </a>
                        </td>
                        <td class="actions">
                            <a href='sqlDel.aspx?id=<%#Eval("WorkID") %>&action=DelWorkPerson' onclick="return confirmDelete()">
                                <img alt="删除" src="../images/delete.png" />
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
        <div class="pager">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="anpager" CurrentPageButtonClass="cpb" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging"
                AlwaysShow="true" PageIndexBoxType="DropDownList" PageSize="20" PrevPageText="上一页" ShowMoreButtons="False" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
            </webdiyer:AspNetPager>
        </div>
    </form>
</body>
</html>
