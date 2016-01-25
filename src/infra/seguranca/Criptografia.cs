﻿using System;
using System.Security.Cryptography;

namespace br.com.klinderrh.social.infra.seguranca
{
	public class Criptografia
	{
		// The following constants may be changed without breaking existing hashes.
		public const int SALT_BYTE_SIZE = 24;
		public const int HASH_BYTE_SIZE = 24;
		public const int PBKDF2_ITERATIONS = 1000;

		public const int ITERATION_INDEX = 0;
		public const int SALT_INDEX = 1;
		public const int PBKDF2_INDEX = 2;

		/// <summary>
		/// Creates a salted PBKDF2 hash of the password.
		/// </summary>
		/// <param name="senha">The password to hash.</param>
		/// <returns>The hash of the password.</returns>
		public static string CriarHash(string senha)
		{
			// Generate a random salt
			var csprng = new RNGCryptoServiceProvider();
			var salt = new byte[SALT_BYTE_SIZE];

			csprng.GetBytes(salt);

			// Hash the password and encode the parameters
			var hash = PBKDF2(senha, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);

			return PBKDF2_ITERATIONS + ":" +
				Convert.ToBase64String(salt) + ":" +
				Convert.ToBase64String(hash);

		}

		/// <summary>
		/// Validates a password given a hash of the correct one.
		/// </summary>
		/// <param name="senha">The password to check.</param>
		/// <param name="hashCorreto">A hash of the correct password.</param>
		/// <returns>True if the password is correct. False otherwise.</returns>
		public static bool ValidarSenha(string senha, string hashCorreto)
		{
			// Extract the parameters from the hash
			char[] delimiter = { ':' };
			string[] split = hashCorreto.Split(delimiter);
			int iterations = Int32.Parse(split[ITERATION_INDEX]);
			byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
			byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

			byte[] testHash = PBKDF2(senha, salt, iterations, hash.Length);

			return SlowEquals(hash, testHash);

		}

		/// <summary>
		/// Compares two byte arrays in length-constant time. This comparison
		/// method is used so that password hashes cannot be extracted from
		/// on-line systems using a timing attack and then attacked off-line.
		/// </summary>
		/// <param name="a">The first byte array.</param>
		/// <param name="b">The second byte array.</param>
		/// <returns>True if both byte arrays are equal. False otherwise.</returns>
		private static bool SlowEquals(byte[] a, byte[] b)
		{
			uint diff = (uint)a.Length ^ (uint)b.Length;
			for (int i = 0; i < a.Length && i < b.Length; i++)
				diff |= (uint)(a[i] ^ b[i]);
			return diff == 0;
		}

		/// <summary>
		/// Computes the PBKDF2-SHA1 hash of a password.
		/// </summary>
		/// <param name="password">The password to hash.</param>
		/// <param name="salt">The salt.</param>
		/// <param name="iterations">The PBKDF2 iteration count.</param>
		/// <param name="outputBytes">The length of the hash to generate, in bytes.</param>
		/// <returns>A hash of the password.</returns>
		private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
		{
			var pbkdf2 = new Rfc2898DeriveBytes(password, salt)
			{
				IterationCount = iterations
			};

			return pbkdf2.GetBytes(outputBytes);

		}

	}

}