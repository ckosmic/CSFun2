using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorMessages {
	class ErrorSettings {
		[DescriptionAttribute("Delay between each loop in milliseconds.")]
		public int updateFrequency { get; set; } = 1000;
		[DescriptionAttribute("Delay between each loop in milliseconds.")]
		public string errorMessage { get; set; } = "System directory is corrupted! (C:\\Windows\\System32)";
	}
}
