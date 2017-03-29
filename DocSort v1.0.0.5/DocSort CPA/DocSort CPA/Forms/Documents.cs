using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Business.Manager;
using Common;

namespace DocSort_CPA.Forms
{
    public partial class Documents : Form
    {
        public Documents()
        {
            InitializeComponent();
        }

        DataTable Dttemp = new DataTable();

        private void Documents_Load(object sender, EventArgs e)
        {
            // Checking Useraccesspermissions based on Role
            GetPermissiondetails(5);
            // End

            this.ControlBox = false;

            txtDocumentName.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //this.Location = new Point(67, 173);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            this.Location = new Point(((Devicewidth-3) - this.ClientSize.Width) / 2, 139);

            //BindCategories();

            Dttemp.Columns.Clear();

            Dttemp.Columns.Add("Date", typeof(String));
            Dttemp.Columns.Add("Keyword_ID", typeof(int));
            Dttemp.Columns.Add("Keyword", typeof(String));
            Dttemp.Columns.Add("Document_ID", typeof(int));
            Dttemp.Columns.Add("File_Name", typeof(String));
            Dttemp.Columns.Add("File_Path", typeof(String));
            Dttemp.Columns.Add("ProcessType", typeof(String));

            GetDocumentDetails();

            txtDocumentName.GotFocus += new EventHandler(this.SearchTextGotFocus);
            txtDocumentName.LostFocus += new EventHandler(this.SearchTextLostFocus);
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

        public void SearchTextGotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Document Name")
            {
                tb.Text = "";
                tb.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            }
        }

