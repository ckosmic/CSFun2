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
	public partial class Form6 : Form {

		private Form mainForm;

		public Form6() {
			InitializeComponent();

			mainForm = Application.OpenForms["Form1"];
			label1.Text = "CSFun 2 version " + Form1.version + " | Developed by Christian Kosman";
			richTextBox1.Text = ((Form1)mainForm).richTextBox1.Text;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start("https://github.com/ckosmic/CSFun2");
		}

		private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e) {
			System.Diagnostics.Process.Start(e.LinkText);
		}
	}
}
