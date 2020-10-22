using SARTopoTracker.Assets;
using System;
using System.Device.Location;

namespace SARTopoTracker.Listeners
{
	public class LocationServiceListener : IListener
	{
		private GeoCoordinateWatcher _GeoCoordinateWatcher { get; set; }

		public event DataReceivedEventHandler DataReceivedEvent;
		public event ExceptionEventHandler ExceptionEvent;

		public void Start()
		{
			this._GeoCoordinateWatcher = new System.Device.Location.GeoCoordinateWatcher(System.Device.Location.GeoPositionAccuracy.High);
			this._GeoCoordinateWatcher.StatusChanged += GeoCoordinateWatcher_StatusChanged;
			this._GeoCoordinateWatcher.Start();
		}

		private void GeoCoordinateWatcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
		{
			try
			{
				DataReceivedEvent?.Invoke(this, new DataReceivedEventArgs(new LocationServiceAsset("This Station", this._GeoCoordinateWatcher.Position)));
			}
			catch (Exception exception)
			{
				ExceptionEvent?.Invoke(this, new ExceptionEventArgs(new Exception[] { exception }));
			}
		}
	}
}
