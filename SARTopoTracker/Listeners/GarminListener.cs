using Garmin.Device.Core;
using SARTopoTracker.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARTopoTracker.Listeners
{
	public class GarminListener : IListener
	{
		public event DataReceivedEventHandler DataReceivedEvent;
		public event ExceptionEventHandler ExceptionEvent;

		public void Start()
		{
			GarminDevice baseStation = null;

			var list = GarminDevice.DiscoverDevices();
			list.ForEach
			(
				f =>
				{
					GarminReader reader = new GarminReader(f);
					DeviceInformation info = reader.ReadInfo();
					if (baseStation == null && info.SupportedProtocols != null && info.SupportedProtocols.Any(p => p.tag == (byte)'A' && p.data == 1100))
						baseStation = f;
					else
						f.Dispose();
				}
			);

			if (baseStation != null)
			{
				GarminReader reader = new GarminReader(baseStation);
				while (true)
				{
					try
					{
						UsbPacket packet = reader.WaitForPacket(3078);
						DataReceivedEvent?.Invoke(this, new DataReceivedEventArgs(new GarminAsset(packet.data)));
					}
					catch (Exception e)
					{
						ExceptionEvent?.Invoke(this, new ExceptionEventArgs(new Exception[] { e }));
					}
				}
			}
		}
	}
}
