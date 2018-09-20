using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFun2.Plugin {
	public class TestPlugin : ISub {
		public string name => "TestPlugin";
		public string description => "A test plugin.";
		public string author => "Christian Kosman";
		public bool enabled { get; set; } = false;
		public Type settings { get => typeof(SubSettings); }

		public Task SubMethod(dynamic settings) {
			for(int i = 0; i < settings.repeat; i++) {
				Console.WriteLine(settings.message);
			}
			return null;
		}
	}
}