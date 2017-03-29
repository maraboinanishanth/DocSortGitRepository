using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Common;
using Business.Manager;

namespace DocSort_CPA.Forms
{
    public partial class NewFileCabinet1 : Form
    {
        public NewFileCabinet1()
        {
            InitializeComponent();
        }
        public string FileCabinetID
        {
            set;
            get;
        }
        public string FileCabinetName
        {
            set;
            get;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (panel1.BorderStyle == BorderStyle.None)
            {
                int thickness = 1;//it's up to you
                int halfThickness = thickness / 2;
                using (Pen p = new Pen(Color.Teal, thickness))
                {
                    e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                              halfThickness,
                                                              panel1.ClientSize.Width - thickness,
                                                              panel1.ClientSize.Height - thickness));
                }
            }
        }
       
        private void btnOK_Click(object sender, EventArgs e)
        {
            bool status = true;
            if (txtFileCabinet.Text == String.Empty)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Cabinet name is required";
                status = false;
                txtFileCabinet.Focus();
                return;
            }
            if (!status)
            {
                MessageBox.Show("Please Enter required data");
            }
            else
            {
                try
                {
                    // Checking duplicate cabinet names

                    FileCabinetManager objFileCabinetManager = new FileCabinetManager();
                    NandanaResult result = new NandanaResult();
                    result = objFileCabinetManager.GetFileCabinets();

                    if (!result.HasError && result.resultDS.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in result.resultDS.Tables[0].Rows)
                        {
                            string CabinetName = dr["FileCabinet_Name"].ToString();

                            if (CabinetName.ToUpper() == txtFileCabinet.Text.ToUpper())
                            {
                                lblErrorMsg.Visible = true;
                                lblErrorMsg.Text = "Cabinet already exists, type a new name";
                                status = false;
                                txtFileCabinet.Focus();
                                return;
                            }

                        }
                    }

                    //end

                    //* inserting File Cabinet details in FileCabinet table *//

                    NandanaResult insertFileCabinet = objFileCabinetManager.InsertFileCabinetDetails(txtFileCabinet.Text.Trim(), "True");
                    if (insertFileCabinet.resultDS != null && insertFileCabinet.resultDS.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = insertFileCabinet.resultDS.Tables[0].Rows[0];
                        FileCabinetID = dr["CabinetID"].ToString();
                        FileCabinetName = txtFileCabinet.Text;
                    }

                    //* End  *//

                    this.Hide();

                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Error while Inserting Data from InsertFileCabinet SP");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtFileCabinet_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblErrorMsg.Visible = false;
        }
    }
}
