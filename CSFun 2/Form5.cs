using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSFun2 {
	public partial class Form5 : Form {

		private bool isListening = false;

		public Form5() {
			this.KeyPreview = true;
			InitializeComponent();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
			if (isListening) {
				//if(keyData.)
					isListening = false;
				Console.WriteLine(keyData);
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void Form5_KeyPress(object sender, KeyPressEventArgs e) {
			/*if (isListening) {
				isListening = false;
				string keyName = "";
				if (e.KeyChar <= 31) {
					keyName = "Ctrl + [KEY]";
				} else {
					keyName = e.KeyChar.ToString();
				}
				Console.WriteLine("Key bound to: " + keyName);
			}*/
		}

		private void button1_Click(object sender, EventArgs e) {
			if (isListening == false) {
				isListening = true;
			}
		}
	}
}
