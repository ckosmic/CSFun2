using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSFun2.Plugin;

namespace ErrorMessages
{
	public class Class1 : ISub {
		public string name => "Error Messages";
		public string description => "Spawns a bunch of fake error messages on the screen forever.";
		public string author => "Christian Kosman";
		public bool enabled { get; set; } = false;
		public Type settings { get => typeof(ErrorSettings); }

		public Task SubMethod(dynamic settings) {
			while (true) {
				Task.Run(() =>
				{
					MessageBox.Show(settings.errorMessage, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
				});

				Task.Delay(settings.updateFrequency).Wait();
			}
		}
	}
}
