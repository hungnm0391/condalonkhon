<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Action.aspx.cs" Inherits="ConDaLonKhon.Admin.Knowledge.Action" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td style="width: 30%">
                Tên kiến thức (<span style="color: #FF0000">*</span>)
            </td>
            <td>
                <asp:TextBox ID="txtKnowledgeName" runat="server" MaxLength="500" Width="100%"></asp:TextBox>
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
