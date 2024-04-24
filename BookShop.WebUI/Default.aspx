<%@ Page Title="当当网上书店首页" Language="C#" MasterPageFile="~/MemberPortal/MainSite.master"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="Default.aspx.cs"
    Inherits="MemberPortal_Default" %>

<%@ Register Src="~/Controls/HotSellBookShow.ascx" TagName="HotSellBookShow" TagPrefix="ucl" %>
<%@ Register Src="~/Controls/UserLogin.ascx" TagName="UserLogin" TagPrefix="ucl" %>
<%@ Register Src="~/Controls/RecentNewBookShow.ascx" TagName="RecentNewBookShow" TagPrefix="ucl" %>
<%@ Register Src="~/Controls/EditorRecommendBookShow.ascx" TagName="EditorRecommendBookShow" TagPrefix="ucl" %>
<%@ Register Src="~/Controls/BookCategoryShow.ascx" TagName="BookCategoryShow" TagPrefix="ucl" %>
<%@ Register Src="~/Controls/BookPubLisherShow.ascx" TagName="BookPubLisherShow" TagPrefix="ucl" %>
<%@ Register Src="~/Controls/ClickTopBookShow.ascx" TagName="ClickTopBookShow" TagPrefix="ucl" %>

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
        #leftlist ul
        {
            list-style-type: none;
            margin: 0;
            padding: 0 0 0 5px;
        }
        #leftlist ul li
        {
            background: url('MemberPortal/image/book_cate_icon.gif') no-repeat left center;
            padding: 0 0 0 25px;
        }
        #rightlist
        {
            width: 157px;
            margin: 0 0 10px 0;
            padding: 10px;
            float: left;
        }
        td.border-rb1
        {
            width: 180px;
            padding: 3px 10px 3px 15px;
        }
        td.border-rb
        {
            width: 381px;
        }
        .style2
        {
            border-bottom: 1 #CCCCCC solid;
            padding-left: 10px;
            text-align: left;
            width: 291px;
        }
        .pinpai
        {
            padding: 5px 10px 10px 10px;
        }
        .dianji-top
        {
            padding: 5px 10px 5px 10px;
            text-decoration: none;
        }
        .imgre
        {
            padding: 10px 25px 10px 20px;
        }
        .book1-right
        {
            padding: 15px 0px 5px 10px;
            text-align: left;
        }
        .box
        {
            margin: 5px auto;
            border-bottom: 1px double #a1a1a1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="middle">
        <!-- InstanceBeginEditable name="EditRegion3" -->
        <div>
            <table width="980px" border="0" cellspacing="0" cellpadding="0" align="center">
                <tr>
                    <!--网页左边部分开始-->
                    <td valign="top" width="180">
                        <ucl:BookCategoryShow ID="BookCategoryShow" runat="server" />
                        <br />
                        <!--商品分类（仅限店中店）开始-->
                        <ucl:BookPubLisherShow ID="BookPubLisherShow" runat="server" />
                    </td>
                    <!--网页左边部分结束-->
                    <!--中间部分开始-->
                    <td valign="top">
                        <!-- 最全的图书、最低的价格尽在当当网 点击进入图书频道首页>> 开始-->
                        <ucl:EditorRecommendBookShow ID="EditorRecommendBookShow" runat="server" />
                        <!-- 最新最热流行CD专辑、华语、欧美、日韩全收录，最佳品质、最优价格！ 开始-->
                        <ucl:RecentNewBookShow ID="RecentNewBookShow" runat="server" />
                        <!-- 最新电影大片、热播电视剧、经典卡通纪录片，全场打折、天天特价！ 开始-->
                        <ucl:HotSellBookShow ID="HotSellBookShow" runat="server" />
                    </td>
                    <!--中间部分结束-->
                    <!--右边部分开始-->
                    <td valign="top" width="180">
                        <!--右1--用户登录开始-->
                        <ucl:UserLogin ID="UserLogin" runat="server"></ucl:UserLogin>
                        <!--右1结束-->
                        <br />
                        <!--右2开始-->
                        <ucl:ClickTopBookShow ID="ClickTopBookShow" runat="server" />
                        <!--右2结束-->
                        <br />
                        <br />
                    </td>
                    <!--右边部分结束-->
                </tr>
            </table>
        </div>
        <!-- InstanceEndEditable -->
    </div>
</asp:Content>
