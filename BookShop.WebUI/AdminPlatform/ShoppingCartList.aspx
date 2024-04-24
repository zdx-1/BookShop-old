<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPlatform/AdminPlatform.master"
    AutoEventWireup="true" CodeFile="ShoppingCartList.aspx.cs" Inherits="AdminPlatform_ShoppingCartList" %>

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
        <div class="header" style="text-align: center">
            <asp:GridView ID="gvwShoppingCartList" runat="server" AutoGenerateColumns="False"
                CellPadding="4" DataKeyNames="Id" ForeColor="#333333" GridLines="None"
                Width="1000px"
                OnRowDataBound="gvwShoppingCartList_RowDataBound">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="订单编号" />
                    <asp:BoundField DataField="OrderDate" HeaderText="订购日期" />
                    <asp:BoundField DataField="TotalPrice" HeaderText="订购总价" />
                    <asp:TemplateField HeaderText="会员账号">
                        <ItemTemplate>
                            <asp:Label ID="lblLoginId" runat="server" Text='<%# Eval("Users.LoginId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="会员姓名">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Users.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="会员级别">
                        <ItemTemplate>
                            <asp:Label ID="lblUserRolesName" runat="server" Text='<%# Eval("Users.UserRoles.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="账号状态">
                        <ItemTemplate>
                            <asp:Label ID="lblUserStatesName" runat="server" Text='<%# Eval("Users.UserStates.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="电话">
                        <ItemTemplate>
                            <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Users.Phone") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="EMail">
                        <ItemTemplate>
                            <asp:Label ID="lblMail" runat="server" Text='<%# Eval("Users.Mail") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="联系地址">
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Users.Address")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/AdminPlatform/ShoppingCartDetails.aspx?OrdersId={0}"
                        HeaderText="浏览" Text="订单详细" />
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
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="10" ShowPageIndexBox="Always" OnPageChanged="AspNetPager1_PageChanged"
                CssClass="anpager" CurrentPageButtonClass="cpb" FirstPageText="|<首页" LastPageText="尾页>|"
                NextPageText="下一页>" PrevPageText="<上一页">
            </webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>
