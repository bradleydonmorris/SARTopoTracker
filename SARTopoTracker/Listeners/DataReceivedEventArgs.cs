using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARTopoTracker.Listeners
{
	public class DataReceivedEventArgs : EventArgs
	{
		public Assets.IAsset Asset { get; set; }

		public DataReceivedEventArgs(Assets.IAsset asset)
		{
			this.Asset = asset;
		}
	}
}
