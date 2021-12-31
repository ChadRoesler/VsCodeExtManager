using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Windows.Forms;
using VsCodeExtManager.Constants;
using VsCodeExtManager.ExtensionMethods;
using VsCodeExtManager.Models;
using VsCodeExtManager.Workers;

namespace VsCodeExtManager
{
    public partial class FrmVsCodeExtManager : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private List<ExtensionInfo> ExtensionList = new List<ExtensionInfo>();
        private void ExtensionUiLoader()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lbExentionList.SelectedIndexChanged -= LbExentionList_SelectedIndexChanged;
                ExtensionList = ExtensionWorker.LoadExtensions(ConfigurationManager.AppSettings["ExtensionDirectory"]);
                lbExentionList.BindArrayExtensionInfoToListBox(ExtensionList);
                ExtensionLoader();
                lbExentionList.SelectedIndexChanged += LbExentionList_SelectedIndexChanged;
                Cursor.Current = Cursors.Default;
            }
            catch(Exception e)
            {
                ExtensionLoader();
                throw e;
            }
        }
        private void ExtensionLoader()
        {
            try
            {
                if (ExtensionList.Count == 0)
                {
                    lblExtensionName.Text = "None";
                    txtExtensionDescription.Text = "None";
                    lblVsCodeId.Text = "None";
                    btnUninstall.Enabled = false;
                    btnInstallUpdate.Enabled = false;
                    btnInstallUpdate.Text = "&Install";
                    lblInformation.Text = "Status: No extensions found!";
                }
                else
                {
                    var selectedExtension = (ExtensionInfo)lbExentionList.SelectedValue;
                    lblExtensionName.Text = selectedExtension.Name;
                    txtExtensionDescription.Text = selectedExtension.Description;
                    lblVsCodeId.Text = selectedExtension.VsCodeId;
                    btnUninstall.Enabled = selectedExtension.Installed;
                    btnInstallUpdate.Enabled = !selectedExtension.Installed || selectedExtension.VersionInstalled < selectedExtension.VersionInRepo;
                    btnInstallUpdate.Text = selectedExtension.VersionInstalled == null ? "&Install" : selectedExtension.VersionInstalled < selectedExtension.VersionInRepo ? "&Update" : "Yay!";
                    lblInformation.Text = $"Status: {(selectedExtension.VersionInstalled == null ? "Not Installed" : selectedExtension.VersionInstalled < selectedExtension.VersionInRepo ? "Update Available!" : "Installed")}";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public FrmVsCodeExtManager()
        {
            InitializeComponent();
            try
            {
                ExtensionUiLoader();
            }
            catch(Exception e)
            {
                Log.Error(e);
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsmiReloadExtensionList_Click(object sender, EventArgs e)
        {
            try
            {
                ExtensionUiLoader();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LbExentionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExtensionLoader();
        }

        private void BtnInstallUpdate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ExtensionWorker.InstallExtension((ExtensionInfo)lbExentionList.SelectedValue);
                MessageBox.Show(MessageStrings.InstallComplete, "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
            try
            {
                ExtensionUiLoader();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUninstall_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ExtensionWorker.UninstallExtension((ExtensionInfo)lbExentionList.SelectedValue);
                MessageBox.Show(MessageStrings.UninstallComplete, "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
            try
            {
                ExtensionUiLoader();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
