using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SARTopoTracker
{
	static class Program
	{
		internal static String ConfigFilePath { get; set; }
		internal static Config.IConfig Config { get; set; }


		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			String executionRoot = (new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase))).LocalPath;
			Program.ConfigFilePath = Path.Combine(executionRoot, "config.json");
			Program.Config = SARTopoTracker.Config.ConfigFile.CreateOrOpen(Program.ConfigFilePath);
			Program.Config.SARTopoSettings = new Config.SARTopoSettings("http://localhost:8080");
			Program.Config.AGWPEPortSettings = new Config.AGWPEPortSettings()
			{
				RadioPort = 2,
				ServerAddress = "localhost",
				ServerPort = 8000
			};
			Program.Config.Save();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form_Main());
		}
	}
}
