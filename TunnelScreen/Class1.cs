using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSFun2.Plugin;

namespace TunnelScreen
{
	public class Class1 : ISub {
		[DllImport("gdi32.dll")]
		static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, TernaryRasterOperations dwRop);
		[DllImport("user32.dll")]
		static extern IntPtr GetDesktopWindow();
		[DllImport("user32.dll")]
		static extern IntPtr GetDC(IntPtr hWnd);
		[DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", SetLastError = true)]
		static extern IntPtr CreateCompatibleDC([In] IntPtr hdc);

		public enum TernaryRasterOperations {
			SRCCOPY = 0x00CC0020, /* dest = source*/
			SRCPAINT = 0x00EE0086, /* dest = source OR dest*/
			SRCAND = 0x008800C6, /* dest = source AND dest*/
			SRCINVERT = 0x00660046, /* dest = source XOR dest*/
			SRCERASE = 0x00440328, /* dest = source AND (NOT dest )*/
			NOTSRCCOPY = 0x00330008, /* dest = (NOT source)*/
			NOTSRCERASE = 0x001100A6, /* dest = (NOT src) AND (NOT dest) */
			MERGECOPY = 0x00C000CA, /* dest = (source AND pattern)*/
			MERGEPAINT = 0x00BB0226, /* dest = (NOT source) OR dest*/
			PATCOPY = 0x00F00021, /* dest = pattern*/
			PATPAINT = 0x00FB0A09, /* dest = DPSnoo*/
			PATINVERT = 0x005A0049, /* dest = pattern XOR dest*/
			DSTINVERT = 0x00550009, /* dest = (NOT dest)*/
			BLACKNESS = 0x00000042, /* dest = BLACK*/
			WHITENESS = 0x00FF0062, /* dest = WHITE*/
		};

		public string name => "Tunnel Screen";
		public string description => "Copies the screen and shrinks the result using StretchBlt.";
		public string author => "Christian Kosman";
		public string version => "1.0.0";
		public bool enabled { get; set; } = false;
		public Type settings { get => typeof(TunnelSettings); }

		//public Task SubMethod(dynamic settings) {
		public void SubMethod(dynamic settings) {
			int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
			int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
			IntPtr desktop = GetDesktopWindow();
			IntPtr desktopDc = GetDC(IntPtr.Zero);
			IntPtr compat = CreateCompatibleDC(desktopDc);
			while (true) {
				StretchBlt(desktopDc, settings.captureDistance, settings.captureDistance, screenWidth - settings.captureDistance*2, screenHeight - settings.captureDistance*2, desktopDc, 0, 0, screenWidth, screenHeight, TernaryRasterOperations.SRCCOPY);
				//Task.Delay(settings.updateFrequency).Wait();
				Thread.Sleep(settings.updateFrequency);
			}
		}
	}
}
