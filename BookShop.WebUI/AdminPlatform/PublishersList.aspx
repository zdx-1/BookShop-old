<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPlatform/AdminPlatform.master"
    AutoEventWireup="true" CodeFile="PublishersList.aspx.cs" Inherits="AdminPlatform_PublishersList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .header
        {
            padding: 20px 230px 10px 10px;
        }
        .content
        {
            text-align: left;
            padding: 20px 20px 10px 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div class="content">
            <asp:Label ID="Label1" runat="server" Text="出版社名称："></asp:Label>
            <asp:TextBox ID="txtPubName" runat="server"></asp:TextBox>
            <asp:Button ID="btnAddBookPublisher" runat="server" Text="新增出版社" OnClick="btnAddBookPublisher_Click" />
        </div>
        <div class="header" style="text-align: center">
            <asp:GridView ID="gvwBookPublisherList" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Id" CellPadding="4" ForeColor="#333333" Width="900px" GridLines="None"
                OnRowCommand="gvwBookPublisher_RowCommand" OnRowDataBound="gvwBookPublisher_RowDataBound"
                OnRowCancelingEdit="gvwBookPublisherList_RowCancelingEdit" OnRowEditing="gvwBookPublisherList_RowEditing"
                OnRowUpdating="gvwBookPublisherList_RowUpdating">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Id">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="出版社名称">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtName" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False" HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" ForeColor="Blue" runat="server" CausesValidation="False"
                                CommandName="Edit" Text="编辑"></asp:LinkButton>
                            <asp:LinkButton ID="lbDelete" ForeColor="Blue" CommandArgument='<%#Eval("Id") %>'
                                runat="server" CausesValidation="False" CommandName="DeletePublisher" OnClientClick="javascript:return confirm('确认删除该出版社吗？');"
                                Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                Text="更新"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="取消"></asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#DCE6F4" ForeColor="Gray" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
        <div style="width: 1000px; text-align: center">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="10" ShowPageIndexBox="Always" OnPageChanged="AspNetPager1_PageChanged"
                CssClass="anpager" CurrentPageButtonClass="cpb" FirstPageText="|<首页" LastPageText="尾页>|"
                NextPageText="下一页>" PrevPageText="<上一页">
            </webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>
