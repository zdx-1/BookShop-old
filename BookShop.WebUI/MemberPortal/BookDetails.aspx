<%@ Page Title="" Language="C#" MasterPageFile="~/MemberPortal/MainSite.master" AutoEventWireup="true"
    CodeFile="BookDetails.aspx.cs" Inherits="BookDetails" %>

<%@ Register Src="~/Controls/BookCategoryShow.ascx" TagName="BookCategoryShow" TagPrefix="ucl" %>
<%@ Register Src="~/Controls/BookPubLisherShow.ascx" TagName="BookPubLisherShow"
    TagPrefix="ucl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .box
        {
            margin: 5px auto;
            height: 1px;
            border-bottom: 3px dashed #9DEAF3;
        }
        #leftlist
        {
            width: 148px;
            margin: 0 0 10px 0;
            padding: 0;
        }
        .pinpai
        {
            padding: 5px 10px 10px 10px;
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
        .border-rb
        {
            width: 400px;
            float: left;
            padding: 0px 10px 10px 50px;
            margin: 0px 10px 10px 50px;
        }
        .style2
        {
            border-bottom: 1 #CCCCCC solid;
            padding-left: 10px;
            text-align: left;
            width: 291px;
        }
        #center
        {
            width: 300;
            float: left;
            padding: 3px 10px 3px 15px;
            margin: 3px 10px 3px 15px;
        }
        .lblUnitPrice
        {
            padding: 0px 2px 3px 15px;
            float: right;
        }
        .lblDescriptionText
        {
            text-align: left;
        }
        #Img6
        {
            margin: 10px 10px 10px 5px;
            padding: 10px 10px 15px 5px;
            float: left;
        }
        #middle
        {
            margin: 0px 28px 10px 35px;
        }
        img:hover
        {
            background-color: #DBECF4;
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
                        <asp:DataList ID="dlsBook" runat="server" RepeatColumns="1" Width="800px" RepeatDirection="Horizontal"
                            CellSpacing="10" OnItemCommand="dlsBook_ItemCommand">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemTemplate>
                                <table width="800" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>
                                        <td>
                                            <asp:Image ID="imgImgUrl" ImageUrl='<%#Eval("ImgUrl","{0}")%>' Width="130" Height="177"
                                                runat="server" />
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <table class="border-rb">
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lnkbtnBookTitle" runat="server" CommandArgument='<%#Eval("Id") %>'
                                                                        CommandName="ShowBookDetails" Text='<%#Eval("Title") %>' ToolTip='<%#Eval("Title") %>'></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblAuthor" runat="server" Text='<%#Eval("Author","作者：{0}") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCategoriesName" runat="server" Text='<%#Eval("Categories.Name","丛书名：{0}") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblPublishersName" runat="server" Text='<%#Eval("Publishers.Name","出版社：{0}") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblISBN" runat="server" Text='<%#Eval("ISBN","ISBN：{0}") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblPublishDate" runat="server" Text='<%#Eval("PublishDate","出版时间：{0:yyyy年MM月dd日}") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblWordsCount" runat="server" Text='<%#Eval("WordsCount","字数：{0}") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <br />
                                                                    <br />
                                                                    <br />
                                                                    <br />
                                                                    <br />
                                                                    <br />
                                                                    定价：<asp:Label ID="lblUnitPrice" runat="server" Font-Bold="true" Text='<%#Eval("UnitPrice","{0:f}") %>'></asp:Label><!--数据格式字符串：DataFormatString="{0:格式字符串}" -->
                                                                    <br />
                                                                    <asp:LinkButton ID="lbtnShopping" runat="server" CommandArgument='<%#Eval("Id") %>'
                                                                        CommandName="ShoppingBook">
                                                                        <img id="Img9" src="image/sale.gif" runat="server" />
                                                                    </asp:LinkButton>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table width="800" border="0" cellspacing="0" cellpadding="0" align="left">
                                    <tr>
                                        <div class="box">
                                        </div>
                                        <div class="lblDescriptionText">
                                            <asp:Label ID="lblContentDescriptionText" runat="server" Font-Size="Large" Text="内容提要："></asp:Label></div>
                                        <br />
                                        <asp:Label ID="lblContentDescription" runat="server" Text='<%#Eval("ContentDescription","{0}") %>'></asp:Label>
                                        <br />
                                    </tr>
                                    <tr>
                                        <div class="box">
                                        </div>
                                        <div class="lblDescriptionText">
                                            <asp:Label ID="lblAuthorDescriptionText" runat="server" Font-Size="Large" Text="作者简介："></asp:Label>
                                            <br />
                                            <asp:Label ID="lblAuthorDescription" runat="server" Text='<%#Eval("AuthorDescription","{0}") %>'></asp:Label></div>
                                        <br />
                                    </tr>
                                    <tr>
                                        <div class="box">
                                        </div>
                                        <div class="lblDescriptionText">
                                            <asp:Label ID="Label6" runat="server" Font-Size="Large" Text="编辑推荐："></asp:Label>
                                            <br />
                                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("EditorComment","{0}") %>'></asp:Label></div>
                                        <br />
                                    </tr>
                                    <tr>
                                        <div class="box">
                                        </div>
                                        <div class="lblDescriptionText">
                                            <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="目录："></asp:Label>
                                            <br />
                                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("TOC").ToString().Length>500? (Eval("TOC").ToString().Substring(0,500)+"...") :Eval("TOC").ToString() %>'></asp:Label></div>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <SeparatorStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
