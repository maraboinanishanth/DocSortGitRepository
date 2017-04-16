using System.Text;
namespace DocSort_CPA.Forms
{
    partial class DashBoardHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoardHome));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FileContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PrintToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CutFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MergeFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LaunchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LaunchwithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestrictionsFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SendtoFilesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportFilesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new TreeViewMS.TreeViewMS();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.RootNodeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExpandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CollaspeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFlatFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ExpandToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.RestrictionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFilesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFoldersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SendtoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelGridview = new System.Windows.Forms.Panel();
            this.dgvDocuments = new System.Windows.Forms.DataGridView();
            this.pnlSearch1 = new System.Windows.Forms.Panel();
            this.pnlSearch2 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PanelWebBrowser = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FileContextMenu.SuspendLayout();
            this.RootNodeContextMenu.SuspendLayout();
            this.FolderContextMenu.SuspendLayout();
            this.PanelGridview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).BeginInit();
            this.pnlSearch1.SuspendLayout();
            this.pnlSearch2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.PanelWebBrowser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // FileContextMenu
            // 
            this.FileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintToolStripMenuItem1,
            this.CutFileToolStripMenuItem,
            this.CopyFileToolStripMenuItem,
            this.DeleteFileToolStripMenuItem1,
            this.MergeFilesToolStripMenuItem,
            this.MoveToolStripMenuItem1,
            this.RenameToolStripMenuItem,
            this.LaunchToolStripMenuItem,
            this.LaunchwithToolStripMenuItem,
            this.RestrictionsFileToolStripMenuItem1,
            this.SendtoFilesToolStripMenuItem1});
            this.FileContextMenu.Name = "FileContextMenu";
            this.FileContextMenu.Size = new System.Drawing.Size(140, 246);
            // 
            // PrintToolStripMenuItem1
            // 
            this.PrintToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.print32;
            this.PrintToolStripMenuItem1.Name = "PrintToolStripMenuItem1";
            this.PrintToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.PrintToolStripMenuItem1.Text = "Print";
            this.PrintToolStripMenuItem1.Visible = false;
            // 
            // CutFileToolStripMenuItem
            // 
            this.CutFileToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.cut16;
            this.CutFileToolStripMenuItem.Name = "CutFileToolStripMenuItem";
            this.CutFileToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.CutFileToolStripMenuItem.Text = "Cut";
            this.CutFileToolStripMenuItem.Visible = false;
            // 
            // CopyFileToolStripMenuItem
            // 
            this.CopyFileToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.copy16;
            this.CopyFileToolStripMenuItem.Name = "CopyFileToolStripMenuItem";
            this.CopyFileToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.CopyFileToolStripMenuItem.Text = "Copy";
            this.CopyFileToolStripMenuItem.Visible = false;
            // 
            // DeleteFileToolStripMenuItem1
            // 
            this.DeleteFileToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.delete1;
            this.DeleteFileToolStripMenuItem1.Name = "DeleteFileToolStripMenuItem1";
            this.DeleteFileToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.DeleteFileToolStripMenuItem1.Text = "Delete";
            this.DeleteFileToolStripMenuItem1.Click += new System.EventHandler(this.DeleteFileToolStripMenuItem1_Click);
            // 
            // MergeFilesToolStripMenuItem
            // 
            this.MergeFilesToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.MergeFiles;
            this.MergeFilesToolStripMenuItem.Name = "MergeFilesToolStripMenuItem";
            this.MergeFilesToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.MergeFilesToolStripMenuItem.Text = "Merge Files";
            this.MergeFilesToolStripMenuItem.Visible = false;
            // 
            // MoveToolStripMenuItem1
            // 
            this.MoveToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.Move;
            this.MoveToolStripMenuItem1.Name = "MoveToolStripMenuItem1";
            this.MoveToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.MoveToolStripMenuItem1.Text = "Move";
            this.MoveToolStripMenuItem1.Click += new System.EventHandler(this.MoveToolStripMenuItem1_Click);
            // 
            // RenameToolStripMenuItem
            // 
            this.RenameToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.RenameFiles;
            this.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
            this.RenameToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.RenameToolStripMenuItem.Text = "Rename";
            this.RenameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItem_Click);
            // 
            // LaunchToolStripMenuItem
            // 
            this.LaunchToolStripMenuItem.Name = "LaunchToolStripMenuItem";
            this.LaunchToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.LaunchToolStripMenuItem.Text = "Launch";
            this.LaunchToolStripMenuItem.Visible = false;
            // 
            // LaunchwithToolStripMenuItem
            // 
            this.LaunchwithToolStripMenuItem.Name = "LaunchwithToolStripMenuItem";
            this.LaunchwithToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.LaunchwithToolStripMenuItem.Text = "Launch with";
            this.LaunchwithToolStripMenuItem.Visible = false;
            // 
            // RestrictionsFileToolStripMenuItem1
            // 
            this.RestrictionsFileToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.Restrictions;
            this.RestrictionsFileToolStripMenuItem1.Name = "RestrictionsFileToolStripMenuItem1";
            this.RestrictionsFileToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.RestrictionsFileToolStripMenuItem1.Text = "Restrictions";
            this.RestrictionsFileToolStripMenuItem1.Visible = false;
            // 
            // SendtoFilesToolStripMenuItem1
            // 
            this.SendtoFilesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportFilesToolStripMenuItem1});
            this.SendtoFilesToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.SendTo;
            this.SendtoFilesToolStripMenuItem1.Name = "SendtoFilesToolStripMenuItem1";
            this.SendtoFilesToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.SendtoFilesToolStripMenuItem1.Text = "Send to";
            // 
            // ExportFilesToolStripMenuItem1
            // 
            this.ExportFilesToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.Export;
            this.ExportFilesToolStripMenuItem1.Name = "ExportFilesToolStripMenuItem1";
            this.ExportFilesToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.ExportFilesToolStripMenuItem1.Text = "Export";
            this.ExportFilesToolStripMenuItem1.Click += new System.EventHandler(this.ExportFilesToolStripMenuItem1_Click);
            // 
            // MoveToolStripMenuItem
            // 
            this.MoveToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.Move;
            this.MoveToolStripMenuItem.Name = "MoveToolStripMenuItem";
            this.MoveToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.MoveToolStripMenuItem.Text = "Move";
            this.MoveToolStripMenuItem.Click += new System.EventHandler(this.MoveToolStripMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 25;
            this.treeView1.LineColor = System.Drawing.Color.Gray;
            this.treeView1.Location = new System.Drawing.Point(1, 50);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.SelectedNodes = ((System.Collections.ArrayList)(resources.GetObject("treeView1.SelectedNodes")));
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(255, 545);
            this.treeView1.TabIndex = 4;
            this.treeView1.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView_DrawNode);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "download.jpg");
            this.imageList1.Images.SetKeyName(1, "Folder.jpg");
            this.imageList1.Images.SetKeyName(2, "File.png");
            this.imageList1.Images.SetKeyName(3, "FolderIcon.png");
            this.imageList1.Images.SetKeyName(4, "JPGIcon.png");
            this.imageList1.Images.SetKeyName(5, "LockerIcon.png");
            this.imageList1.Images.SetKeyName(6, "PDFIcon.png");
            this.imageList1.Images.SetKeyName(7, "TXTIcon.png");
            // 
            // RootNodeContextMenu
            // 
            this.RootNodeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFolderToolStripMenuItem,
            this.ExpandToolStripMenuItem,
            this.CollaspeAllToolStripMenuItem,
            this.RefreshToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.importToolStripMenuItem,
            this.SendtoToolStripMenuItem});
            this.RootNodeContextMenu.Name = "contextMenuStrip1";
            this.RootNodeContextMenu.Size = new System.Drawing.Size(137, 180);
            this.RootNodeContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.RootNodeContextMenu_Opening);
            // 
            // NewFolderToolStripMenuItem
            // 
            this.NewFolderToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.NewFolder;
            this.NewFolderToolStripMenuItem.Name = "NewFolderToolStripMenuItem";
            this.NewFolderToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.NewFolderToolStripMenuItem.Text = "New Folder";
            this.NewFolderToolStripMenuItem.Click += new System.EventHandler(this.NewFolderToolStripMenuItem_Click);
            // 
            // ExpandToolStripMenuItem
            // 
            this.ExpandToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.ExpandAll;
            this.ExpandToolStripMenuItem.Name = "ExpandToolStripMenuItem";
            this.ExpandToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ExpandToolStripMenuItem.Text = "Expand";
            this.ExpandToolStripMenuItem.Click += new System.EventHandler(this.ExpandToolStripMenuItem_Click);
            // 
            // CollaspeAllToolStripMenuItem
            // 
            this.CollaspeAllToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.CollapseAll;
            this.CollaspeAllToolStripMenuItem.Name = "CollaspeAllToolStripMenuItem";
            this.CollaspeAllToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.CollaspeAllToolStripMenuItem.Text = "Collapse All";
            this.CollaspeAllToolStripMenuItem.Click += new System.EventHandler(this.CollaspeAllToolStripMenuItem_Click);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.Refresh_24;
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.RefreshToolStripMenuItem.Text = "Refresh";
            this.RefreshToolStripMenuItem.Visible = false;
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.paste32;
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.PasteToolStripMenuItem.Text = "Paste";
            this.PasteToolStripMenuItem.Visible = false;
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.delete1;
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.DeleteToolStripMenuItem.Text = "Delete";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click_1);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportFilesToolStripMenuItem,
            this.ImportFoldersToolStripMenuItem,
            this.ImportFlatFileToolStripMenuItem});
            this.importToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.Import;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // ImportFilesToolStripMenuItem
            // 
            this.ImportFilesToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.FromFolderIcon1;
            this.ImportFilesToolStripMenuItem.Name = "ImportFilesToolStripMenuItem";
            this.ImportFilesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ImportFilesToolStripMenuItem.Text = "Import Files";
            this.ImportFilesToolStripMenuItem.Click += new System.EventHandler(this.ImportFilesToolStripMenuItem_Click);
            // 
            // ImportFoldersToolStripMenuItem
            // 
            this.ImportFoldersToolStripMenuItem.Name = "ImportFoldersToolStripMenuItem";
            this.ImportFoldersToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ImportFoldersToolStripMenuItem.Text = "Import Folders";
            this.ImportFoldersToolStripMenuItem.Visible = true;
            this.ImportFoldersToolStripMenuItem.Click += new System.EventHandler(this.ImportFoldersToolStripMenuItem_Click);
            // 
            // ImportFlatFileToolStripMenuItem
            // 
            this.ImportFlatFileToolStripMenuItem.Name = "ImportFlatFileToolStripMenuItem";
            this.ImportFlatFileToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ImportFlatFileToolStripMenuItem.Text = "Import Flat File";
            this.ImportFlatFileToolStripMenuItem.Visible = false;
            // 
            // SendtoToolStripMenuItem
            // 
            this.SendtoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportToolStripMenuItem});
            this.SendtoToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.SendTo;
            this.SendtoToolStripMenuItem.Name = "SendtoToolStripMenuItem";
            this.SendtoToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.SendtoToolStripMenuItem.Text = "Send to";
            this.SendtoToolStripMenuItem.Visible = false;
            // 
            // ExportToolStripMenuItem
            // 
            this.ExportToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.Export;
            this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            this.ExportToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.ExportToolStripMenuItem.Text = "Export";
            // 
            // FolderContextMenu
            // 
            this.FolderContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFolderToolStripMenuItem1,
            this.ExpandToolStripMenuItem1,
            this.collapseToolStripMenuItem,
            this.CutToolStripMenuItem1,
            this.CopyToolStripMenuItem1,
            this.PasteToolStripMenuItem1,
            this.DeleteToolStripMenuItem1,
            this.MoveToolStripMenuItem,
            this.RenameToolStripMenuItem1,
            this.RestrictionsToolStripMenuItem1,
            this.ImportToolStripMenuItem1,
            this.SendtoToolStripMenuItem1});
            this.FolderContextMenu.Name = "contextMenuStrip2";
            this.FolderContextMenu.Size = new System.Drawing.Size(136, 268);
            // 
            // NewFolderToolStripMenuItem1
            // 
            this.NewFolderToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.NewFolder;
            this.NewFolderToolStripMenuItem1.Name = "NewFolderToolStripMenuItem1";
            this.NewFolderToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.NewFolderToolStripMenuItem1.Text = "New Folder";
            this.NewFolderToolStripMenuItem1.Click += new System.EventHandler(this.NewFolderToolStripMenuItem1_Click);
            // 
            // ExpandToolStripMenuItem1
            // 
            this.ExpandToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.ExpandAll;
            this.ExpandToolStripMenuItem1.Name = "ExpandToolStripMenuItem1";
            this.ExpandToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.ExpandToolStripMenuItem1.Text = "Expand";
            this.ExpandToolStripMenuItem1.Click += new System.EventHandler(this.ExpandToolStripMenuItem1_Click);
            // 
            // collapseToolStripMenuItem
            // 
            this.collapseToolStripMenuItem.Image = global::DocSort_CPA.Properties.Resources.CollapseAll;
            this.collapseToolStripMenuItem.Name = "collapseToolStripMenuItem";
            this.collapseToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.collapseToolStripMenuItem.Text = "Collapse";
            this.collapseToolStripMenuItem.Click += new System.EventHandler(this.collapseToolStripMenuItem_Click);
            // 
            // CutToolStripMenuItem1
            // 
            this.CutToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.cut16;
            this.CutToolStripMenuItem1.Name = "CutToolStripMenuItem1";
            this.CutToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.CutToolStripMenuItem1.Text = "Cut";
            this.CutToolStripMenuItem1.Visible = false;
            // 
            // CopyToolStripMenuItem1
            // 
            this.CopyToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.copy16;
            this.CopyToolStripMenuItem1.Name = "CopyToolStripMenuItem1";
            this.CopyToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.CopyToolStripMenuItem1.Text = "Copy";
            this.CopyToolStripMenuItem1.Visible = false;
            // 
            // PasteToolStripMenuItem1
            // 
            this.PasteToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.paste32;
            this.PasteToolStripMenuItem1.Name = "PasteToolStripMenuItem1";
            this.PasteToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.PasteToolStripMenuItem1.Text = "Paste";
            this.PasteToolStripMenuItem1.Visible = false;
            // 
            // DeleteToolStripMenuItem1
            // 
            this.DeleteToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.delete1;
            this.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1";
            this.DeleteToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.DeleteToolStripMenuItem1.Text = "Delete";
            this.DeleteToolStripMenuItem1.Click += new System.EventHandler(this.DeleteToolStripMenuItem1_Click);
            // 
            // RenameToolStripMenuItem1
            // 
            this.RenameToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.RenameFiles;
            this.RenameToolStripMenuItem1.Name = "RenameToolStripMenuItem1";
            this.RenameToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.RenameToolStripMenuItem1.Text = "Rename";
            this.RenameToolStripMenuItem1.Click += new System.EventHandler(this.RenameToolStripMenuItem1_Click);
            // 
            // RestrictionsToolStripMenuItem1
            // 
            this.RestrictionsToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.Restrictions;
            this.RestrictionsToolStripMenuItem1.Name = "RestrictionsToolStripMenuItem1";
            this.RestrictionsToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.RestrictionsToolStripMenuItem1.Text = "Restrictions";
            this.RestrictionsToolStripMenuItem1.Visible = false;
            // 
            // ImportToolStripMenuItem1
            // 
            this.ImportToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportFilesToolStripMenuItem1,
            this.ImportFoldersToolStripMenuItem1});
            this.ImportToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.Import;
            this.ImportToolStripMenuItem1.Name = "ImportToolStripMenuItem1";
            this.ImportToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.ImportToolStripMenuItem1.Text = "Import";
            // 
            // ImportFilesToolStripMenuItem1
            // 
            this.ImportFilesToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.File;
            this.ImportFilesToolStripMenuItem1.Name = "ImportFilesToolStripMenuItem1";
            this.ImportFilesToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.ImportFilesToolStripMenuItem1.Text = "Import Files";
            this.ImportFilesToolStripMenuItem1.Click += new System.EventHandler(this.ImportFilesToolStripMenuItem1_Click);
            // 
            // ImportFoldersToolStripMenuItem1
            // 
            this.ImportFoldersToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.Folder16x16;
            this.ImportFoldersToolStripMenuItem1.Name = "ImportFoldersToolStripMenuItem1";
            this.ImportFoldersToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.ImportFoldersToolStripMenuItem1.Text = "Import Folders";
            this.ImportFoldersToolStripMenuItem1.Visible = true;

            this.ImportFoldersToolStripMenuItem1.Click += new System.EventHandler(this.ImportFoldersToolStripMenuItem1_Click);
            // 
            // SendtoToolStripMenuItem1
            // 
            this.SendtoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportToolStripMenuItem1});
            this.SendtoToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.SendTo;
            this.SendtoToolStripMenuItem1.Name = "SendtoToolStripMenuItem1";
            this.SendtoToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.SendtoToolStripMenuItem1.Text = "Send to";
            this.SendtoToolStripMenuItem1.Visible = false;
            // 
            // ExportToolStripMenuItem1
            // 
            this.ExportToolStripMenuItem1.Image = global::DocSort_CPA.Properties.Resources.Export;
            this.ExportToolStripMenuItem1.Name = "ExportToolStripMenuItem1";
            this.ExportToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.ExportToolStripMenuItem1.Text = "Export";
            // 
            // PanelGridview
            // 
            this.PanelGridview.AutoScrollMargin = new System.Drawing.Size(0, 560);
            this.PanelGridview.AutoSize = true;
            this.PanelGridview.BackColor = System.Drawing.Color.White;
            this.PanelGridview.Controls.Add(this.dgvDocuments);
            this.PanelGridview.Location = new System.Drawing.Point(262, 50);
            this.PanelGridview.Name = "PanelGridview";
            this.PanelGridview.Size = new System.Drawing.Size(748, 559);
            this.PanelGridview.TabIndex = 7;
            this.PanelGridview.Visible = false;
            // 
            // dgvDocuments
            // 
            this.dgvDocuments.AllowUserToAddRows = false;
            this.dgvDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocuments.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDocuments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocuments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocuments.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDocuments.EnableHeadersVisualStyles = false;
            this.dgvDocuments.GridColor = System.Drawing.SystemColors.Menu;
            this.dgvDocuments.Location = new System.Drawing.Point(7, 6);
            this.dgvDocuments.Name = "dgvDocuments";
            this.dgvDocuments.RowHeadersVisible = false;
            this.dgvDocuments.Size = new System.Drawing.Size(693, 550);
            this.dgvDocuments.TabIndex = 534;
            this.dgvDocuments.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocuments_CellMouseEnter);
            this.dgvDocuments.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDocuments_CellPainting);
            // 
            // pnlSearch1
            // 
            this.pnlSearch1.BackColor = System.Drawing.Color.White;
            this.pnlSearch1.Controls.Add(this.pnlSearch2);
            this.pnlSearch1.Location = new System.Drawing.Point(1, 1);
            this.pnlSearch1.Name = "pnlSearch1";
            this.pnlSearch1.Size = new System.Drawing.Size(255, 61);
            this.pnlSearch1.TabIndex = 9;
            // 
            // pnlSearch2
            // 
            this.pnlSearch2.BackColor = System.Drawing.SystemColors.Menu;
            this.pnlSearch2.Controls.Add(this.txtSearch);
            this.pnlSearch2.Controls.Add(this.pictureBox2);
            this.pnlSearch2.Location = new System.Drawing.Point(10, 8);
            this.pnlSearch2.Name = "pnlSearch2";
            this.pnlSearch2.Size = new System.Drawing.Size(235, 30);
            this.pnlSearch2.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.Location = new System.Drawing.Point(31, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(198, 18);
            this.txtSearch.TabIndex = 64;
            this.txtSearch.Text = "Search";
            this.txtSearch.WordWrap = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::DocSort_CPA.Properties.Resources.SearchIcon;
            this.pictureBox2.Location = new System.Drawing.Point(8, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 63;
            this.pictureBox2.TabStop = false;
            // 
            // PanelWebBrowser
            // 
            this.PanelWebBrowser.AutoSize = true;
            this.PanelWebBrowser.BackColor = System.Drawing.Color.White;
            this.PanelWebBrowser.Controls.Add(this.webBrowser1);
            this.PanelWebBrowser.Location = new System.Drawing.Point(265, 232);
            this.PanelWebBrowser.Name = "PanelWebBrowser";
            this.PanelWebBrowser.Size = new System.Drawing.Size(742, 356);
            this.PanelWebBrowser.TabIndex = 10;
            this.PanelWebBrowser.Visible = false;
            this.PanelWebBrowser.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelWebBrowser_Paint);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.webBrowser1.Location = new System.Drawing.Point(5, 8);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(729, 337);
            this.webBrowser1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewStart1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Symbol", 11F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(499, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "Open fullscreen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(262, -112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(745, 162);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // DashBoardHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1005, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.PanelWebBrowser);
            this.Controls.Add(this.PanelGridview);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pnlSearch1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DashBoardHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashBoardHome";
            this.Load += new System.EventHandler(this.DashBoardHome_Load);
            this.FileContextMenu.ResumeLayout(false);
            this.RootNodeContextMenu.ResumeLayout(false);
            this.FolderContextMenu.ResumeLayout(false);
            this.PanelGridview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).EndInit();
            this.pnlSearch1.ResumeLayout(false);
            this.pnlSearch2.ResumeLayout(false);
            this.pnlSearch2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.PanelWebBrowser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem RestrictionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ImportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ImportFilesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ImportFoldersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SendtoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ExportToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip FileContextMenu;
        private System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CutFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MergeFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem LaunchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LaunchwithToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestrictionsFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SendtoFilesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ExportFilesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem RenameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem1;
        private TreeViewMS.TreeViewMS treeView1;
        //private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip RootNodeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem NewFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExpandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CollaspeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportFoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportFlatFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SendtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip FolderContextMenu;
        private System.Windows.Forms.ToolStripMenuItem NewFolderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ExpandToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem1;
        private System.Windows.Forms.Panel PanelGridview;
        private System.Windows.Forms.DataGridView dgvDocuments;
        private System.Windows.Forms.Panel pnlSearch1;
        private System.Windows.Forms.Panel pnlSearch2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ToolStripMenuItem collapseToolStripMenuItem;
        private System.Windows.Forms.Panel PanelWebBrowser;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;

    }
}