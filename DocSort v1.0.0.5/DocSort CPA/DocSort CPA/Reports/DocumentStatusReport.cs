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
    public partial class DocumentStatusReport : Form
    {
        public DocumentStatusReport()
        {
            InitializeComponent();
        }
        DataGridViewPrinter MyDataGridViewPrinter;
        private void DocumentStatusReport_Load(object sender, EventArgs e)
        {
            // Checking Useraccesspermissions based on Role
            GetPermissiondetails(7);
            // End

            this.ControlBox = false;

            dtpEndDate.CalendarForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            dtpStartDate.CalendarForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            txtKeyword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            cmbType.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            lblStartDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            lblEndDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //this.Location = new Point(17, 173);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            this.Location = new Point(((Devicewidth-3) - this.ClientSize.Width) / 2, 139);

            //this.ControlBox = false;
            rbtnByDate.Checked = true;
            cmbType.Text = "-Choose a Status-";
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

        public void GetDocumentScannedResults()
        {
            bool status = true;

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
            if (!status)
            {
                MessageBox.Show("Please enter required data");
            }
            else
            {
                dgvDocuments.Columns.Clear();
                dgvDocuments.AutoGenerateColumns = false;
                dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDocuments.BorderStyle = BorderStyle.None;
                dgvDocuments.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
                this.dgvDocuments.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11.00F);

                DataGridViewColumn clnSrNo = new DataGridViewTextBoxColumn();
                clnSrNo.DataPropertyName = "Sr.no";
                clnSrNo.Name = "S.No";
                dgvDocuments.Columns.Add(clnSrNo);
                clnSrNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnSrNo.Width = 80;

                DataGridViewColumn clnKeyword = new DataGridViewTextBoxColumn();
                clnKeyword.DataPropertyName = "Keyword";
                clnKeyword.Name = "Parent Folder";
                dgvDocuments.Columns.Add(clnKeyword);

                DataGridViewColumn clnFile_Name = new DataGridViewTextBoxColumn();
                clnFile_Name.DataPropertyName = "File_Name";
                clnFile_Name.Name = "Document Name";
                dgvDocuments.Columns.Add(clnFile_Name);

                DataGridViewColumn clnMatch = new DataGridViewTextBoxColumn();
                clnMatch.DataPropertyName = "Match";
                clnMatch.Name = "Status";
                dgvDocuments.Columns.Add(clnMatch);

                DataGridViewColumn clnProcesstype = new DataGridViewTextBoxColumn();
                clnProcesstype.DataPropertyName = "ProcessType";
                clnProcesstype.Name = "Import By";
                dgvDocuments.Columns.Add(clnProcesstype);

                DataGridViewColumn clnDate = new DataGridViewTextBoxColumn();
                clnDate.DataPropertyName = "Date";
                clnDate.Name = "Date";
                dgvDocuments.Columns.Add(clnDate);

                

                DataTable dttemp = new DataTable();
                dttemp.Columns.Add("Sr.no", typeof(int));
                dttemp.Columns.Add("Date", typeof(String));
                dttemp.Columns.Add("Keyword", typeof(String));
                dttemp.Columns.Add("File_Name", typeof(String));
                dttemp.Columns.Add("Match", typeof(String));
                dttemp.Columns.Add("ProcessType", typeof(String));

                try
                {
                    DocumentStatusReportManager objDocumentStatusReportManager = new DocumentStatusReportManager();
                    NandanaResult dsgetScannedDocumentResultsdetails = objDocumentStatusReportManager.GetDocumentStatusReportUsingDate(dtpStartDate.Value.ToString("yyyy-MM-dd"), dtpEndDate.Value.ToString("yyyy-MM-dd"));

                    DataTable dtFinalResult = new DataTable();
                    if (dsgetScannedDocumentResultsdetails.resultDS != null && dsgetScannedDocumentResultsdetails.resultDS.Tables[0].Rows.Count > 0)
                    {
                        if (txtKeyword.Text != "" && cmbType.Text != "-Choose a Status-")
                        {
                            if (cmbType.Text == "Matched")
                            {
                                DataRow[] drResult = dsgetScannedDocumentResultsdetails.resultDS.Tables[0].Select("Keyword like '%" + txtKeyword.Text.Trim() + "%'" + "and" + " MatchStatus = '" + "Matched" + "'");
                                if (drResult.Count() != 0)
                                {
                                    dtFinalResult = drResult.CopyToDataTable();
                                }
                            }
                            else if (cmbType.Text == "Mismatched")
                            {
                                DataRow[] drResult = dsgetScannedDocumentResultsdetails.resultDS.Tables[0].Select("Keyword like '%" + txtKeyword.Text.Trim() + "%'" + "and" + " MatchStatus = '" + "Mismatched" + "'");
                                if (drResult.Count() != 0)
                                {
                                    dtFinalResult = drResult.CopyToDataTable();
                                }
                            }
                        }
                        else if (txtKeyword.Text != "")
                        {
                            DataRow[] drResult = dsgetScannedDocumentResultsdetails.resultDS.Tables[0].Select("Keyword like '%" + txtKeyword.Text.Trim() + "%'");
                            if (drResult.Count() != 0)
                            {
                                dtFinalResult = drResult.CopyToDataTable();
                            }
                        }
                        else if (cmbType.Text != "-Choose a Status-")
                        {
                            if (cmbType.Text == "Matched")
                            {
                                DataRow[] drResult = dsgetScannedDocumentResultsdetails.resultDS.Tables[0].Select("MatchStatus = '" + "Matched" + "'");
                                if (drResult.Count() != 0)
                                {
                                    dtFinalResult = drResult.CopyToDataTable();
                                }
                            }
                            else if (cmbType.Text == "Mismatched")
                            {
                                DataRow[] drResult = dsgetScannedDocumentResultsdetails.resultDS.Tables[0].Select("MatchStatus = '" + "Mismatched" + "'");
                                if (drResult.Count() != 0)
                                {
                                    dtFinalResult = drResult.CopyToDataTable();
                                }
                            }
                        }

                        else
                        {
                            dtFinalResult = dsgetScannedDocumentResultsdetails.resultDS.Tables[0];
                        }

                        if (dtFinalResult.Rows.Count > 0)
                        {
                            int i = 0;
                            foreach (DataRow dr in dtFinalResult.Rows)
                            {
                                DataRow drtemp = dttemp.NewRow();
                                drtemp["Sr.no"] = i + 1;
                                drtemp["Date"] = DateTime.Parse(dr["Date"].ToString(), System.Globalization.CultureInfo.InvariantCulture).ToString(); //Convert.ToDateTime(dr["Date"]).ToString("yyyy-MM-dd h:mm:ss tt").ToString();
                                drtemp["Keyword"] = dr["Keyword"].ToString();
                                drtemp["File_Name"] = dr["File_Name"].ToString();
                                drtemp["Match"] = dr["MatchStatus"].ToString();
                                drtemp["ProcessType"] = dr["ProcessType"].ToString();
                                dttemp.Rows.Add(drtemp);
                                i++;
                            }

                            dgvDocuments.DataSource = dttemp;
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
                    MessageBox.Show(x.Message, "Error While retriving data from GetScannedDocumentResults SP");
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
            cmbType.Text = "-Choose a Status-";
            txtKeyword.Text = "";
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

            MyPrintDocument.DocumentName = "Documents Status Report";
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Do you want the report to be centered on the page", "InvoiceManager - Center on Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MyDataGridViewPrinter = new DataGridViewPrinter(dgvDocuments, MyPrintDocument, true, true, "Documents Status Report", new System.Drawing.Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            else
                MyDataGridViewPrinter = new DataGridViewPrinter(dgvDocuments, MyPrintDocument, true, true, "Documents Status Report", new System.Drawing.Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

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

        private void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            pnlError.Visible = false;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlError.Visible = false;
        }

        private void cmbType_MouseClick(object sender, MouseEventArgs e)
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
