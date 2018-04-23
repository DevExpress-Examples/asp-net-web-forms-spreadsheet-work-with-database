<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPxSpreadsheetBinding.Default" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpreadsheet.v15.2, Version=15.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpreadsheet" TagPrefix="dx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxSpreadsheet ID="Spreadsheet" runat="server" WorkDirectory="~/App_Data/WorkDirectory" OnSaving="Spreadsheet_Saving"></dx:ASPxSpreadsheet>
        <dx:ASPxButton ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click"></dx:ASPxButton>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DocumentsConnectionString %>" OnUpdating="SqlDataSource1_Updating" SelectCommand="SELECT * FROM [Docs]" UpdateCommand="UPDATE [Docs] SET [DocBytes] = @DocBytes WHERE [Id] = @Id">
            <UpdateParameters>
                <asp:Parameter Name="DocBytes" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>