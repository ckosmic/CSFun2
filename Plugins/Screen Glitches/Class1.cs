using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSFun2.Plugin;

namespace Screen_Glitches
{
    public class Class1 : ISub {
		[DllImport("gdi32.dll")]
		static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, CopyMethod dwRop);
		[DllImport("user32.dll")]
		static extern IntPtr GetDesktopWindow();
		[DllImport("user32.dll")]
		static extern IntPtr GetDC(IntPtr hWnd);

		public string name => "Screen Glitches";
		public string description => "Swaps the functions of the left and right mouse buttons every specified amount of time.";
		public string author => "Christian Kosman";
		public string version => "1.0.0";
		public bool enabled { get; set; } = false;
		public Type settings { get => typeof(GlitchSettings); }

		public void SubMethod(dynamic settings) {
			int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
			int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
			IntPtr desktop = GetDesktopWindow();
			IntPtr desktopDc = GetDC(IntPtr.Zero);

			int destX = 0;
			int destY = 0;
			int destW = 0;
			int destH = 0;
			int srcX = 0;
			int srcY = 0;
			int srcW = 0;
			int srcH = 0;

			Random rand = new Random();
			while (true) {

				destX = rand.Next(0, screenWidth);
				destY = rand.Next(0, screenHeight);
				destW = rand.Next(0, settings.artifactSize);
				destH = rand.Next(0, settings.artifactSize);
				srcX = rand.Next(0, screenWidth);
				srcY = rand.Next(0, screenHeight);
				srcW = rand.Next(0, settings.artifactSize);
				srcH = rand.Next(0, settings.artifactSize);

				if (rand.Next(0, 4) == 0) {
					destX = 0;
					destW = screenWidth;
					destH = rand.Next(0, 20);
				}

				StretchBlt(desktopDc,
					destX,  //Destination X
					destY,  //Destination Y
					destW,    //Destination width
					destH,	//Destination height
					desktopDc,  //Src DC
					srcX,  //Src X
					srcY,  //Src Y
					srcW,    //Src width
					srcH,	//Src height
					settings.copyMethod);
				Thread.Sleep(settings.updateFrequency);
			}
		}

		public enum CopyMethod : int {
			BLACKNESS = 0x42,
			DSTINVERT = 0x550009,
			MERGECOPY = 0xC000CA,
			MERGEPAINT = 0xBB0226,
			NOTSRCCOPY = 0x330008,
			NOTSRCERASE = 0x1100A6,
			PATCOPY = 0xF00021,
			PATINVERT = 0x5A0049,
			PATPAINT = 0xFB0A09,
			SRCAND = 0x8800C6,
			SRCCOPY = 0xCC0020,
			SRCERASE = 0x440328,
			SRCINVERT = 0x660046,
			SRCPAINT = 0xEE0086,
			WHITENESS = 0xFF0062
		}
	}
}
