namespace button_tester
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menustripMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveProjectAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddNewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSimulation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRunRandom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripMain = new System.Windows.Forms.ToolStrip();
            this.tsbNewProject = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.tsbEditItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCut = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRun = new System.Windows.Forms.ToolStripButton();
            this.tsbRunRandom = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.lblCurrentValues = new System.Windows.Forms.Label();
            this.lstPriorities = new System.Windows.Forms.ListView();
            this.lblErr = new System.Windows.Forms.Label();
            this.lblCnt = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.lblBreak = new System.Windows.Forms.Label();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.lvMain = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fdSave = new System.Windows.Forms.SaveFileDialog();
            this.fdOpen = new System.Windows.Forms.OpenFileDialog();
            this.tmrUIUpdate = new System.Windows.Forms.Timer(this.components);
            this.tmrLoop = new System.Windows.Forms.Timer(this.components);
            this.tmrCountdown = new System.Windows.Forms.Timer(this.components);
            this.fdSaveLog = new System.Windows.Forms.SaveFileDialog();
            this.menustripMain.SuspendLayout();
            this.toolstripMain.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menustripMain
            // 
            this.menustripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.menustripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuSimulation,
            this.mnuHelp});
            this.menustripMain.Location = new System.Drawing.Point(0, 0);
            this.menustripMain.Name = "menustripMain";
            this.menustripMain.Size = new System.Drawing.Size(936, 24);
            this.menustripMain.TabIndex = 0;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewProject,
            this.mnuOpenProject,
            this.toolStripMenuItem3,
            this.mnuSaveProject,
            this.mnuSaveProjectAs,
            this.toolStripMenuItem2,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(35, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuNewProject
            // 
            this.mnuNewProject.Image = global::button_tester.Properties.Resources.NewDocument;
            this.mnuNewProject.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuNewProject.Name = "mnuNewProject";
            this.mnuNewProject.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.N)));
            this.mnuNewProject.Size = new System.Drawing.Size(240, 22);
            this.mnuNewProject.Text = "&New project";
            this.mnuNewProject.Click += new System.EventHandler(this.mnuNewProject_Click);
            // 
            // mnuOpenProject
            // 
            this.mnuOpenProject.Image = global::button_tester.Properties.Resources.openHS;
            this.mnuOpenProject.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuOpenProject.Name = "mnuOpenProject";
            this.mnuOpenProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpenProject.Size = new System.Drawing.Size(240, 22);
            this.mnuOpenProject.Text = "&Open project...";
            this.mnuOpenProject.Click += new System.EventHandler(this.mnuOpenProject_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(237, 6);
            // 
            // mnuSaveProject
            // 
            this.mnuSaveProject.Image = global::button_tester.Properties.Resources.Save;
            this.mnuSaveProject.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuSaveProject.Name = "mnuSaveProject";
            this.mnuSaveProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSaveProject.Size = new System.Drawing.Size(240, 22);
            this.mnuSaveProject.Text = "&Save project";
            this.mnuSaveProject.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuSaveProjectAs
            // 
            this.mnuSaveProjectAs.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuSaveProjectAs.Name = "mnuSaveProjectAs";
            this.mnuSaveProjectAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.mnuSaveProjectAs.Size = new System.Drawing.Size(240, 22);
            this.mnuSaveProjectAs.Text = "Save project &as...";
            this.mnuSaveProjectAs.Click += new System.EventHandler(this.mnuSaveProjectAs_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(237, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(240, 22);
            this.mnuExit.Text = "&Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddNewItem,
            this.mnuEditItem,
            this.toolStripMenuItem1,
            this.mnuCut,
            this.mnuCopy,
            this.mnuPaste,
            this.mnuDelete,
            this.toolStripSeparator1,
            this.mnuMoveUp,
            this.mnuMoveDown,
            this.toolStripSeparator6,
            this.mnuOptions});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(37, 20);
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuAddNewItem
            // 
            this.mnuAddNewItem.Image = global::button_tester.Properties.Resources.InsertPage;
            this.mnuAddNewItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuAddNewItem.Name = "mnuAddNewItem";
            this.mnuAddNewItem.Size = new System.Drawing.Size(181, 22);
            this.mnuAddNewItem.Text = "&Add new item...";
            this.mnuAddNewItem.Click += new System.EventHandler(this.mnuAddNew_Click);
            // 
            // mnuEditItem
            // 
            this.mnuEditItem.Image = global::button_tester.Properties.Resources.EditInformation;
            this.mnuEditItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuEditItem.Name = "mnuEditItem";
            this.mnuEditItem.Size = new System.Drawing.Size(181, 22);
            this.mnuEditItem.Text = "&Edit selected item...";
            this.mnuEditItem.Click += new System.EventHandler(this.mnuEditItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuCut
            // 
            this.mnuCut.Image = global::button_tester.Properties.Resources.CutHS;
            this.mnuCut.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuCut.Size = new System.Drawing.Size(181, 22);
            this.mnuCut.Text = "Cu&t";
            this.mnuCut.Click += new System.EventHandler(this.mnuCut_Click);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Image = global::button_tester.Properties.Resources.CopyHS;
            this.mnuCopy.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCopy.Size = new System.Drawing.Size(181, 22);
            this.mnuCopy.Text = "&Copy";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Image = global::button_tester.Properties.Resources.PasteHS;
            this.mnuPaste.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuPaste.Size = new System.Drawing.Size(181, 22);
            this.mnuPaste.Text = "&Paste";
            this.mnuPaste.Click += new System.EventHandler(this.mnuPaste_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::button_tester.Properties.Resources.DeleteHS;
            this.mnuDelete.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(181, 22);
            this.mnuDelete.Text = "&Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuMoveUp
            // 
            this.mnuMoveUp.Image = global::button_tester.Properties.Resources.FillUpHS;
            this.mnuMoveUp.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuMoveUp.Name = "mnuMoveUp";
            this.mnuMoveUp.Size = new System.Drawing.Size(181, 22);
            this.mnuMoveUp.Text = "Move &up";
            this.mnuMoveUp.Click += new System.EventHandler(this.mnuMoveUp_Click);
            // 
            // mnuMoveDown
            // 
            this.mnuMoveDown.Image = global::button_tester.Properties.Resources.FillDownHS;
            this.mnuMoveDown.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuMoveDown.Name = "mnuMoveDown";
            this.mnuMoveDown.Size = new System.Drawing.Size(181, 22);
            this.mnuMoveDown.Text = "Move &down";
            this.mnuMoveDown.Click += new System.EventHandler(this.mnuMoveDown_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuOptions
            // 
            this.mnuOptions.Image = global::button_tester.Properties.Resources.OptionsHS;
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(181, 22);
            this.mnuOptions.Text = "&Options";
            this.mnuOptions.Click += new System.EventHandler(this.mnuOptions_Click);
            // 
            // mnuSimulation
            // 
            this.mnuSimulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRun,
            this.mnuRunRandom,
            this.mnuStop});
            this.mnuSimulation.Name = "mnuSimulation";
            this.mnuSimulation.Size = new System.Drawing.Size(67, 20);
            this.mnuSimulation.Text = "&Simulation";
            // 
            // mnuRun
            // 
            this.mnuRun.Image = global::button_tester.Properties.Resources.FormRunHS;
            this.mnuRun.Name = "mnuRun";
            this.mnuRun.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuRun.Size = new System.Drawing.Size(170, 22);
            this.mnuRun.Text = "&Start";
            this.mnuRun.Click += new System.EventHandler(this.mnuRun_Click);
            // 
            // mnuRunRandom
            // 
            this.mnuRunRandom.Image = global::button_tester.Properties.Resources.FormRunHS_red;
            this.mnuRunRandom.Name = "mnuRunRandom";
            this.mnuRunRandom.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuRunRandom.Size = new System.Drawing.Size(170, 22);
            this.mnuRunRandom.Text = "&Start Random";
            this.mnuRunRandom.Click += new System.EventHandler(this.mnuRunRandom_Click);
            // 
            // mnuStop
            // 
            this.mnuStop.Enabled = false;
            this.mnuStop.Image = global::button_tester.Properties.Resources.StopHS;
            this.mnuStop.Name = "mnuStop";
            this.mnuStop.Size = new System.Drawing.Size(170, 22);
            this.mnuStop.Text = "S&top";
            this.mnuStop.Click += new System.EventHandler(this.mnuStop_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(40, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Image = global::button_tester.Properties.Resources.Help;
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(114, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // toolstripMain
            // 
            this.toolstripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolstripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewProject,
            this.tsbOpen,
            this.tsbSave,
            this.toolStripSeparator4,
            this.tsbAddNewItem,
            this.tsbEditItem,
            this.toolStripSeparator5,
            this.tsbMoveUp,
            this.tsbMoveDown,
            this.toolStripSeparator,
            this.tsbOptions,
            this.toolStripSeparator7,
            this.tsbCut,
            this.tsbCopy,
            this.tsbPaste,
            this.toolStripSeparator3,
            this.tsbRun,
            this.tsbRunRandom,
            this.tsbStop,
            this.toolStripSeparator2,
            this.helpToolStripButton});
            this.toolstripMain.Location = new System.Drawing.Point(0, 24);
            this.toolstripMain.Name = "toolstripMain";
            this.toolstripMain.Size = new System.Drawing.Size(936, 25);
            this.toolstripMain.Stretch = true;
            this.toolstripMain.TabIndex = 1;
            this.toolstripMain.Text = "toolStrip1";
            // 
            // tsbNewProject
            // 
            this.tsbNewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewProject.Image = global::button_tester.Properties.Resources.NewDocument;
            this.tsbNewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewProject.Name = "tsbNewProject";
            this.tsbNewProject.Size = new System.Drawing.Size(23, 22);
            this.tsbNewProject.Text = "&New";
            this.tsbNewProject.Click += new System.EventHandler(this.tsbNewProject_Click);
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Text = "&Open";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "&Save";
            this.tsbSave.Click += new System.EventHandler(this.tlbSave_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAddNewItem
            // 
            this.tsbAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddNewItem.Image = global::button_tester.Properties.Resources.InsertPage;
            this.tsbAddNewItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddNewItem.Name = "tsbAddNewItem";
            this.tsbAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.tsbAddNewItem.Text = "Insert new item";
            this.tsbAddNewItem.Click += new System.EventHandler(this.tsbAddNewItem_Click);
            // 
            // tsbEditItem
            // 
            this.tsbEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditItem.Image = global::button_tester.Properties.Resources.EditInformation;
            this.tsbEditItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditItem.Name = "tsbEditItem";
            this.tsbEditItem.Size = new System.Drawing.Size(23, 22);
            this.tsbEditItem.Text = "Edit the selected item";
            this.tsbEditItem.Click += new System.EventHandler(this.tsbEditItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbMoveUp
            // 
            this.tsbMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveUp.Image = global::button_tester.Properties.Resources.FillUpHS;
            this.tsbMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveUp.Name = "tsbMoveUp";
            this.tsbMoveUp.Size = new System.Drawing.Size(23, 22);
            this.tsbMoveUp.Text = "Move up";
            this.tsbMoveUp.Click += new System.EventHandler(this.tsbMoveUp_Click);
            // 
            // tsbMoveDown
            // 
            this.tsbMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveDown.Image = global::button_tester.Properties.Resources.FillDownHS;
            this.tsbMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveDown.Name = "tsbMoveDown";
            this.tsbMoveDown.Size = new System.Drawing.Size(23, 22);
            this.tsbMoveDown.Text = "Move down";
            this.tsbMoveDown.Click += new System.EventHandler(this.tsbMoveDown_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbOptions
            // 
            this.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOptions.Image = global::button_tester.Properties.Resources.OptionsHS;
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(23, 22);
            this.tsbOptions.Text = "Options";
            this.tsbOptions.Click += new System.EventHandler(this.tsbOptions_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCut
            // 
            this.tsbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCut.Image = ((System.Drawing.Image)(resources.GetObject("tsbCut.Image")));
            this.tsbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCut.Name = "tsbCut";
            this.tsbCut.Size = new System.Drawing.Size(23, 22);
            this.tsbCut.Text = "C&ut";
            this.tsbCut.Click += new System.EventHandler(this.tsbCut_Click);
            // 
            // tsbCopy
            // 
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(23, 22);
            this.tsbCopy.Text = "&Copy";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // tsbPaste
            // 
            this.tsbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsbPaste.Image")));
            this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Size = new System.Drawing.Size(23, 22);
            this.tsbPaste.Text = "&Paste";
            this.tsbPaste.Click += new System.EventHandler(this.tsbPaste_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRun
            // 
            this.tsbRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRun.Image = global::button_tester.Properties.Resources.FormRunHS;
            this.tsbRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRun.Name = "tsbRun";
            this.tsbRun.Size = new System.Drawing.Size(23, 22);
            this.tsbRun.Text = "Run";
            this.tsbRun.Click += new System.EventHandler(this.tsbRun_Click);
            // 
            // tsbRunRandom
            // 
            this.tsbRunRandom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRunRandom.Image = global::button_tester.Properties.Resources.FormRunHS_red;
            this.tsbRunRandom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRunRandom.Name = "tsbRunRandom";
            this.tsbRunRandom.Size = new System.Drawing.Size(23, 22);
            this.tsbRunRandom.Text = "Start with a random order";
            this.tsbRunRandom.Click += new System.EventHandler(this.tsbRunRandom_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStop.Enabled = false;
            this.tsbStop.Image = global::button_tester.Properties.Resources.StopHS;
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(23, 22);
            this.tsbStop.Text = "Stop";
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.AutoScroll = true;
            this.toolStripContainer2.ContentPanel.Controls.Add(this.lblCurrentValues);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.lstPriorities);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.lblErr);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.lblCnt);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.lblDirection);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.lblBreak);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.lblCountdown);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.lvMain);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(936, 460);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(936, 509);
            this.toolStripContainer2.TabIndex = 5;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.menustripMain);
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolstripMain);
            // 
            // lblCurrentValues
            // 
            this.lblCurrentValues.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentValues.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentValues.Location = new System.Drawing.Point(117, 308);
            this.lblCurrentValues.Name = "lblCurrentValues";
            this.lblCurrentValues.Size = new System.Drawing.Size(103, 149);
            this.lblCurrentValues.TabIndex = 9;
            this.lblCurrentValues.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrentValues.UseMnemonic = false;
            // 
            // lstPriorities
            // 
            this.lstPriorities.FullRowSelect = true;
            this.lstPriorities.Location = new System.Drawing.Point(0, 308);
            this.lstPriorities.MultiSelect = false;
            this.lstPriorities.Name = "lstPriorities";
            this.lstPriorities.Size = new System.Drawing.Size(116, 152);
            this.lstPriorities.TabIndex = 8;
            this.lstPriorities.UseCompatibleStateImageBehavior = false;
            this.lstPriorities.View = System.Windows.Forms.View.List;
            // 
            // lblErr
            // 
            this.lblErr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblErr.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(767, 383);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(169, 75);
            this.lblErr.TabIndex = 7;
            this.lblErr.Text = "Err:";
            this.lblErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblErr.UseMnemonic = false;
            // 
            // lblCnt
            // 
            this.lblCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCnt.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCnt.Location = new System.Drawing.Point(767, 308);
            this.lblCnt.Name = "lblCnt";
            this.lblCnt.Size = new System.Drawing.Size(169, 75);
            this.lblCnt.TabIndex = 6;
            this.lblCnt.Text = "Cnt:";
            this.lblCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCnt.UseMnemonic = false;
            // 
            // lblDirection
            // 
            this.lblDirection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDirection.Font = new System.Drawing.Font("Arial Black", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirection.Location = new System.Drawing.Point(701, 308);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(64, 149);
            this.lblDirection.TabIndex = 5;
            this.lblDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDirection.UseMnemonic = false;
            // 
            // lblBreak
            // 
            this.lblBreak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBreak.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreak.ForeColor = System.Drawing.Color.Green;
            this.lblBreak.Location = new System.Drawing.Point(220, 400);
            this.lblBreak.Name = "lblBreak";
            this.lblBreak.Size = new System.Drawing.Size(481, 57);
            this.lblBreak.TabIndex = 4;
            this.lblBreak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBreak.UseMnemonic = false;
            // 
            // lblCountdown
            // 
            this.lblCountdown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCountdown.Font = new System.Drawing.Font("Arial Black", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountdown.Location = new System.Drawing.Point(220, 308);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(481, 92);
            this.lblCountdown.TabIndex = 3;
            this.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCountdown.UseMnemonic = false;
            // 
            // lvMain
            // 
            this.lvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMain.FullRowSelect = true;
            this.lvMain.GridLines = true;
            this.lvMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvMain.HideSelection = false;
            this.lvMain.Location = new System.Drawing.Point(0, 0);
            this.lvMain.MultiSelect = false;
            this.lvMain.Name = "lvMain";
            this.lvMain.Size = new System.Drawing.Size(933, 305);
            this.lvMain.TabIndex = 0;
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.View = System.Windows.Forms.View.Details;
            this.lvMain.DoubleClick += new System.EventHandler(this.lvMain_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 35;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Details";
            this.columnHeader3.Width = 620;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Chosen";
            this.columnHeader4.Width = 150;
            // 
            // fdSave
            // 
            this.fdSave.Filter = "Button Tester Project Files|*.btprj|All files|*.*";
            // 
            // fdOpen
            // 
            this.fdOpen.Filter = "Button Tester Project Files|*.btprj|All files|*.*";
            // 
            // tmrUIUpdate
            // 
            this.tmrUIUpdate.Enabled = true;
            this.tmrUIUpdate.Interval = 500;
            this.tmrUIUpdate.Tick += new System.EventHandler(this.tmrUIUpdate_Tick);
            // 
            // tmrLoop
            // 
            this.tmrLoop.Tick += new System.EventHandler(this.tmrLoop_Tick);
            // 
            // tmrCountdown
            // 
            this.tmrCountdown.Tick += new System.EventHandler(this.tmrCountdown_Tick);
            // 
            // fdSaveLog
            // 
            this.fdSaveLog.Filter = "CSV Files|*.csv|All files|*.*";
            this.fdSaveLog.OverwritePrompt = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 509);
            this.Controls.Add(this.toolStripContainer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menustripMain;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Button tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menustripMain.ResumeLayout(false);
            this.menustripMain.PerformLayout();
            this.toolstripMain.ResumeLayout(false);
            this.toolstripMain.PerformLayout();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menustripMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveUp;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddNewItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEditItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNewProject;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenProject;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveProject;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveProjectAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuSimulation;
        private System.Windows.Forms.ToolStripMenuItem mnuRunRandom;
        private System.Windows.Forms.ToolStripMenuItem mnuStop;
        private System.Windows.Forms.ToolStrip toolstripMain;
        private System.Windows.Forms.ToolStripButton tsbNewProject;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton tsbCut;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbRun;
        private System.Windows.Forms.ToolStripButton tsbStop;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.SaveFileDialog fdSave;
        private System.Windows.Forms.OpenFileDialog fdOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbAddNewItem;
        private System.Windows.Forms.ToolStripButton tsbEditItem;
        private System.Windows.Forms.Timer tmrUIUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbMoveUp;
        private System.Windows.Forms.ToolStripButton tsbMoveDown;
        private System.Windows.Forms.Timer tmrLoop;
        private System.Windows.Forms.ListView lvMain;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Timer tmrCountdown;
        private System.Windows.Forms.ToolStripButton tsbRunRandom;
        private System.Windows.Forms.ToolStripMenuItem mnuRun;
        private System.Windows.Forms.Label lblBreak;
        private System.Windows.Forms.SaveFileDialog fdSaveLog;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions;
        private System.Windows.Forms.ToolStripButton tsbOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Label lblCnt;
        private System.Windows.Forms.ListView lstPriorities;
        private System.Windows.Forms.Label lblCurrentValues;
    }
}

