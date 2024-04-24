<%@ Page Title="" Language="C#" MasterPageFile="~/MemberPortal/MainSite.master" AutoEventWireup="true"
    CodeFile="ShoppingCart.aspx.cs" Inherits="MemberPortal_ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .top-1
        {
            padding: 5px 0px 15px 5px;
        }
        .top-2
        {
            padding: 10px 0px 3px 10px;
        }
        .myshoppingcar
        {
            height: 43px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="myshoppingcar" style="text-align: left">
        <table>
            <tr>
                <td>
                    <div class="top-1">
                        <img src="image/top-gwc.gif" /><asp:Label Text="我的购物车" Font-Size="15" ForeColor="#3DA68D"
                            Font-Bold="true" runat="server"></asp:Label></div>
                </td>
                <td>
                    <div class="top-2">
                        <asp:Label ID="Label2" Text="您选好的商品：" Font-Size="11" ForeColor="Black" Font-Bold="true"
                            runat="server"></asp:Label></div>
                </td>
                <td class="top-2">
                    <asp:Label ID="lblShowNon" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div style="text-align: center">
        <asp:GridView ID="gvwCart" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            PageSize="5" ShowFooter="True" Width="980px" CellPadding="4"
            OnRowDataBound="gvwCart_RowDataBound" OnPageIndexChanging="gvwCart_PageIndexChanging"
            OnRowCancelingEdit="gvwCart_RowCancelingEdit" OnRowEditing="gvwCart_RowEditing"
            OnRowUpdating="gvwCart_RowUpdating" OnRowDeleting="gvwCart_RowDeleting" ForeColor="#333333"
            GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="图示">
                    <ItemTemplate>
                        <asp:Image ID="ImgImgUrl" ImageUrl='<%#Eval("Book.ImgUrl")%>' Width="48" Height="65" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="图书名称">
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Book.Title").ToString().Length > 20 ? Eval("Book.Title").ToString().Substring(0, 20)+"..." : Eval("Book.Title").ToString()%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="价格">
                    <ItemTemplate>
                        <asp:Label ID="lblUnitPrice" runat="server" Text='<%# Eval("Book.UnitPrice","{0:f}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ControlStyle-Width="20" HeaderText="数量">
                    <FooterTemplate>
                        <asp:Label ID="lblTotalNumber" runat="server" Text="Label"></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNumber" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNumber" Text='<%#Eval("Quantity")%>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ControlStyle Width="20px"></ControlStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="小计">
                    <FooterTemplate>
                        <asp:Label ID="lblTotalPrice" runat="server" ></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPrices" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="编辑"></asp:LinkButton>
                        |
                        <asp:LinkButton ID="lblDeleteCartBook" runat="server" CausesValidation="False" CommandName="Delete"
                            OnClientClick="javascript:return confirm('确认删除该图书吗？');" Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                            Text="更新"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="取消"></asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#8CF0D4" ForeColor="Gray" Height="30" Font-Size="10" />
            <HeaderStyle BackColor="#48C6A6" Height="30" ForeColor="White" Font-Size="10" />
            <PagerStyle ForeColor="#333333" HorizontalAlign="Center" BackColor="White" />
            <PagerTemplate>
                <table width="100%">
                    <tr>
                        <td style="text-align: left">
                            第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />页
                            总共/<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />页
                            每页<asp:Label ID="Label1" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageSize  %>' />条记录
                        </td>
                        <td style="text-align: right">
                            <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                CommandName="Page" Text="|<首页" />
                            <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                CommandName="Page" Text="<上一页" />
                            <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                CommandName="Page" Text="下一页>" />
                            <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                CommandName="Page" Text="尾页>|" />
                            <asp:Label ID="Label3" Text="转到" ForeColor="Black" runat="server"></asp:Label>
                            <asp:TextBox ID="txtNewPageIndex" runat="server" Width="25px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                            <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                CommandName="Page" Text="GO" OnClick="btnGo_Click" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                        </td>
                    </tr>
                </table>
            </PagerTemplate>
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </div>
    <br />
    <div style="text-align: right">
        <asp:LinkButton ID="lbtnSettlement" runat="server" OnClick="lbtnSettlement_Click">
            <img id="Img9" src="image/balance.gif" runat="server" />
        </asp:LinkButton>
    </div>
</asp:Content>
