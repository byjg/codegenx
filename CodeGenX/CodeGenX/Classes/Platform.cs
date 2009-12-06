using System;

namespace CodeGenX.Classes
{
    public class Platform
    {

		public static bool isWindowsOS()
		{
			return System.Environment.OSVersion.Platform.ToString().ToLower().IndexOf("win") >= 0;
		}

		
		public static string Slash()
		{
			return isWindowsOS() ? "\\" : "/";
		}
		
		public static string FixPath(string path)
		{
			if (isWindowsOS())
			{
				return path.Replace("/", "\\");
			}
			else
			{
				return path.Replace("\\", "/");
			}
		}
		
    }

}
