using System;
using System.IO;

namespace SmartlyDressedMama
{
	// Token: 0x02000008 RID: 8
	internal class Logger
	{
		// Token: 0x06000030 RID: 48 RVA: 0x00006D48 File Offset: 0x00004F48
		public static void Log(string message)
		{
			if (!Config.debug)
			{
				return;
			}
			using (StreamWriter streamWriter = new StreamWriter(Path.Combine(Environment.GetFolderPath(Logger.logFileFolder), Logger.logFileName), true))
			{
				streamWriter.WriteLine(message);
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00006D9C File Offset: 0x00004F9C
		public static void Reset()
		{
			if (!Config.debug)
			{
				return;
			}
			File.WriteAllText(Path.Combine(Environment.GetFolderPath(Logger.logFileFolder), Logger.logFileName), string.Empty);
		}

		// Token: 0x04000031 RID: 49
		private static string logFileName = "log";

		// Token: 0x04000032 RID: 50
		private static Environment.SpecialFolder logFileFolder = Environment.SpecialFolder.Personal;
	}
}
