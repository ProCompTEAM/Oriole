using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Oriole
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{	
			Oriole.generic.Oriole.LoadAll();
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
