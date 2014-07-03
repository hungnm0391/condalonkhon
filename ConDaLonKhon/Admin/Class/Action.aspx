<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Action.aspx.cs" Inherits="ConDaLonKhon.Admin.Class.Action" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td style="width: 30%">
                Tên lớp học (<span style="color: #FF0000">*</span>)
            </td>
            <td>
                <asp:TextBox ID="txtClassName" runat="server" MaxLength="500" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Trường (<span style="color: #FF0000">*</span>)
            </td>
            <td>
                <asp:DropDownList ID="ddlSchool" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Loại lớp (<span style="color: #FF0000">*</span>)
            </td>
            <td>
                <asp:DropDownList ID="ddlClassType" runat="server">
                    <asp:ListItem Value="" Text="--- Chọn loại lớp ---"></asp:ListItem>
                    <asp:ListItem Value="01" Text="Lớp lớn"></asp:ListItem>
                    <asp:ListItem Value="02" Text="Lớp nhỡ"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Loại kiến thức sẽ học
            </td>
            <td>
                <asp:CheckBoxList ID="cblKnowledge" runat="server" BorderStyle="Solid">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="btnInsert" Text="Thêm mới" runat="server" Visible="false" OnClick="btnInsert_Click" />
                <asp:Button ID="btnUpdate" Text="Cập nhật" runat="server" Visible="false" OnClick="btnUpdate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
