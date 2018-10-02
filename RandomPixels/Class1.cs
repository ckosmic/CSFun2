using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSFun2.Plugin;

namespace RandomPixels
{
    public class Class1 : ISub {
		[DllImport("user32.dll")]
		static extern IntPtr GetDC(IntPtr hWnd);
		[DllImport("gdi32.dll")]
		static extern uint SetPixel(IntPtr hdc, int X, int Y, uint crColor);

		public string name => "Random Pixels";
		public string description => "Places randomly colored pixels in random locations on the screen.";
		public string author => "Christian Kosman";
		public string version => "1.0.0";
		public bool enabled { get; set; } = false;
		public Type settings { get => typeof(PixelSettings); }

		//public Task SubMethod(dynamic settings) {
		public void SubMethod(dynamic settings) {
			int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
			int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;

			uint red = 0;
			uint green = 0;
			uint blue = 0;
			uint rgb = 0;

			int x = 0;
			int y = 0;

			IntPtr hdc = GetDC(IntPtr.Zero);

			Random rand = new Random();
			while (true) {
				red = (uint)rand.Next(0, 255);
				green = (uint)rand.Next(0, 255);
				blue = (uint)rand.Next(0, 255);
				rgb = rgbColor(red, green, blue);

				if (settings.surroundMouse) {
					x = System.Windows.Forms.Cursor.Position.X + rand.Next(-settings.surroundRadius, settings.surroundRadius);
					y = System.Windows.Forms.Cursor.Position.Y + rand.Next(-settings.surroundRadius, settings.surroundRadius);
				} else {
					x = rand.Next(0, screenWidth);
					y = rand.Next(0, screenHeight);
				}

				SetPixel(hdc, x, y, rgb);

				//Task.Delay(settings.updateFrequency).Wait();
				Thread.Sleep(settings.updateFrequency);
			}

			uint rgbColor(uint r, uint g, uint b) {
				return (uint)((r & 0x0ff) << 16) | ((g & 0x0ff) << 8 | (b & 0x0ff));
			}
		}
	}
}