        public void SearchTextLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Document Name";
                tb.ForeColor = Color.Gray;

            }
        }

        public static DataTable GetComboBoxedDataTable(DataTable oldDataTable, string valueColumn, string textColumn, string topRowValue, string topRowText)
        {
            DataTable newDataTable = new DataTable();
            newDataTable.Columns.Add(valueColumn);
            newDataTable.Columns.Add(textColumn);

            foreach (DataRow oldDR in oldDataTable.Rows)
            {
                DataRow newDR = newDataTable.NewRow();
                newDR[0] = oldDR[valueColumn].ToString();
                newDR[1] = oldDR[textColumn].ToString();
                newDataTable.Rows.InsertAt(newDR, newDataTable.Rows.Count);
            }

            // Add your 'Select an item' option at the top
            DataRow dr = newDataTable.NewRow();
            dr[0] = topRowValue;
            dr[1] = topRowText;
            newDataTable.Rows.InsertAt(dr, 0);

            return newDataTable;
        }

        //public void BindCategories()
        //{
        //    try
        //    {
        //        CategoryManager objCategoryManager = new CategoryManager();
        //        NandanaResult dsCategorydetails = objCategoryManager.GetCategoryDetails();
        //        if (dsCategorydetails.resultDS != null && dsCategorydetails.resultDS.Tables[0].Rows.Count > 0)
        //        {
        //            // cmbCategoryName.Items.Clear();
        //            cmbCategoryName.DisplayMember = "Category_Name";
        //            cmbCategoryName.ValueMember = "Category_ID";
        //            cmbCategoryName.DataSource = GetComboBoxedDataTable(dsCategorydetails.resultDS.Tables[0], "Category_ID", "Category_Name", "0", "-Select Category-");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error While retriving data from Category table");
        //    }
        //}

        public void GetDocumentDetails()
        {
            dgvDocuments.Columns.Clear();
            dgvDocuments.AutoGenerateColumns = false;
            dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDocuments.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            this.dgvDocuments.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11.00F);



            DataGridViewColumn clnDocumentID = new DataGridViewTextBoxColumn();
            clnDocumentID.DataPropertyName = "Document_ID";
            clnDocumentID.Name = "Document_ID";
            dgvDocuments.Columns.Add(clnDocumentID);
            clnDocumentID.Visible = false;

            DataGridViewLinkColumn clnDocumentName = new DataGridViewLinkColumn();
            clnDocumentName.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            clnDocumentName.LinkColor = Color.Blue;
            clnDocumentName.DataPropertyName = "File_Name";
            clnDocumentName.Name = "Document Name";
            dgvDocuments.Columns.Add(clnDocumentName);
            dgvDocuments.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dgvDocuments.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            DataGridViewColumn clnDocumentPath = new DataGridViewTextBoxColumn();
            clnDocumentPath.DataPropertyName = "File_Path";
            clnDocumentPath.Name = "Document Path";
            dgvDocuments.Columns.Add(clnDocumentPath);
            clnDocumentPath.Visible = false;

            DataGridViewColumn clnKeywordID = new DataGridViewTextBoxColumn();
            clnKeywordID.DataPropertyName = "Keyword_ID";
            clnKeywordID.Name = "Keyword_ID";
            dgvDocuments.Columns.Add(clnKeywordID);
            clnKeywordID.Visible = false;

            DataGridViewColumn clnKeyword = new DataGridViewTextBoxColumn();
            clnKeyword.DataPropertyName = "Keyword";
            clnKeyword.Name = "Folder";
            dgvDocuments.Columns.Add(clnKeyword);
            dgvDocuments.Columns[4].HeaderCell.SortGlyphDirection = SortOrder.None;

            //dgvDocuments.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DataGridViewColumn clnProcesstype = new DataGridViewTextBoxColumn();
            clnProcesstype.DataPropertyName = "ProcessType";
            clnProcesstype.Name = "Import By";
            dgvDocuments.Columns.Add(clnProcesstype);

            DataGridViewColumn clnDate = new DataGridViewTextBoxColumn();
            clnDate.DataPropertyName = "Date";
            clnDate.Name = "Date";
            dgvDocuments.Columns.Add(clnDate);
            dgvDocuments.Columns[5].HeaderCell.SortGlyphDirection = SortOrder.None;


            try
            {

                ShowDocumentsManager objShowDocumentsManager = new ShowDocumentsManager();
                NandanaResult dsgetScannedDocumentResultsdetails = objShowDocumentsManager.ShowScannedDocuments();
                if (dsgetScannedDocumentResultsdetails.resultDS != null && dsgetScannedDocumentResultsdetails.resultDS.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsgetScannedDocumentResultsdetails.resultDS.Tables[0].Rows)
                    {
                        if (dr["Date"].ToString() != "")
                        {
                            dr["Date"] = DateTime.Parse(dr["Date"].ToString(), System.Globalization.CultureInfo.InvariantCulture).ToString();
                        }
                    }

                    dgvDocuments.DataSource = dsgetScannedDocumentResultsdetails.resultDS.Tables[0];
                }
                else
                {
                    //pnlError.Visible = true;
                    //pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                    //pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                    //lblErrorMsg.Text = "No records to display";
                    //lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                    dgvDocuments.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error While retriving data from ScannedDocumentresuls table");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool status = true;
            if (txtDocumentName.Text == String.Empty || txtDocumentName.Text == "Document Name")
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblErrorMsg.Text = "Document Name is required";
                lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                status = false;
                txtDocumentName.Focus();
                return;
            }
            if (!status)
            {
                MessageBox.Show("Please Enter required data");
            }
            else
            {

                ShowDocumentsManager objShowDocumentsManager = new ShowDocumentsManager();
                NandanaResult dsgetScannedDocumentResultsdetails = objShowDocumentsManager.ShowScannedDocuments();

                DataTable dtFinalResult = new DataTable();
                if (dsgetScannedDocumentResultsdetails.resultDS != null && dsgetScannedDocumentResultsdetails.resultDS.Tables[0].Rows.Count > 0)
                {
                    if (txtDocumentName.Text != "")
                    {
                        DataRow[] drResult = dsgetScannedDocumentResultsdetails.resultDS.Tables[0].Select("File_Name like '%" + txtDocumentName.Text.Trim() + "%'");
                        if (drResult.Count() != 0)
                        {
                            dtFinalResult = drResult.CopyToDataTable();
                        }
                    }

                    else
                    {
                        dtFinalResult = dsgetScannedDocumentResultsdetails.resultDS.Tables[0];
                    }

                    

                    if (dtFinalResult.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtFinalResult.Rows)
                        {
                            if (dr["Date"].ToString() != "")
                            {
                                dr["Date"] = DateTime.Parse(dr["Date"].ToString(), System.Globalization.CultureInfo.InvariantCulture).ToString();
                            }
                        }

                        dgvDocuments.DataSource = dtFinalResult;
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


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            GetDocumentDetails();
            pnlError.Visible = false;
            //cmbCategoryName.SelectedValue = 0;
            txtDocumentName.Text = "Document Name";
            txtDocumentName.ForeColor = Color.Gray;
            //dgvDocuments.DataSource = null;
        }

        private void dgvDocuments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocuments.RowCount > 0)
            {
                if (e.ColumnIndex == 1)
                {
                    //string DocID = string.Empty;
                    int row;
                    row = e.RowIndex;

                    string FilePath = dgvDocuments.Rows[row].Cells[2].Value.ToString();
                    //string FilePath = "C:\\Users\\kanayya\\Desktop\\Desktop Backup\\Shirisha-CPA\\0-1988153.pdf";
                    ShowDocumentPage obj = new ShowDocumentPage();
                    obj.strFileName = FilePath;
                    obj.ShowDialog();
                }

                //else
                //{
                //    MessageBox.Show("No Documents are attached");
                //}
            }
        }

        private void cmbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;
        }

        private void cmbCategoryName_MouseClick(object sender, MouseEventArgs e)
        {
            lblErrorMsg.Visible = false;
        }

        private void txtDocumentName_KeyPress(object sender, KeyPressEventArgs e)
        {
            pnlError.Visible = false;
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
