<%@ Page Title="" Language="C#" MasterPageFile="~/MemberPortal/MainSite.master" AutoEventWireup="true"
    CodeFile="Settlement.aspx.cs" Inherits="MemberPortal_Settlement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .xianshi
        {
            font-size: 25px;
            text-align: center;
            vertical-align: middle;
        }
        .anniu
        {
            padding: 5px 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <table width="980" height="250" border="2px" border-color="red">
                <tr>
                    <td>
                        <p class="xianshi">
                            此图书已成功添加至购物车！</p>
                    </td>
                    <td>
                        <div class="anniu">
                            <asp:LinkButton ID="lbtnShopping" runat="server" CommandArgument='<%#Eval("Id") %>'
                                CommandName="ShoppingBook" OnClick="lbtnShopping_Click">
                                <img id="Img9" src="image/goumai.png" runat="server" />
                            </asp:LinkButton>
                        </div>
                        <div class="anniu">
                            <asp:LinkButton ID="lbtnCart" runat="server" OnClick="lbtnCart_Click">
                                <img id="Img1" src="image/jiesuan.png" runat="server" />
                            </asp:LinkButton>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <table width="980" height="250" border="2px" border-color="red">
                <tr>
                    <td>
                        <div class="anniu">
                            <asp:HyperLink ID="lbtnDefault" runat="server" NavigateUrl="~/Default.aspx">
                               <p class="xianshi">
                            已成功结算订单，点击返回首页！</p>
                            </asp:HyperLink>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server">
            <table width="980" height="250" border="2px" border-color="red">
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">
                               <p class="xianshi">
                            此页商品已添加过一次，页面已过期，想再买此商品请点击继续购物！</p>
                            </asp:HyperLink>
                    </td>
                    <td>
                        <div class="anniu">
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("Id") %>'
                                CommandName="ShoppingBook" OnClick="lbtnShopping_Click">
                                <img id="Img2" src="image/goumai.png" runat="server" />
                            </asp:LinkButton>
                        </div>
                        <div class="anniu">
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lbtnCart_Click">
                                <img id="Img3" src="image/jiesuan.png" runat="server" />
                            </asp:LinkButton>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
