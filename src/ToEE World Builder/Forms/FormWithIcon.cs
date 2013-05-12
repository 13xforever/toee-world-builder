using System.Windows.Forms;

namespace WorldBuilder.Forms
{
	internal class FormWithIcon : Form
	{
		protected FormWithIcon()
		{
			//because Visual Designer is stupid and won't work with this line compiled
#if !DEBUG
			Icon = Program.Splash.Icon;
#endif
		}
	}
}