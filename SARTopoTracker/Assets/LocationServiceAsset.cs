using System;
using System.Collections.Generic;
using System.Device.Location;

namespace SARTopoTracker.Assets
{
	public class LocationServiceAsset : IAsset
	{
		public String Identifier { get; set; }
		public String Message { get; set; }
		public String Comment { get; set; }
		public Double Latitude { get; set; }
		public Double Longitude { get; set; }
		public Single? Altitude { get; set; }
		public DateTimeOffset Time { get; set; }

		public Double Course { get; set; }
		public Double Speed { get; set; }
		public Double HorizontalAccuracy { get; set; }
		public Double VerticalAccuracy { get; set; }

		public LocationServiceAsset(String identifier, GeoPosition<GeoCoordinate> geoPosition)
		{
			this.Identifier = identifier;
			this.Latitude = geoPosition.Location.Latitude;
			this.Longitude = geoPosition.Location.Longitude;
			this.Altitude = (Single)geoPosition.Location.Altitude;
			this.Time = geoPosition.Timestamp;
			this.Course = geoPosition.Location.Course;
			this.Speed = geoPosition.Location.Speed;
			this.HorizontalAccuracy = geoPosition.Location.HorizontalAccuracy;
			this.VerticalAccuracy = geoPosition.Location.VerticalAccuracy;
			this.Message = String.Empty;
			this.Comment = String.Format
			(
				"Course: {0}, Speed: {1}, HAcc: {2}, VAcc: {3}",
				this.Course,
				this.Speed,
				this.HorizontalAccuracy,
				this.VerticalAccuracy
			);
		}
	}
}
