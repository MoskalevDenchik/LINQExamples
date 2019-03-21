#region Using

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

#endregion

namespace Helpers
{
	public static class DataProvider
	{
		public static List<T> GetEntities<T>() where T : class, new()
		{
			var serializer = new DataContractJsonSerializer(typeof(List<T>));

			var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", $"{typeof(T).Name}s.json");

			using (var stream = new FileStream(filePath, FileMode.Open))
			{
				return (List<T>)serializer.ReadObject(stream);
			}
		}
	}
}
