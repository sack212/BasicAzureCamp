using System;
using System.Text;

namespace Data_Storage_Demos
{
	public static class StringExtensions
	{
		public static string ToBase64String(this string toBase64String)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(toBase64String));
		}

		public static string FromBase64String(this string fromBase64String)
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String(fromBase64String));
		}
	}
}