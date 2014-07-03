<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Action.aspx.cs" Inherits="ConDaLonKhon.Admin.City.Action" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td style="width: 30%">
                Tên thành phố (<span style="color: #FF0000">*</span>)
            </td>
            <td>
                <asp:TextBox ID="txtCityName" runat="server" MaxLength="255" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="btnInsert" Text="Thêm mới" runat="server" Visible="false" 
                    onclick="btnInsert_Click" />
                <asp:Button ID="btnUpdate" Text="Cập nhật" runat="server" Visible="false" 
                    onclick="btnUpdate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
