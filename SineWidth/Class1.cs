using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSFun2.Plugin;

namespace SineWidth
{
    public class Class1 : ISub {
		[DllImport("user32.dll")]
		static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);
		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

		public string name => "Sine Width";
		public string description => "Makes the active window's width pulse in a sine wave function.";
		public string author => "Christian Kosman";
		public string version => "1.0.0";
		public bool enabled { get; set; } = false;
		public Type settings { get => typeof(SineSettings); }

		//public Task SubMethod(dynamic settings) {
		public void SubMethod(dynamic settings) {
			int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
			int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;

			IntPtr foregroundWindow = GetForegroundWindow();
			IntPtr previousWindow = IntPtr.Zero;
			RECT rect = new RECT();
			GetWindowRect(foregroundWindow, out rect);

			float increment = 0;

			while (true) {
				foregroundWindow = GetForegroundWindow();
				GetWindowRect(foregroundWindow, out rect);
				if (foregroundWindow != IntPtr.Zero && foregroundWindow != previousWindow) {
					GetWindowRect(foregroundWindow, out rect);
					previousWindow = foregroundWindow;
				}
				increment += 0.1f;
				MoveWindow(foregroundWindow, rect.Left - (int)(Math.Sin(increment * settings.frequency) * settings.amplitude) / 2, rect.Top, rect.Width + (int)(Math.Sin(increment * settings.frequency) * settings.amplitude), rect.Height, true);
				//Task.Delay(settings.updateFrequency).Wait();
				Thread.Sleep(settings.updateFrequency);
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT {
			public int Left, Top, Right, Bottom;

			public RECT(int left, int top, int right, int bottom) {
				Left = left;
				Top = top;
				Right = right;
				Bottom = bottom;
			}

			public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

			public int X
			{
				get { return Left; }
				set { Right -= (Left - value); Left = value; }
			}

			public int Y
			{
				get { return Top; }
				set { Bottom -= (Top - value); Top = value; }
			}

			public int Height
			{
				get { return Bottom - Top; }
				set { Bottom = value + Top; }
			}

			public int Width
			{
				get { return Right - Left; }
				set { Right = value + Left; }
			}

			public System.Drawing.Point Location
			{
				get { return new System.Drawing.Point(Left, Top); }
				set { X = value.X; Y = value.Y; }
			}

			public System.Drawing.Size Size
			{
				get { return new System.Drawing.Size(Width, Height); }
				set { Width = value.Width; Height = value.Height; }
			}

			public static implicit operator System.Drawing.Rectangle(RECT r) {
				return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
			}

			public static implicit operator RECT(System.Drawing.Rectangle r) {
				return new RECT(r);
			}

			public static bool operator ==(RECT r1, RECT r2) {
				return r1.Equals(r2);
			}

			public static bool operator !=(RECT r1, RECT r2) {
				return !r1.Equals(r2);
			}

			public bool Equals(RECT r) {
				return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
			}

			public override bool Equals(object obj) {
				if (obj is RECT)
					return Equals((RECT)obj);
				else if (obj is System.Drawing.Rectangle)
					return Equals(new RECT((System.Drawing.Rectangle)obj));
				return false;
			}

			public override int GetHashCode() {
				return ((System.Drawing.Rectangle)this).GetHashCode();
			}

			public override string ToString() {
				return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
			}
		}

	}
}
