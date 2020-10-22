using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARTopoTracker.Config
{
	public class AGWPEPortSettings
	{
		public Byte RadioPort { get; set; }
		public String ServerAddress { get; set; }
		public Int32 ServerPort { get; set; }

		[JsonIgnore]
		public String URI
		{
			get
			{
				return String.Format
				(
					"agw://{0}:{1}/Port_{2}",
					this.ServerAddress,
					this.ServerPort,
					this.RadioPort
				);
			}
		}

		public override String ToString()
		{
			return this.URI;
		}
	}
}
