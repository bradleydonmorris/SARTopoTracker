using SARTopoTracker.Assets;
using System;
using System.Device.Location;

namespace SARTopoTracker.Listeners
{
	public class LocationServiceListener : IListener
	{
		public event DataReceivedEventHandler DataReceivedEvent;
		public event ExceptionEventHandler ExceptionEvent;

		private GeoCoordinateWatcher _GeoCoordinateWatcher { get; set; }
		private Boolean _Stop { get; set; }

		public void Dispose()
		{
			this.Stop();
		}

		public void Start()
		{
			this._Stop = false;
			this._GeoCoordinateWatcher = new System.Device.Location.GeoCoordinateWatcher(System.Device.Location.GeoPositionAccuracy.High);
			this._GeoCoordinateWatcher.StatusChanged += GeoCoordinateWatcher_StatusChanged;
			this._GeoCoordinateWatcher.Start();
		}

		public void Stop()
		{
			this._Stop = true;
			this._GeoCoordinateWatcher.Dispose();
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
