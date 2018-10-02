using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSFun2.Plugin;

namespace ProgramSpam
{
    public class Class1 : ISub {
		public string name => "Program Spam";
		public string description => "Opens every program in the specified directory and every directory under that.";
		public string author => "Christian Kosman";
		public string version => "1.0.0";
		public bool enabled { get; set; } = false;
		public Type settings { get => typeof(ProgramSettings); }

		//public Task SubMethod(dynamic settings) {
		public void SubMethod(dynamic settings) {
			string[] allFiles = Directory.GetFiles(settings.baseDirectory, "*.*", SearchOption.AllDirectories);
			foreach (string file in allFiles) {
				try {
					Console.WriteLine("Opening file: " + file);
					Process proc = new Process();
					proc.StartInfo.FileName = file;
					proc.Start();
				} catch (Exception e) {
					Console.WriteLine("Couldn't open file: " + file);
				}
			}
			//return null;
		}
	}
}
