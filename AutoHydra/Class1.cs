using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSFun2.Plugin;

namespace AutoHydra
{
    public class Class1 : ISub {

		public string name => "Auto Hydra";
		public string description => "Spawns windows in random locations on the screen that print out #yoloswag or the set string.";
		public string author => "Christian Kosman";
		public bool enabled { get; set; } = false;
		public Type settings { get => typeof(HydraSettings); }

		public Task SubMethod(dynamic settings) {
			int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
			int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;

			Random rand = new Random();
			while(true) {
				Task windowSpawn = Task.Run(() => SpawnWindow(settings));
				Task.Delay(settings.updateFrequency).Wait();
			}
		}

		private Task SpawnWindow(dynamic settings) {
			Form1 newForm = new Form1(settings.text);
			newForm.ShowDialog();
			return null;
		}
	}
}
