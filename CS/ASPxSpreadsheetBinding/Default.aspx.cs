using DevExpress.Spreadsheet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPxSpreadsheetBinding {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Spreadsheet_Init(object sender, EventArgs e) {
            if (!IsPostBack) {
                DataView view = (DataView)Sqldatasource1.Select(DataSourceSelectArguments.Empty);
                Spreadsheet.Document.LoadDocument((byte[])view.Table.Rows[0]["DocBytes"], DevExpress.Spreadsheet.DocumentFormat.Xlsx);
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e) {
            Sqldatasource1.Update();
        }

        protected void Sqldatasource1_Updating(object sender, SqlDataSourceCommandEventArgs e) {
            e.Command.Parameters["@Id"].Value = 1; // First Row
            e.Command.Parameters["@DocBytes"].Value = Spreadsheet.Document.SaveDocument(DocumentFormat.Xlsx);
        }
    }
}