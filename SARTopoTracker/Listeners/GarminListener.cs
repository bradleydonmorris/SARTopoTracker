using Garmin.Device.Core;
using SARTopoTracker.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SARTopoTracker.Listeners
{
	public class GarminListener : IListener
	{
		public event DataReceivedEventHandler DataReceivedEvent;
		public event ExceptionEventHandler ExceptionEvent;

		private String _GarminPrefix { get; set; }
		private Boolean _Stop { get; set; }

		public void Dispose()
		{
			this.Stop();
		}

		public GarminListener(String garminPrefix)
		{
			this._GarminPrefix = garminPrefix;
		}

		public void Start()
		{
			this._Stop = false;
			List<GarminDevice> list = GarminDevice.DiscoverDevices();
			list.ForEach
			(
				garminDevice =>
				{
					Task task;
					GarminReader reader = new GarminReader(garminDevice);
					DeviceInformation info = reader.ReadInfo();
					if
					(
						info.SupportedProtocols != null
						&& info.SupportedProtocols.Any(p => p.tag == (Byte)'A' && p.data == 1100)
					)
						task = Task.Run
						(
							() =>
							{
								this._Monitor(garminDevice);
							}
						);
					else
						garminDevice.Dispose();
				}
			);

		}

		public void Stop()
		{
			this._Stop = true;
		}

		private void _Monitor(GarminDevice garminDevice)
		{
			if (garminDevice != null)
			{
				GarminReader reader = new GarminReader(garminDevice);
				while (true)
				{
					if (_Stop)
						break;
					try
					{
						UsbPacket packet = reader.WaitForPacket(3078);
						DataReceivedEvent?.Invoke(this, new DataReceivedEventArgs(new GarminAsset(this._GarminPrefix, packet.data)));
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
