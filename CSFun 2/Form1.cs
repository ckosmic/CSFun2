using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;
using CSFun2.Plugin;
using System.Net;
using System.Threading;

namespace CSFun2 {
	public partial class Form1 : Form {
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AllocConsole();
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();
		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		[DllImport("USER32.dll")]
		static extern short GetKeyState(int nVirtKey);

		public const string version = "1.0.0";
		public string onlineVersion = "";

		public List<ISub> plugins;
		public ISub currentlySelectedPlugin;

		public List<object> settings = new List<object>();

		public Form1() {
			InitializeComponent();
			//AllocConsole();
			button3.Hide();
			this.Text = "CSFun 2 - " + version;

			int SW_HIDE = 0;
			int SW_SHOW = 0;

			IntPtr handle = GetConsoleWindow();
			//ShowWindow(handle, SW_HIDE);

			PluginLoader loader = new PluginLoader();
			loader.LoadPlugins();

			plugins = loader.plugins;
			foreach (ISub plugin in plugins) {
				if (plugin != null) {
					checkedListBox1.Items.Add(plugin.name);
					settings.Add(Activator.CreateInstance(plugin.settings));
					Console.WriteLine("Subprocess plugin '" + plugin.name + "' was loaded.");
				} else {
					Console.WriteLine("Could not find plugin!");
				}
			}

			Console.WriteLine("Initialized");

			

			Task.Run(AsyncFunction);

			CheckForUpdates();
		}

		public void CheckForUpdates() {
			var webRequest = WebRequest.Create("https://ckosmic.github.io/CSFun2/version.txt");
			using (var response = webRequest.GetResponse())
			using (var content = response.GetResponseStream())
			using (var reader = new StreamReader(content)) {
				onlineVersion = reader.ReadLine();

				Version curVer = new Version(version);
				Version onlVer = new Version(onlineVersion);

				int result = onlVer.CompareTo(curVer);
				if (result > 0) {
					Console.WriteLine("An update is available: version " + onlineVersion + ".");
					Form7 updateForm = new Form7();
					updateForm.ShowUpdatePrompt(version, onlineVersion);
					updateForm.TopMost = true;
				}
			}
		}

		private Task AsyncFunction() {
			while (true) {
				if ((GetKeyState(0x74) & 0x8000) != 0 && (GetKeyState(0x11) & 0x8000) != 0) {
					Application.Exit();
				}
				Task.Delay(10).Wait();
			}
		}

		private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e) {
			plugins[e.Index].enabled = (e.NewValue == CheckState.Checked);

			string desc = plugins[e.Index].description;
			if (desc == null || desc == "") {
				desc = "No description provided.";
			}
			richTextBox1.Text = desc;
			label2.Text = plugins[e.Index].name + " - v" + plugins[e.Index].version;
			string author = plugins[e.Index].author;
			if (author == null || author == "") {
				author = "Anonymous";
			}
			label3.Text = "by " + author;
			button3.Show();

			currentlySelectedPlugin = plugins[e.Index];
		}

		private void button1_Click(object sender, EventArgs e) {
			Console.WriteLine("Starting...");
			foreach (ISub plugin in plugins) {
				if (plugin != null) {
					if (plugin.enabled) {
						int settingIndex = -1;
						for (int i = 0; i < settings.Count; i++) {
							if (settings[i].GetType().FullName == plugin.settings.FullName)
								settingIndex = i;
						}
						//Task.Run(() => plugin.SubMethod(settings[settingIndex]));

						Thread thread = new Thread(new ParameterizedThreadStart(plugin.SubMethod));
						thread.IsBackground = true;
						thread.Start(settings[settingIndex]);

						Console.WriteLine("Started sub: '" + plugin.name + "'.");
					}
				} else {
					Console.WriteLine("Could not find plugin!");
				}
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			ShowAddSubDialogue();
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e) {
			ShowAddSubDialogue();
		}

		public void ShowAddSubDialogue() {
			Form2 addNew = new Form2(this);
			addNew.Show();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Application.Exit();
		}

		private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e) {
			System.Diagnostics.Process.Start(e.LinkText);
		}

		private void pathsToolStripMenuItem_Click(object sender, EventArgs e) {
			Form3 pathsForm = new Form3();
			pathsForm.Show();
		}

		private void button3_Click(object sender, EventArgs e) {
			Form4 subSettings = new Form4();
			subSettings.Show();
		}

		private void hotkeysToolStripMenuItem_Click(object sender, EventArgs e) {
			Form5 keySettings = new Form5();
			keySettings.Show();
		}

		private void button4_Click(object sender, EventArgs e) {
			Application.Exit();
		}

		private void documentationToolStripMenuItem_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("https://christiankosman.com/docs/csfun2");
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e) {
			Form6 aboutForm = new Form6();
			aboutForm.Show();
		}
	}
}
