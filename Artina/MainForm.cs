using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Artina.Extensions;
using Artina.Attributes;
using Artina.FileFormats;

namespace Artina
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            if (Properties.Settings.Default.LastDatasetDir == string.Empty)
                Properties.Settings.Default.LastDatasetDir = @"E:\[SSD User Data]\Downloads\disg-BLUS30727\START-datfiles\";

            fbdDatasetDir.SelectedPath = Properties.Settings.Default.LastDatasetDir;
            if (fbdDatasetDir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Properties.Settings.Default.LastDatasetDir = fbdDatasetDir.SelectedPath;
            else
                Environment.Exit(-1);

            DataManager.LoadDatasets(new System.IO.DirectoryInfo(Properties.Settings.Default.LastDatasetDir).EnumerateFiles());

            comboBox1.SelectedValueChanged += ((s, e) =>
            {
                var item = (s as ComboBox).SelectedItem;
                if (item is KeyValuePair<string, ParsableData>)
                {
                    var instance = ((KeyValuePair<string, ParsableData>)item).Value;

                    object data = null;
                    string displayName = string.Empty;

                    foreach (System.Reflection.PropertyInfo propInfo in instance.GetType().GetProperties())
                    {
                        var dataPropAttrib = propInfo.GetAttribute<DataPropertyAttribute>();

                        if (dataPropAttrib != null)
                        {
                            data = propInfo.GetValue(instance, null);

                            var elementType = propInfo.PropertyType.GetElementType();
                            foreach (System.Reflection.PropertyInfo dataPropInfo in elementType.GetProperties())
                            {
                                var displayPropAttrib = dataPropInfo.GetAttribute<DisplayPropertyAttribute>();
                                if (displayPropAttrib != null) displayName = dataPropInfo.Name;
                            }
                            break;
                        }
                    }

                    listBox1.DataSource = data;
                    listBox1.DisplayMember = displayName;
                }
            });
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";

            listBox1.SelectedValueChanged += ((s, e) =>
            {
                propertyGrid1.SelectedObject = (s as ListBox).SelectedItem;
            });

            comboBox1.DataSource = DataManager.GetDatasets<ParsableData>().ToList();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
