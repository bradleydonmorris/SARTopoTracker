using System;
using System.Collections.Generic;

namespace SARTopoTracker.Config
{
	public interface IConfig
	{
		String ThisStationIdentifier { get; set; }
		AGWPEPortSettings AGWPEPortSettings { get; set; }
		SARTopoSettings SARTopoSettings { get; set; }
		String GarminPrefix { get; set; }
		Int32 SARTopoUpdateSeconds { get; set; }
		void Save();
	}
}
