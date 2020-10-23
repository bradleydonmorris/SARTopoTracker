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
	public class GenericConfig : IConfig
	{
		public static GenericConfig Default = new GenericConfig()
		{
			SARTopoSettings = SARTopoSettings.Default,
			AGWPEPortSettings = new AGWPEPortSettings()
		};

		public String ThisStationIdentifier { get; set; }
		public SARTopoSettings SARTopoSettings { get; set; }
		public AGWPEPortSettings AGWPEPortSettings { get; set; }
		public String GarminPrefix { get; set; }
		public Int32 SARTopoUpdateSeconds { get; set; }

		public GenericConfig()
		{
			this.AGWPEPortSettings = new AGWPEPortSettings();
		}

		public GenericConfig(IConfig config)
		{
			this.ThisStationIdentifier = config.ThisStationIdentifier;
			this.SARTopoSettings = config.SARTopoSettings;
			this.AGWPEPortSettings = config.AGWPEPortSettings;
			this.GarminPrefix = config.GarminPrefix;
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		public override String ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Configuration:");
			stringBuilder.AppendFormat("\tThis Station Identifier: {0}\r\n", this.ThisStationIdentifier);
			stringBuilder.AppendFormat("\tSAR Topo  URI: {0}\r\n", this.SARTopoSettings);
			stringBuilder.AppendFormat("\tAGWPE Port  URI: {0}\r\n", this.AGWPEPortSettings);
			stringBuilder.AppendFormat("\tGarmin Prefix: {0}\r\n", this.GarminPrefix);
			stringBuilder.AppendFormat("\tSAR Topo Update Seconds: {0}\r\n", this.SARTopoUpdateSeconds);
			return stringBuilder.ToString();
		}
	}
}
