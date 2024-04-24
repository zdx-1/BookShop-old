<%@ Page Title="" Language="C#" MasterPageFile="~/MemberPortal/MainSite.master" AutoEventWireup="true"
    CodeFile="UserLogin.aspx.cs" Inherits="MemberPortal_UserLogin" %>
    <%@ Register Src="~/Controls/LoginControl.ascx" TagName="LoginControl" TagPrefix="ucl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div align="center">
            <table width="983" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="7" height="27">
                    </td>
                    <td>
                        <hr style="color: #8ab6db" size="1" align="center" width="98%" />
                    </td>
                    <td width="7">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!--中间部分开始-->
    <div id="middle">
        <table width="950" border="0" cellspacing="0" cellpadding="0" align="center">
            <tr>
                <td>
                    <div class="login-left">
                        <img alt="" src="image/login-left1.gif" />
                        <hr size="1" width="99%" color="#cccccc" />
                        <ul style="list-style-type: none;">
                            <li>更多选择</li>
                            60万种图书音像，并有家居百货、化妆品、数码等几十个类别共计百万种商品，2000个入驻精品店中店
                            <br />
                            <li>更低价格</li>
                            电视购物的3-5折，传统书店的5-7折，其他网站的7-9折
                            <br />
                            <li>更方便、更安全</li>
                            全国超过300个城市送货上门、货到付款。鼠标一点，零风险购物，便捷到家。
                        </ul>
                    </div>
                    <ucl:LoginControl ID="LoginControl" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
