<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/ASPxSpreadsheetBinding/Default.aspx) (VB: [Default.aspx](./VB/ASPxSpreadsheetBinding/Default.aspx))
* [Default.aspx.cs](./CS/ASPxSpreadsheetBinding/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/ASPxSpreadsheetBinding/Default.aspx.vb))
<!-- default file list end -->
# ASPxSpreadsheet - How to save and load documents from a database


<p><strong>UPDATED:</strong><br><br>This code example demonstrates how to save and restore ASPxSpreadsheet documents from a database using a Binary column.<br>Starting with version <strong>15.1</strong>, we recommend using the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxSpreadsheetASPxSpreadsheet_Opentopic">ASPxSpreadsheet.Open</a> method to load a document and call the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxSpreadsheetASPxSpreadsheet_SaveCopytopic">ASPxSpreadsheet.SaveCopy</a> method to save changes.</p>
<p>In version <strong>15.2</strong>, it is also possible to handle the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxSpreadsheetASPxSpreadsheet_Savingtopic">ASPxSpreadsheet.Saving</a> event to save a document by clicking the ribbon's built-in Save button.</p>
<p><br><strong>For Older Versions:</strong><br>Use <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressSpreadsheetISpreadsheetComponent_LoadDocumenttopic">ISpreadsheetComponent.LoadDocument</a> to load a document and <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressSpreadsheetISpreadsheetComponent_SaveDocumenttopic">ISpreadsheetComponent.SaveDocument</a> - to save it.<br><br><strong>See Also:<br>MVC Version:</strong><br><a href="https://www.devexpress.com/Support/Center/p/T190813">T190813: Spreadsheet - How to save and load documents from a database</a></p>

<br/>


