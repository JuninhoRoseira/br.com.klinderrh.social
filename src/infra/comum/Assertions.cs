using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace br.com.klinderrh.social.infra.comum
{
	public static class Assertions<TException> where TException : Exception
	{
		private static void Raise(params object[] args)
		{
			var expandedArgs = new object[args.Length];
			for (var i = 0; i < args.Length; ++i)
				expandedArgs[i] = args[i] is Delegate ? ((Delegate)args[0]).DynamicInvoke() : args[i];

			throw (TException)Activator.CreateInstance(typeof(TException), expandedArgs);
		}

		public static void AreEqual<T>(T expected, T received, params object[] args)
		{
			if (!Equals(expected, received))
				Raise(args);
		}

		public static void AreEqual(double expected, double received, double threshold, params object[] args)
		{
			if (Math.Abs(expected - received) >= threshold)
				Raise(args);
		}

		public static void AreNotEqual<T>(T expected, T received, params object[] args)
		{
			if (Equals(expected, received))
				Raise(args);
		}

		public static void AreNotEqual(double expected, double received, double threshold, params object[] args)
		{
			if (Math.Abs(expected - received) < threshold)
				Raise(args);
		}

		public static void IsTrue(bool value, params object[] args)
		{
			if (!value)
				Raise(args);
		}

		public static void IsFalse(bool value, params object[] args)
		{
			if (value)
				Raise(args);
		}

		public static void IsNull(object value, params object[] args)
		{
			if (value != null)
				Raise(args);
		}

		public static void IsNotNull(object value, params object[] args)
		{
			if (value == null)
				Raise(args);
		}

		public static void IsNotNullOrEmpty(object value, params object[] args)
		{
			if (value == null || string.IsNullOrEmpty((string)value))
				Raise(args);
		}

		public static void IsGreaterOrEquasTo(decimal value, decimal expected, params object[] args)
		{
			if (value < expected)
				Raise(args);
		}

		public static void IsNotGreaterOrEquasTo(decimal value, decimal expected, params object[] args)
		{
			if (value >= expected)
				Raise(args);
		}

		public static void ShouldThrow<T>(Action action, params object[] args) where T : Exception
		{
			try
			{
				action();
			}
			catch (T)
			{
				return;
			}
			Raise(args);
		}

		public static void SequenceEqual<T>(IEnumerable<T> first, IEnumerable<T> second, params object[] args)
		{
			if (!first.SequenceEqual(second))
				Raise(args);
		}

		public static void IsValidEmail(string email, params object[] args)
		{
			var isEmail = Regex.IsMatch(
				email,
				@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
				RegexOptions.IgnoreCase);

			if (!isEmail)
				Raise(args);

		}

	}

}