<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Action.aspx.cs" Inherits="ConDaLonKhon.Admin.School.Action" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td style="width: 30%">
                Tên trường học (<span style="color: #FF0000">*</span>)
            </td>
            <td>
                <asp:TextBox ID="txtSchoolName" runat="server" MaxLength="500" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Địa chỉ
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" MaxLength="500" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Điện thoại
            </td>
            <td>
                <asp:TextBox ID="txtTelephone" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="320" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Website
            </td>
            <td>
                <asp:TextBox ID="txtWebsite" runat="server" MaxLength="253" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Thành phố (<span style="color: #FF0000">*</span>)
            </td>
            <td>
                <asp:DropDownList ID="ddlCity" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="btnInsert" Text="Thêm mới" runat="server" OnClick="btnInsert_Click" />
                <asp:Button ID="btnUpdate" Text="Cập nhật" runat="server" 
                    onclick="btnUpdate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
