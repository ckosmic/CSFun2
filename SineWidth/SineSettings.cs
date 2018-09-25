using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SineWidth {
	class SineSettings {
		[DescriptionAttribute("Delay between each loop in milliseconds.")]
		public int updateFrequency { get; set; } = 1000/30;
		[DescriptionAttribute("The intensity of the sine wave.")]
		public int amplitude { get; set; } = 15;
		[DescriptionAttribute("The speed of the sine wave.")]
		public int frequency { get; set; } = 5;
	}
}
