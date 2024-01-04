using System;
using SDG.Unturned;
using UnityEngine;

namespace SmartlyDressedMama
{
	// Token: 0x02000010 RID: 16
	internal class Zombies : MonoBehaviour
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x00008BA0 File Offset: 0x00006DA0
		private void Update()
		{
			if (!Config.enabled || !Config.Zombies.enabled)
			{
				return;
			}
			this.lastRefreshTime += Time.deltaTime;
			if (this.lastRefreshTime > Config.Zombies.refreshInterval)
			{
				this.UpdateZombies();
				this.lastRefreshTime = 0f;
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00008BEC File Offset: 0x00006DEC
		private void OnGUI()
		{
			if (!Config.enabled || !Config.Zombies.enabled)
			{
				return;
			}
			this.DrawZombies();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00008C04 File Offset: 0x00006E04
		private void DrawZombies()
		{
			foreach (Zombie zombie in Zombies.zombies)
			{
				try
				{
					this.DrawZombie(zombie);
				}
				catch (Exception arg)
				{
					Logger.Log(string.Format("Ошибка при отрисовке зомби: {0}", arg));
				}
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00008C58 File Offset: 0x00006E58
		private void DrawZombie(Zombie zombie)
		{
			if (zombie.isDead || zombie == null)
			{
				return;
			}
			Vector3 position = zombie.transform.position;
			float num = Vector3.Distance(Camera.main.transform.position, position);
			if (num > Config.Zombies.maxDistance)
			{
				return;
			}
			Vector3 vector = Camera.main.WorldToScreenPoint(position);
			if (vector.z <= 0f)
			{
				return;
			}
			vector.y = (float)Screen.height - vector.y;
			string text = zombie.name;
			if (Config.Zombies.showDistance)
			{
				text += string.Format("\n{0}m", Mathf.Round(num));
			}
			Drawer.DrawString(vector, text, Config.Zombies.espColor, 1f, true, false);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00008D12 File Offset: 0x00006F12
		private void UpdateZombies()
		{
			Zombies.zombies = Object.FindObjectsOfType<Zombie>();
		}

		// Token: 0x04000044 RID: 68
		public static Zombie[] zombies;

		// Token: 0x04000045 RID: 69
		private float lastRefreshTime;
	}
}
