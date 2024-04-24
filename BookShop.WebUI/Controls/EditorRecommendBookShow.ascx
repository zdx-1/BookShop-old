<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditorRecommendBookShow.ascx.cs"
    Inherits="Controls_EditorRecommendBookShow" %>
<div align="center">
    <table width="90%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="3" height="35" style="padding-left:25px">
                <div class="bigtuhuang">
                    <img src="./MemberPortal/image/index-arrow.gif" />
                    主编推荐&nbsp;最全的图书、最低的价格尽在当当网！</div>
            </td>
        </tr>
        <tr align="center">
            <td colspan="3">
                <asp:DataList ID="dlsEditorRecommendBooks" runat="server" RepeatColumns="4" Width="580px"
                    RepeatDirection="Horizontal" OnItemCommand="dlsNewBooks_ItemCommand" CellPadding="10"
                    CellSpacing="5">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Top" />
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td class="book1-right">
                                    <a href="MemberPortal/BookDetails.aspx?BookId=<%#Eval("Id") %>">
                                        <img id="Img7" src='<%#Eval("ImgUrl","{0}")%>' width="138" height="200" runat="server" /></a>
                                </td>
                                <td>
                                    <table width="450" border="0" cellspacing="0" cellpadding="0" align="right">
                                        <tr>
                                            <td class="book1-right">
                                                <h3>
                                                    <asp:LinkButton ID="lnkbtnEditorBookTitle" runat="server" CommandArgument='<%#Eval("Id") %>'
                                                        CommandName="ShowBookDetails" Text='<%#Eval("Title").ToString().Length>30? (Eval("Title").ToString().Substring(0,30)+"...") :Eval("Title").ToString()%>'
                                                        ToolTip='<%#Eval("Title") %>'></asp:LinkButton></h3>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="book1-right">
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("EditorComment").ToString().Length>300? (Eval("EditorComment").ToString().Substring(0,300)+"...") :Eval("EditorComment").ToString() %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="book1-right">
                                                <s>原价：￥98元</s>&nbsp;
                                                <asp:Label ID="lblEditorUnitPrice" runat="server" Text='<%#Eval("UnitPrice","定价：￥{0:f}元") %>'></asp:Label><!--数据格式字符串：DataFormatString="{0:格式字符串}" -->
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
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
