using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSFun2.Plugin;

namespace AutoHydra
{
    public class Class1 : ISub {

		public string name => "Auto Hydra";
		public string description => "Spawns windows in random locations on the screen that print out #yoloswag or the set string.";
		public string author => "Christian Kosman";
		public string version => "1.0.0";
		public bool enabled { get; set; } = false;
		public Type settings { get => typeof(HydraSettings); }

		dynamic settingsGlobal;

		//public Task SubMethod(dynamic settings) {
		public void SubMethod(dynamic settings) {
			int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
			int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;

			settingsGlobal = settings;

			Random rand = new Random();
			while(true) {
				//Task windowSpawn = Task.Run(() => SpawnWindow(settings));
				ThreadStart job = new ThreadStart(SpawnWindow);
				Thread thread = new Thread(job);
				thread.Start();
				//Task.Delay(settings.updateFrequency).Wait();
				Thread.Sleep(settings.updateFrequency);
			}
		}

		private void SpawnWindow() {
			Form1 newForm = new Form1(settingsGlobal.text);
			newForm.ShowDialog();
			//return null;
		}
	}
}
