﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeRingsSharp.XansData {

	/// <summary>
	/// Provides some handy extension methods for <see cref="string"/>.
	/// </summary>
	public static class StringExtension {
		/// <summary>
		/// Returns a <see langword="string"/> of everything after the first located instance of <paramref name="text"/>. This does not include the sequence. For instance, if the text <c>cool.beans.nice.meme</c> is input and the method is called with a parameter of <c>nice.</c> for <paramref name="text"/>, the return value will be <c>meme</c><para/>
		/// Returns <see langword="null"/> if <paramref name="text"/> could not be found.
		/// </summary>
		/// <param name="str">The string to search.</param>
		/// <param name="text">The text to locate.</param>
		/// <returns></returns>
		public static string AfterIndexOf(this string str, string text) {
			int idx = str.IndexOf(text);
			if (idx < 0) return null;
			if (idx + text.Length >= str.Length) return string.Empty;

			return str.Substring(idx + text.Length);
		}

		/// <summary>
		/// Returns a <see langword="string"/> of everything after the last located instance of <paramref name="text"/>. This does not include the sequence. For instance, if the text <c>cool.beans.nice.meme</c> is input and the method is called with a parameter of <c>nice.</c> for <paramref name="text"/>, the return value will be <c>meme</c><para/>
		/// Returns <see langword="null"/> if <paramref name="text"/> could not be found.
		/// </summary>
		/// <param name="str">The string to search.</param>
		/// <param name="text">The text to locate.</param>
		/// <returns></returns>
		public static string AfterLastIndexOf(this string str, string text) {
			int idx = str.LastIndexOf(text);
			if (idx < 0) return null;
			if (idx + text.Length >= str.Length) return string.Empty;

			return str.Substring(idx + text.Length);
		}

		/// <summary>
		/// Returns true if the string is alphanumeric, or, if it is within the range of a-z, A-Z, and 0-9.
		/// </summary>
		/// <param name="inp"></param>
		/// <returns></returns>
		public static bool IsAlphanumeric(this string inp) {
			foreach (char c in inp) {
				bool isNumber = (c >= 48 && c <= 57);
				bool isCap = (c >= 65 && c <= 90);
				bool isLow = (c >= 97 && c <= 122);
				bool ok = isNumber || isCap || isLow;
				if (!ok) return false;
			}
			return true;
		}
	}
}