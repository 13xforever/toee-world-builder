using System;
using System.Windows.Forms;

namespace WorldBuilder
{
	internal static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new Worlded());
		}
	}
}