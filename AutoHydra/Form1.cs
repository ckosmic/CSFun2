using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoHydra {
	public partial class Form1 : Form {

		private string printText = "";
		private int subIndex = 0;

		public Form1(string text) {
			InitializeComponent();
			printText = text;
		}

		private void Form1_Load(object sender, EventArgs e) {
			Random rand = new Random();
			int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
			int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
			Location = new System.Drawing.Point(rand.Next(0, screenWidth), rand.Next(0, screenHeight));
		}

		private void timer1_Tick(object sender, EventArgs e) {
			richTextBox1.Text += printText.Substring(subIndex, 1);
			subIndex++;
			if (subIndex >= printText.Length) {
				subIndex = 0;
			}
		}
	}
}
