using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSFun2.Plugin;

namespace ErrorMessages
{
	public class Class1 : ISub {
		public string name => "Error Messages";
		public string description => "Spawns a bunch of fake error messages on the screen forever.";
		public string author => "Christian Kosman";
		public string version => "1.0.0";
		public bool enabled { get; set; } = false;
		public Type settings { get => typeof(ErrorSettings); }

		dynamic settingsGlobal;

		//public Task SubMethod(dynamic settings) {
		public void SubMethod(dynamic settings) {
			settingsGlobal = settings;
			while (true) {
				/*Task.Run(() =>
				{
					
				});*/

				ThreadStart job = new ThreadStart(SpawnMessageBox);
				Thread thread = new Thread(job);
				thread.Start();

				//Task.Delay(settings.updateFrequency).Wait();
				Thread.Sleep(settings.updateFrequency);
			}
		}

		private void SpawnMessageBox() {
			MessageBox.Show(settingsGlobal.errorMessage, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
		}
	}
}
