using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARTopoTracker.Assets
{
	public interface IAsset
	{
		String Identifier { get; set; }
		String Message { get; set; }
		String Comment { get; set; }
		Double Latitude { get; set; }
		Double Longitude { get; set; }
		Single? Altitude { get; set; }
		DateTimeOffset Time { get; set; }
	}
}
