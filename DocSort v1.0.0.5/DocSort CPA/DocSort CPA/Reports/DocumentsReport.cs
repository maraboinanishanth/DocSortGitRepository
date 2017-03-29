using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System.IO;
using System.Collections;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using Business.Manager;
using Common;

namespace DocSort_CPA.Reports
{
    public partial class DocumentsReport : Form
    {
        public DocumentsReport()
        {
            InitializeComponent();
        }

        DataGridViewPrinter MyDataGridViewPrinter;
        private void DocumentsReport_Load(object sender, EventArgs e)
        {
            // Checking Useraccesspermissions based on Role
            GetPermissiondetails(8);
            // End

            this.ControlBox = false;

            dtpStartDate.CalendarForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            dtpEndDate.CalendarForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            lblStartDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            lblEndDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //this.Location = new Point(50, 173);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            this.Location = new Point(((Devicewidth-3) - this.ClientSize.Width) / 2, 139);

            rbtnByDate.Checked = true;
           
            ShowPrintButtons();
        }

        public void GetPermissiondetails(int FormID)
        {
            UserManager objUserManager = new UserManager();
            NandanaResult dsuserPermission = new NandanaResult();
            dsuserPermission = objUserManager.GetUserPermissions(UserAccessPermissionvalues.RoleID);
            if (dsuserPermission.resultDS != null && dsuserPermission.resultDS.Tables[0].Rows.Count > 0)
            {
                Boolean View = false;

                DataRow[] drpermissions = dsuserPermission.resultDS.Tables[0].Select("Form_ID ='" + FormID + "'");

                if (drpermissions.Length > 0)
                {
                    View = Convert.ToBoolean(drpermissions[0]["IsView"]);
                }
                if (View == false)
                {
                    ChangeControlStatus(false);
                }
                else
                {
                    ChangeControlStatus(true);
                }
            }
        }

        public void ChangeControlStatus(bool status)
        {

            foreach (Control c in this.Controls)
            {
                foreach (Control ctrl in c.Controls)
                {
                    EnableControls(ctrl, status);
                }

                EnableControls(c, status);
            }

        }

        public void EnableControls(Control ctrl, bool status)
        {
            if (ctrl is TextBox)

                ((TextBox)ctrl).Enabled = status;

            else if (ctrl is Button)

                ((Button)ctrl).Enabled = status;

            else if (ctrl is RadioButton)

                ((RadioButton)ctrl).Enabled = status;

            else if (ctrl is DataGridView)

                ((DataGridView)ctrl).Enabled = status;

            else if (ctrl is CheckBox)

                ((CheckBox)ctrl).Enabled = status;

            else if (ctrl is ComboBox)

                ((ComboBox)ctrl).Enabled = status;

            else if (ctrl is LinkLabel)

                ((LinkLabel)ctrl).Enabled = status;

            else if (ctrl is Panel)

                ((Panel)ctrl).Enabled = status;

            else if (ctrl is TreeView)

                ((TreeView)ctrl).Enabled = status;

            else if (ctrl is WebBrowser)

                ((WebBrowser)ctrl).Enabled = status;

            else if (ctrl is DateTimePicker)

                ((DateTimePicker)ctrl).Enabled = status;
        }


        public void ShowPrintButtons()
        {
            if (this.dgvDocuments.RowCount >= 1)
            {
                btnPrint.Visible = true;
                btnPrintPreview.Visible = true;
            }
            else
            {
                btnPrint.Visible = false;
                btnPrintPreview.Visible = false;
            }
        }

        public class FinalInfoView
        {
            public string Date { get; set; }
            public int TotalDocsCount { get; set; }
            public int MatchedDocsCount { get; set; }
             
        }

