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
			//Program.Config.SARTopoSettings = new Config.SARTopoSettings("http://192.168.254.70:8080");
			//Program.Config.AGWPEPortSettings = new Config.AGWPEPortSettings()
			//{
			//	RadioPort = 1,
			//	ServerAddress = "192.168.254.70",
			//	ServerPort = 8000
			//};
			if (String.IsNullOrEmpty(Program.Config.ThisStationIdentifier))
				Program.Config.ThisStationIdentifier = System.Net.Dns.GetHostName();
			if (Program.Config.SARTopoSettings == null)
				Program.Config.SARTopoSettings = SARTopoTracker.Config.SARTopoSettings.Default;
			if (Program.Config.AGWPEPortSettings == null)
				Program.Config.AGWPEPortSettings = SARTopoTracker.Config.AGWPEPortSettings.Default;
			if (String.IsNullOrEmpty(Program.Config.GarminPrefix))
				Program.Config.GarminPrefix = "GK9";
			Program.Config.Save();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form_Main());
		}
	}
}
