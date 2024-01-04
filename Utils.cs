using System;
using SDG.Unturned;
using UnityEngine;

namespace SmartlyDressedMama
{
	// Token: 0x0200000E RID: 14
	internal class Utils : MonoBehaviour
	{
		// Token: 0x06000095 RID: 149 RVA: 0x0000846C File Offset: 0x0000666C
		public static string GenerateRandomString(int length)
		{
			Random random = new Random();
			char[] array = new char[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"[random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".Length)];
			}
			return new string(array);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000084B8 File Offset: 0x000066B8
		public static void Reconnect()
		{
			SteamServerInfo currentServerInfo = Provider.currentServerInfo;
			Provider.disconnect();
			MenuPlayConnectUI.connect(new SteamConnectionInfo(currentServerInfo.ip, currentServerInfo.queryPort, ""), true);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000084EC File Offset: 0x000066EC
		public static void Disconnect()
		{
			if (Provider.isConnected)
			{
				Provider.disconnect();
				Base.willBeKickedSoon = false;
				Base.hasToLeave = false;
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00008508 File Offset: 0x00006708
		public static Texture2D MakeTex(int width, int height, Color color)
		{
			Color[] array = new Color[width * height];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = color;
			}
			Texture2D texture2D = new Texture2D(width, height);
			texture2D.SetPixels(array);
			texture2D.Apply();
			return texture2D;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00008548 File Offset: 0x00006748
		public static Color ColorFromHEX(string hex)
		{
			Color result;
			if (ColorUtility.TryParseHtmlString(hex, ref result))
			{
				return result;
			}
			return Color.gray;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00008566 File Offset: 0x00006766
		public static string HEXFromColor(Color color)
		{
			return ColorUtility.ToHtmlStringRGBA(color);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00008570 File Offset: 0x00006770
		public static Player GetFOVPlayer()
		{
			Player[] array = Object.FindObjectsOfType<Player>();
			Player result = null;
			float num = 9999f;
			foreach (Player player in array)
			{
				float num2 = Vector3.Distance(Camera.main.transform.position, player.transform.position);
				if (!player.channel.IsLocalPlayer && !player.life.isDead && num2 <= Config.Aim.maxDistance && Vector3.Angle(Camera.main.transform.forward, player.look.getEyesPosition() - Camera.main.transform.position) <= Config.Aim.angle / Utils.angleDivider && num2 < num)
				{
					result = player;
					num = num2;
				}
			}
			return result;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00008638 File Offset: 0x00006838
		public static Zombie GetFOVZombie()
		{
			Zombie[] array = Object.FindObjectsOfType<Zombie>();
			Zombie result = null;
			float num = 9999f;
			foreach (Zombie zombie in array)
			{
				float num2 = Vector3.Distance(Camera.main.transform.position, zombie.transform.position);
				if (!zombie.isDead && num2 <= Config.Aim.maxDistance && Vector3.Angle(Camera.main.transform.forward, zombie.transform.position - Camera.main.transform.position) <= Config.Aim.angle / Utils.angleDivider && num2 < num)
				{
					result = zombie;
					num = num2;
				}
			}
			return result;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000086F0 File Offset: 0x000068F0
		public static bool IsPlayerInFOV(Vector3 cameraPosition, Vector3 cameraForward, Vector3 playerPosition)
		{
			Vector3 vector = playerPosition - cameraPosition;
			return Vector3.Angle(cameraForward, vector) <= Config.Aim.angle / Utils.angleDivider;
		}

		// Token: 0x04000041 RID: 65
		private static float angleDivider = 1.5f;
	}
}
