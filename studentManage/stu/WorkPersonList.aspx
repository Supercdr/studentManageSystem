<%@ Page Title="" Language="C#" MasterPageFile="~/stu/MasterPage.master" AutoEventWireup="true" CodeBehind="WorkPersonList.aspx.cs" Inherits="studentManage.stu.WorkPersonList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="table-container">
        <asp:GridView ID="gdvWishList" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="gdvWishList_RowDataBound" CssClass="gridview">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkSelected" runat="server" CssClass="checkbox" />
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
                <asp:TemplateField HeaderText="文件下载">
                    <ItemTemplate>
                        <a href='../../admin/DownloadFile.aspx?id=<%#Eval("WorkID")%>&action=WorkPerson' title="下载上传文件" class="blue">download</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="WorkTime" HeaderText="上传时间" />
                <asp:TemplateField HeaderText="作品视频">
                    <ItemTemplate>
                        <a href='../admin/PlayOnline.aspx?id=<%#Eval("WorkID")%>&action=WorkPerson' title="播放作品视频">
                            <img src="../imags/11.jpeg" border="0" width="50" height="50" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="查看详细">
                    <ItemTemplate>
                        <a href='WorkInfo.aspx?action=check?id=<%#Eval("WorkID")%>&action=StuEdit' title="查看详细" class="blue">查看详细</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="pager">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="anpager" CurrentPageButtonClass="cpb" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging"
                AlwaysShow="true" PageIndexBoxType="DropDownList" PageSize="20" PrevPageText="上一页" ShowMoreButtons="False" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页"
                TextBeforePageIndexBox="转到">
            </webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>
