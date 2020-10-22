﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARTopoTracker.Config
{
	public class SARTopoSettings
	{
		public static SARTopoSettings Default = new SARTopoSettings()
		{
			Scheme = "http",
			Address = "localhost",
			Port = 8080
		};

		public String Scheme { get; set; }
		public String Address { get; set; }
		public Int32 Port { get; set; }

		[JsonIgnore]
		public String URI
		{
			get
			{
				return String.Format
				(
					"{0}://{1}:{2}",
					this.Scheme,
					this.Address,
					this.Port
				);
			}
		}

		public SARTopoSettings() { }

		public SARTopoSettings(String url)
		{
			Uri uri = new Uri(url);
			this.Scheme = uri.Scheme;
			this.Address = uri.DnsSafeHost;
			this.Port = uri.Port;
		}

		public override String ToString()
		{
			return this.URI;
		}
	}
}
