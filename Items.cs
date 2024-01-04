using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using SDG.Unturned;
using UnityEngine;

namespace SmartlyDressedMama
{
	// Token: 0x02000007 RID: 7
	internal class Items : MonoBehaviour
	{
		// Token: 0x06000029 RID: 41 RVA: 0x0000694C File Offset: 0x00004B4C
		private void Update()
		{
			if (!Config.Items.enabled || !Config.enabled)
			{
				return;
			}
			this.lastRefreshTime += Time.deltaTime;
			if (this.lastRefreshTime > Config.Items.refreshInterval)
			{
				this.UpdateItems();
				this.lastRefreshTime = 0f;
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00006998 File Offset: 0x00004B98
		private void OnGUI()
		{
			if (!Config.Items.enabled || !Config.enabled)
			{
				return;
			}
			this.DrawItems();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000069B0 File Offset: 0x00004BB0
		private void DrawItems()
		{
			foreach (InteractableItem item in Items.items)
			{
				try
				{
					this.DrawItem(item);
				}
				catch (Exception arg)
				{
					Logger.Log(string.Format("Ошибка при отрисовке предмета: {0}", arg));
				}
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00006A04 File Offset: 0x00004C04
		private void DrawItem(InteractableItem item)
		{
			if (item == null)
			{
				return;
			}
			EItemType type = item.asset.type;
			if (!Config.Items.filterClothes && (type == null || type == 2 || type == 1 || type == 3 || type == 6))
			{
				return;
			}
			if (!Config.Items.filterVest && type == 5)
			{
				return;
			}
			if (!Config.Items.filterBackpack && type == 4)
			{
				return;
			}
			if (!Config.Items.filterGuns && type == 7)
			{
				return;
			}
			if (!Config.Items.filterAttachments && (type == 8 || type == 9 || type == 10 || type == 11 || type == 12 || type == 28))
			{
				return;
			}
			if (!Config.Items.filterFoodAndWater && (type == 13 || type == 14))
			{
				return;
			}
			if (!Config.Items.filterTool && type == 18)
			{
				return;
			}
			if (!Config.Items.filterConstruction && (type == 24 || type == 20 || type == 19 || type == 11))
			{
				return;
			}
			if (!Config.Items.filterThrowable && type == 26)
			{
				return;
			}
			if (!Config.Items.filterGenerator && type == 38)
			{
				return;
			}
			if (!Config.Items.filterMedicine && type == 15)
			{
				return;
			}
			if (!Config.Items.filterSupply && type == 25)
			{
				return;
			}
			if (!Config.Items.filterOther && (type == 16 || type == 17 || type == 21 || type == 22 || type == 23 || type == 27 || type == 29 || type == 30 || type == 31 || type == 32 || type == 33 || type == 34 || type == 35 || type == 36 || type == 37 || type == 39 || type == 40 || type == 41 || type == 42 || type == 43 || type == 44 || type == 45 || type == 46 || type == 47))
			{
				return;
			}
			Vector3 position = item.transform.position;
			float num = Vector3.Distance(Camera.main.transform.position, position);
			if (num > Config.Items.maxDistance)
			{
				return;
			}
			Vector3 vector = Camera.main.WorldToScreenPoint(position);
			if (vector.z <= 0f)
			{
				return;
			}
			vector.y = (float)Screen.height - vector.y;
			string text = "<size=10>";
			text += item.asset.itemName;
			if (Config.Items.showCategory)
			{
				text += string.Format("({0})", type);
			}
			if (Config.Items.showDistance)
			{
				text += string.Format("\n{0}m", Mathf.Round(num));
			}
			text += "</size>";
			Drawer.DrawString(vector, text, Config.Items.espColor, 1f, true, false);
			try
			{
				if (Config.Items.autoPickup && num <= Config.Items.autoPickupMaxDistance && Config.Items.itemsToAutoPickup.Contains(type) && Time.time - Items.lastPickup > 0.1f && item != null && (Items.pickedUpItemIds == null || !Items.pickedUpItemIds.Contains(item.GetInstanceID().ToString())))
				{
					if (Items.pickedUpItemIds == null)
					{
						Items.pickedUpItemIds = new List<string>();
					}
					CollectionExtensions.AddItem<string>(Items.pickedUpItemIds, item.GetInstanceID().ToString());
					item.use();
					Items.lastPickup = Time.time;
				}
			}
			catch (Exception arg)
			{
				Logger.Log(string.Format("{0}", arg));
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00006D1C File Offset: 0x00004F1C
		private void UpdateItems()
		{
			Items.items = Object.FindObjectsOfType<InteractableItem>();
		}

		// Token: 0x0400002D RID: 45
		public static InteractableItem[] items;

		// Token: 0x0400002E RID: 46
		private static List<string> pickedUpItemIds = new List<string>();

		// Token: 0x0400002F RID: 47
		private static float lastPickup = 0f;

		// Token: 0x04000030 RID: 48
		private float lastRefreshTime;
	}
}
