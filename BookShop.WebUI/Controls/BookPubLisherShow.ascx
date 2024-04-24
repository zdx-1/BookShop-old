<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BookPubLisherShow.ascx.cs"
    Inherits="Controls_BookPubLisherShow" %>
<div id="left-top2">
    <table width="100%" border="0" style="text-align:center" cellspacing="0" cellpadding="0">
        <tr>
            <td width="6">
                <img id="IMG1" src="~/MemberPortal/image/index-bg-left.gif" runat="server" />
            </td>
            <td class="booktype-headerbg">
                <span class="white-13">品牌出版商</span>
            </td>
            <td width="6">
                <img id="IMG2" src="~/MemberPortal/image/index-bg-right.gif" runat="server">
            </td>
        </tr>
    </table>
</div>
<div id="left-middle2" class="border-lr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="dlsPublishers" runat="server" RepeatColumns="1" OnItemCommand="dlsPublishers_ItemCommand">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <div class="pinpai">
                            <asp:LinkButton ID="lkbtnPublishers" runat="server" CommandArgument='<%#Eval("Id") %>'
                                CommandName="ShowBookListPubId" Text='<%#Eval("Name").ToString().Length>20? (Eval("Name").ToString().Substring(0,20)+"...") :Eval("Name").ToString()%>'
                                ToolTip='<%#Eval("Name") %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
</div>
<div id="left-end2">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td width="7" height="6">
                <img id="IMG3" src="~/MemberPortal/image/index-end-left.gif" runat="server" />
            </td>
            <td class="bottom">
                &nbsp;&nbsp;&nbsp;
            </td>
            <td width="7">
                <img id="IMG4" src="~/MemberPortal/image/index-end-right.gif" runat="server" />
            </td>
        </tr>
    </table>
</div>
