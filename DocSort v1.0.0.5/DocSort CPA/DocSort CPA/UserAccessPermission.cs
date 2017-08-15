using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
 
namespace DocSort_CPA
{
    public partial class UserAccessPermission : Form
    {
        public UserAccessPermission()
        {
            InitializeComponent();
        }
        private void UserAccessPermission_Load(object sender, EventArgs e)
        {
            //this.ControlBox = false;
            BindRoles();
        }


        private void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRoles.SelectedValue.ToString() != "0")
            {
                BindUsers(ddlRoles.SelectedValue.ToString());
                //BindPermissions();
            }
        }
        private void BindRoles()
        { 
            try
            {
                string dfRoles = "XMLs/Roles.xml";
                DataSet dsroles = new DataSet();
                dsroles.ReadXml(dfRoles);


                ddlRoles.DisplayMember = "Role_Name";
                ddlRoles.ValueMember = "Role_ID";
                ddlRoles.DataSource = GetComboBoxedDataTable(dsroles.Tables[0], "Role_ID", "Role_Name", "0", "--Select Role--");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error While retriving data from GetUsers");
            }
        }
        private void BindUsers(string RoleId)
        {
            try
            {
                string dfUsers = "XMLs/Users.xml";
                DataSet dsusers = new DataSet();
                dsusers.ReadXml(dfUsers);

                DataTable dtFinalResult = new DataTable();
                DataRow[] drResult = dsusers.Tables[0].Select("Role_ID = '" + RoleId + "'");
                if (drResult.Count() != 0)
                {
                    dtFinalResult = drResult.CopyToDataTable();
                }

                ddlUsers.DisplayMember = "User_Name";
                ddlUsers.ValueMember = "User_ID";
                ddlUsers.DataSource = GetComboBoxedDataTable(dtFinalResult, "User_ID", "User_Name", "0", "--Select User--");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error While retriving data from GetUsers");
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
        private void BindPermissions()
        {
            if (ddlRoles.SelectedValue != null && ddlUsers.SelectedValue != null)
            {
                string dfForms = "XMLs/Forms.xml";
                DataSet dsResult = new DataSet();
                dsResult.ReadXml(dfForms);

                string dfPermissions = "XMLs/UserAccessPermission.xml";
                DataSet dsusers = new DataSet();
                dsusers.ReadXml(dfPermissions);

                DataTable dsuserPermission = new DataTable();
                DataRow[] drResult = dsusers.Tables[0].Select("RoleID = '" + ddlRoles.SelectedValue.ToString() + "'" + "and" + " UserId = '" + ddlUsers.SelectedValue.ToString() + "'");
               
                if (drResult.Count() != 0)
                {
                    dsuserPermission = drResult.CopyToDataTable();
                }

                DataTable dtUserAccess = new DataTable();
                dtUserAccess.Columns.Add("ID", typeof(string));
                dtUserAccess.Columns.Add("FormName", typeof(string));
                dtUserAccess.Columns.Add("View", typeof(Boolean));
                dtUserAccess.Columns.Add("Add", typeof(Boolean));
                dtUserAccess.Columns.Add("Edit", typeof(Boolean));
                dtUserAccess.Columns.Add("Delete", typeof(Boolean));

                string RoleId = ddlRoles.SelectedValue.ToString();
                string UserId = ddlUsers.SelectedValue.ToString();

                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.RowHeadersVisible = false;

                DataGridViewColumn clnFormID = new DataGridViewTextBoxColumn();
                clnFormID.DataPropertyName = "ID";
                clnFormID.Name = "ID";
                dataGridView1.Columns.Add(clnFormID);
                clnFormID.Visible = false;

                DataGridViewColumn clnFormName = new DataGridViewTextBoxColumn();
                clnFormName.DataPropertyName = "FormName";
                clnFormName.Name = "FormName";
                dataGridView1.Columns.Add(clnFormName);
                clnFormName.Width = 320;

                DataGridViewCheckBoxColumn clnView = new DataGridViewCheckBoxColumn();
                clnView.DataPropertyName = "View";
                clnView.Name = "View";
                dataGridView1.Columns.Add(clnView);
                clnView.Width = 120;

                DataGridViewCheckBoxColumn ClnAdd = new DataGridViewCheckBoxColumn();
                ClnAdd.DataPropertyName = "Add";
                ClnAdd.Name = "Add";
                dataGridView1.Columns.Add(ClnAdd);
                ClnAdd.Width = 120;

                DataGridViewCheckBoxColumn clnEdit = new DataGridViewCheckBoxColumn();
                clnEdit.DataPropertyName = "Edit";
                clnEdit.Name = "Edit";
                dataGridView1.Columns.Add(clnEdit);
                clnEdit.Width = 120;

                DataGridViewCheckBoxColumn clnDelete = new DataGridViewCheckBoxColumn();
                clnDelete.DataPropertyName = "Delete";
                clnDelete.Name = "Delete";
                dataGridView1.Columns.Add(clnDelete);
                clnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnDelete.Width = 120;

                //dsuserPermission = objUserManager.GetUserPermissions(ddlRoles.SelectedValue.ToString(), ddlUsers.SelectedValue.ToString());
                if (!dsResult.HasErrors && dsResult.Tables[0].Rows.Count > 0)
                {
                    string MenuIds = string.Empty;

                    //DataRow[] drMainMenus = dsResult.Tables[0].Select("MainMenuId is NULL ");  //
                    //DataTable dtMainMenus = drMainMenus.CopyToDataTable();

                    foreach (DataRow dr in dsResult.Tables[0].Rows)
                    {
                        Boolean View = false;
                        Boolean Add = false;
                        Boolean Edit = false;
                        Boolean Delete = false;
                        DataRow[] drpermissions = dsuserPermission.Select("FormID ='" + Convert.ToString(dr["ID"]) + "'");
                        string FormName = GetMenuName(Convert.ToString(dr["ID"]));
                        if (drpermissions.Length > 0)
                        {
                            View = Convert.ToBoolean(drpermissions[0]["IsView"]);
                            Add = Convert.ToBoolean(drpermissions[0]["IsInsert"]);
                            Edit = Convert.ToBoolean(drpermissions[0]["IsEdit"]);
                            Delete = Convert.ToBoolean(drpermissions[0]["IsDelete"]);
                        }
                        dtUserAccess.Rows.Add(Convert.ToString(dr["ID"]), FormName, View, Add, Edit, Delete);
                    }
                    dataGridView1.DataSource = dtUserAccess;
                    dataGridView1.Visible = true;
                }
                else
                {
                    dataGridView1.Visible = false;

                }
            }
            else
            {
                dataGridView1.Visible = false;

            }
            
        
        }

        private string GetMenuName(string ID)
        {
            string MenuId = string.Empty;
            String MenuName = string.Empty;

            string dfForms = "XMLs/Forms.xml";
            DataSet dsforms = new DataSet();
            dsforms.ReadXml(dfForms);

            DataTable dtforms = new DataTable();
            DataRow[] drResult = dsforms.Tables[0].Select("ID = '" + ID + "'");
            if (drResult.Count() != 0)
            {
                dtforms = drResult.CopyToDataTable();
                DataRow dr = dtforms.Rows[0];
                MenuId = dr["MenuId"].ToString();
            }

            string dfMenus = "XMLs/Menus.xml";
            DataSet dsmenus = new DataSet();
            dsmenus.ReadXml(dfMenus);

            DataTable dtMainMenu = new DataTable();
            DataTable dtMenu = new DataTable();
            DataRow[] drgetmenuname = dsmenus.Tables[0].Select("MenuID = '" + MenuId + "'");

            if (drgetmenuname.Count() != 0)
            {
                dtMenu = drgetmenuname.CopyToDataTable();
                DataRow dr = dtMenu.Rows[0];
                DataRow[] drgetMainmenuname = dsmenus.Tables[0].Select("MenuID = '" + dr["MainMenuId"].ToString() + "'");
                if (drgetMainmenuname.Count() != 0)
                {
                    dtMainMenu = drgetMainmenuname.CopyToDataTable();
                    DataRow drMain = dtMainMenu.Rows[0];
                    MenuName = drMain["MenuName"].ToString() + ":" + dr["MenuName"].ToString();
                }
            }
            return MenuName;
        }

        private void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRoles.SelectedValue != "0" && ddlUsers.SelectedValue != "0")
            {
                BindPermissions();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdatePermission();
            BindPermissions();
        }
        private void UpdatePermission()
        {
            string dfUserPermissions = "XMLs/UserAccessPermission.xml";
            DataSet dsUserPermissions = new DataSet();
            dsUserPermissions.ReadXml(dfUserPermissions);

            DataTable dtuserPermission = new DataTable();
            DataRow[] drResult = dsUserPermissions.Tables[0].Select("RoleID = '" + ddlRoles.SelectedValue.ToString() + "'" + "and" + " UserId = '" + ddlUsers.SelectedValue.ToString() + "'");

            if (drResult.Count() != 0)
            {
                dtuserPermission = drResult.CopyToDataTable();
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("XMLs/UserAccessPermission.xml");
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Table/tbl_UserAccessPermission");


            int k = 0;
            int i = 0;
            foreach (DataGridViewRow gvrow in dataGridView1.Rows)
            {
                bool View = Convert.ToBoolean(gvrow.Cells[2].Value);
                bool Add = Convert.ToBoolean(gvrow.Cells[3].Value);
                bool Edit = Convert.ToBoolean(gvrow.Cells[4].Value);
                bool Delete = Convert.ToBoolean(gvrow.Cells[5].Value);
                try
                {

                    int count = 0;
                    i = k;
                    for (; i < dtuserPermission.Rows.Count;i++)
                    {
                        DataRow dr = dtuserPermission.Rows[i];
                        count = 0;
                        if (count == 0)
                        {
                            foreach (XmlNode node in nodeList)
                            {
                                if (count == 0)
                                {
                                    //if (node["RoleID"].InnerText == "1" && node["UserId"].InnerText == "1")
                                    //{
                                    if (node["ID"].InnerText == dr["ID"].ToString())
                                    {
                                        count += 1;

                                        node["RoleID"].InnerText = ddlRoles.SelectedValue.ToString();
                                        node["UserId"].InnerText = ddlUsers.SelectedValue.ToString();
                                        node["FormID"].InnerText = Convert.ToString(gvrow.Cells[0].Value);
                                        node["IsView"].InnerText = Convert.ToString(gvrow.Cells[2].Value);
                                        node["IsEdit"].InnerText = Convert.ToString(gvrow.Cells[3].Value);
                                        node["IsInsert"].InnerText = Convert.ToString(gvrow.Cells[4].Value);
                                        node["IsDelete"].InnerText = Convert.ToString(gvrow.Cells[5].Value);

                                        xmlDoc.Save("XMLs/UserAccessPermission.xml");

                                        k = i + 1;
                                        i = dtuserPermission.Rows.Count - 1;
                                    }
                                    //}
                                }
                            }
                        }
                    }
                    //UserManager objUserManager = new UserManager();
                    //dsResult = objUserManager.InsertUpdateUserAccessPermissions(ddlRoles.SelectedValue.ToString(), ddlUsers.SelectedValue.ToString(), Convert.ToString(gvrow.Cells[0].Value), Convert.ToBoolean(gvrow.Cells[2].Value), Convert.ToBoolean(gvrow.Cells[3].Value), Convert.ToBoolean(gvrow.Cells[4].Value), Convert.ToBoolean(gvrow.Cells[5].Value));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error while Deleting Data from Patient table");
                }
            }
        }
    }
}