        public void GetDocumentScannedResults()
        {
            bool status = true;
            if (rbtnByDate.Checked)
            {
                if (Convert.ToDateTime(dtpStartDate.Value.ToString("yyyy-MM-dd")) > DateTime.Today)
                {
                    pnlError.Visible = true;
                    pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                    pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                    lblErrorMsg.Text = "From Date should be before To Date";
                    lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                    status = false;
                    dtpStartDate.Focus();
                    return;
                }
                //if (Convert.ToDateTime(dtpEndDate.Value.ToString("yyyy-MM-dd")) > DateTime.Today)
                //{
                //    pnlError.Visible = true;
                //    pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                //    pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                //    lblErrorMsg.Text = "End Date is greater than today(s) date";
                //    lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                //    status = false;
                //    dtpEndDate.Focus();
                //    return;
                //}
                if (Convert.ToDateTime(dtpStartDate.Value.ToString("yyyy-MM-dd")) > Convert.ToDateTime(dtpEndDate.Value.ToString("yyyy-MM-dd")))
                {
                    pnlError.Visible = true;
                    pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                    pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                    lblErrorMsg.Text = "From Date should be before To Date";
                    lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                    status = false;
                    dtpEndDate.Focus();
                    return;
                }
            }
            if (!status)
            {
                MessageBox.Show("Please enter required data");
            }
            else
            {
                dgvDocuments.Columns.Clear();
                dgvDocuments.AutoGenerateColumns = false;
                dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDocuments.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
                this.dgvDocuments.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11.00F);
                //DataGridViewCellStyle style = new DataGridViewCellStyle();
                //style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewColumn clnSrNo = new DataGridViewTextBoxColumn();
                clnSrNo.DataPropertyName = "Sr.no";
                clnSrNo.Name = "S.No";
                dgvDocuments.Columns.Add(clnSrNo);
                clnSrNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnSrNo.Width = 80;



                //DataGridViewColumn clnCategoryID = new DataGridViewTextBoxColumn();
                //clnCategoryID.DataPropertyName = "Category_ID";
                //clnCategoryID.Name = "Category_ID";
                //dgvDocuments.Columns.Add(clnCategoryID);
                //clnCategoryID.Visible = false;

                //DataGridViewColumn clnCategoryName = new DataGridViewTextBoxColumn();
                //clnCategoryName.DataPropertyName = "Category_Name";
                //clnCategoryName.Name = "Category Name";
                //dgvDocuments.Columns.Add(clnCategoryName);

                DataGridViewColumn clnDocumentsCount = new DataGridViewTextBoxColumn();
                clnDocumentsCount.DataPropertyName = "NumberOfDocumentsCount";
                clnDocumentsCount.Name = "Total Documents";
                dgvDocuments.Columns.Add(clnDocumentsCount);
                //this.dgvDocuments.Columns["Total Docs Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                DataGridViewColumn clnMatchedDocumentsCount = new DataGridViewTextBoxColumn();
                clnMatchedDocumentsCount.DataPropertyName = "NumberOfMatchedDocumentsCount";
                clnMatchedDocumentsCount.Name = "Total Matched Documents";
                dgvDocuments.Columns.Add(clnMatchedDocumentsCount);

                DataGridViewColumn clnUnMatchedDocumentsCount = new DataGridViewTextBoxColumn();
                clnUnMatchedDocumentsCount.DataPropertyName = "NumberOfUnMatchedDocumentsCount";
                clnUnMatchedDocumentsCount.Name = "Total Mismatched Documents";
                dgvDocuments.Columns.Add(clnUnMatchedDocumentsCount);

                DataGridViewColumn clnDate = new DataGridViewTextBoxColumn();
                clnDate.DataPropertyName = "Date";
                clnDate.Name = "Date";
                dgvDocuments.Columns.Add(clnDate);
                clnDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnDate.Width = 80;

                DataTable dttemp = new DataTable();
                dttemp.Columns.Add("Sr.no", typeof(String));
                dttemp.Columns.Add("Date", typeof(String));
                //dttemp.Columns.Add("Category_ID", typeof(int));
                //dttemp.Columns.Add("Category_Name", typeof(String));
                dttemp.Columns.Add("NumberOfDocumentsCount", typeof(int));
                dttemp.Columns.Add("NumberOfMatchedDocumentsCount", typeof(int));
                dttemp.Columns.Add("NumberOfUnMatchedDocumentsCount", typeof(int));

                try
                {
                    DocumentReportManager objDocumentReportManager = new DocumentReportManager();
                    NandanaResult dsgetNumberOfDocumentResultsdetails = objDocumentReportManager.GetNumberOfDocumentCountDetailsUsingDate(dtpStartDate.Value.ToString("yyyy-MM-dd"), dtpEndDate.Value.ToString("yyyy-MM-dd"));
                    NandanaResult dsgetNumberOfMatchedDocumentResultsdetails = objDocumentReportManager.GetNumberOfMatchedDocumentCountUsingDate(dtpStartDate.Value.ToString("yyyy-MM-dd"), dtpEndDate.Value.ToString("yyyy-MM-dd"));
                    DataTable dtFinalResult = new DataTable();
                    if (dsgetNumberOfDocumentResultsdetails.resultDS != null && dsgetNumberOfDocumentResultsdetails.resultDS.Tables[0].Rows.Count > 0)
                    {
                        if (dsgetNumberOfDocumentResultsdetails.resultDS.Tables[0].Rows.Count > 0 && dsgetNumberOfMatchedDocumentResultsdetails.resultDS!=null)
                        {
                            DataTable newTable = new DataTable();
                            newTable.Columns.Add("Date", typeof(String));
                            newTable.Columns.Add("NumberOfDocumentsCount", typeof(int));
                            newTable.Columns.Add("NumberOfMatchedDocumentsCount", typeof(int));

                            var JoinResult = from p in dsgetNumberOfDocumentResultsdetails.resultDS.Tables[0].AsEnumerable()
                                             join t in dsgetNumberOfMatchedDocumentResultsdetails.resultDS.Tables[0].AsEnumerable()
                                             on DateTime.Parse(Convert.ToDateTime(p.Field<String>("Date")).ToString("yyyy-MM-dd")) equals DateTime.Parse(Convert.ToDateTime(t.Field<String>("Date")).ToString("yyyy-MM-dd"))
                                             where (DateTime.Parse(Convert.ToDateTime(p.Field<String>("Date")).ToString("yyyy-MM-dd")) >= DateTime.Parse(dtpStartDate.Value.ToString("yyyy-MM-dd")) && DateTime.Parse(Convert.ToDateTime(p.Field<String>("Date")).ToString("yyyy-MM-dd")) <= DateTime.Parse(dtpEndDate.Value.ToString("yyyy-MM-dd")))
                                             select new
                                             {
                                                p,t

                                             };

                            foreach (var dr in JoinResult)
                            {
                                DataRow newRow = newTable.NewRow();
                                //newTable.Rows.Add(dr.Date, dr.TotalDocsCount, dr.MatchedDocsCount);

                                newRow["Date"] = dr.p.Field<String>("Date");
                                newRow["NumberOfDocumentsCount"] =(dr.p.Field<Int64>("NumberOfDocumentsCount"));
                                newRow["NumberOfMatchedDocumentsCount"] = (dr.t.Field<Int64>("NumberOfMatchedDocumentsCount"));

                                newTable.Rows.Add(newRow);
                            }

                            

                            dtFinalResult = newTable;

                            int MatchedDocumentCount;
                            int i = 0;
                            if (dtFinalResult.Rows.Count > 0)
                            {
                               
                                foreach (DataRow dr in dtFinalResult.Rows)
                                {
                                    DataRow drtemp = dttemp.NewRow();
                                    drtemp["Sr.no"] = (i + 1).ToString();
                                    drtemp["Date"] = Convert.ToDateTime(dr["Date"]).ToString("yyyy-MM-dd").ToString();
                                    drtemp["NumberOfDocumentsCount"] =Convert.ToInt32(dr["NumberOfDocumentsCount"]);
                                    if (!(dr["NumberOfMatchedDocumentsCount"] is DBNull))
                                    {
                                        drtemp["NumberOfMatchedDocumentsCount"] = dr["NumberOfMatchedDocumentsCount"];
                                        MatchedDocumentCount = Convert.ToInt32(dr["NumberOfMatchedDocumentsCount"]);
                                    }
                                    else
                                    {
                                        drtemp["NumberOfMatchedDocumentsCount"] = 0;
                                        MatchedDocumentCount = 0;
                                    }

                                    drtemp["NumberOfUnMatchedDocumentsCount"] = Convert.ToInt32(dr["NumberOfDocumentsCount"]) - MatchedDocumentCount;


                                    dttemp.Rows.Add(drtemp);
                                    
                                    i++;
                                }
                            }

                            if (dsgetNumberOfDocumentResultsdetails.resultDS != null && dsgetNumberOfDocumentResultsdetails.resultDS.Tables[1].Rows.Count > 0)
                            {
                                foreach (DataRow drManual in dsgetNumberOfDocumentResultsdetails.resultDS.Tables[1].Rows)
                                {
                                    DataRow drtemp = dttemp.NewRow();
                                    drtemp["Sr.no"] = (i+1).ToString();
                                    drtemp["Date"] = Convert.ToDateTime(drManual["Date"]).ToString("yyyy-MM-dd").ToString();
                                    drtemp["NumberOfDocumentsCount"] = Convert.ToInt32(drManual["NumberOfManualDocumentsCount"]);

                                    drtemp["NumberOfMatchedDocumentsCount"] = 0;
                                    drtemp["NumberOfUnMatchedDocumentsCount"] = 0;


                                    dttemp.Rows.Add(drtemp);

                                    i++;

                                }
                            }

                            if (dttemp.Rows.Count > 0)
                            {
                                int TotalCount = 0; int MatchedCount = 0; int UnMatchedCount = 0;
                                foreach (DataRow dr in dttemp.Rows)
                                {
                                    if (dr["Date"].ToString() != "")
                                    {
                                        dr["Date"] = DateTime.Parse(dr["Date"].ToString(), System.Globalization.CultureInfo.InvariantCulture).ToString("d");
                                    }
                                    if (dr["NumberOfDocumentsCount"].ToString() != "")
                                    {
                                        TotalCount += Convert.ToInt32((String)dr["NumberOfDocumentsCount"].ToString());
                                    }
                                    if (dr["NumberOfMatchedDocumentsCount"].ToString() != "")
                                    {
                                        MatchedCount += Convert.ToInt32((String)dr["NumberOfMatchedDocumentsCount"].ToString());
                                    }
                                    if (dr["NumberOfUnMatchedDocumentsCount"].ToString() != "")
                                    {
                                        UnMatchedCount += Convert.ToInt32((String)dr["NumberOfUnMatchedDocumentsCount"].ToString());
                                    }
                                }
                                int index = dttemp.Rows.Count;
                                DataRow Footer = dttemp.NewRow();


                                //Footer["File_Name"] = "Total Count";
                                Footer["Sr.no"] = "Total Count";
                                Footer["NumberOfDocumentsCount"] = TotalCount;
                                Footer["NumberOfMatchedDocumentsCount"] = MatchedCount;
                                Footer["NumberOfUnMatchedDocumentsCount"] = UnMatchedCount;

                                dttemp.Rows.Add(Footer);

                                dgvDocuments.DataSource = dttemp;

                                DataGridViewCellStyle style = new DataGridViewCellStyle();
                                style.Font = new System.Drawing.Font(dgvDocuments.Font, FontStyle.Bold);
                                dgvDocuments.Rows[index].DefaultCellStyle = style;

                                foreach (DataGridViewColumn column in dgvDocuments.Columns)
                                {
                                    //column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                }
                            }

                            else
                            {
                                pnlError.Visible = true;
                                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                                lblErrorMsg.Text = "No results found, try a new search.";
                                lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                                dgvDocuments.DataSource = null;
                            }
                        }
                        else if (dsgetNumberOfDocumentResultsdetails.resultDS.Tables[0].Rows.Count > 0 && dsgetNumberOfMatchedDocumentResultsdetails.resultDS==null)
                        {
                            int i = 0;
                            int MatchedDocumentCount;
                            foreach (DataRow dr in dsgetNumberOfDocumentResultsdetails.resultDS.Tables[0].Rows)
                            {
                                DataRow drtemp = dttemp.NewRow();
                                drtemp["Sr.no"] = (i + 1).ToString();
                                drtemp["Date"] = Convert.ToDateTime(dr["Date"]).ToString("yyyy-MM-dd").ToString();
                                drtemp["NumberOfDocumentsCount"] = dr["NumberOfDocumentsCount"];

                                drtemp["NumberOfMatchedDocumentsCount"] = 0;
                                MatchedDocumentCount = 0;


                                drtemp["NumberOfUnMatchedDocumentsCount"] = Convert.ToInt32(dr["NumberOfDocumentsCount"]) - MatchedDocumentCount;


                                dttemp.Rows.Add(drtemp);
                                i++;
                            }

                            if (dsgetNumberOfDocumentResultsdetails.resultDS != null && dsgetNumberOfDocumentResultsdetails.resultDS.Tables[1].Rows.Count > 0)
                            {
                                foreach (DataRow drManual in dsgetNumberOfDocumentResultsdetails.resultDS.Tables[1].Rows)
                                {
                                    DataRow drtemp = dttemp.NewRow();
                                    drtemp["Sr.no"] = (i + 1).ToString();
                                    drtemp["Date"] = Convert.ToDateTime(drManual["Date"]).ToString("yyyy-MM-dd").ToString();
                                    drtemp["NumberOfDocumentsCount"] = Convert.ToInt32(drManual["NumberOfManualDocumentsCount"]);

                                    drtemp["NumberOfMatchedDocumentsCount"] = 0;
                                    drtemp["NumberOfUnMatchedDocumentsCount"] = 0;


                                    dttemp.Rows.Add(drtemp);

                                    i++;

                                }
                            }

                            int TotalCount = 0; int MatchedCount = 0; int UnMatchedCount = 0;
                            foreach (DataRow dr in dttemp.Rows)
                            {
                                if (dr["Date"].ToString() != "")
                                {
                                    dr["Date"] = DateTime.Parse(dr["Date"].ToString(), System.Globalization.CultureInfo.InvariantCulture).ToString("d");
                                }
                                if (dr["NumberOfDocumentsCount"].ToString() != "")
                                {
                                    TotalCount += Convert.ToInt32((String)dr["NumberOfDocumentsCount"].ToString());
                                }
                                if (dr["NumberOfMatchedDocumentsCount"].ToString() != "")
                                {
                                    MatchedCount += Convert.ToInt32((String)dr["NumberOfMatchedDocumentsCount"].ToString());
                                }
                                if (dr["NumberOfUnMatchedDocumentsCount"].ToString() != "")
                                {
                                    UnMatchedCount += Convert.ToInt32((String)dr["NumberOfUnMatchedDocumentsCount"].ToString());
                                }
                            }
                            int index = dttemp.Rows.Count;
                            DataRow Footer = dttemp.NewRow();


                            //Footer["File_Name"] = "Total Count";
                            Footer["Sr.no"] = "Total Count";
                            Footer["NumberOfDocumentsCount"] = TotalCount;
                            Footer["NumberOfMatchedDocumentsCount"] = MatchedCount;
                            Footer["NumberOfUnMatchedDocumentsCount"] = UnMatchedCount;

                            dttemp.Rows.Add(Footer);

                            dgvDocuments.DataSource = dttemp;

                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.Font = new System.Drawing.Font(dgvDocuments.Font, FontStyle.Bold);
                            dgvDocuments.Rows[index].DefaultCellStyle = style;

                            foreach (DataGridViewColumn column in dgvDocuments.Columns)
                            {
                                //column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                                
                        }
                    }
                    else if (dsgetNumberOfDocumentResultsdetails.resultDS.Tables[1].Rows.Count > 0)
                    {
                        int i = 0;
                        foreach (DataRow drManual in dsgetNumberOfDocumentResultsdetails.resultDS.Tables[1].Rows)
                        {
                            DataRow drtemp = dttemp.NewRow();
                            drtemp["Sr.no"] = (i + 1).ToString();
                            drtemp["Date"] = Convert.ToDateTime(drManual["Date"]).ToString("yyyy-MM-dd").ToString();
                            drtemp["NumberOfDocumentsCount"] = Convert.ToInt32(drManual["NumberOfManualDocumentsCount"]);

                            drtemp["NumberOfMatchedDocumentsCount"] = 0;
                            drtemp["NumberOfUnMatchedDocumentsCount"] = 0;


                            dttemp.Rows.Add(drtemp);

                            i++;

                        }

                        int TotalCount = 0; int MatchedCount = 0; int UnMatchedCount = 0;
                        foreach (DataRow dr in dttemp.Rows)
                        {
                            if (dr["Date"].ToString() != "")
                            {
                                dr["Date"] = DateTime.Parse(dr["Date"].ToString(), System.Globalization.CultureInfo.InvariantCulture).ToString("d");
                            }
                            if (dr["NumberOfDocumentsCount"].ToString() != "")
                            {
                                TotalCount += Convert.ToInt32((String)dr["NumberOfDocumentsCount"].ToString());
                            }
                            if (dr["NumberOfMatchedDocumentsCount"].ToString() != "")
                            {
                                MatchedCount += Convert.ToInt32((String)dr["NumberOfMatchedDocumentsCount"].ToString());
                            }
                            if (dr["NumberOfUnMatchedDocumentsCount"].ToString() != "")
                            {
                                UnMatchedCount += Convert.ToInt32((String)dr["NumberOfUnMatchedDocumentsCount"].ToString());
                            }
                        }
                        int index = dttemp.Rows.Count;
                        DataRow Footer = dttemp.NewRow();


                        //Footer["File_Name"] = "Total Count";
                        Footer["Sr.no"] = "Total Count";
                        Footer["NumberOfDocumentsCount"] = TotalCount;
                        Footer["NumberOfMatchedDocumentsCount"] = MatchedCount;
                        Footer["NumberOfUnMatchedDocumentsCount"] = UnMatchedCount;

                        dttemp.Rows.Add(Footer);

                        dgvDocuments.DataSource = dttemp;

                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.Font = new System.Drawing.Font(dgvDocuments.Font, FontStyle.Bold);
                        dgvDocuments.Rows[index].DefaultCellStyle = style;

                        foreach (DataGridViewColumn column in dgvDocuments.Columns)
                        {
                            //column.SortMode = DataGridViewColumnSortMode.NotSortable;
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }
                    else
                    {
                        pnlError.Visible = true;
                        pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                        pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                        lblErrorMsg.Text = "No results found, try a new search.";
                        lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                        dgvDocuments.DataSource = null;
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Error While retriving data from GetDocumentCountDetailsUsingDate SP");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetDocumentScannedResults();
            ShowPrintButtons();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            dgvDocuments.DataSource = null;
            pnlError.Visible = false;
            ShowPrintButtons();
        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
                MyPrintDocument.Print();
        }

        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            MyPrintDocument.DocumentName = "Summary by Status Report";
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Do you want the report to be centered on the page", "InvoiceManager - Center on Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MyDataGridViewPrinter = new DataGridViewPrinter(dgvDocuments, MyPrintDocument, true, true, "Summary by Status Report", new System.Drawing.Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            else
                MyDataGridViewPrinter = new DataGridViewPrinter(dgvDocuments, MyPrintDocument, true, true, "Summary by Status Report", new System.Drawing.Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void dgvDocuments_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                e.Handled = true;
                using (Brush b = new SolidBrush(dgvDocuments.DefaultCellStyle.BackColor))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }
                using (Pen p = new Pen(Brushes.LightGray))
                {
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                    e.Graphics.DrawLine(p, new Point(0, e.CellBounds.Bottom - 1), new Point(e.CellBounds.Right-2, e.CellBounds.Bottom - 1));
                }
                e.PaintContent(e.ClipBounds);
            }
        }

        private void pnlError_Paint(object sender, PaintEventArgs e)
        {
            if (pnlError.BorderStyle == BorderStyle.None)
            {
                int thickness = 1;//it's up to you
                int halfThickness = thickness / 2;
                using (Pen p = new Pen(System.Drawing.ColorTranslator.FromHtml("#e64c4a"), thickness))
                {
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(halfThickness,
                                                              halfThickness,
                                                              pnlError.ClientSize.Width - thickness,
                                                              pnlError.ClientSize.Height - thickness));
                }
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            pnlError.Visible = false;
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            pnlError.Visible = false;
        }

        private void dgvDocuments_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                dgvDocuments.Cursor = Cursors.Hand;
            }
            else
                dgvDocuments.Cursor = Cursors.Default;
        }
    }
}
