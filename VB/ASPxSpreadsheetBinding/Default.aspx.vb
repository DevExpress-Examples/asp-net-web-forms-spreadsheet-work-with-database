Imports DevExpress.Spreadsheet
Imports System
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ASPxSpreadsheetBinding

    Public Partial Class [Default]
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Protected Sub Spreadsheet_Init(ByVal sender As Object, ByVal e As EventArgs)
            If Not IsPostBack Then
                Dim view As DataView = CType(Sqldatasource1.Select(DataSourceSelectArguments.Empty), DataView)
                Spreadsheet.Document.LoadDocument(CType(view.Table.Rows(0)("DocBytes"), Byte()), DocumentFormat.Xlsx)
            End If
        End Sub

        Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Sqldatasource1.Update()
        End Sub

        Protected Sub Sqldatasource1_Updating(ByVal sender As Object, ByVal e As SqlDataSourceCommandEventArgs)
            e.Command.Parameters("@Id").Value = 1 ' First Row
            e.Command.Parameters("@DocBytes").Value = Spreadsheet.Document.SaveDocument(DocumentFormat.Xlsx)
        End Sub
    End Class
End Namespace
