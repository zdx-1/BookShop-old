<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClickTopBookShow.ascx.cs"
    Inherits="Controls_ClickTopBookShow" %>
<div id="left-top2">
    <table width="100%" border="0" style="text-align:center" cellspacing="0" cellpadding="0">
        <tr>
            <td width="6">
                <img src="./MemberPortal/image/index-bg-left.gif">
            </td>
            <td class="booktype-headerbg">
                <span class="white-13">点击排行榜 Top10</span>
            </td>
            <td width="6">
                <img src="./MemberPortal/image/index-bg-right.gif">
            </td>
        </tr>
    </table>
</div>
<div id="left-middle2" class="border-lr">
    <table width="88%" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td>
                <div id="book1">
                    <br />
                    <asp:DataList ID="dlsClicks" runat="server" RepeatColumns="1" OnItemCommand="dlsNewBooks_ItemCommand"
                        Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="False">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <div class="dianji-top">
                                <asp:LinkButton ID="lnkbtnClicksNum" runat="server" CommandArgument='<%#Eval("Id") %>'
                                    CommandName="ShowBookDetails" Text='<%#Eval("WordsCount","{0}、") %>' ToolTip='<%#Eval("WordsCount","{0}、") %>'></asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnClicks" runat="server" CommandArgument='<%#Eval("Id") %>'
                                    CommandName="ShowBookDetails" Text='<%#Eval("Title").ToString().Length>22? (Eval("Title").ToString().Substring(0,22)+"...") :Eval("Title").ToString()%>'
                                    ToolTip='<%#Eval("Title") %>'></asp:LinkButton>
                            </div>
                            <div class="box">
                            </div>
                        </ItemTemplate>
                        <SeparatorStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" />
                    </asp:DataList>
                </div>
            </td>
        </tr>
        <tr>
            <td height="8">
            </td>
        </tr>
    </table>
</div>
<div id="left-end2">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td width="7" height="6">
                <img src="./MemberPortal/image/index-end-left.gif">
            </td>
            <td class="bottom">
                &nbsp;&nbsp;&nbsp;
            </td>
            <td width="7">
                <img src="./MemberPortal/image/index-end-right.gif">
            </td>
        </tr>
    </table>
</div>
