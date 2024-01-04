using System;
using System.Diagnostics;

namespace SmartlyDressedMama
{
	// Token: 0x0200000C RID: 12
	internal static class SystemInfoHelper
	{
		// Token: 0x0600004A RID: 74 RVA: 0x00007DE8 File Offset: 0x00005FE8
		private static string GetUserName()
		{
			return Environment.UserName;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00007DF0 File Offset: 0x00005FF0
		private static string GetHWID()
		{
			Process process = new Process();
			process.StartInfo.FileName = "wmic";
			process.StartInfo.Arguments = "csproduct get uuid";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			string text = process.StandardOutput.ReadToEnd();
			process.WaitForExit();
			return text.Trim().Replace("\r", "").Split(new char[]
			{
				'\n'
			})[1].Trim();
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00007E8C File Offset: 0x0000608C
		public static string GetUniqueIdentifier()
		{
			string result;
			try
			{
				string userName = SystemInfoHelper.GetUserName();
				string hwid = SystemInfoHelper.GetHWID();
				result = userName + ":" + hwid;
			}
			catch (Exception ex)
			{
				Logger.Log(ex.ToString());
				result = "";
			}
			return result;
		}
	}
}
