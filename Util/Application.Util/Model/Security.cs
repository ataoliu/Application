using System;
namespace Application.Util
{
	public class Security
	{
		private  int _length;
		public Security()
		{
		}
		/// <summary>
        /// 
        /// </summary>
        /// <param name="length">key的长度</param>
		public Security(int length)
        {
			this._length = length;
        }
		/// <summary>
        /// 密匙
        /// </summary>
		public  string SecretKey { get {return Extention.Extention.RandomString(_length); } }
	}
}

