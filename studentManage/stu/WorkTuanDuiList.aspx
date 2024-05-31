<%@ Page Title="" Language="C#" MasterPageFile="~/stu/MasterPage.master" AutoEventWireup="true" CodeBehind="WorkTuanDuiList.aspx.cs" Inherits="studentManage.stu.WorkTuanDuiList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .table-container {
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            max-width: 1000px;
            margin: 0 auto;
        }

        .table-container h3 {
            margin-bottom: 20px;
            text-align: center;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        table, th, td {
            border: 1px solid #dddddd;
        }

        th, td {
            padding: 10px;
            text-align: center;
        }

        th {
            background-color: #f2f2f2;
        }

        .actions img {
            width: 20px;
            height: 20px;
        }

        .pager {
            text-align: center;
        }

        .anpager a, .anpager span {
            display: inline-block;
            padding: 5px 10px;
            margin: 0 2px;
            border: 1px solid #dddddd;
            border-radius: 5px;
            text-decoration: none;
            color: #007bff;
        }

        .anpager .cpb {
            background-color: #007bff;
            color: white;
        }

        .anpager a:hover {
            background-color: #007bff;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="table-container">
        <h3>团队作品（仅限查看当前学生参与的作品）</h3>
        <asp:GridView ID="gdvWishList" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="gdvWishList_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkSelected" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="编号" ReadOnly="true" />
                <asp:BoundField DataField="WorkName" HeaderText="作品名称" />
                <asp:BoundField DataField="WorkCate" HeaderText="作品分类" />
                <asp:TemplateField HeaderText="作品描述">
                    <ItemTemplate>
                        <a href="#" title='<%#Eval("WorkDes")%>' class="blue">
                            <%#Eval("WorkDes").ToString()%>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UserName" HeaderText="团队组长" />
                <asp:TemplateField HeaderText="文件下载">
                    <ItemTemplate>
                        <a href='../admin/DownloadFile.aspx?id=<%#Eval("WorkID")%>&action=WorkTuanDui' title="下载上传文件" class="blue">download</a>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="WorkTime" HeaderText="上传时间"/>
                <asp:TemplateField HeaderText="作品视频">
                    <ItemTemplate>
                        <a href='../admin/PlayOnline.aspx?id=<%#Eval("WorkID")%>&action=WorkTuanDui' title="播放作品视频">
                            <img src="../images/11.jpeg" border="0" width="50" height="50"/>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="查看详细">
                    <ItemTemplate>
                        <a href='WorkTuanDuiInfo.aspx?id=<%#Eval("WorkID")%>&action=StuEdit' title="查看详细" class="blue">查看详细</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="pager">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="anpager" CurrentPageButtonClass="cpb" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging"
                AlwaysShow="true" PageIndexBoxType="DropDownList" PageSize="20" PrevPageText="上一页" ShowMoreButtons="False" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
            </webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>
