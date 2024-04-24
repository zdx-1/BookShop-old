<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HotSellBookShow.ascx.cs"
    Inherits="Controls_HotSellBookShow" %>
<div align="center">
    <table width="90%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="3" height="35">
                <div class="bigtuhuang">
                    <img src="./MemberPortal/image/index-arrow.gif" />
                    本周媒体热点&nbsp;最热图书，全场打折、天天特价！</div>
            </td>
        </tr>
        <tr align="center">
            <td colspan="3">
                <asp:DataList ID="dlsHotSellBooks" runat="server" RepeatColumns="2" Width="580px"
                    RepeatDirection="Horizontal" OnItemCommand="dlsNewBooks_ItemCommand" CellPadding="10"
                    CellSpacing="5">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Top" />
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td class="imgre">
                                    <a href="MemberPortal/BookDetails.aspx?BookId=<%#Eval("Id") %>">
                                        <img id="Img6" src='<%#Eval("ImgUrl","{0}")%>' width="88" height="117" runat="server" /></a>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkbtnHotSellBookTitle" runat="server" CommandArgument='<%#Eval("Id") %>'
                                        CommandName="ShowBookDetails" Text='<%#Eval("Title")%>' ToolTip='<%#Eval("Title") %>'></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:Label ID="lblHotSellUnitPrice" runat="server" Text='<%#Eval("UnitPrice","定价：￥{0:f}元") %>'></asp:Label><!--数据格式字符串：DataFormatString="{0:格式字符串}" -->
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</div>
