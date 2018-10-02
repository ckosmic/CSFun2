using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earthquake {
	class EarthquakeSettings {
		[DescriptionAttribute("Delay between each loop in milliseconds.")]
		public int updateFrequency { get; set; } = 1000 / 30;
		[DescriptionAttribute("The intensity of the window shaking and resizing.")]
		public int intensity { get; set; } = 15;
	}
}
