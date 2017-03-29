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
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml;

namespace DocSort_CPA.Reports
{
    public partial class TotalDocumentsReport : Form
    {
        public TotalDocumentsReport()
        {
            InitializeComponent();
        }

        DataGridViewPrinter MyDataGridViewPrinter;
        private void TotalDocumentsReport_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            dtpStartDate.CalendarForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            dtpEndDate.CalendarForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            lblStartDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            lblEndDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //this.Location = new Point(67, 173);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            this.Location = new Point(((Devicewidth-3) - this.ClientSize.Width) / 2, 139);

            rbtnByDate.Checked = true;

            ShowPrintButtons();
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
                lblErrorMsg.Text = "Start Date is greater than today(s) date";
                lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                status = false;
                dtpStartDate.Focus();
                return;
            }
            if (Convert.ToDateTime(dtpEndDate.Value.ToString("yyyy-MM-dd")) > DateTime.Today)
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblErrorMsg.Text = "End Date is greater than today(s) date";
                lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                status = false;
                dtpEndDate.Focus();
                return;
            }
            if (Convert.ToDateTime(dtpStartDate.Value.ToString("yyyy-MM-dd")) > Convert.ToDateTime(dtpEndDate.Value.ToString("yyyy-MM-dd")))
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblErrorMsg.Text = "Start Date is greater than End Date";
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
                dgvDocuments.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
                this.dgvDocuments.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11.00F);

                //DataGridViewColumn clnSrNo = new DataGridViewTextBoxColumn();
                //clnSrNo.DataPropertyName = "Sr.no";
                //clnSrNo.Name = "Sr No.";
                //dgvDocuments.Columns.Add(clnSrNo);
                //clnSrNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //clnSrNo.Width = 70;

                DataGridViewColumn clnDate = new DataGridViewTextBoxColumn();
                clnDate.DataPropertyName = "Date";
                clnDate.Name = "Date";
                dgvDocuments.Columns.Add(clnDate);
                //clnDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //clnDate.Width = 150;

                DataGridViewColumn clnKeyword = new DataGridViewTextBoxColumn();
                clnKeyword.DataPropertyName = "Keyword";
                clnKeyword.Name = "Keyword";
                dgvDocuments.Columns.Add(clnKeyword);
                //clnKeyword.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //clnKeyword.Width = 150;


                DataGridViewColumn clnSubSection = new DataGridViewTextBoxColumn();
                clnSubSection.DataPropertyName = "SubSection";
                clnSubSection.Name = "SubSection";
                dgvDocuments.Columns.Add(clnSubSection);
                //clnSubSection.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //clnSubSection.Width = 150;


                //DataGridViewColumn clnFile_Name = new DataGridViewTextBoxColumn();
                //clnFile_Name.DataPropertyName = "File_Name";
                //clnFile_Name.Name = "File Name";
                //dgvDocuments.Columns.Add(clnFile_Name);

                //dgvDocuments.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //dgvDocuments.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;


                DataGridViewColumn clnNoofCount = new DataGridViewTextBoxColumn();
                clnNoofCount.DataPropertyName = "No Of Count";
                clnNoofCount.Name = "No Of Count";
                dgvDocuments.Columns.Add(clnNoofCount);
                //clnNoofCount.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //clnNoofCount.Width = 100;
                //this.dgvDocuments.Columns["No Of Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //DataGridViewColumn clnMatch = new DataGridViewTextBoxColumn();
                //clnMatch.DataPropertyName = "Match";
                //clnMatch.Name = "Match";
                //dgvDocuments.Columns.Add(clnMatch);

                DataTable dttemp = new DataTable();
                //dttemp.Columns.Add("Sr.no", typeof(int));
                dttemp.Columns.Add("Date", typeof(String));
                dttemp.Columns.Add("Keyword", typeof(String));
                dttemp.Columns.Add("SubSection", typeof(String));
                //dttemp.Columns.Add("File_Name", typeof(String));
                dttemp.Columns.Add("No Of Count", typeof(String));
                //dttemp.Columns.Add("Match", typeof(String));

                try
                {
                //XmlDocument xmlKeywordDoc = new XmlDocument();
                //xmlKeywordDoc.Load("XMLs/Keywords.xml");
                //XmlNodeList KeywordnodeList = xmlKeywordDoc.DocumentElement.SelectNodes("/Table/tbl_Keywords");
                   
                //List<String> Keywordlist= new List<String>();
                //foreach (XmlNode node in KeywordnodeList)
                //{
                //    Keywordlist.Add(node.Name);
                //}

                //XmlDocument xmlScannedDoc = new XmlDocument();
                //xmlScannedDoc.Load("XMLs/ScannedDocumentResults.xml");
                //XmlNodeList ScannednodeList = xmlKeywordDoc.DocumentElement.SelectNodes("/Table/tbl_ScannedDocumentResults");

                //List<String> Scannedlist = new List<String>();
                //foreach (XmlNode node in ScannednodeList)
                //{
                //    Scannedlist.Add(node.Name);
                //}

                //var query2 = from Scanned in Scannedlist
                //             join Keyword in Keywordlist on Scanned.ElementAt(2) equals Keyword.ElementAt(0)
                //             where (DateTime.Parse(Convert.ToDateTime(Scanned.ElementAt(1)).ToString("yyyy-MM-dd")) >= DateTime.Parse(dtpStartDate.Value.ToString("yyyy-MM-dd")) && DateTime.Parse(Convert.ToDateTime(Scanned.ElementAt(1)).ToString("yyyy-MM-dd")) <= DateTime.Parse(dtpEndDate.Value.ToString("yyyy-MM-dd")))
                //             group Total by DateTime.Parse(Convert.ToDateTime(Scanned.ElementAt(1)).ToString("yyyy-MM-dd")) && Keyword.ElementAt(2) && Keyword.ElementAt(3) into f
                              
                //             select new { OwnerName = person.FirstName, PetName = pet.Name };

                    //XElement Keyword = XElement.Load("XMLs/Keywords.xml");
                    //XElement ScannedDoc = XElement.Load("XMLs/ScannedDocumentResults.xml");
                    //var joinQuery = from r in ScannedDoc.Descendants("tbl_ScannedDocumentResults")
                    //                join s in Keyword.Descendants("tbl_Keywords") on (int)r.Attribute("Keyword_ID") equals (int)s.Attribute("ID") into ScannedKeyword
                    //                where (DateTime.Parse(Convert.ToDateTime((string)r.Attribute("Date")).ToString("yyyy-MM-dd")) >= DateTime.Parse(dtpStartDate.Value.ToString("yyyy-MM-dd")) && DateTime.Parse(Convert.ToDateTime((string)r.Attribute("Date")).ToString("yyyy-MM-dd")) <= DateTime.Parse(dtpEndDate.Value.ToString("yyyy-MM-dd")))
                    //                group ScannedKeyword by DateTime.Parse(Convert.ToDateTime((string)r.Attribute("Date")).ToString("yyyy-MM-dd")) && (string)ScannedKeyword.Attributes("Keyword") && (string)s.Attribute("Subsection");
                    //                                  select new
                    //{
                    //    Date = ScannedKeyword.Attributes("Date"),
                    //    NoofCount =
                    //      (ScannedKeyword.Attributes("ID")).Count(),
                    //    Keyword =
                    //      (ScannedKeyword.Attributes("Keyword")),
                    //    SubSection = 
                    //    (ScannedKeyword.Attributes("Subsection"))
                    //};


                //string dfScanned = "XMLs/ScannedDocumentResults.xml";
                //DataSet dsScanned = new DataSet();
                //dsScanned.ReadXml(dfScanned);

                //DataTable dtScanned = new DataTable();
                //dtScanned = dsScanned.Tables[0];

                    //string dfKeyword = "XMLs/Keywords.xml";
                    //DataSet dsKeyword = new DataSet();
                    //dsKeyword.ReadXml(dfKeyword);


                //var q = (from pd in Scannedlist
                         
                //         select new
                //         {
                //             pd
                //         });

                    //var q = (from pd in Scannedlist
                    //         join od in Keywordlist on pd.ElementAt(2) equals od.ElementAt(0) into t
                    //         from rt in t
                    //         where (DateTime.Parse(Convert.ToDateTime(pd.ElementAt(1)).ToString("yyyy-MM-dd")) >= DateTime.Parse(dtpStartDate.Value.ToString("yyyy-MM-dd")) && DateTime.Parse(Convert.ToDateTime(pd.ElementAt(1)).ToString("yyyy-MM-dd")) <= DateTime.Parse(dtpEndDate.Value.ToString("yyyy-MM-dd")))
                    //         group rt by t.ElementAt(0) into total
                    //         select new
                    //         {
                    //             total
                    //         });

                    //var resultingTable = from t1 in dtScannedDocs.AsEnumerable()
                    //                     join t2 in dtKeywords.AsEnumerable()
                    //                         on t1.Field<int>("Keyword_ID") equals t2.Field<int>("ID")

                    //                     select new { t1, t2 };
                    //DataTable newDataTable = new DataTable();
                    //// Now with the results of the query fill in the columns of the new DataTable
                    //foreach (var dr in q)
                    //{
                    //    DataRow newRow = newDataTable.NewRow();
                    //    // Now fill the row with the value from the query t1
                    //   //newRow["ColumnName1"] = dr.t1.Field<DataType of Column>("ColumnName1");
                    //    // ... Continue with all the columns from t1 in the same way

                    //    // Now fill the row with the value from the query t2
                    //    // In the same way as above

                    //    // When all columns have been filled in then add the row to the table
                    //    newDataTable.Rows.Add(newRow);
                    //} 

                    //DataTable dtScannedDocs = new DataTable();

                    //string dfScanned = "XMLs/ScannedDocumentResults.xml";
                    //DataSet dsScanned = new DataSet();
                    //dsScanned.ReadXml(dfScanned);
                    //dtScannedDocs=(dsScanned.Tables[0]);

                    //DataTable dtKeywords = new DataTable();

                    //string dfKeyword = "XMLs/Keywords.xml";
                    //DataSet dsKeyword = new DataSet();
                    //dsKeyword.ReadXml(dfKeyword);
                    //dtKeywords=(dsKeyword.Tables[0]);
                    //var resultingTable = from t1 in dtScannedDocs.AsEnumerable()
                    // join t2 in dtKeywords.AsEnumerable() 
                    //     on t1.Field<int>("Keyword_ID") equals t2.Field<int>("ID")

                    // select new { t1, t2 };

                    //var resultingTable = from t1 in dtScannedDocs.AsEnumerable()
                    //                     join t2 in dtKeywords.AsEnumerable()
                    //                         on t1.Field<int>("Keyword_ID") equals t2.Field<int>("ID")
                    //                     where (DateTime.Parse(Convert.ToDateTime(t1.Field<String>("Date")).ToString("yyyy-MM-dd")) >= DateTime.Parse(dtpStartDate.Value.ToString("yyyy-MM-dd")) && DateTime.Parse(Convert.ToDateTime(t1.Field<String>("Date")).ToString("yyyy-MM-dd")) <= DateTime.Parse(dtpEndDate.Value.ToString("yyyy-MM-dd")))

                    //                     select new { t1, t2 };


                    //// Now with the results of the query fill in the columns of the new DataTable
                    //foreach (var dr in resultingTable)
                    //{
                    //    DataRow newRow = dttemp.NewRow();
                    //    // Now fill the row with the value from the query t1
                    //    // newRow["Date"] = dr.t1.Field<int>("ID");
                    //    newRow["Date"] = dr.t1.Field<String>("Date");
                    //    newRow["Keyword"] = dr.t2.Field<String>("Keyword");
                    //    newRow["SubSection"] = dr.t2.Field<String>("SubSection");

                    //    dttemp.Rows.Add(newRow);
                    //}
                    //DataTable dtFinalResult1 = new DataTable();
                    //dtFinalResult1.Columns.Add("Date", typeof(String));
                    //dtFinalResult1.Columns.Add("Keyword", typeof(String));
                    //dtFinalResult1.Columns.Add("SubSection", typeof(String));
                    //dtFinalResult1.Columns.Add("No Of Count", typeof(String));

                    //foreach (DataRow dr in dttemp.Rows)
                    //{
                    //    string[] selectedColumns = new[] { "Keyword", "SubSection" };

                    //    DataTable dt = new DataView(dttemp).ToTable(false, selectedColumns);

                    //    DataTable dt1 = new DataView(dtFinalResult1).ToTable(false, selectedColumns);
                    //    string keyword = dr["Keyword"].ToString();
                    //    string subsection = dr["SubSection"].ToString();
                    //    DataRow[] strcount = dttemp.Select("Keyword = '" + keyword + "'" + "and" + " SubSection = '" + subsection + "'");
                    //    DataRow[] strduplicate = dtFinalResult1.Select("Keyword = '" + keyword + "'" + "and" + " SubSection = '" + subsection + "'");
                    //    if (strduplicate.Count() == 0)
                    //    {
                    //        DataRow newRow = dtFinalResult1.NewRow();
                    //        // Now fill the row with the value from the query t1
                    //        // newRow["Date"] = dr.t1.Field<int>("ID");
                    //        newRow["Date"] = dr["Date"].ToString();
                    //        newRow["Keyword"] = dr["Keyword"].ToString();
                    //        newRow["SubSection"] = dr["SubSection"].ToString();
                    //        newRow["No Of Count"] = strcount.Count();
                    //        dtFinalResult1.Rows.Add(newRow);
                    //    }
                    //}

                    //dgvDocuments.DataSource = dtFinalResult1;

                    //MoveMyFilesManager objMoveMyFilesManager = new MoveMyFilesManager();
                    //NandanaResult dsgetScannedDocumentResultsdetails = objMoveMyFilesManager.GetTotalScannedDocumentCountResultsUsingDate(dtpStartDate.Value.ToString("yyyy-MM-dd"), dtpEndDate.Value.ToString("yyyy-MM-dd"));

                    //DataTable dtFinal = new DataTable();
                    //DataTable dtFinalResult = new DataTable();
                    //if (dsgetScannedDocumentResultsdetails.resultDS != null && dsgetScannedDocumentResultsdetails.resultDS.Tables[0].Rows.Count > 0)
                    //{
                    //    dtFinal = dsgetScannedDocumentResultsdetails.resultDS.Tables[0];
                    //    //dtFinalResult = dsgetScannedDocumentResultsdetails.resultDS.Tables[1];

                    //    if (dtFinal.Rows.Count > 0)
                    //    {
                    //        int count = dtFinal.Rows.Count;

                    //        for (int i = 0; i < count; i++)
                    //        {

                    //            DataRow drtemp = dttemp.NewRow();
                    //            //drtemp["Sr.no"] = i + 1;
                    //            drtemp["Date"] = Convert.ToDateTime(dtFinal.Rows[i]["Date"]).ToString("dd-MM-yyyy").ToString();
                    //            //drtemp["Date"] = Convert.ToDateTime(dtFinal.Rows[i]["Date"]).ToString("dd-MM-yyyy h:mm:ss tt").ToString();
                    //            drtemp["Keyword"] = dtFinal.Rows[i]["Keyword"].ToString();
                    //            drtemp["SubSection"] = dtFinal.Rows[i]["SubSection"].ToString();
                    //            //drtemp["File_Name"] = filename;
                    //            drtemp["No Of Count"] = dtFinal.Rows[i]["DocsCount"].ToString();
                    //            //drtemp["Match"] = dr["Match"].ToString();

                    //            dttemp.Rows.Add(drtemp);

                    //            //string Search = dtFinal.Rows[i]["Keyword"].ToString();
                    //            //string SubSection = dtFinal.Rows[i]["SubSection"].ToString();

                    //            //if (dtFinal.Rows[i]["Keyword"].ToString() != "")
                    //            //{
                    //            //    DataRow[] drKeyResult = dtFinalResult.Select("Keyword like '" + Regex.Replace(dtFinal.Rows[i]["Keyword"].ToString(), @"[_[]+", "") + "'");

                    //            //    if (drKeyResult.Count() > 0)
                    //            //    {
                    //            //        int subcount = 0;
                    //            //        DataTable dtkeyFinal1 = drKeyResult.CopyToDataTable();
                    //            //        for (int j = 0; j < dtkeyFinal1.Rows.Count; j++)
                    //            //        {
                    //            //            if (dtkeyFinal1.Rows[j]["SubSection"].ToString() != "")
                    //            //            {
                    //            //                if (dtFinal.Rows[i]["SubSection"].ToString() == dtkeyFinal1.Rows[j]["SubSection"].ToString())
                    //            //                {
                    //            //                    subcount += 1;
                    //            //                    if (subcount == 1)
                    //            //                    {
                    //            //                        DataRow[] drResult = dtkeyFinal1.Select("SubSection like '" + Regex.Replace(dtkeyFinal1.Rows[j]["SubSection"].ToString(), @"[_[]+", "") + "'");

                    //            //                        if (drResult.Count() > 0)
                    //            //                        {
                    //            //                            DataTable dtFinal1 = drResult.CopyToDataTable();
                    //            //                            string filename = string.Empty;

                    //            //                            for (int k = 0; k < dtFinal1.Rows.Count; k++)
                    //            //                            {
                    //            //                                filename = filename + dtFinal1.Rows[k]["File_Name"].ToString() + ",";

                    //            //                            }
                    //            //                            filename = filename.Substring(0, filename.Length - 1);

                    //            //                            DataRow drtemp = dttemp.NewRow();
                    //            //                            //drtemp["Sr.no"] = i + 1;
                    //            //                            drtemp["Date"] = Convert.ToDateTime(dtFinal.Rows[i]["Date"]).ToString("dd-MM-yyyy").ToString();
                    //            //                            //drtemp["Date"] = Convert.ToDateTime(dtFinal.Rows[i]["Date"]).ToString("dd-MM-yyyy h:mm:ss tt").ToString();
                    //            //                            drtemp["Keyword"] = dtFinal.Rows[i]["Keyword"].ToString();
                    //            //                            drtemp["SubSection"] = dtFinal.Rows[i]["SubSection"].ToString();
                    //            //                            drtemp["File_Name"] = filename;
                    //            //                            drtemp["No Of Count"] = dtFinal.Rows[i]["DocsCount"].ToString();
                    //            //                            //drtemp["Match"] = dr["Match"].ToString();

                    //            //                            dttemp.Rows.Add(drtemp);
                    //            //                        }
                    //            //                    }
                    //            //                }
                    //            //            }
                    //            //            else
                    //            //            {
                    //            //                DataRow drtemp = dttemp.NewRow();
                    //            //                //drtemp["Sr.no"] = i + 1;
                    //            //                drtemp["Date"] = Convert.ToDateTime(dtFinal.Rows[i]["Date"]).ToString("dd-MM-yyyy").ToString();
                    //            //                //drtemp["Date"] = Convert.ToDateTime(dtFinal.Rows[i]["Date"]).ToString("dd-MM-yyyy h:mm:ss tt").ToString();
                    //            //                drtemp["Keyword"] = dtFinal.Rows[i]["Keyword"].ToString();
                    //            //                drtemp["SubSection"] = dtFinal.Rows[i]["SubSection"].ToString();
                    //            //                drtemp["File_Name"] = dtkeyFinal1.Rows[j]["File_Name"].ToString();
                    //            //                drtemp["No Of Count"] = dtFinal.Rows[i]["DocsCount"].ToString();
                    //            //                //drtemp["Match"] = dr["Match"].ToString();

                    //            //                dttemp.Rows.Add(drtemp);
                    //            //            }
                    //            //        }
                    //            //        //if (dtFinal.Rows[i]["SubSection"].ToString() != "")
                    //            //        //{
                    //            //        //    DataRow[] drResult = dtFinalResult.Select("SubSection like '" + Regex.Replace(dtFinal.Rows[i]["SubSection"].ToString(), @"[_[]+", "") + "'");

                    //            //        //    if (drResult.Count() > 0)
                    //            //        //    {
                    //            //        //        DataTable dtFinal1 = drResult.CopyToDataTable();
                    //            //        //        string filename = string.Empty;

                    //            //        //        for (int j = 0; j < dtFinal1.Rows.Count; j++)
                    //            //        //        {
                    //            //        //            filename = filename + dtFinal1.Rows[j]["File_Name"].ToString() + ",";

                    //            //        //        }
                    //            //        //        filename = filename.Substring(0, filename.Length - 1);

                    //            //        //        DataRow drtemp = dttemp.NewRow();
                    //            //        //        //drtemp["Sr.no"] = i + 1;
                    //            //        //        drtemp["Date"] = Convert.ToDateTime(dtFinal.Rows[i]["Date"]).ToString("dd-MM-yyyy").ToString();
                    //            //        //        //drtemp["Date"] = Convert.ToDateTime(dtFinal.Rows[i]["Date"]).ToString("dd-MM-yyyy h:mm:ss tt").ToString();
                    //            //        //        drtemp["Keyword"] = dtFinal.Rows[i]["Keyword"].ToString();
                    //            //        //        drtemp["SubSection"] = dtFinal.Rows[i]["SubSection"].ToString();
                    //            //        //        drtemp["File_Name"] = filename;
                    //            //        //        drtemp["No Of Count"] = dtFinal.Rows[i]["DocsCount"].ToString();
                    //            //        //        //drtemp["Match"] = dr["Match"].ToString();

                    //            //        //        dttemp.Rows.Add(drtemp);
                    //            //        //    }
                    //            //        //else
                    //            //        //{
                    //            //        //    DataRow drtemp = dttemp.NewRow();
                    //            //        //    //drtemp["Sr.no"] = i + 1;
                    //            //        //    drtemp["Date"] = Convert.ToDateTime(dtFinal.Rows[i]["Date"]).ToString("dd-MM-yyyy h:mm:ss tt").ToString();
                    //            //        //    drtemp["Keyword"] = dtFinal.Rows[i]["Keyword"].ToString();
                    //            //        //    drtemp["SubSection"] = dtFinal.Rows[i]["SubSection"].ToString();
                    //            //        //    drtemp["File_Name"] = dtFinalResult.Rows[i]["File_Name"].ToString();
                    //            //        //    drtemp["No Of Count"] = dtFinal.Rows[i]["DocsCount"].ToString();
                    //            //        //    //drtemp["Match"] = dr["Match"].ToString();

                    //            //        //    dttemp.Rows.Add(drtemp);
                    //            //        //}
                    //            //    }
                    //            //}
                    //        }
                    //    }

                    //    int TotalCount = 0;
                    //    foreach (DataRow dr in dttemp.Rows)
                    //    {
                    //        if (dr["No Of Count"].ToString() != "")
                    //        {
                    //            TotalCount += Convert.ToInt32((String)dr["No Of Count"].ToString());
                    //        }
                    //    }
                    //    int index = dttemp.Rows.Count;
                    //    DataRow Footer = dttemp.NewRow();


                    //    //Footer["File_Name"] = "Total Count";
                    //    Footer["SubSection"] = "Total Count";
                    //    Footer["No Of Count"] = TotalCount;

                    //    dttemp.Rows.Add(Footer);

                    //    dgvDocuments.DataSource = dttemp;

                    //    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    //    style.Font = new System.Drawing.Font(dgvDocuments.Font, FontStyle.Bold);
                    //    dgvDocuments.Rows[index].DefaultCellStyle = style;

                    //    foreach (DataGridViewColumn column in dgvDocuments.Columns)
                    //    {
                    //        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    //        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //    }

                    //    //dgvDocuments.DataSource = dttemp;
                    //    //}

                    //}
                    //else
                    //{
                    //    dgvDocuments.DataSource = null;
                    //}

                    if (File.Exists("XMLs/ScannedDocumentResults.xml") && File.Exists("XMLs/Keywords.xml"))
                    {
                        DataTable dtScannedDocs = new DataTable();
                        dtScannedDocs.Columns.Add("ID", typeof(int));
                        dtScannedDocs.Columns.Add("Date", typeof(String));
                        dtScannedDocs.Columns.Add("Keyword_ID", typeof(int));
                        dtScannedDocs.Columns.Add("Document_ID", typeof(int));
                        dtScannedDocs.Columns.Add("Document_Path", typeof(String));
                        dtScannedDocs.Columns.Add("Match", typeof(string));

                        DataTable dtKeywords = new DataTable();
                        dtKeywords.Columns.Add("ID", typeof(int));
                        //dtKeywords.Columns.Add("Date", typeof(String));
                        dtKeywords.Columns.Add("Keyword", typeof(String));
                        dtKeywords.Columns.Add("SubSection", typeof(String));
                        dtKeywords.Columns.Add("StartWith", typeof(String));
                        dtKeywords.Columns.Add("EndWith", typeof(String));

                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load("XMLs/ScannedDocumentResults.xml");
                        XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Table/tbl_ScannedDocumentResults");

                        XmlDocument KeyxmlDoc = new XmlDocument();
                        KeyxmlDoc.Load("XMLs/Keywords.xml");
                        XmlNodeList KeynodeList = KeyxmlDoc.DocumentElement.SelectNodes("/Table/tbl_Keywords");

                        foreach (XmlNode node in nodeList)
                        {
                            DataRow drtemp = dtScannedDocs.NewRow();
                            drtemp["ID"] = node["ID"].InnerText;
                            drtemp["Date"] = node["Date"].InnerText;
                            drtemp["Keyword_ID"] = node["Keyword_ID"].InnerText;
                            drtemp["Document_ID"] = node["Document_ID"].InnerText;
                            drtemp["Document_Path"] = node["Document_Path"].InnerText;
                            drtemp["Match"] = node["Match"].InnerText;

                            dtScannedDocs.Rows.Add(drtemp);

                        }

                        foreach (XmlNode node in KeynodeList)
                        {
                            DataRow drtemp = dtKeywords.NewRow();
                            drtemp["ID"] = node["ID"].InnerText;
                            //drtemp["Date"] = node["Date"].InnerText;
                            drtemp["Keyword"] = node["Keyword"].InnerText;
                            drtemp["SubSection"] = node["SubSection"].InnerText;
                            drtemp["StartWith"] = node["StartWith"].InnerText;
                            drtemp["EndWith"] = node["EndWith"].InnerText;

                            dtKeywords.Rows.Add(drtemp);

                        }

                        var resultingTable = from t1 in dtScannedDocs.AsEnumerable()
                                             join t2 in dtKeywords.AsEnumerable()
                                                 on t1.Field<int>("Keyword_ID") equals t2.Field<int>("ID")
                                             where (DateTime.Parse(Convert.ToDateTime(t1.Field<String>("Date")).ToString("yyyy-MM-dd")) >= DateTime.Parse(dtpStartDate.Value.ToString("yyyy-MM-dd")) && DateTime.Parse(Convert.ToDateTime(t1.Field<String>("Date")).ToString("yyyy-MM-dd")) <= DateTime.Parse(dtpEndDate.Value.ToString("yyyy-MM-dd")))
                                             select new { t1, t2 };


                        // Now with the results of the query fill in the columns of the new DataTable
                        foreach (var dr in resultingTable)
                        {
                            DataRow newRow = dttemp.NewRow();
                            // Now fill the row with the value from the query t1
                            // newRow["Date"] = dr.t1.Field<int>("ID");
                            newRow["Date"] = dr.t1.Field<String>("Date");
                            newRow["Keyword"] = dr.t2.Field<String>("Keyword");
                            newRow["SubSection"] = dr.t2.Field<String>("SubSection");

                            dttemp.Rows.Add(newRow);
                        }
                        DataTable dtFinalResult1 = new DataTable();
                        dtFinalResult1.Columns.Add("Date", typeof(String));
                        dtFinalResult1.Columns.Add("Keyword", typeof(String));
                        dtFinalResult1.Columns.Add("SubSection", typeof(String));
                        dtFinalResult1.Columns.Add("No Of Count", typeof(String));

                        foreach (DataRow dr in dttemp.Rows)
                        {
                            string[] selectedColumns = new[] { "Keyword", "SubSection" };

                            DataTable dt = new DataView(dttemp).ToTable(false, selectedColumns);

                            DataTable dt1 = new DataView(dtFinalResult1).ToTable(false, selectedColumns);
                            string keyword = dr["Keyword"].ToString();
                            string subsection = dr["SubSection"].ToString();
                            DataRow[] strcount = dttemp.Select("Keyword = '" + keyword + "'" + "and" + " SubSection = '" + subsection + "'");
                            DataRow[] strduplicate = dtFinalResult1.Select("Keyword = '" + keyword + "'" + "and" + " SubSection = '" + subsection + "'");
                            if (strduplicate.Count() == 0)
                            {
                                DataRow newRow = dtFinalResult1.NewRow();
                                // Now fill the row with the value from the query t1
                                // newRow["Date"] = dr.t1.Field<int>("ID");
                                newRow["Date"] = Convert.ToDateTime(dr["Date"]).ToString("dd-MM-yyyy").ToString();
                                newRow["Keyword"] = dr["Keyword"].ToString();
                                newRow["SubSection"] = dr["SubSection"].ToString();
                                newRow["No Of Count"] = strcount.Count();
                                dtFinalResult1.Rows.Add(newRow);
                            }
                        }

                        if (dtFinalResult1.Rows.Count > 0)
                        {
                            int TotalCount = 0;
                            foreach (DataRow dr in dtFinalResult1.Rows)
                            {
                                if (dr["No Of Count"].ToString() != "")
                                {
                                    TotalCount += Convert.ToInt32((String)dr["No Of Count"].ToString());
                                }
                            }
                            int index = dtFinalResult1.Rows.Count;
                            DataRow Footer = dtFinalResult1.NewRow();


                            //Footer["File_Name"] = "Total Count";
                            Footer["SubSection"] = "Total Count";
                            Footer["No Of Count"] = TotalCount;

                            dtFinalResult1.Rows.Add(Footer);

                            dgvDocuments.DataSource = dtFinalResult1;

                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.Font = new System.Drawing.Font(dgvDocuments.Font, FontStyle.Bold);
                            dgvDocuments.Rows[index].DefaultCellStyle = style;

                            foreach (DataGridViewColumn column in dgvDocuments.Columns)
                            {
                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }

                            //dgvDocuments.DataSource = dttemp;
                            //}

                        }
                        else
                        {
                            dgvDocuments.DataSource = null;
                        }
                    }
                    else
                    {
                        dgvDocuments.DataSource = null;
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Error While retriving data from GetScannedDocumentCountResults SP");
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

        private void MyPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
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

            MyPrintDocument.DocumentName = "Documents Report";
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Do you want the report to be centered on the page", "InvoiceManager - Center on Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MyDataGridViewPrinter = new DataGridViewPrinter(dgvDocuments, MyPrintDocument, true, true, "Documents Report", new System.Drawing.Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            else
                MyDataGridViewPrinter = new DataGridViewPrinter(dgvDocuments, MyPrintDocument, true, true, "Documents Report", new System.Drawing.Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

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
                    e.Graphics.DrawLine(p, new Point(0, e.CellBounds.Bottom - 1), new Point(e.CellBounds.Right - 2, e.CellBounds.Bottom - 1));
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
    }
}
