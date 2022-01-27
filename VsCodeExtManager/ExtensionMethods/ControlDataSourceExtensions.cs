using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VsCodeExtManager.Constants;
using VsCodeExtManager.Models;

namespace VsCodeExtManager.ExtensionMethods
{
    internal static class ControlDataSourceExtensions
    {
        /// <summary>
        /// Attaches an list of objects to a datasource
        /// </summary>
        /// <param name="currentListBox">Listbox the method is extending</param>
        /// <param name="extensionInfos">The list of objects to attach to the Datasources</param>
        internal static void BindArrayExtensionInfoToListBox(this ListBox currentListBox, IEnumerable<ExtensionInfo> extensionInfos)
        {
            var dataSource = new Dictionary<string, ExtensionInfo>();
            dataSource = extensionInfos.ToDictionary(x => string.Format(ResourceStrings.ExtDataSourceDisplayFormat, (x.VersionInstalled == null ? string.Empty : x.VersionInstalled < x.VersionInRepo ? "🔺 " : "✔️ "), x.Name, x.Author), x => x);
            currentListBox.DataSource = new BindingSource(dataSource, null);
            currentListBox.DisplayMember = "Key";
            currentListBox.ValueMember = "Value";
        }
    }
}
