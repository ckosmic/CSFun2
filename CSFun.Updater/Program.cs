using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSFun2.Updater {
	class Program {
		static void Main(string[] args) {
			Process[] processes = Process.GetProcessesByName("CSFun 2");
			Console.WriteLine("--CSFun 2 Updater version 1.0.0--");

			if (processes.Length > 0 && args.Length > 0) {
				Console.WriteLine("Closing CSFun 2...");
				processes[0].Kill();
				if (processes[0].HasExited) {
					Thread.Sleep(1000);
					string exePath = args[0];
					string exeDir = Path.GetDirectoryName(exePath);
					File.Delete(exePath);
					using (var client = new WebClient()) {
						client.DownloadFile("https://ckosmic.github.io/CSFun2/CSFun%202.exe", exeDir + "\\CSFun 2.exe");
						if (File.Exists(exeDir + "\\CSFun 2.exe")) {
							Process proc = new Process();
							proc.StartInfo.FileName = exeDir + "\\CSFun 2.exe";
							proc.Start();
						}
					}
				}
			}

		}
	}
}
