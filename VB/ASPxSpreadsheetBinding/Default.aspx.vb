Imports System
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Spreadsheet
Imports DevExpress.Web.Office

Namespace ASPxSpreadsheetBinding
	Partial Public Class [Default]
		Inherits System.Web.UI.Page

		Private SessionKey As String = "EditedDocuemntID"
		Protected Property EditedDocuemntID() As String
			Get
				Return If(DirectCast(Session(SessionKey), String), String.Empty)
			End Get
			Set(ByVal value As String)
				Session(SessionKey) = value
			End Set
		End Property
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			If Not IsPostBack AndAlso Not IsCallback Then
				If Not String.IsNullOrEmpty(EditedDocuemntID) Then
					DocumentManager.CloseDocument(DocumentManager.FindDocument(EditedDocuemntID).DocumentId)
					EditedDocuemntID = String.Empty
				End If

				EditedDocuemntID = Guid.NewGuid().ToString()

				Dim view As DataView = DirectCast(SqlDataSource1.Select(DataSourceSelectArguments.Empty), DataView)
				Spreadsheet.Open(EditedDocuemntID, DocumentFormat.Xlsx, Function()
					Return CType(view.Table.Rows(0)("DocBytes"), Byte())
				End Function)
			End If
		End Sub

		Protected Sub Spreadsheet_Saving(ByVal source As Object, ByVal e As DevExpress.Web.Office.DocumentSavingEventArgs)
			' Save document with the Ribbon Save button
			e.Handled = True
			SqlDataSource1.Update()
		End Sub

		Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			SqlDataSource1.Update()
		End Sub

		Protected Sub SqlDataSource1_Updating(ByVal sender As Object, ByVal e As SqlDataSourceCommandEventArgs)
			e.Command.Parameters("@Id").Value = 1 ' First Row
			e.Command.Parameters("@DocBytes").Value = Spreadsheet.SaveCopy(DocumentFormat.Xlsx)
		End Sub
	End Class
End Namespace