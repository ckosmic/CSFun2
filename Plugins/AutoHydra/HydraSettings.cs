using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHydra {
	class HydraSettings {
		[DescriptionAttribute("Delay between each loop in milliseconds.")]
		public int updateFrequency { get; set; } = 1000;
		[DescriptionAttribute("The text to print over and over in each window.")]
		public string text { get; set; } = "#yoloswag ";
	}
}
