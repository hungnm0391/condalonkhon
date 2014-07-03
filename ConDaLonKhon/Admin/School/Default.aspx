<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ConDaLonKhon.Admin.School.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td style="width: 30%">
                Thành phố
            </td>
            <td>
                <asp:DropDownList ID="ddlCity" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Tên trường học
            </td>
            <td>
                <asp:TextBox ID="txtSchoolName" runat="server" Width="100%" MaxLength="255"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                <input type="button" value="Thêm mới" onclick="window.location='/Admin/School/Action.aspx'" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="grvSchool" Width="100%" runat="server" AutoGenerateColumns="false"
                    EmptyDataText="Không có dữ liệu" OnRowCommand="grvSchool_RowCommand" OnRowDataBound="grvSchool_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="STT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Literal ID="ltrSTT" runat="server"></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên trường học">
                            <ItemTemplate>
                                <asp:Literal ID="ltrSchoolName" runat="server"></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thành phố">
                            <ItemTemplate>
                                <asp:Literal ID="ltrCity" runat="server"></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/images/edit.png" CommandName="SUA" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/images/delete.png" CommandName="XOA"
                                    OnClientClick="return confirm('Bạn chắc chắn muốn xóa thành phố này?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
