#region Using

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Helpers
{
	public static class DisplayExtension
	{
		public static void Show<T>(this IEnumerable<T> source, Func<T, string> func)
		{
			foreach (var item in source)
			{
				Console.WriteLine(func(item));
			}
		}

		public static void ShowAndCompareWith<T>(this IEnumerable<T> source, IEnumerable<T> other, Func<T, string> func)
		{
			var firstArray = source.ToArray();
			var secondArray = other.ToArray();

			for (int i = 0; i < firstArray.Length; i++)
			{
				Console.WriteLine($" {func(firstArray[i])}  |  {func(secondArray[i])}");
			}
		}
	}
}
