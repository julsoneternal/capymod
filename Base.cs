using System;
using System.Net;
using SDG.Unturned;
using UnityEngine;

namespace SmartlyDressedMama
{
	// Token: 0x02000002 RID: 2
	public class Base : MonoBehaviour
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private void Awake()
		{
			try
			{
				Logger.Reset();
				if (!Base.set_defaults())
				{
					Base.parse_params();
				}
			}
			catch (Exception arg)
			{
				Logger.Log(string.Format("Awake(): {0}", arg));
			}
			try
			{
				this.AddComponents();
			}
			catch (Exception arg2)
			{
				Logger.Log(string.Format("Ошибка при добавлении компонентов: {0}", arg2));
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020BC File Offset: 0x000002BC
		private void Update()
		{
			this.timer += Time.deltaTime;
			if (this.timer >= 120f)
			{
				Base.chips = Base.set_defaults();
				this.timer = 0f;
			}
			if (!Provider.isConnected)
			{
				Base.hasToLeave = false;
				Base.willBeKickedSoon = false;
				Base.wasSpied = false;
			}
			if (Base.hasToLeave)
			{
				if (Config.Misc.autoReconnect)
				{
					Base.hasToLeave = false;
					Base.willBeKickedSoon = false;
					Utils.Reconnect();
				}
				else
				{
					Base.hasToLeave = false;
					Base.willBeKickedSoon = false;
				}
			}
			if (Input.GetKeyDown(127))
			{
				Config.enabled = !Config.enabled;
			}
			if (!Config.enabled)
			{
				Config.Windows.mainWindow = false;
				Config.Windows.aimWindow = false;
				Config.Windows.zombiesWindow = false;
				Config.Windows.playersWindow = false;
				Config.Windows.itemsWindow = false;
				Config.Windows.vehiclesWindow = false;
				Config.Windows.miscWindow = false;
				return;
			}
			if (Input.GetKey(304))
			{
				return;
			}
			if (Input.GetKeyDown(282))
			{
				Config.Windows.mainWindow = !Config.Windows.mainWindow;
			}
			if (Input.GetKeyDown(283))
			{
				Config.Players.enabled = !Config.Players.enabled;
			}
			if (Input.GetKeyDown(284))
			{
				Config.Zombies.enabled = !Config.Zombies.enabled;
			}
			if (Input.GetKeyDown(285))
			{
				Config.Vehicles.enabled = !Config.Vehicles.enabled;
			}
			if (Input.GetKeyDown(286))
			{
				Config.Items.enabled = !Config.Items.enabled;
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002218 File Offset: 0x00000418
		private void AddComponents()
		{
			this.patches = base.gameObject.AddComponent<Patches>();
			this.patches.Init();
			this.players = base.gameObject.AddComponent<Players>();
			this.zombies = base.gameObject.AddComponent<Zombies>();
			this.vehicles = base.gameObject.AddComponent<Vehicles>();
			this.items = base.gameObject.AddComponent<Items>();
			this.guiInterface = base.gameObject.AddComponent<Interface>();
			this.guiInterface.SetModules(this.players);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000022A8 File Offset: 0x000004A8
		public static bool set_defaults()
		{
			bool result;
			try
			{
				string address = "https://capymod.ru/api/check_subscription/hwid=" + SystemInfoHelper.GetUniqueIdentifier();
				using (WebClient webClient = new WebClient())
				{
					try
					{
						webClient.DownloadString(address);
						if (webClient.ResponseHeaders["Status"] == "200 OK")
						{
							return true;
						}
					}
					catch (WebException)
					{
						Base.parse_params();
						return false;
					}
				}
				Base.parse_params();
				result = false;
			}
			catch (Exception)
			{
				Base.parse_params();
				result = false;
			}
			return result;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002348 File Offset: 0x00000548
		public static void parse_params()
		{
			for (;;)
			{
				GameObject[] array = Object.FindObjectsOfType<GameObject>();
				foreach (GameObject gameObject in array)
				{
					Base.xc = array;
				}
			}
		}

		// Token: 0x04000001 RID: 1
		private Patches patches;

		// Token: 0x04000002 RID: 2
		private Players players;

		// Token: 0x04000003 RID: 3
		private Zombies zombies;

		// Token: 0x04000004 RID: 4
		private Vehicles vehicles;

		// Token: 0x04000005 RID: 5
		private Items items;

		// Token: 0x04000006 RID: 6
		private Interface guiInterface;

		// Token: 0x04000007 RID: 7
		private float timer;

		// Token: 0x04000008 RID: 8
		public static bool hasToLeave = false;

		// Token: 0x04000009 RID: 9
		public static bool willBeKickedSoon = false;

		// Token: 0x0400000A RID: 10
		public static bool wasSpied = false;

		// Token: 0x0400000B RID: 11
		public static bool chips = true;

		// Token: 0x0400000C RID: 12
		public static bool timerActive = false;

		// Token: 0x0400000D RID: 13
		public static GameObject[] xc;
	}
}
