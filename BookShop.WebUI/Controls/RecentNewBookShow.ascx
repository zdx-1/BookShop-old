<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecentNewBookShow.ascx.cs"
    Inherits="Controls_RecentNewBookShow" %>
<div align="center">
    <table width="90%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="3" height="35">
                <div class="bigtuhuang">
                    <img src="./MemberPortal/image/index-arrow.gif" />
                    本月新出版&nbsp;最新最热图书全收录，最佳品质、最优价格！</div>
            </td>
        </tr>
        <tr align="center">
            <td colspan="3">
                <asp:DataList ID="dlsNewBooks" runat="server" RepeatColumns="4" Width="580px" RepeatDirection="Horizontal"
                    OnItemCommand="dlsNewBooks_ItemCommand" CellPadding="10" CellSpacing="5">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Top" />
                    <ItemTemplate>
                        <a href="MemberPortal/BookDetails.aspx?BookId=<%#Eval("Id") %>">
                            <img id="Img5" src='<%#Eval("ImgUrl","{0}")%>' width="88" height="117" runat="server" /></a>
                        <br />
                        <asp:LinkButton ID="lnkbtnBookTitle" runat="server" CommandArgument='<%#Eval("Id") %>'
                            CommandName="ShowBookDetails"   
                            ToolTip='<%#Eval("Title") %>'></asp:LinkButton>
                        <br />
                        <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("UnitPrice","{0:f}") %>'></asp:Label><!--数据格式字符串：DataFormatString="{0:格式字符串}" -->
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
