using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SARTopoTracker.SARTopoClient
{
	public class Client
	{
		private HttpClient _HttpClient { get; set; }
		private UriBuilder _SARTopoUriBuilder = new UriBuilder("http", "localhost", 8080);

		public String ServerScheme
		{
			get { return this._SARTopoUriBuilder.Scheme; }
			set { this._SARTopoUriBuilder.Scheme = value; }
		}
		public String ServerAddress
		{
			get { return this._SARTopoUriBuilder.Host; }
			set { this._SARTopoUriBuilder.Host = value; }
		}
		public Int32 ServerPort
		{
			get { return this._SARTopoUriBuilder.Port; }
			set { this._SARTopoUriBuilder.Port = value; }
		}
		public Uri SARTopoUri
		{
			get { return this._SARTopoUriBuilder.Uri; }
			set { this._SARTopoUriBuilder = new UriBuilder(value); }
		}
		public String MapID { get; set; }

		public Client(String mapId)
		{
			this.MapID = mapId;
			this._HttpClient = new HttpClient();
		}

		public Client(String serverScheme, String serverAddress, Int32 serverPort, String mapId)
		{
			this.ServerScheme = serverScheme;
			this.ServerAddress = serverAddress;
			this.ServerPort = serverPort;
			this.MapID = mapId;
			this._HttpClient = new HttpClient();
		}

		public Client(String uri, String mapId)
		{
			this.SARTopoUri = new Uri(uri);
			this.MapID = mapId;
			this._HttpClient = new HttpClient();
		}

		public Client(Uri uri, String mapId)
		{
			this.SARTopoUri = uri;
			this.MapID = mapId;
			this._HttpClient = new HttpClient();
		}

		public void UpdateLocator(String callSignAndSID, Double latitude, Double longitude)
		{
			Uri endPoint = new Uri
			(
				this._SARTopoUriBuilder.Uri,
				String.Format
				(
					"/rest/location/update/position?lat={0}&lng={1}&id=FLEET:{2}",
					latitude, longitude, callSignAndSID
				)
			);
			HttpResponseMessage httpResponseMessage = this._HttpClient.GetAsync(endPoint).Result;
			if (!httpResponseMessage.IsSuccessStatusCode)
				throw new Exception(httpResponseMessage.ReasonPhrase);
		}

		private Uri _GetAPIURI(String mapId, String element)
		{
			return new Uri
			(
				new Uri
				(
					this._SARTopoUriBuilder.Uri,
					String.Format("/api/v1/map/{0}/", this.MapID)
				),
				element
			);
		}

		public void AddMarker(String title, String description, Double latitude, Double longitude, Marker marker)
		{
			String jsonString =
			(
				"{" +
					"\"id\":null," +
					"\"geometry\":" +
						"{" +
							"\"type\":\"Point\"," +
							"\"coordinates\":[{@Longitude},{@Latitude}]" +
						"}," +
					"\"properties\":" +
					"{" +
						"\"title\":{@Title}," +
						"\"description\":{@Description}," +
						"\"folderId\":null," +
						"\"marker-symbol\":{@Marker.Symbol}," +
						"\"marker-color\":{@Marker.Color}," +
						"\"marker-rotation\":{@Marker.Rotation}" +
					"}" +
				"}"
			);
			jsonString = jsonString
				.Replace("{@Longitude}", longitude.ToString())
				.Replace("{@Latitude}", latitude.ToString())
				.Replace("{@Title}", (String.IsNullOrEmpty(title) ? "null" : "\"" + title + "\""))
				.Replace("{@Description}", (String.IsNullOrEmpty(description) ? "null" : "\"" + description + "\""))
				.Replace("{@Marker.Symbol}", (String.IsNullOrEmpty(marker.Symbol) ? "null" : "\"" + marker.Symbol + "\""))
				.Replace("{@Marker.Color}", (String.IsNullOrEmpty(marker.Color) ? "null" : "\"" + marker.Color + "\""))
				.Replace("{@Marker.Rotation}", (String.IsNullOrEmpty(marker.Rotation) ? "null" : "\"" + marker.Rotation + "\""));
			HttpResponseMessage result = this._HttpClient.PostAsync
			(
				this._GetAPIURI(this.MapID, "Marker"),
				new MultipartFormDataContent
				{
					{
						new StringContent
						(
							jsonString,
							UnicodeEncoding.UTF8,
							"application/json"
						),
						"json"
					}
				}
			).Result;
		}
	}
}
