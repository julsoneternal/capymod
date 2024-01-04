using System;
using HighlightingSystem;
using SDG.Unturned;
using UnityEngine;

namespace SmartlyDressedMama
{
	// Token: 0x0200000A RID: 10
	internal class Players : MonoBehaviour
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00006FBC File Offset: 0x000051BC
		public void IncreaseLocalPlayerScale()
		{
			this.scaleChanged = true;
			if (this.playersScale > 0)
			{
				this.localPlayerScale++;
				this.UpdatePlayers();
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00006FE2 File Offset: 0x000051E2
		public void DecreaseLocalPlayerScale()
		{
			this.scaleChanged = true;
			if (this.playersScale > 0)
			{
				this.localPlayerScale--;
				this.UpdatePlayers();
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00007008 File Offset: 0x00005208
		public void ResetPlayersScale()
		{
			this.localPlayerScale = 1;
			this.playersScale = 1;
			this.UpdatePlayers();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000701E File Offset: 0x0000521E
		public void IncreasePlayersScale()
		{
			this.scaleChanged = true;
			if (this.playersScale > 0)
			{
				this.playersScale++;
				this.UpdatePlayers();
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00007044 File Offset: 0x00005244
		public void DecreasePlayersScale()
		{
			this.scaleChanged = true;
			if (this.playersScale > 1)
			{
				this.playersScale--;
				this.UpdatePlayers();
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000706A File Offset: 0x0000526A
		private void Update()
		{
			if (!Config.enabled)
			{
				return;
			}
			this.lastRefreshTime += Time.deltaTime;
			if (this.lastRefreshTime > Config.Players.refreshInterval)
			{
				this.UpdatePlayers();
				this.lastRefreshTime = 0f;
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000070A4 File Offset: 0x000052A4
		private void OnGUI()
		{
			if (!Config.Players.enabled || !Config.enabled)
			{
				return;
			}
			this.DrawPlayers();
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000070BC File Offset: 0x000052BC
		private void DrawPlayers()
		{
			foreach (Player player in this.players)
			{
				try
				{
					this.DrawPlayer(player);
				}
				catch (Exception arg)
				{
					Logger.Log(string.Format("Ошибка при отрисовке игрока: {0}", arg));
				}
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00007110 File Offset: 0x00005310
		private void DrawPlayer(Player player)
		{
			if (player == this.localPlayer || player == null)
			{
				return;
			}
			Vector3 position = player.transform.position;
			float num = Vector3.Distance(Camera.main.transform.position, position);
			if (num > Config.Players.maxDistance)
			{
				return;
			}
			Vector3 vector;
			vector..ctor(position.x, position.y, position.z);
			Vector3 vector2;
			vector2..ctor(position.x, position.y + 2f, position.z);
			Vector3 vector3 = Camera.main.WorldToScreenPoint(vector);
			Vector3 vector4 = Camera.main.WorldToScreenPoint(vector2);
			if (vector3.z <= 0f)
			{
				return;
			}
			float num2 = vector4.y - vector3.y;
			float num3 = num2 / 1.8f;
			Vector2 vector5 = vector3;
			Vector2 vector6 = vector4;
			vector5.x = vector3.x - num3 / 2f;
			vector6.x = vector4.x - num3 / 2f;
			vector5.y = (float)Screen.height - vector5.y;
			vector6.y = (float)Screen.height - vector6.y;
			Vector2 vector7;
			vector7..ctor((float)Screen.width / 2f, (float)Screen.height);
			Vector2.Lerp(vector7, vector5, 0.8f);
			Color color = Config.Players.defaultEspColor;
			float num4 = Config.Players.defaultEspThickness;
			if (Config.Players.distanceVisible >= num)
			{
				color = Config.Players.visibleEspColor;
				num4 = Config.Players.visibleEspThickness;
			}
			if (player.life.isDead)
			{
				color = Config.Players.deadEspColor;
				num4 = Config.Players.deadEspThickness;
			}
			if (Config.Players.highlight)
			{
				this.HighlightPlayer(player, Config.Players.highlightColor);
			}
			else
			{
				this.UnhighlightPlayer(player);
			}
			if (Config.Players.espBox)
			{
				Drawer.DrawBox(vector6.x, vector6.y, num3, num2, num4, color);
				if (Config.Players.espInfo && Config.Players.espDistance && !Config.Players.espLine)
				{
					this.DrawPlayerInfo(player, vector5, num, color, true);
				}
				else if ((Config.Players.espInfo && !Config.Players.espDistance) || Config.Players.espLine)
				{
					this.DrawPlayerInfo(player, vector5, num, color, false);
				}
				if (Config.Players.espLine)
				{
					Vector2 vector8;
					switch (Config.Players.espLineStart)
					{
					case Config.Players.ESPLineStart.верх:
						vector8..ctor((float)Screen.width / 2f, 0f);
						break;
					case Config.Players.ESPLineStart.центр:
						vector8..ctor((float)Screen.width / 2f, (float)Screen.height / 2f);
						break;
					case Config.Players.ESPLineStart.низ:
						vector8 = vector7;
						break;
					default:
						vector8 = vector7;
						break;
					}
					this.DrawLine(vector8, new Vector2(vector3.x, vector5.y), num4, color);
					if (Config.Players.espDistance)
					{
						Drawer.DrawString(Vector2.Lerp(vector8, vector5, 0.7f), string.Format("{0}m", Mathf.Round(num)), Config.Players.distanceColor, 1f, true, false);
					}
				}
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000073F9 File Offset: 0x000055F9
		private void DrawLine(Vector2 startPos, Vector2 playerFootPos, float espThickness, Color espColor)
		{
			Drawer.DrawLine(startPos, playerFootPos, espThickness, espColor);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00007408 File Offset: 0x00005608
		private void DrawPlayerInfo(Player player, Vector2 screenFootPos, float distanceToPlayer, Color color, bool showDistance = false)
		{
			string text = "<size=10>";
			text += player.channel.owner.playerID.characterName;
			if (player.life.isDead)
			{
				text += "\nМёртв";
			}
			if (Config.Players.espIsBleeding && player.life.isBleeding && !player.life.isDead)
			{
				text += "\nКровотёк";
			}
			if (Config.Players.espIsBrokenLeg && player.life.isBroken)
			{
				text += "\nСломана нога";
			}
			if (Config.Players.espShowWeapon && player.equipment.asset != null)
			{
				text = text + "\n[" + player.equipment.asset.itemName + "]";
			}
			if (showDistance)
			{
				text += string.Format("\n{0}m", Mathf.Round(distanceToPlayer));
			}
			text += "</size>";
			float num = 120f;
			float num3;
			if (distanceToPlayer > num)
			{
				float maxDistance = Config.Players.maxDistance;
				float num2 = 0.5f;
				num3 = Mathf.Lerp(1f, num2, (distanceToPlayer - num) / (maxDistance - num));
				num3 = Mathf.Clamp(num3, num2, 1f);
			}
			else
			{
				num3 = 1f;
			}
			Drawer.DrawString(new Vector2(screenFootPos.x, screenFootPos.y), text, color, num3, true, true);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000755B File Offset: 0x0000575B
		private void HighlightPlayer(Player player, Color color)
		{
			player.gameObject.GetComponent<Highlighter>().ConstantOnImmediate(color);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00007570 File Offset: 0x00005770
		private void UnhighlightPlayer(Player player)
		{
			try
			{
				player.GetComponent<Highlighter>().ConstantOffImmediate();
			}
			catch
			{
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000075A0 File Offset: 0x000057A0
		private void UpdatePlayers()
		{
			Player[] array = Object.FindObjectsOfType<Player>();
			foreach (Player player in array)
			{
				if (player.GetComponent<Highlighter>() == null)
				{
					player.gameObject.AddComponent<Highlighter>();
				}
				if (this.scaleChanged)
				{
					if (player == this.localPlayer)
					{
						player.gameObject.transform.localScale = new Vector3((float)this.localPlayerScale, (float)this.localPlayerScale, (float)this.localPlayerScale);
					}
					else
					{
						player.gameObject.transform.localScale = new Vector3((float)this.playersScale, (float)this.playersScale, (float)this.playersScale);
					}
				}
			}
			if (this.localPlayer == null)
			{
				this.localPlayer = this.GetLocalPlayer();
			}
			this.players = array;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00007668 File Offset: 0x00005868
		private Player GetLocalPlayer()
		{
			return Camera.main.GetComponentInParent<Player>();
		}

		// Token: 0x04000039 RID: 57
		public Player localPlayer;

		// Token: 0x0400003A RID: 58
		public Player[] players;

		// Token: 0x0400003B RID: 59
		public int playersScale = 1;

		// Token: 0x0400003C RID: 60
		public int localPlayerScale = 1;

		// Token: 0x0400003D RID: 61
		private bool scaleChanged;

		// Token: 0x0400003E RID: 62
		private float lastRefreshTime;
	}
}
