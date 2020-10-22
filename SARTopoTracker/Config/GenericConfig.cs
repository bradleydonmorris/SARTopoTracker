using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARTopoTracker.Config
{
	public class GenericConfig
	{
		public static GenericConfig Default = new GenericConfig()
		{
			SARTopoSettings = SARTopoSettings.Default,
			AGWPEPortSettings = new AGWPEPortSettings()
		};

		public SARTopoSettings SARTopoSettings { get; set; }
		public AGWPEPortSettings AGWPEPortSettings { get; set; }


		public GenericConfig()
		{
			this.AGWPEPortSettings = new AGWPEPortSettings();
		}

		public GenericConfig(IConfig config)
		{
			this.SARTopoSettings = config.SARTopoSettings;
			this.AGWPEPortSettings = config.AGWPEPortSettings;
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		public override String ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Configuration:");
			stringBuilder.AppendFormat("\tSAR Topo  URI: {0}\r\n", this.SARTopoSettings);
			stringBuilder.AppendFormat("\tAGWPE Port  URI: {0}\r\n", this.AGWPEPortSettings);
			return stringBuilder.ToString();
		}
	}
}
