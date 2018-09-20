using CSFun2.Plugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSFun2 {
	public partial class Form2 : Form {

		private Form mainForm;
		private string pluginPath;

		public Form2(Form1 main) {
			mainForm = Application.OpenForms["Form1"];
			InitializeComponent();
		}

		private void label2_Click(object sender, EventArgs e) {

		}

		//Confirm button
		private void button1_Click(object sender, EventArgs e) {
			File.Copy(pluginPath, Properties.Settings.Default.PluginsDir + "\\" + Path.GetFileName(pluginPath));
			PluginLoader loader = new PluginLoader();
			ISub sub = loader.LoadPlugin(Path.GetFileName(pluginPath));
			((Form1)mainForm).plugins.Add(sub);
			((Form1)mainForm).checkedListBox1.Items.Add(sub.name);
			((Form1)mainForm).settings.Add(Activator.CreateInstance(sub.settings));

			pluginPath = "";
			this.Close();
		}

		//Cancel button
		private void button2_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void label1_Click(object sender, EventArgs e) {

		}

		private void button3_Click(object sender, EventArgs e) {
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK) {
				pluginPath = openFileDialog1.FileName;
			}
		}
	}
}
