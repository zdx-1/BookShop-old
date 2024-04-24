<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPlatform/AdminPlatform.master"
    AutoEventWireup="true" CodeFile="AddNewBook.aspx.cs" Inherits="AdminPlatform_AddNewBook" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<%@ Register Assembly="DateTextBox" Namespace="Titan.WebForm" TagPrefix="TW" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        td.border-rb1
        {
            width: 180px;
            padding: 3px 10px 3px 15px;
        }
        td.border-rb
        {
            width: 381px;
        }
        .style3
        {
            border-bottom: 1 #CCCCCC solid;
            padding-left: 10px;
            text-align: left;
            width: 448px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td class="border-rb1" style="width: 101px">
                图书名称：
            </td>
            <td class="style3">
                <asp:TextBox ID="txtTitle" runat="server" Width="174px" MaxLength="199" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="red" runat="server"
                    ControlToValidate="txtTitle" ErrorMessage="*必填"></asp:RequiredFieldValidator>
            </td>
            <td class="border-rb" style="width: 426px">
                图书名称由出空格外任意长度不超过200的字符组成
            </td>
        </tr>
        <tr>
            <td class="border-rb1" style="width: 101px">
                图书类别：
            </td>
            <td class="style3">
                <asp:DropDownList ID="ddlCategory" runat="server">
                </asp:DropDownList>
            </td>
            <td class="border-rb" style="width: 426px">
                请选择图书类别
            </td>
        </tr>
        <tr>
            <td class="border-rb1" style="width: 101px">
                编著者：
            </td>
            <td class="style3">
                <asp:TextBox ID="txtAuthor" runat="server" TextMode="SingleLine" Width="174px" MaxLength="199" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="red" runat="server"
                    ControlToValidate="txtAuthor" ErrorMessage="*必填"></asp:RequiredFieldValidator>
            </td>
            <td class="border-rb" style="width: 426px">
                输入任意长度不超过200的字符
            </td>
        </tr>
        <tr>
            <td class="border-rb1" style="width: 101px">
                出版社：
            </td>
            <td class="style3">
                <asp:DropDownList ID="ddlPublisher" runat="server">
                </asp:DropDownList>
            </td>
            <td class="border-rb" style="width: 426px">
                选择出版社
            </td>
        </tr>
        <tr>
            <td class="border-rb1" style="width: 101px">
                ISBN：
            </td>
            <td class="style3">
                <asp:TextBox ID="txtISBN" runat="server" Width="174px" MaxLength="20" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ForeColor="red" runat="server"
                    ControlToValidate="txtISBN" ErrorMessage="*必填"></asp:RequiredFieldValidator>
            </td>
            <td class="border-rb" style="width: 426px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="border-rb1" style="width: 101px">
                出版时间：
            </td>
            <td class="style3">
                <TW:DateTextBox ID="dtbPublishDate" runat="server" Width="174px"></TW:DateTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ForeColor="red" runat="server"
                    ControlToValidate="dtbPublishDate" ErrorMessage="*必填"></asp:RequiredFieldValidator>
            </td>
            <td class="border-rb" style="width: 426px">
                不能超过系统时间
            </td>
        </tr>
        <tr>
            <td class="border-rb1" style="width: 101px">
                字数：
            </td>
            <td class="style3">
                <asp:TextBox ID="txtWordsCount" runat="server" TextMode="SingleLine" Width="174px"
                    MaxLength="9" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ForeColor="red" runat="server"
                    ControlToValidate="txtWordsCount" ErrorMessage="*必填"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*请规范输入"
                    ControlToValidate="txtWordsCount" ValidationExpression="[+]?\d+" ForeColor="red"></asp:RegularExpressionValidator>
            </td>
            <td class="border-rb" style="width: 426px">
                输入由0-9数字组成的正整数
            </td>
        </tr>
        <tr>
            <td class="border-rb1" style="width: 101px">
                价格：
            </td>
            <td class="style3">
                <asp:TextBox ID="txtUnitPrice" runat="server" Width="174px" MaxLength="6" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ForeColor="red" runat="server"
                    ControlToValidate="txtUnitPrice" ErrorMessage="*必填"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*填写价格不规范"
                    ControlToValidate="txtUnitPrice" ValidationExpression="^[+]?\d*[\.]?\d*$" ForeColor="red"></asp:RegularExpressionValidator>
            </td>
            <td class="border-rb" style="width: 426px">
                输入正实数
            </td>
        </tr>
        <tr>
            <td class="border-rb1" style="width: 101px">
                内容摘要:
            </td>
            <td class="style3">
                <asp:TextBox ID="txtContentDescription" runat="server" TextMode="MultiLine" Height="70px"
                    Width="174px" />
            </td>
            <td class="border-rb" style="width: 426px">
            </td>
        </tr>
        <tr>
            <td class="border-rb1" style="width: 101px">
                作者简介：
            </td>
            <td class="style3">
                <asp:TextBox ID="txtAuthorDescription" runat="server" TextMode="MultiLine" Height="64px"
                    Width="174px" />
            </td>
            <td class="border-rb" style="width: 426px">
            </td>
        </tr>
        <tr>
            <td class="border-rb1" style="width: 101px">
                编辑推荐：
            </td>
            <td class="style3">
                <asp:TextBox ID="txtEditorComment" runat="server" TextMode="MultiLine" Height="63px"
                    Width="174px" />
            </td>
            <td class="border-rb" style="width: 426px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="border-rb1" style="width: 101px">
                目录：
            </td>
            <td class="style3">
                <FTB:FreeTextBox ID="txtTOC" runat="server" Width="450px">
                </FTB:FreeTextBox>
            </td>
            <td class="border-rb" style="width: 426px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="border-rb1" style="width: 101px">
                上传图片：
            </td>
            <td class="style3">
                <asp:FileUpload ID="fulImgUrl" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="red" runat="server"
                    ControlToValidate="fulImgUrl" ErrorMessage="*必填"></asp:RequiredFieldValidator>
            </td>
            <td class="border-rb" style="width: 426px">
                上传*.jpg、*.gif、*.png、*.jpeg、*.bmp格式的图片
            </td>
        </tr>
    </table>
    <center>
        <asp:Button ID="btnOk" runat="server" Text="新增图书" class="submit" OnClick="btnOk_Click" />
    </center>
</asp:Content>
