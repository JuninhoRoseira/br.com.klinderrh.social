using System;

namespace br.com.klinderrh.social.infra.comum
{
	public static class StringExtensions
	{
		public static int ToInteger(this string value)
		{
			int intValue;

			int.TryParse(value, out intValue);

			return intValue;

		}

		public static int? ToNulleableInteger(this string value)
		{
			int? intValue = null;

			if (!string.IsNullOrWhiteSpace(value))
			{
				intValue = int.Parse(value);
			}
			
			return intValue;

		}

		public static Guid ToGuid(this string value)
		{
			Guid guidValue;

			Guid.TryParse(value, out guidValue);

			return guidValue;

		}

		public static Guid? ToNulleableGuid(this string value)
		{
			Guid? guidValue = null;

			if (!string.IsNullOrWhiteSpace(value))
			{
				guidValue = Guid.Parse(value);
			}

			return guidValue;

		}

	}

}