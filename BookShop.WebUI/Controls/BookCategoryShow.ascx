<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BookCategoryShow.ascx.cs"
    Inherits="Controls_BookCategoryShow" %>
<div id="left-top1">
    <table width="180" style="text-align:center" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="6">
                <img id="Img1" src="~/MemberPortal/image/index-bg-left.gif" runat="server">
            </td>
            <td class="booktype-headerbg">
                <span class="white-13">图书分类 </span>
            </td>
            <td width="6">
                <img id="Img2" src="~/MemberPortal/image/index-bg-right.gif" runat="server">
            </td>
        </tr>
    </table>
</div>
<div id="left-middle1" class="border-lr">
    <table width="178" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td>
                <div id="leftlist" style="text-align: left">
                    <ul>
                        <br />
                        <asp:Repeater ID="dlsCategories" runat="server" OnItemCommand="dlsCategories_ItemCommand">
                            <ItemTemplate>
                                <li>
                                    <asp:LinkButton ID="lkbtnCategories" runat="server" CommandArgument='<%#Eval("Id")%>'
                                        CommandName="ShowBookListsCatId" Text='<%#Eval("Name").ToString().Length>10? (Eval("Name").ToString().Substring(0,10)+"...") :Eval("Name").ToString()%>'
                                        ToolTip='<%#Eval("Name") %>'></asp:LinkButton></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</div>
<div id="left-end1">
    <table width="180" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td width="7" height="6">
                <img id="Img3" src="~/MemberPortal/image/index-end-left.gif" runat="server">
            </td>
            <td class="bottom">
                &nbsp;&nbsp;&nbsp;
            </td>
            <td width="7">
                <img id="Img4" src="~/MemberPortal/image/index-end-right.gif" runat="server">
            </td>
        </tr>
    </table>
</div>
