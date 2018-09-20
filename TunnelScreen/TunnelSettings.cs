using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunnelScreen {
	class TunnelSettings {
		[DescriptionAttribute("Delay between each loop in milliseconds.")]
		public int updateFrequency { get; set; } = 100;
		[DescriptionAttribute("The distance from the screen size (bigger = more spaced out images).")]
		public int captureDistance { get; set; } = 5;
	}
}
