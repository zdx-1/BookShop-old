<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPlatform/AdminPlatform.master"
    AutoEventWireup="true" CodeFile="BookList.aspx.cs" Inherits="AdminPlatform_BookList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .header
        {
            padding: 0px 230px 10px 10px;
        }
        .topShow
        {
            padding: 0px 10px 3px 500px;
            float: left;
        }
        .topShow1
        {
            padding: 0px 10px 3px 30px;
            float: left;
        }
        .topShow2
        {
            padding: 0px 10px 3px 10px;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table width="1000">
            <tr>
                <br />
                <div class="topShow2">
                    <asp:DropDownList ID="ddlCategory" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                        <asp:ListItem Value="-1">-所有分类-</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="topShow">
                    <asp:CheckBox ID="chkSelectAll" Text="全选" AutoPostBack="true" runat="server" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                </div>
                <div class="topShow1">
                    <img src="images/083.gif" />
                    <asp:LinkButton ID="lnkbtnDelete" CommandArgument='<%#Eval("Id") %>' runat="server"
                        CausesValidation="False" CommandName="DeleteBook" OnClientClick="javascript:return confirm('确认删除该图书吗？');"
                        Text="删除" OnClick="lnkbtnDelete_Click"></asp:LinkButton>
                </div>
                <div class="topShow1">
                    <img src="images/001.gif" />
                    <a href="AddNewBook.aspx">新增</a>
                </div>
            </tr>
            <br />
        </table>
        <div class="header" style="text-align: center">
            <asp:GridView ID="gvwBookList" runat="server" CellPadding="4" ForeColor="#333333"
                DataKeyNames="Id" GridLines="None" Width="900px" AutoGenerateColumns="False"
                OnRowCommand="gvwBookList_RowCommand" OnRowDataBound="gvwBookList_RowDataBound">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="书名">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlTitle" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ShowBookDetails"
                                Text='<%#Eval("Title").ToString().Length>26? 
                                    (Eval("Title").ToString().Substring(0,22)+"...") 
                                    :Eval("Title").ToString()%>' ToolTip='<%#Eval("Title") %>'>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="作者">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlAuthor" runat="server" Text='<%#Eval("Author").ToString().Length>10? 
                            (Eval("Author").ToString().Substring(0,10)+"...") 
                            :Eval("Author").ToString()%>' ToolTip='<%#Eval("Title") %>'>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="出版社">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Publishers.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UnitPrice" HeaderText="单价" DataFormatString="{0:f}" />
                    <asp:BoundField DataField="PublishDate" DataFormatString="{0:yyyy/MM/DD}" HeaderText="出版日期" />
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/AdminPlatform/BookDetails.aspx?BookId={0}"
                        HeaderText="浏览" Text="详细" />
                    <asp:TemplateField ShowHeader="False" HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDelete" ForeColor="Blue" CommandArgument='<%#Eval("Id") %>'
                                runat="server" CausesValidation="False" CommandName="DeleteBook" OnClientClick="javascript:return confirm('确认删除该图书吗？');"
                                Text="删除"></asp:LinkButton>
                            <asp:LinkButton ID="lbUpdate" ForeColor="Blue" CommandArgument='<%#Eval("Id") %>'
                                runat="server" CausesValidation="False" CommandName="UpdateBook" Text="编辑"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <EmptyDataTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AdminPlatform/AddNewBook.aspx"
                        Text="还没有任何图书记录,点击添加！" Font-Size="X-Large"></asp:HyperLink>
                </EmptyDataTemplate>
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
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="10" ShowPageIndexBox="Always"
                OnPageChanged="AspNetPager1_PageChanged" CssClass="anpager" NumericButtonCount="10"
                CurrentPageButtonClass="cpb" FirstPageText="|<首页" LastPageText="尾页>|" NextPageText="下一页>"
                PrevPageText="<上一页">
            </webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>
