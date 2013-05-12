// !!! WARNING !!!
// THE ORIGINAL CREDITS AND THE DEDICATION LINE IN THE ABOUT BOX OF THE 
// TOEE WORLD BUILDER MUST BE RETAINED IN ALL CUSTOM BUILDS !!!

using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using WorldBuilder.Helpers;

namespace WorldBuilder.Forms
{
	internal partial class AboutForm : FormWithIcon
	{
		public AboutForm()
		{
			InitializeComponent();

			var ver = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
			var verAsString = new StringBuilder("World Builder v")
				.Append(ver.FileMajorPart).Append(".").Append(ver.FileMinorPart);
			if (ver.FileBuildPart > 0)
				verAsString.Append(".").Append(ver.FileBuildPart);

			using (var stream = MiscHelper.GetResourceStreamThatEndsWith("build.ver"))
				if (stream != null)
					using (var reader = new StreamReader(stream, Encoding.UTF8, false))
					{
						var revision = reader.ReadLine();
						if (!string.IsNullOrEmpty(revision))
							verAsString.Append(" (").Append(revision).Append(")");
					}

			label1.Text = verAsString.ToString();
		}
	}
}