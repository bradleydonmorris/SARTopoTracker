using Newtonsoft.Json;
using System;
using System.Text;

namespace SARTopoTracker
{
	public class Statics
	{
		public static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
		{
			DateFormatHandling = DateFormatHandling.IsoDateFormat,
			DateParseHandling = DateParseHandling.DateTimeOffset,
			DateTimeZoneHandling = DateTimeZoneHandling.Utc,
			Formatting = Newtonsoft.Json.Formatting.Indented,
			NullValueHandling = NullValueHandling.Include
		};

		public static String GetHash(Object obj)
		{
			System.Security.Cryptography.SHA256Managed sha256Managed = new System.Security.Cryptography.SHA256Managed();
			Byte[] checksum = sha256Managed.ComputeHash(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj, Statics.JsonSerializerSettings)));
			return BitConverter.ToString(checksum).Replace("-", String.Empty);
		}

		public static String GetToken(Object data)
		{
			System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256CryptoServiceProvider.Create();
			return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data, Statics.JsonSerializerSettings))));
		}

		public static String ToJSONString(Object obj)
		{
			return JsonConvert.SerializeObject(obj, Statics.JsonSerializerSettings);
		}

		public static T FromJSONString<T>(String data)
		{
			return JsonConvert.DeserializeObject<T>(data, Statics.JsonSerializerSettings);
		}

		public static string GetUniqueString(Int32 length)
		{
			Char[] character = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
			Byte[] data = new Byte[4 * length];
			using (System.Security.Cryptography.RNGCryptoServiceProvider crypto = new System.Security.Cryptography.RNGCryptoServiceProvider())
			{
				crypto.GetBytes(data);
			}
			StringBuilder stringBuilder = new StringBuilder(length);
			for (Int32 index = 0; index < length; index++)
				stringBuilder.Append(character[BitConverter.ToUInt32(data, index * 4) % character.Length]);
			return stringBuilder.ToString();
		}

		public static string GetUniqueString(Int32 length, String allowedCharacters)
		{
			Char[] character = allowedCharacters.ToCharArray();
			Byte[] data = new Byte[4 * length];
			using (System.Security.Cryptography.RNGCryptoServiceProvider crypto = new System.Security.Cryptography.RNGCryptoServiceProvider())
			{
				crypto.GetBytes(data);
			}
			StringBuilder stringBuilder = new StringBuilder(length);
			for (Int32 index = 0; index < length; index++)
				stringBuilder.Append(character[BitConverter.ToUInt32(data, index * 4) % character.Length]);
			return stringBuilder.ToString();
		}
	}
}
