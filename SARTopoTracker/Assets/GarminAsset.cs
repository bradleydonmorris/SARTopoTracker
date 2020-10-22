using SARTopoTracker.Assets.GarminTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARTopoTracker.Assets
{
	public class GarminAsset : IAsset
	{
		public String Identifier { get; set; }
		public String Message { get; set; }
		public String Comment { get; set; }
		public Double Latitude { get; set; }
		public Double Longitude { get; set; }
		public Single? Altitude { get; set; }
		public DateTimeOffset Time { get; set; }

		public DogStatus DogStatus { get; set; }
		public PlatformType Platform { get; set; }
		public TrackerType TrackerType { get; set; }
		public StatusFlags StatusFlags { get; set; }
		public SymbolType Symbol { get; set; }
		public UInt16 CollarId { get; set; }
		public Byte Color { get; set; }
		public Byte Battery { get; set; }
		public Byte Gps { get; set; }
		public Byte Comm { get; set; }
		public Byte Channel { get; set; }
		public Byte SquelchCode { get; set; }
		public Byte Index { get; set; }

		public override string ToString()
		{
			return $"{this.Identifier,-20}Time:{this.Time:T}     Batt:{this.Battery}/4     Comm:{this.Comm}/5     GPS:{this.Gps}/3     ID:{this.CollarId / 256}-{this.CollarId % 256}     {this.Latitude:0.000000}, {this.Longitude:0.000000}     {this.DogStatus}";
		}

		public GarminAsset() { }

		public GarminAsset(byte[] buffer)
		{
			Int32 offset = 0;

			Latitude = BitConverter.ToInt32(buffer, offset) * 180.0 / Int32.MaxValue;
			offset += 4;

			Longitude = BitConverter.ToInt32(buffer, offset) * 180.0 / Int32.MaxValue;
			offset += 4;

			Altitude = BitConverter.ToSingle(buffer, offset);
			offset += 4;

			Time = new DateTimeOffset(1989, 12, 31, 0, 0, 0, TimeSpan.FromSeconds(0)).AddSeconds(BitConverter.ToUInt32(buffer, offset)).ToLocalTime();
			offset += 4;

			UInt32 status = BitConverter.ToUInt32(buffer, offset);
			offset += 4;
			DogStatus = (DogStatus)(status & 0x0f);
			Platform = (PlatformType)((status >> 4) & 0x1f);
			TrackerType = (TrackerType)((status >> 8) & 0x07);
			StatusFlags = (StatusFlags)((status >> 11) & 0x1f);

			Symbol = (SymbolType)BitConverter.ToUInt16(buffer, offset);
			offset += 2;

			CollarId = BitConverter.ToUInt16(buffer, offset);
			offset += 2;

			Color = buffer[offset++];
			Battery = buffer[offset++];
			Gps = buffer[offset++];
			Comm = buffer[offset++];
			Channel = buffer[offset++];
			SquelchCode = buffer[offset++];
			Index = buffer[offset++];

			StringBuilder sringBuilder = new StringBuilder();
			for (Int32 i = 0; i < 37; i++)
			{
				if (buffer[offset + i] == 0) break;
				sringBuilder.Append((Char)buffer[offset + i]);
			}
			offset += 37;
			Identifier = sringBuilder.ToString();

			sringBuilder.Clear();
			for (Int32 i = 0; i < 31; i++)
			{
				if (buffer[offset + i] == 0) break;
				sringBuilder.Append((Char)buffer[offset + i]);
			}
			offset += 31;
			Message = sringBuilder.ToString();



			this.Comment = String.Format
			(
				"DogStatus: {0}, TrackerType: {1}, Battery: {2}, Channel: {3}",
				this.DogStatus,
				this.TrackerType,
				this.Battery,
				this.Channel
			);
	}
}
}
