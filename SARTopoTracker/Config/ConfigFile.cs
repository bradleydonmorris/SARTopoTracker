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
	public class ConfigFile : IConfig
	{
		public static ConfigFile Default = new ConfigFile()
		{
			SARTopoSettings = SARTopoSettings.Default,
			AGWPEPortSettings = new AGWPEPortSettings()
		};

		[JsonIgnore]
		public String FilePath { get; set; }

		public SARTopoSettings SARTopoSettings { get; set; }
		public AGWPEPortSettings AGWPEPortSettings { get; set; }

		public ConfigFile()
		{
			this.AGWPEPortSettings = new AGWPEPortSettings();
		}

		public void Save()
		{
			if (File.Exists(this.FilePath))
				File.Delete(this.FilePath);
			File.WriteAllText(this.FilePath, Statics.ToJSONString(this));
		}

		public void SaveAs
		(
			String filePath,
			Boolean overwriteFile
		)
		{
			if (!File.Exists(filePath))
			{
				File.WriteAllText(filePath, Statics.ToJSONString(this));
				this.FilePath = filePath;
			}
			else if
			(
				File.Exists(filePath)
				&& overwriteFile
			)
			{
				File.Delete(filePath);
				File.WriteAllText(filePath, Statics.ToJSONString(this));
				this.FilePath = filePath;
			}
			else throw new IOException("File \"" + filePath + "\" already exists.");
		}

		public static ConfigFile CreateOrOpen(String filePath)
		{
			if (File.Exists(filePath)) return ConfigFile.Open(filePath);
			else return ConfigFile.Create(filePath);
		}

		public static ConfigFile Create(String filePath)
		{
			ConfigFile returnValue = ConfigFile.Default;
			returnValue.FilePath = filePath;
			returnValue.Save();
			returnValue = Statics.FromJSONString<ConfigFile>(File.ReadAllText(filePath));
			returnValue.FilePath = filePath;
			return returnValue;
		}

		public static ConfigFile Open(String filePath)
		{
			ConfigFile returnValue = ConfigFile.Default;
			if (!File.Exists(filePath))
				throw new FileNotFoundException();
			returnValue = Statics.FromJSONString<ConfigFile>(File.ReadAllText(filePath));
			returnValue.FilePath = filePath;
			return returnValue;
		}

		public override String ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Configuration:");
			stringBuilder.AppendFormat("\tSAR Topo  URI: {0}\r\n", this.SARTopoSettings);
			stringBuilder.AppendFormat("\tAGWPE Port  URI: {0}\r\n", this.AGWPEPortSettings);
			stringBuilder.AppendFormat("\tConfig File Path: {0}\r\n", this.FilePath);
			return stringBuilder.ToString();
		}
	}
}
