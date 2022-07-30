using System;
namespace Application.Util.Extention
{
	/// <summary>
    /// Char
    /// </summary>
	public static partial class Extention
	{
		/// <summary>
		/// 0-1 a-z A-Z CharArray
		/// </summary>
		/// <returns>char[]</returns>
		public static char[]  GetCharacter()
        {
			string character= "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
			return	character.ToCharArray();
		}
	}
}
