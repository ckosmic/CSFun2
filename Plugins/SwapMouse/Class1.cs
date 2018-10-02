using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSFun2.Plugin;

namespace SwapMouse
{
    public class Class1 : ISub {
		[DllImport("user32.dll")]
		static extern bool SwapMouseButton(bool fSwap);

		public string name => "Swap Mouse";
		public string description => "Swaps the functions of the left and right mouse buttons every specified amount of time.";
		public string author => "Christian Kosman";
		public string version => "1.0.0";
		public bool enabled { get; set; } = false;
		public Type settings { get => typeof(MouseSettings); }

		public void SubMethod(dynamic settings) {
			bool swap = false;
			while (true) {
				SwapMouseButton(swap);
				Thread.Sleep(settings.updateFrequency);
				swap = !swap;
			}
		}
	}
}
