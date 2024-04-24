<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPlatform/AdminPlatform.master"
    AutoEventWireup="true" CodeFile="BookDetails.aspx.cs" Inherits="AdminPlatform_BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .box
        {
            margin: 5px auto;
            height: 1px;
            border-bottom: 3px dashed #9DEAF3;
        }
        .border-rb
        {
            width: 450px;
            float: left;
            text-align:left;
            vertical-align:middle;
            padding: 0px 20px 10px 40px;
            margin: 0px 20px 10px 40px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="vertical-align: top">
        <asp:DataList ID="dlsBook" runat="server" RepeatColumns="1" Width="800px" RepeatDirection="Horizontal"
            CellSpacing="10">
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
                                            <tr>
                                                <td>
                                                    <br />
                                                    定价：<asp:Label ID="lblUnitPrice" runat="server" Font-Bold="true" Text='<%#Eval("UnitPrice","{0:f}") %>'></asp:Label><!--数据格式字符串：DataFormatString="{0:格式字符串}" -->
                                                    <br />
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            
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
    </div>
</asp:Content>
