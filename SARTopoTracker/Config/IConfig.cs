using System;
using System.Collections.Generic;

namespace SARTopoTracker.Config
{
	public interface IConfig
	{
		AGWPEPortSettings AGWPEPortSettings { get; set; }
		SARTopoSettings SARTopoSettings { get; set; }
		void Save();
	}
}
