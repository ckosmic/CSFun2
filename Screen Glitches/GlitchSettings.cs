using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screen_Glitches {
	class GlitchSettings {
		[DescriptionAttribute("Delay between each loop in milliseconds.")]
		public int updateFrequency { get; set; } = 100;
		[DescriptionAttribute("The copy method that BitBlt uses to capture pixels from the screen.")]
		public Class1.CopyMethod copyMethod { get; set; } = Class1.CopyMethod.SRCINVERT;
		[DescriptionAttribute("Maximum size of each copied screen rectangle.")]
		public int artifactSize { get; set; } = 300;
	}
}
