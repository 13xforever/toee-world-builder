using System;
using System.Windows.Forms;
using WorldBuilder.Forms;

namespace WorldBuilder
{
	internal static class Program
	{
		public static Form Splash;

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Splash = new Splash();
			Splash.Show();
			Splash.Refresh();
			Application.Run(new Worlded());
		}
	}
}