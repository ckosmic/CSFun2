using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSpam {
	class ProgramSettings {
		[DescriptionAttribute("Delay between each loop in milliseconds.")]
		public int updateFrequency { get; set; } = 1000;
		[DescriptionAttribute("Delay between each loop in milliseconds.")]
		public string baseDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
	}
}
