<%@ Page Title="" Language="C#" MasterPageFile="~/MemberPortal/MainSite.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="BookLists.aspx.cs" Inherits="MemberPortal_BookLists" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/Controls/BookCategoryShow.ascx" TagName="BookCategoryShow" TagPrefix="ucl" %>
<%@ Register Src="~/Controls/BookPubLisherShow.ascx" TagName="BookPubLisherShow"
    TagPrefix="ucl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #leftlist
        {
            width: 148px;
            margin: 0 0 10px 0;
            padding: 0;
        }
        #leftlist ul
        {
            list-style-type: none;
            margin: 0;
            padding: 0 0 0 5px;
        }
        #leftlist ul li
        {
            background: url('image/book_cate_icon.gif') no-repeat left center;
            padding: 0 0 0 25px;
        }
        #center
        {
            width: 300;
            float: left;
            padding: 3px 10px 3px 15px;
            margin: 3px 10px 3px 15px;
        }
        .border-rb
        {
            width: 550px;
            float: left;
            padding: 0px 10px 10px 10pxs;
            margin: 0px 10px 10px 10px;
        }
        .pinpai
        {
            padding: 5px 10px 10px 10px;
        }
        .lblUnitPrice
        {
            padding: 0px 2px 3px 15px;
            float: right;
        }
        .img6c
        {
            margin: 15px 15px 10px 0px;
            padding: 15px 15px 15px 0px;
            float: left;
            text-align: left;
            vertical-align: top;
        }
        #middle
        {
            margin: 0px 15px 10px 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="middle">
        <!-- InstanceBeginEditable name="EditRegion3" -->
        <div>
            <table width="700px" border="0" cellspacing="0" cellpadding="0" align="left">
                <tr>
                    <!--网页左边部分开始-->
                    <td valign="top" width="180">
                        <ucl:BookCategoryShow ID="BookCategoryShow" runat="server" />
                        <br />
                        <!--商品分类（仅限店中店）开始-->
                        <ucl:BookPubLisherShow ID="BookPubLisherShow" runat="server" />
                    </td>
                    <!--网页左边部分结束-->
                    <td style="vertical-align: top">
                        <br />
                        <div id="center">
                            <asp:Label ID="Label1" runat="server" Text="排列方式："></asp:Label>
                            <asp:Button ID="btnPublishDate" runat="server" Text="出版日期" OnClick="btnPublishDate_Click" />
                            |
                            <asp:Button ID="btnUnitPrice" runat="server" Text="价格" OnClick="btnUnitPrice_Click" />
                        </div>
                        <br />
                        <br />
                        <asp:DataList ID="dlsBook" runat="server" RepeatColumns="1" Width="800px" CellSpacing="10"
                            OnItemCommand="dlsNewBooks_ItemCommand" Font-Bold="False" Font-Italic="False"
                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Horizontal">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemTemplate>
                                <table width="500" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>
                                        <td class="img6c" style="text-align: left">
                                            <a href="BookDetails.aspx?BookId=<%#Eval("Id") %>">
                                                <img id="Img6" src='<%#Eval("ImgUrl","{0}")%>' width="118" height="150" runat="server" /></a>
                                        </td>
                                        <td>
                                            <table class="border-rb">
                                                <tr style="vertical-align: top">
                                                    <asp:LinkButton ID="lnkbtnBookLists" runat="server" CommandArgument='<%#Eval("Id") %>'
                                                        CommandName="ShowBookDetails" Text='<%#Eval("Title") %>' ToolTip='<%#Eval("Title") %>'></asp:LinkButton><br />
                                                </tr>
                                                <tr>
                                                    <asp:Label ID="lblAuthor" runat="server" Text='<%#Eval("Author","{0}") %>'></asp:Label><br />
                                                </tr>
                                                <tr>
                                                    <asp:Label ID="lblPublishDate" runat="server" Text='<%#Eval("PublishDate","出版日期：{0:yyyy年MM月dd日}") %>'></asp:Label><br />
                                                </tr>
                                                <tr>
                                                    <asp:Label ID="lblContentDescription" runat="server" Text='<%#Eval("ContentDescription").ToString().Length > 250 ? (Eval("ContentDescription").ToString().Substring(0, 250)+"...") : Eval("ContentDescription").ToString()%>'></asp:Label><br />
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <div class="lblUnitPrice">
                                    <asp:Label ID="lblUnitPrice" runat="server" Font-Bold="true" Text='<%#Eval("UnitPrice","￥{0:f}元") %>'></asp:Label><!--数据格式字符串：DataFormatString="{0:格式字符串}" -->
                                </div>
                                <br />
                            </ItemTemplate>
                            <SeparatorStyle Font-Bold="false" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" Wrap="False" BackColor="Gray" Font-Size="1px" ForeColor="Gray"
                                HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:DataList>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="5" ShowPageIndexBox="Always"
                            OnPageChanged="AspNetPager1_PageChanged" FirstPageText="首页" LastPageText="尾页"
                            NextPageText="下一页" PrevPageText="上一页">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
