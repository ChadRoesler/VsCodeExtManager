namespace VsCodeExtManager
{
    partial class FrmVsCodeExtManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVsCodeExtManager));
            this.lbExentionList = new System.Windows.Forms.ListBox();
            this.lblExentionList = new System.Windows.Forms.Label();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.btnInstallUpdate = new System.Windows.Forms.Button();
            this.pnlExtensionInfo = new System.Windows.Forms.Panel();
            this.lblVsCodeId = new System.Windows.Forms.Label();
            this.lblInformation = new System.Windows.Forms.Label();
            this.lblExtensionName = new System.Windows.Forms.Label();
            this.txtExtensionDescription = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReloadExtensionList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLegend = new System.Windows.Forms.Label();
            this.pnlExtensionInfo.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbExentionList
            // 
            this.lbExentionList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbExentionList.FormattingEnabled = true;
            this.lbExentionList.Location = new System.Drawing.Point(12, 38);
            this.lbExentionList.Name = "lbExentionList";
            this.lbExentionList.Size = new System.Drawing.Size(167, 290);
            this.lbExentionList.TabIndex = 1;
            this.lbExentionList.SelectedIndexChanged += new System.EventHandler(this.LbExentionList_SelectedIndexChanged);
            // 
            // lblExentionList
            // 
            this.lblExentionList.AutoSize = true;
            this.lblExentionList.Location = new System.Drawing.Point(12, 24);
            this.lblExentionList.Name = "lblExentionList";
            this.lblExentionList.Size = new System.Drawing.Size(61, 13);
            this.lblExentionList.TabIndex = 2;
            this.lblExentionList.Text = "Extensions:";
            // 
            // btnUninstall
            // 
            this.btnUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUninstall.Location = new System.Drawing.Point(347, 311);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(75, 23);
            this.btnUninstall.TabIndex = 5;
            this.btnUninstall.Text = "&Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.BtnUninstall_Click);
            // 
            // btnInstallUpdate
            // 
            this.btnInstallUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstallUpdate.Location = new System.Drawing.Point(428, 311);
            this.btnInstallUpdate.Name = "btnInstallUpdate";
            this.btnInstallUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnInstallUpdate.TabIndex = 4;
            this.btnInstallUpdate.Text = "&Install";
            this.btnInstallUpdate.UseVisualStyleBackColor = true;
            this.btnInstallUpdate.Click += new System.EventHandler(this.BtnInstallUpdate_Click);
            // 
            // pnlExtensionInfo
            // 
            this.pnlExtensionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlExtensionInfo.Controls.Add(this.lblVsCodeId);
            this.pnlExtensionInfo.Controls.Add(this.lblInformation);
            this.pnlExtensionInfo.Controls.Add(this.lblExtensionName);
            this.pnlExtensionInfo.Controls.Add(this.txtExtensionDescription);
            this.pnlExtensionInfo.Controls.Add(this.btnInstallUpdate);
            this.pnlExtensionInfo.Controls.Add(this.btnUninstall);
            this.pnlExtensionInfo.Location = new System.Drawing.Point(185, 27);
            this.pnlExtensionInfo.Name = "pnlExtensionInfo";
            this.pnlExtensionInfo.Size = new System.Drawing.Size(506, 335);
            this.pnlExtensionInfo.TabIndex = 3;
            // 
            // lblVsCodeId
            // 
            this.lblVsCodeId.AutoSize = true;
            this.lblVsCodeId.Location = new System.Drawing.Point(7, 39);
            this.lblVsCodeId.Name = "lblVsCodeId";
            this.lblVsCodeId.Size = new System.Drawing.Size(79, 13);
            this.lblVsCodeId.TabIndex = 9;
            this.lblVsCodeId.Text = "VsCodeId Here";
            // 
            // lblInformation
            // 
            this.lblInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInformation.AutoSize = true;
            this.lblInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformation.Location = new System.Drawing.Point(3, 307);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(170, 25);
            this.lblInformation.TabIndex = 8;
            this.lblInformation.Text = "Information Here";
            // 
            // lblExtensionName
            // 
            this.lblExtensionName.AutoSize = true;
            this.lblExtensionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtensionName.Location = new System.Drawing.Point(3, 0);
            this.lblExtensionName.Name = "lblExtensionName";
            this.lblExtensionName.Size = new System.Drawing.Size(328, 37);
            this.lblExtensionName.TabIndex = 7;
            this.lblExtensionName.Text = "Extension Name Here";
            // 
            // txtExtensionDescription
            // 
            this.txtExtensionDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtensionDescription.Location = new System.Drawing.Point(3, 55);
            this.txtExtensionDescription.Multiline = true;
            this.txtExtensionDescription.Name = "txtExtensionDescription";
            this.txtExtensionDescription.ReadOnly = true;
            this.txtExtensionDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtExtensionDescription.Size = new System.Drawing.Size(500, 241);
            this.txtExtensionDescription.TabIndex = 6;
            this.txtExtensionDescription.Text = "Extension Description Here";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(703, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReloadExtensionList,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "&File";
            // 
            // tsmiReloadExtensionList
            // 
            this.tsmiReloadExtensionList.Name = "tsmiReloadExtensionList";
            this.tsmiReloadExtensionList.Size = new System.Drawing.Size(185, 22);
            this.tsmiReloadExtensionList.Text = "&Reload Extension List";
            this.tsmiReloadExtensionList.Click += new System.EventHandler(this.TsmiReloadExtensionList_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(185, 22);
            this.tsmiExit.Text = "&Exit";
            this.tsmiExit.Click += new System.EventHandler(this.TsmiExit_Click);
            // 
            // lblLegend
            // 
            this.lblLegend.AutoSize = true;
            this.lblLegend.Location = new System.Drawing.Point(12, 339);
            this.lblLegend.Name = "lblLegend";
            this.lblLegend.Size = new System.Drawing.Size(106, 26);
            this.lblLegend.TabIndex = 5;
            this.lblLegend.Text = "✔️: Installed\r\n🔺: Update Available";
            // 
            // FrmVsCodeExtManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 374);
            this.Controls.Add(this.lblLegend);
            this.Controls.Add(this.pnlExtensionInfo);
            this.Controls.Add(this.lblExentionList);
            this.Controls.Add(this.lbExentionList);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(719, 413);
            this.Name = "FrmVsCodeExtManager";
            this.Text = "VS Code Extension Manager";
            this.pnlExtensionInfo.ResumeLayout(false);
            this.pnlExtensionInfo.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbExentionList;
        private System.Windows.Forms.Label lblExentionList;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Button btnInstallUpdate;
        private System.Windows.Forms.Panel pnlExtensionInfo;
        private System.Windows.Forms.Label lblExtensionName;
        private System.Windows.Forms.TextBox txtExtensionDescription;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiReloadExtensionList;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Label lblVsCodeId;
        private System.Windows.Forms.Label lblLegend;
    }
}

