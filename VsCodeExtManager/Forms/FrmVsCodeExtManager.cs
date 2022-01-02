using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Windows.Forms;
using VsCodeExtManager.Constants;
using VsCodeExtManager.Enums;
using VsCodeExtManager.ExtensionMethods;
using VsCodeExtManager.Models;
using VsCodeExtManager.Workers;

namespace VsCodeExtManager
{
    internal partial class FrmVsCodeExtManager : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private List<ExtensionInfo> ExtensionList = new List<ExtensionInfo>();
        private void ExtensionUiLoader()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lbExentionList.SelectedIndexChanged -= LbExentionList_SelectedIndexChanged;
                ExtensionList = ExtensionWorker.LoadExtensions(ConfigurationManager.AppSettings[ResourceStrings.ExtensionDirConfigKey]);
                lbExentionList.BindArrayExtensionInfoToListBox(ExtensionList);
                ExtensionLoader();
                lbExentionList.SelectedIndexChanged += LbExentionList_SelectedIndexChanged;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                ExtensionList = new List<ExtensionInfo>();
                
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
                    lbExentionList.DataSource = null;
                    lblExtensionName.Text = UiStrings.NoneString;
                    txtExtensionDescription.Text = UiStrings.NoneString;
                    lblVsCodeId.Text = UiStrings.NoneString;
                    btnUninstall.Enabled = false;
                    btnInstallUpdate.Enabled = false;
                    btnInstallUpdate.Text = UiStrings.InstallButtonText;
                    lblInformation.Text = string.Format(UiStrings.ExtensionStatus, UiStrings.NoExtensionsStatus);
                }
                else
                {
                    var selectedExtension = (ExtensionInfo)lbExentionList.SelectedValue;
                    lblExtensionName.Text = selectedExtension.Name;
                    txtExtensionDescription.Text = selectedExtension.Description;
                    lblVsCodeId.Text = selectedExtension.VsCodeId;
                    btnUninstall.Enabled = selectedExtension.Installed;
                    btnInstallUpdate.Enabled = !selectedExtension.Installed || selectedExtension.VersionInstalled < selectedExtension.VersionInRepo;
                    btnInstallUpdate.Text = selectedExtension.VersionInstalled == null ? UiStrings.InstallButtonText : selectedExtension.VersionInstalled < selectedExtension.VersionInRepo ? UiStrings.Update : UiStrings.NoneString;
                    lblInformation.Text = string.Format(UiStrings.ExtensionStatus, (selectedExtension.VersionInstalled == null ? UiStrings.NotInstalledStatus : selectedExtension.VersionInstalled < selectedExtension.VersionInRepo ? UiStrings.UpdateStatus : UiStrings.InstalledStatus));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        internal FrmVsCodeExtManager()
        {
            InitializeComponent();
            try
            {
                ExtensionUiLoader();
            }
            catch (Exception e)
            {
                Log.Error(e);
                MessageBox.Show(e.Message, UiStrings.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, UiStrings.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ExtensionWorker.ExtensionCommand(ExtensionCommandType.install, (ExtensionInfo)lbExentionList.SelectedValue);
                MessageBox.Show(MessageStrings.InstallComplete, UiStrings.TaskCompleteTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, UiStrings.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
            try
            {
                ExtensionUiLoader();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, UiStrings.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUninstall_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ExtensionWorker.ExtensionCommand(ExtensionCommandType.uninstall, (ExtensionInfo)lbExentionList.SelectedValue);
                MessageBox.Show(MessageStrings.UninstallComplete, UiStrings.TaskCompleteTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, UiStrings.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
            try
            {
                ExtensionUiLoader();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, UiStrings.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
