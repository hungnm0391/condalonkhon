<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ConDaLonKhon.Admin.City.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td style="width: 30%">
                Tên thành phố
            </td>
            <td>
                <asp:TextBox ID="txtCityName" runat="server" Width="100%" MaxLength="255"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                <input type="button" value="Thêm mới" onclick="window.location='/Admin/City/Action.aspx'" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="grvCity" Width="100%" runat="server" OnRowDataBound="grvCity_RowDataBound"
                    AutoGenerateColumns="false" OnRowCommand="grvCity_RowCommand" EmptyDataText="Không có dữ liệu">
                    <Columns>
                        <asp:TemplateField HeaderText="STT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Literal ID="ltrSTT" runat="server"></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên thành phố">
                            <ItemTemplate>
                                <asp:Literal ID="ltrCityName" runat="server"></asp:Literal>
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
