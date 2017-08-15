using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Business.Manager;
using Common;
 
namespace DocSort_CPA.Forms
{
    public partial class Log_History : Form
    {
        public Log_History()
        {
            InitializeComponent();
        }

        private void Log_History_Load(object sender, EventArgs e)
        {
            // Checking Useraccesspermissions based on Role
            GetPermissiondetails(12);
            // End

            this.ControlBox = false;
            //this.Location = new Point(71, 120);

            dtpLogDate.CalendarForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            cmbType.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            this.Location = new Point((Devicewidth - this.ClientSize.Width) / 2, 104);
            cmbType.Text = "-Select Type-";

            dgvLogHistory.AutoGenerateColumns = false;
            dgvLogHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLogHistory.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            this.dgvLogHistory.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11.00F);

            DataGridViewColumn clnLogID = new DataGridViewTextBoxColumn();
            clnLogID.DataPropertyName = "Log_ID";
            clnLogID.Name = "Sr No.";
            dgvLogHistory.Columns.Add(clnLogID);
            clnLogID.Visible = false;

            DataGridViewColumn clnLogDateTime = new DataGridViewTextBoxColumn();
            clnLogDateTime.DataPropertyName = "log_datetme";
            clnLogDateTime.Name = "Activity Date";
            dgvLogHistory.Columns.Add(clnLogDateTime);
            clnLogDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            clnLogDateTime.Width = 220;

            DataGridViewColumn clnLoggedUser = new DataGridViewTextBoxColumn();
            clnLoggedUser.DataPropertyName = "loggedIn_user";
            clnLoggedUser.Name = "User Name";
            dgvLogHistory.Columns.Add(clnLoggedUser);
            clnLoggedUser.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            clnLoggedUser.Width = 150;

            DataGridViewColumn clnDescription = new DataGridViewTextBoxColumn();
            clnDescription.DataPropertyName = "Description";
            clnDescription.Name = "Activity";
            dgvLogHistory.Columns.Add(clnDescription);

            GetLogHistoryDetails();
        }

        public void GetPermissiondetails(int FormID)
        {
            UserManager objUserManager = new UserManager();
            DocSortResult dsuserPermission = new DocSortResult();
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


        public void GetLogHistoryDetails()
        {
            try
            {
                Log_History_Manager objLogHistory = new Log_History_Manager();
                DocSortResult dsgethistorydetails = objLogHistory.GetLogHistoryDetails();
                if (!dsgethistorydetails.HasError && dsgethistorydetails.resultDS.Tables[0].Rows.Count > 0)
                {
                    dgvLogHistory.DataSource = dsgethistorydetails.resultDS.Tables[0];
                }
                else
                {
                    dgvLogHistory.DataSource = null;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error While retriving data from GetLogHistoryDetails SP");
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            if (dtpLogDate.Value != null && cmbType.Text != "-Select Type-" && cmbType.Text != string.Empty)
            {
                try
                {
                    Log_History_Manager objLogHistory = new Log_History_Manager();
                    DocSortResult dsgethistorydetailsusingDate = objLogHistory.GetLogHistoryDetailsGO(dtpLogDate.Value.ToString("dd-MM-yyyy"));
                    if (!dsgethistorydetailsusingDate.HasError && dsgethistorydetailsusingDate.resultDS.Tables[0].Rows.Count > 0)
                    {
                        if (cmbType.Text != "-Select Type-" && cmbType.Text.Length != 0)
                        {
                            DataView dv = new DataView(dsgethistorydetailsusingDate.resultDS.Tables[0]);
                            dv.RowFilter = "Type='" + cmbType.Text.ToUpper() + "'";
                            if (dv.Count > 0)
                            {
                                dgvLogHistory.DataSource = dv;
                            }
                            else
                            {
                                pnlError.Visible = true;
                                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                                lblErrorMsg.Text = "No results found, try a new search.";
                                lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                                dgvLogHistory.DataSource = null;
                            }
                        }
                        else
                        {
                            dgvLogHistory.DataSource = dsgethistorydetailsusingDate.resultDS.Tables[0];
                        }
                    }
                    else
                    {
                        pnlError.Visible = true;
                        pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                        pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                        lblErrorMsg.Text = "No results found, try a new search.";
                        lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                        dgvLogHistory.DataSource = null;
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Error While retriving data from GetLogHistoryDetailsGO SP");
                }
            }
            else if (cmbType.Text == "-Select Type-" || cmbType.Text == string.Empty)
            {
                lblErrorMsg.Visible = false;
                try
                {
                    Log_History_Manager objLogHistory = new Log_History_Manager();
                    DocSortResult dsgethistorydetailsusingDate = objLogHistory.GetLogHistoryDetailsGO(dtpLogDate.Value.ToString("dd-MM-yyyy"));
                    if (!dsgethistorydetailsusingDate.HasError && dsgethistorydetailsusingDate.resultDS.Tables[0].Rows.Count > 0)
                    {
                        dgvLogHistory.DataSource = dsgethistorydetailsusingDate.resultDS.Tables[0];
                    }
                    else
                    {
                        pnlError.Visible = true;
                        pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                        pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                        lblErrorMsg.Text = "No results found, try a new search.";
                        lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                        dgvLogHistory.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error while Retrieving Data from GetLogHistoryDetailsGO SP");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            dtpLogDate.Value = DateTime.Today;
            cmbType.Text = "-Select Type-";
            GetLogHistoryDetails();
        }

        private void dgvLogHistory_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                e.Handled = true;
                using (Brush b = new SolidBrush(dgvLogHistory.DefaultCellStyle.BackColor))
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

        private void dtpLogDate_ValueChanged(object sender, EventArgs e)
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

        private void dgvLogHistory_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                dgvLogHistory.Cursor = Cursors.Hand;
            }
            else
                dgvLogHistory.Cursor = Cursors.Default;
        }
    }
}
