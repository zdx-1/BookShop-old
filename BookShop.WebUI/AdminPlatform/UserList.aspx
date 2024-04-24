<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPlatform/AdminPlatform.master"
    AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="AdminPlatform_UserList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .header
        {
            padding: 0px 230px 10px 10px;
        }
        .topShow
        {
            padding: 0px 10px 3px 690px;
            float: left;
        }
        .topShow1
        {
            padding: 0px 10px 3px 30px;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table width="1000">
            <tr>
                <div class="topShow">
                    <asp:CheckBox ID="chkSelectAll" Text="全选" AutoPostBack="true" runat="server" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                </div>
                <div class="topShow1">
                    <img src="images/083.gif" />
                    <asp:LinkButton ID="lnkbtnDelete" CommandArgument='<%#Eval("Id") %>' runat="server"
                        CausesValidation="False" CommandName="DeleteBook" OnClientClick="javascript:return confirm('确认删除该用户吗？');"
                        Text="删除" OnClick="lnkbtnDelete_Click"></asp:LinkButton>
                </div>
                <div class="topShow1">
                    <img src="images/001.gif" />
                    <a href="UserRegister.aspx">新增</a>
                </div>
            </tr>
        </table>
        <div class="header" style="text-align: center">
            <asp:GridView ID="gvwUserList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                DataKeyNames="Id" ForeColor="#333333" GridLines="None" Width="900px" OnRowCommand="gvwUserList_RowCommand"
                OnRowDataBound="gvwUserList_RowDataBound">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="LoginId" HeaderText="用户名" />
                    <asp:BoundField DataField="Name" HeaderText="姓名" />
                    <asp:BoundField DataField="Address" HeaderText="地址" />
                    <asp:BoundField DataField="Phone" HeaderText="电话" />
                    <asp:BoundField DataField="Mail" HeaderText="EMail" />
                    <asp:BoundField DataField="RegDate" HeaderText="注册日期" />
                    <asp:TemplateField HeaderText="权限">
                        <ItemTemplate>
                            <asp:Label ID="lblUserRolesName" runat="server" Text='<%#Eval("UserRoles.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <asp:Label ID="lblUserStatesName" runat="server" Text='<%#Eval("UserStates.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="LoginId" DataNavigateUrlFormatString="~/AdminPlatform/UserInfo.aspx?LoginId={0}"
                        HeaderText="浏览" Text="详细" />
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue" CausesValidation="False"
                                CommandArgument='<%#Eval("Id") %>' CommandName="DeleteUser" Text="删除" OnClientClick="javascript:return confirm('确认删除该用户吗？');"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="Blue" CausesValidation="False"
                                CommandArgument='<%#Eval("Id") %>' CommandName="UpdateUser" Text="状态编辑" OnClientClick="javascript:return confirm('确认编辑该用户状态吗？');"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#DCE6F4" ForeColor="Gray" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
        <div style="width: 1000px; text-align: center">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="10" ShowPageIndexBox="Always"
                OnPageChanged="AspNetPager1_PageChanged" CssClass="anpager" CurrentPageButtonClass="cpb"
                FirstPageText="|<首页" LastPageText="尾页>|" NextPageText="下一页>" PrevPageText="<上一页">
            </webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>
