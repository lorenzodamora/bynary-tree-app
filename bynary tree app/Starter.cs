using System;
using System.Windows.Forms;

namespace bynary_tree_app
{
	internal static class Starter
	{
		public static bool restart = true;
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			while(restart)
			{
				restart = false;
				Application.Run(new App());
			}
		}
	}
}
