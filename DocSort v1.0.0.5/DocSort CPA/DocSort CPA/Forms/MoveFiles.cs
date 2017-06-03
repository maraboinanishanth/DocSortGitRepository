using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DocSort_CPA.Forms
{
    public partial class MoveFiles : Form
    {
        DashBoardHome DBHome = new DashBoardHome();

        public string GetCabinet 
        {
            get
            {
                if (listBox1.SelectedItem != null)
                    return listBox1.SelectedItem.ToString();
                else
                    return null;
            }
        }

        public string GetFolder
        {
            get
            {
                if (listBox2.SelectedItem != null)
                    return listBox2.SelectedItem.ToString();
                else
                    return null;
            }
        }
    
        public MoveFiles()
        {
            InitializeComponent();

            //List<string> Cabinets  = DashBoardHome.GetFileCabinets() ;

            //foreach(var itm in Cabinets)
            //    listBox1.Items.Add(itm);

            LoadCabinets();            
        }

        private void LoadCabinets()
        {
            DataTable DtCabinets = DBHome.GetFileCabinets();

            DataRow[] drResult = DtCabinets.Select("FileCabinet_ID <> '" + 1 + "'" + "and" + " IsDelete = '" + "True" + "'");

            if (drResult.Count() != 0)
            {
                //listBox1.Items.Add("ROOT");

                DataTable dtfilecabinets = drResult.CopyToDataTable();

                DataView dv = dtfilecabinets.DefaultView;
                dv.Sort = "FileCabinet_Name asc";
                DataTable sortedDT = dv.ToTable();
                //END

                foreach (DataRow dr in sortedDT.Rows)
                {
                    listBox1.Items.Add(dr["FileCabinet_Name"].ToString().ToUpper());
                    //MessageBox.Show(string.Format("You selected: {0}", n.Text)); 
                }
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(string.Format("You selected: {0}", listBox1.SelectedItem));
            listBox2.Items.Clear();

            DataTable DtCabinets = DBHome.GetFileCabinets();

            DataRow[] drResult = DtCabinets.Select("FileCabinet_ID <> '" + 1 + "'" + "and" + " IsDelete = '" + "True" + "'");
            if (drResult.Count() != 0)
            {
                DataTable  dtfilecabinets = drResult.CopyToDataTable();

                DataView dv = dtfilecabinets.DefaultView;
                dv.Sort = "FileCabinet_Name asc";
                DataTable sortedDT = dv.ToTable();

                
               
                foreach (DataRow dr in sortedDT.Rows)
                {
                    if (listBox1.SelectedItem == "ROOT")  
                    {
                        GetMainFoldersBasedonCabinet("1", "0");
                        break;
                    }
                    else if (dr["FileCabinet_Name"].ToString().ToUpper().Equals(listBox1.SelectedItem))
                    {
                        GetMainFoldersBasedonCabinet(dr["FileCabinet_ID"].ToString(), "0");
                        break;
                    }
                }

            }
             
        }

        private void listBox2_Click(object sender, EventArgs e)
        {

        }

        private void GetMainFoldersBasedonCabinet(string strRootNodeID, string ParentFolderID)
        {
            try
            {
                DataTable DtMainFolders = new DataTable();

                DataTable DtFolders = DBHome.GetFolders();

                if (DtFolders != null)
                {
                    if (DtFolders.Rows.Count > 0)
                    {
                        DataRow[] drResult = DtFolders.Select("FileCabinet_ID = '" + strRootNodeID + "'" + "and" + " ParentFolderID = '" + ParentFolderID + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            DtMainFolders = drResult.CopyToDataTable();
                        }

                        if (DtMainFolders.HasErrors != true && DtMainFolders.Rows.Count > 0)
                        { 
                            foreach (DataRow dr in DtMainFolders.Rows)
                            {
                                listBox2.Items.Add(dr["Folder_Name"].ToString());
                            }

                            listBox2.Sorted = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
	

        private void button1_Click(object sender, EventArgs e)
        {   
            DialogResult = DialogResult.OK;

            //MessageBox.Show(string.Format("You selected: {0}", listBox1.SelectedItem));
            //MessageBox.Show(string.Format("You selected: {0}", listBox2.SelectedItem));
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
