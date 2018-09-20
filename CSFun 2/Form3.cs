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
	public partial class Form3 : Form {

		public Form3() {
			InitializeComponent();
		}

		private void Form3_Load(object sender, EventArgs e) {
			textBox1.Text = Properties.Settings.Default.PluginsDir;
			label2.Text = "";
		}

		private void button1_Click(object sender, EventArgs e) {
			if (Directory.Exists(textBox1.Text)) {
				Properties.Settings.Default.PluginsDir = textBox1.Text;
				Properties.Settings.Default.Save();
				Close();
			} else {
				label2.Text = "Error: The chosen plugins directory does not exist!";
			}
		}

		private void button3_Click(object sender, EventArgs e) {
			folderBrowserDialog1.SelectedPath = Properties.Settings.Default.PluginsDir;
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if (result == DialogResult.OK) {
				textBox1.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
