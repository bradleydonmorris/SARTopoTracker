using System;
using System.Collections.Generic;
using System.Device.Location;

namespace SARTopoTracker.Assets
{
	public class APRSAsset : IAsset
	{
		public String Identifier { get; set; }
		public String Message { get; set; }
		public String Comment { get; set; }
		public Double Latitude { get; set; }
		public Double Longitude { get; set; }
		public Single? Altitude { get; set; }
		public DateTimeOffset Time { get; set; }
		public Int32 PositionAmbiguity { get; set; }
		public Char? SymbolCode { get; set; }
		public Char? SymbolTable { get; set; }

		public APRSAsset(HamAprsParser.AprsPacket aprsPacket)
		{
			this.Identifier = aprsPacket.SourceCall.ToString();
			this.Time = aprsPacket.Created;
			if (aprsPacket.Payload is HamAprsParser.Payloads.PositionPayload positionPayload)
			{
				this.Latitude = positionPayload.Position.Latitude;
				this.Longitude = positionPayload.Position.Latitude;
				if (positionPayload.Position.AltitudeFt.HasValue)
					this.Altitude = (Single)positionPayload.Position.AltitudeFt / (Single)0.3048;
				this.PositionAmbiguity = positionPayload.Position.PositionAmbiguity;
				this.SymbolCode = positionPayload.Position.SymbolCode;
				this.SymbolTable = positionPayload.Position.SymbolTable;
				this.Message = positionPayload.Comment;
				this.Comment = String.Format
				(
					"SymbolTable: {0}, SymbolCode: {1}, PositionAmbiguity: {2}, Message: {3}",
					this.SymbolTable,
					this.SymbolCode,
					this.PositionAmbiguity,
					this.Message
				);
			}

		}
	}
}
