<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPlatform/AdminPlatform.master"
    AutoEventWireup="true" CodeFile="ShoppingCartDetails.aspx.cs" Inherits="AdminPlatform_ShoppingCartDetails" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .top1
        {
            width: 980px;
            height: 45px;
            text-align: left;
            vertical-align: middle;
            padding-left: 13px;
            background: #345466;
            font-weight: bolder;
            font-size: 17px;
        }
        .top3
        {
            font-size: 17px;
            font-weight: 500;
        }
        .border-rb
        {
            width: 980px;
            float: left;
            margin-top: 10px;
            margin-left: 15px;
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table>
            <tr>
                <td>
                    <div style="vertical-align: top; text-align: left; float: left">
                        <asp:DataList ID="dlsBook" runat="server" RepeatColumns="1" Width="980px" Height="200px"
                            CellSpacing="10">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                BackColor="#F7F7F2" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td class="top1">
                                            <asp:Label ID="Label1" runat="server" ForeColor="White">订单明细</asp:Label>
                                        </td>
                                    </tr>
                                    <table class="border-rb">
                                        <tr class="top3">
                                            <td style="text-align: left">
                                                <asp:Label ID="lblOrdersId" runat="server" ForeColor="#31328C" Text='<%#Eval("OrdersId","订单编号：{0}") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblOrderDate" runat="server" Text='<%#Eval("OrderDate","订购日期：{0:yyyy/MM/dd}") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTotalPrice" runat="server" Text='<%#Eval("TotalPrice","订购总价：{0:C}") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="top3">
                                            <td style="text-align: left">
                                                <asp:Label ID="lblLoginId" runat="server" Text='<%#Eval("LoginId","用户账号：{0}") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblLoginName" runat="server" Text='<%#Eval("LoginName","用户姓名：{0}") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                            </td>
                                        </tr>
                                        <tr class="top3">
                                            <td style="text-align: left">
                                                <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone","联系电话：{0}") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblMail" runat="server" Text='<%#Eval("Mail","电子邮箱：{0}") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                            </td>
                                        </tr>
                                        <tr class="top3">
                                            <td style="text-align: left">
                                                <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address","联系地址：{0}") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                            </td>
                                            <td style="text-align: left">
                                            </td>
                                        </tr>
                                    </table>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <SeparatorStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:DataList>
                    </div>
                    <div class="top3" style="text-align: left; padding: 20px 10px 10px 13px">
                        <asp:GridView ID="gvwOrdersBook" runat="server" AutoGenerateColumns="False" Width="997px"
                            ShowFooter="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gvwOrdersBook_RowDataBound">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="图书编号" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"
                                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBookId" runat="server" Text='<%#Eval("Books.Id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="图书名称" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"
                                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lblTitle" runat="server" Font-Size="17px" NavigateUrl='<%# Eval("Books.Id", "~/AdminPlatform/BookDetails.aspx?BookId={0}") %>'
                                            Text='<%#Eval("Books.Title").ToString().Length > 23 ? Eval("Books.Title").ToString().Substring(0, 23) + "..." : Eval("Books.Title").ToString()%>'></asp:HyperLink>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="单价" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"
                                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderBooksUnitPrice" runat="server" Text='<%#Eval("UnitPrice") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="20" HeaderText="数量" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Center" FooterStyle-VerticalAlign="Middle"
                                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalNumber" runat="server" Text="Label"></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="20px"></ControlStyle>
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="小计" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"
                                    FooterStyle-HorizontalAlign="Center" FooterStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center"
                                    ItemStyle-VerticalAlign="Middle">
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrices" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#B6D0DC" Font-Bold="True" ForeColor="Gray" />
                            <HeaderStyle BackColor="#6D8AAA" Font-Bold="True" ForeColor="White" />
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
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="5" ShowPageIndexBox="Always"
                            OnPageChanged="AspNetPager1_PageChanged" CssClass="anpager" CurrentPageButtonClass="cpb"
                            FirstPageText="|<首页" LastPageText="尾页>|" NextPageText="下一页>" PrevPageText="<上一页">
                        </webdiyer:AspNetPager>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
