using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Spreadsheet;
using DevExpress.Web.Office;

namespace ASPxSpreadsheetBinding {
    public partial class Default : System.Web.UI.Page {
        string SessionKey = "EditedDocumentID";
        protected string EditedDocumentID {
            get { return (string)Session[SessionKey] ?? string.Empty; }
            set { Session[SessionKey] = value; }
        }
        protected void Page_Init(object sender, EventArgs e) {
            if(!IsPostBack && !IsCallback) {
                if(!string.IsNullOrEmpty(EditedDocumentID)) {
                    DocumentManager.CloseDocument(DocumentManager.FindDocument(EditedDocumentID).DocumentId);
                    EditedDocumentID = string.Empty;
                }

                EditedDocumentID = Guid.NewGuid().ToString();

                DataView view = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
                Spreadsheet.Open(
                    EditedDocumentID,
                    DocumentFormat.Xlsx,
                    () => { return (byte[])view.Table.Rows[0]["DocBytes"]; }
                );
            }
        }

        protected void Spreadsheet_Saving(object source, DevExpress.Web.Office.DocumentSavingEventArgs e) {
            // Save document with the Ribbon Save button
            e.Handled = true;
            SqlDataSource1.Update();
        }

        protected void SaveButton_Click(object sender, EventArgs e) {
            SqlDataSource1.Update();
        }

        protected void SqlDataSource1_Updating(object sender, SqlDataSourceCommandEventArgs e) {
            e.Command.Parameters["@Id"].Value = 1; // First Row
            e.Command.Parameters["@DocBytes"].Value = Spreadsheet.SaveCopy(DocumentFormat.Xlsx);
        }
    }
}