<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPlatform/AdminPlatform.master"
    ValidateRequest="false" AutoEventWireup="true" CodeFile="ModifyBook.aspx.cs"
    Inherits="AdminPlatform_ModifyBook" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<%@ Register Assembly="DateTextBox" Namespace="Titan.WebForm" TagPrefix="TW" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #content
        {
            width: 900px;
            padding: 20px 40px;
        }
        .ImgfulImgUrlcss
        {
            text-align: left;
            vertical-align: middle;
            padding-left: 50px;
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <asp:Label runat="server" Text="修改图书信息：" ForeColor="Red" Font-Size="X-Large"></asp:Label>
        <br />
        <br />
        <table>
            <tr>
                <td class="border-rb1" style="width: 131px">
                    图书编号：
                </td>
                <td class="style3">
                    <asp:Label ID="lblId" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="border-rb1" style="width: 131px">
                    图书名称：
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtTitle" runat="server" Width="624px" MaxLength="199" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="red" runat="server"
                        ControlToValidate="txtTitle" ErrorMessage="*必填"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*请规范输入"
                        ControlToValidate="txtTitle" ForeColor="red" ValidationExpression="^[\d\D]{1,200}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="border-rb1" style="width: 131px">
                    编著者：
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtAuthor" runat="server" TextMode="SingleLine" Width="624px" MaxLength="199" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="red" runat="server"
                        ControlToValidate="txtAuthor" ErrorMessage="*必填"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <div style="text-align: left">
                        <table style="width: 500px">
                            <tr>
                                <td class="border-rb1" style="width: 131px">
                                    所属丛书分类：
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="ddlCategory" runat="server" Width="204px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1" style="width: 131px">
                                    出版社：
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="ddlPublisher" runat="server" Width="204px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1" style="width: 131px">
                                    ISBN：
                                </td>
                                <td class="style3">
                                    <asp:TextBox ID="txtISBN" runat="server" Width="204px" MaxLength="20" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ForeColor="red" runat="server"
                                        ControlToValidate="txtISBN" ErrorMessage="*必填"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1" style="width: 131px">
                                    出版时间：
                                </td>
                                <td class="style3">
                                    <TW:DateTextBox ID="dtbPublishDate" runat="server" Width="204px"></TW:DateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ForeColor="red" runat="server"
                                        ControlToValidate="dtbPublishDate" ErrorMessage="*必填"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1" style="width: 131px">
                                    定价（元）：
                                </td>
                                <td class="style3">
                                    <asp:TextBox ID="txtUnitPrice" runat="server" Width="204px" MaxLength="6" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ForeColor="red" runat="server"
                                        ControlToValidate="txtUnitPrice" ErrorMessage="*必填"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*填写价格不规范"
                                        ControlToValidate="txtUnitPrice" ValidationExpression="^[+]?\d*[\.]?\d*$" ForeColor="red"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1" style="width: 131px">
                                    字数：
                                </td>
                                <td class="style3">
                                    <asp:TextBox ID="txtWordsCount" runat="server" TextMode="SingleLine" Width="204px"
                                        MaxLength="9" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ForeColor="red" runat="server"
                                        ControlToValidate="txtWordsCount" ErrorMessage="*必填"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*请规范输入"
                                        ControlToValidate="txtWordsCount" ValidationExpression="[+]?\d+" ForeColor="red"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1" style="width: 131px">
                                    上传封面：
                                </td>
                                <td class="style3">
                                    <asp:FileUpload ID="fulImgUrl" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td>
                    <div class="ImgfulImgUrlcss">
                        <asp:Image ID="ImgfulImgUrl" runat="server" Height="155px" Width="128px" />
                        &nbsp;<br />
                    </div>
                </td>
            </tr>
        </table>
        <div class="border-rb1" style="text-align: left">
            内容提要:
        </div>
        <br />
        <div class="style3">
            <asp:TextBox ID="txtContentDescription" runat="server" TextMode="MultiLine" Height="100px"
                Width="754px" />
        </div>
        <br />
        <div class="border-rb1" style="text-align: left">
            作者简介：
        </div>
        <br />
        <div class="style3">
            <asp:TextBox ID="txtAuthorDescription" runat="server" TextMode="MultiLine" Height="100px"
                Width="754px" />
        </div>
        <br />
        <div class="border-rb1" style="text-align: left">
            编辑推荐：
        </div>
        <br />
        <div class="style3">
            <asp:TextBox ID="txtEditorComment" runat="server" TextMode="MultiLine" Height="100px"
                Width="754px" />
        </div>
        <br />
        <div class="border-rb1" style="text-align: left">
            目录：
        </div>
        <br />
        <div class="style3">
            <FTB:FreeTextBox ID="txtTOC" runat="server" Width="754px">
            </FTB:FreeTextBox>
        </div>
        <br />
        <br />
        <center>
            <asp:Button ID="btnOk" runat="server" Text="编辑图书" class="submit" OnClick="btnOk_Click" />
        </center>
    </div>
</asp:Content>
