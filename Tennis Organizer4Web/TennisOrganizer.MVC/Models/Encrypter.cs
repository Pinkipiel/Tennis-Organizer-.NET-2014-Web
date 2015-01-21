using System;
using System.Text;
using System.Security.Cryptography;

namespace TennisOrganizer.MVC.Models
{
	// klasa służąca do hashowania danych
	public class Encrypter
	{
		private static byte[] GetBytes(string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}
		private static string GetString(byte[] bytes)
		{
			char[] chars = new char[bytes.Length / sizeof(char)];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			//return new string(chars);
			return Convert.ToBase64String(bytes);
		}
		/// <summary>
		/// Metoda zwraca hash otrzymany algorytmem SHA256 z podanego source.
		/// </summary>
		public static string GetSHA256Hash(string source)
		{
			byte[] b = Encoding.Unicode.GetBytes(source);
			//byte[] b = Encoding.UTF8.GetBytes(source);
			SHA256 encrypter = SHA256Managed.Create();
			byte[] hash = encrypter.ComputeHash(b);
			return GetString(hash);
		}
	}
}
