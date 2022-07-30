using System;
namespace Application.Util.Root
{
	public class Root
	{
		private static DirectoryInfo BaseDirectoryInfo =new  DirectoryInfo(AppContext.BaseDirectory);
		public static string RootPath { get {
				return BaseDirectoryInfo.Parent.Parent.Parent.FullName;
			}  }
	}
}

