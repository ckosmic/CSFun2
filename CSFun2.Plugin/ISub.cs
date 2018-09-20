using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFun2.Plugin {
	public interface ISub {
		string name { get; }
		string description { get; }
		string author { get; }
		bool enabled { get; set; }
		Type settings { get; }
		Task SubMethod(dynamic settings);
	}
}
