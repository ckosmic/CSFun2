using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSFun2 {
	public partial class Form7 : Form {

		private Form mainForm;

		public Form7() {
			InitializeComponent();
			mainForm = Application.OpenForms["Form1"];
		}

		public void ShowUpdatePrompt(string version, string onlVersion) {
			Show();
			label2.Text = "Current version: " + version;
			label3.Text = "New version: " + onlVersion;

			var webRequest = WebRequest.Create("https://ckosmic.github.io/CSFun2/changelog.txt");
			using (var response = webRequest.GetResponse())
			using (var content = response.GetResponseStream())
			using (var reader = new StreamReader(content)) {
				string changelog = reader.ReadToEnd();
				string[] changes = changelog.Split(new string[] { "-|-" }, StringSplitOptions.None);
				string versionChanges = changes[changes.Length - 1];

				richTextBox1.Text = versionChanges;
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			Close();
		}

		private void button2_Click(object sender, EventArgs e) {
			using (var client = new WebClient()) {
				client.DownloadFile("https://ckosmic.github.io/CSFun2/CSFun2.Updater.exe", "Updater.exe");
				if (File.Exists("Updater.exe")) {
					Process proc = new Process();
					proc.StartInfo.FileName = "Updater.exe";
					proc.StartInfo.Arguments = "\"" + System.Reflection.Assembly.GetEntryAssembly().Location + "\"";
					proc.Start();
				}
			}
		}
	}
}
