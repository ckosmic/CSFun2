using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSFun2.Plugin;

namespace CSFun2 {
	public partial class Form4 : Form {

		private Form mainForm;

		public Form4() {
			InitializeComponent();
			mainForm = Application.OpenForms["Form1"];
		}

		private void Form4_Load(object sender, EventArgs e) {
			Type settingsType = ((Form1)mainForm).currentlySelectedPlugin.settings;
			int settingIndex = -1;
			for (int i = 0; i < ((Form1)mainForm).settings.Count; i++) {
				if (((Form1)mainForm).settings[i].GetType().FullName == settingsType.FullName)
					settingIndex = i;
			}
			if (settingIndex == -1) {
				((Form1)mainForm).settings.Add(Activator.CreateInstance(settingsType));
				propertyGrid1.SelectedObject = ((Form1)mainForm).settings[((Form1)mainForm).settings.Count-1];

				Console.WriteLine("Settings doesn't exist, created one.");
			} else {
				propertyGrid1.SelectedObject = ((Form1)mainForm).settings[settingIndex];
				Console.WriteLine("Settings does exist, using existing one.");
			}
		}
	}
}
