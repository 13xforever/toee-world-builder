using System;
using System.Windows.Forms;
using WorldBuilder.Forms;

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