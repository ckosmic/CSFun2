using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPixels {
	class PixelSettings {
		[DescriptionAttribute("Delay between each loop in milliseconds.")]
		public int updateFrequency { get; set; } = 1000 / 30;
		[DescriptionAttribute("Place pixels near the mouse cursor.")]
		public bool surroundMouse { get; set; } = false;
		[DescriptionAttribute("The radius that pixels get placed around the mouse cursor.")]
		public int surroundRadius { get; set; } = 10;
	}
}
