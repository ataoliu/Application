using System;
namespace Application.Util
{
    /// <summary>
    /// APP的一些操作
    /// </summary>
    public class App
    {
        /// <summary>
        /// 程序根目录
        /// </summary>
        public static string ApplicationRootPath{ get { return AppDomain.CurrentDomain.BaseDirectory; } }
    }
}
