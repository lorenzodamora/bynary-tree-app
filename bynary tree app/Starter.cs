using System;
using System.Windows.Forms;

namespace bynary_tree_app
{
	internal static class Starter
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new App());
		}
	}
}
