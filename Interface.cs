using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SDG.Unturned;
using UnityEngine;

namespace SmartlyDressedMama
{
	// Token: 0x02000006 RID: 6
	internal class Interface : MonoBehaviour
	{
		// Token: 0x06000018 RID: 24 RVA: 0x000028E4 File Offset: 0x00000AE4
		private void Awake()
		{
			this.defaultTextColor = new Color32(124, 22, 46, byte.MaxValue);
			this.windowBackground = Utils.MakeTex(2, 2, new Color32(17, 14, 27, 200));
			this.buttonBackground = Utils.MakeTex(2, 2, new Color32(25, 21, 40, byte.MaxValue));
			this.buttonHoverBackground = Utils.MakeTex(2, 2, new Color32(66, 22, 47, byte.MaxValue));
			this.sliderBackground = Utils.MakeTex(200, 20, new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
			this.sliderThumbBackground = Utils.MakeTex(10, 10, new Color32(124, 22, 46, byte.MaxValue));
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000029C8 File Offset: 0x00000BC8
		private void hideAllWindows()
		{
			try
			{
				Provider.modeConfigData.Gameplay.Timer_Leave_Group = 0U;
				Provider.modeConfigData.Gameplay.Satellite = true;
				Provider.modeConfigData.Gameplay.Timer_Exit = 0U;
				Provider.modeConfigData.Gameplay.Timer_Respawn = 0U;
			}
			catch
			{
			}
			Config.Windows.aimWindow = false;
			Config.Windows.playersWindow = false;
			Config.Windows.zombiesWindow = false;
			Config.Windows.vehiclesWindow = false;
			Config.Windows.itemsWindow = false;
			Config.Windows.miscWindow = false;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002A50 File Offset: 0x00000C50
		private void LateUpdate()
		{
			if (!Config.enabled)
			{
				return;
			}
			Time.timeScale = this.timeScale;
			float num = (float)this.players.localPlayer.life.health;
			if (num <= 10f && (Config.Misc.autokick_10hp || (Config.Misc.autokick_5hp && num <= 5f) || (Config.Misc.autokick_3hp && num <= 3f) || (Config.Misc.autokick_1hp && num <= 1f)))
			{
				Provider.disconnect();
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002AC8 File Offset: 0x00000CC8
		private void OnGUI()
		{
			if (!Config.enabled)
			{
				return;
			}
			this.ApplyGUIStyle();
			if (Config.Misc.crosshair && Provider.isConnected)
			{
				Drawer.DrawLine(new Vector2((float)Screen.width / 2f - 6f, (float)Screen.height / 2f - 1f), new Vector2((float)Screen.width / 2f + 6f, (float)Screen.height / 2f - 1f), 2f, Color.white);
				Drawer.DrawLine(new Vector2((float)Screen.width / 2f + 1f, (float)Screen.height / 2f - 6f), new Vector2((float)Screen.width / 2f + 1f, (float)Screen.height / 2f + 6f), 2f, Color.white);
			}
			if (Base.willBeKickedSoon && (Config.Misc.autoKick || Config.Misc.autoReconnect))
			{
				GUI.Box(new Rect((float)Screen.width - 210f, 10f, 200f, 20f), "Вы скоро будете кикнуты!");
			}
			if (Config.Aim.enabled)
			{
				if (Config.Aim.showAngle)
				{
					Drawer.DrawCircle(Config.Aim.angle, new Color(1f, 0.2f, 0.2f), 1.6f);
				}
				if (Config.Aim.showVictim)
				{
					Player fovplayer = Utils.GetFOVPlayer();
					if (fovplayer)
					{
						Vector2 vector = Camera.main.WorldToScreenPoint(new Vector3(fovplayer.transform.position.x, fovplayer.transform.position.y + 1.5f, fovplayer.transform.position.z));
						Drawer.DrawLine(new Vector2((float)(Screen.width / 2 - 1), (float)(Screen.height / 2 - 1)), new Vector2(vector.x + 2f, (float)Screen.height - vector.y), 2f, Color.magenta);
						Drawer.DrawBox(vector.x, (float)Screen.height - vector.y, 4f, 4f, 2f, Color.magenta);
					}
				}
			}
			if (!Config.Windows.mainWindow)
			{
				this.hideAllWindows();
			}
			if (Config.Windows.mainWindow)
			{
				this.mainWindowRect = GUI.Window(-1000, this.mainWindowRect, new GUI.WindowFunction(this.MainWindow), "<b>CapyMod v" + Config.version + "</b>", Interface.windowStyle);
				if (Config.debug)
				{
					float num = (float)Screen.width - 300f;
					float num2 = 30f;
					float num3 = 25f;
					GUI.Box(new Rect((float)Screen.width - 305f, 0f, 305f, (float)Screen.height), "Debug");
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Enable zoom", Interface.buttonStyle))
					{
						this.players.localPlayer.look.enableZoom(10f);
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Disable zoom", Interface.buttonStyle))
					{
						this.players.localPlayer.look.disableZoom();
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "FPS Boost", Interface.buttonStyle))
					{
						try
						{
							base.gameObject.AddComponent<FPSBoost>().ToggleFPSBoost();
						}
						catch (Exception ex)
						{
							Logger.Log(ex.ToString());
						}
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Recoil", Interface.buttonStyle))
					{
						this.players.localPlayer.look.recoil(10f, 10f, 10f, 10f);
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Respawn", Interface.buttonStyle))
					{
						this.players.localPlayer.life.ReceiveRespawnRequest(false);
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Life stats", Interface.buttonStyle))
					{
						this.players.localPlayer.life.ReceiveLifeStats(100, 100, 100, 100, 100, false, false);
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Stamina", Interface.buttonStyle))
					{
						this.players.localPlayer.life.ReceiveModifyStamina(100);
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Jump", Interface.buttonStyle))
					{
						this.players.localPlayer.movement.ReceivePluginJumpMultiplier(10f);
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Speed", Interface.buttonStyle))
					{
						this.players.localPlayer.movement.ReceivePluginSpeedMultiplier(10f);
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Gravity", Interface.buttonStyle))
					{
						this.players.localPlayer.movement.ReceivePluginGravityMultiplier(-5f);
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Teleport", Interface.buttonStyle))
					{
						this.players.localPlayer.ReceiveTeleport(new Vector3(0f, 0f, 0f), 90);
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Suicide", Interface.buttonStyle))
					{
						this.players.localPlayer.transform.position = new Vector3(0f, 0f, 0f);
						this.players.localPlayer.life.sendSuicide();
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Respawn", Interface.buttonStyle))
					{
						this.players.localPlayer.transform.position = new Vector3(0f, 0f, 0f);
						this.players.localPlayer.life.sendRespawn(false);
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Hallucination ON", Interface.buttonStyle))
					{
						this.players.localPlayer.life.serverModifyHallucination(255f);
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Hallucination OFF", Interface.buttonStyle))
					{
						this.players.localPlayer.life.serverModifyHallucination(1f);
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), string.Format("NoClip {0}", this.testbool), Interface.buttonStyle))
					{
						this.testbool = !this.testbool;
						if (this.testbool)
						{
							Player localPlayer = this.players.localPlayer;
							localPlayer.movement.enabled = false;
							Rigidbody component = localPlayer.GetComponent<Rigidbody>();
							component.constraints = 0;
							component.freezeRotation = false;
							component.useGravity = false;
							component.isKinematic = true;
							if (Input.GetKey(119))
							{
								component.MovePosition(localPlayer.transform.position + localPlayer.transform.forward * (1f * Time.fixedDeltaTime));
							}
						}
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), string.Format("timescale ({0}) +", this.timeScale), Interface.buttonStyle))
					{
						this.timeScale += 0.01f;
						Time.timeScale = this.timeScale;
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), string.Format("timescale ({0}) -", Time.timeScale), Interface.buttonStyle))
					{
						this.timeScale -= 0.01f;
						Time.timeScale = this.timeScale;
					}
					num2 += num3;
					RaycastHit raycastHit;
					if (Physics.Raycast(new Ray(MainCamera.instance.transform.position, MainCamera.instance.transform.forward), ref raycastHit, 500f, RayMasks.DAMAGE_CLIENT))
					{
						GUI.Label(new Rect(num, num2, 250f, 20f), raycastHit.transform.gameObject.name);
						num2 += num3 - 5f;
						GUI.Label(new Rect(num, num2, 250f, 20f), raycastHit.transform.gameObject.tag);
						num2 += num3 - 5f;
						GUI.Label(new Rect(num, num2, 250f, 20f), raycastHit.transform.gameObject.layer.ToString());
						num2 += num3 - 5f;
						GUI.Label(new Rect(num, num2, 250f, 20f), raycastHit.transform.position.ToString());
						num2 += num3 - 5f;
						GUI.Label(new Rect(num, num2, 250f, 20f), raycastHit.transform.rotation.ToString());
						num2 += num3 - 5f;
						foreach (Component component2 in raycastHit.transform.gameObject.GetComponents(typeof(Component)))
						{
							GUI.Label(new Rect(num, num2, 250f, 20f), component2.GetType().ToString());
							num2 += num3 - 5f;
						}
						string a = raycastHit.transform.tag.ToString();
						if (!(a == "Structure") && a == "Barricade")
						{
							InteractableFarm component3 = raycastHit.transform.gameObject.GetComponent<InteractableFarm>();
							GUI.Label(new Rect(num, num2, 250f, 20f), component3.tag);
							num2 += num3 - 5f;
						}
					}
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Compass", Interface.buttonStyle))
					{
						Provider.modeConfigData.Gameplay.Compass = true;
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Ballistics", Interface.buttonStyle))
					{
						Provider.modeConfigData.Gameplay.Ballistics = false;
					}
					num2 += num3;
					if (GUI.Button(new Rect(num, num2, 140f, 20f), "Crosshair OFF", Interface.buttonStyle))
					{
						Provider.modeConfigData.Gameplay.Crosshair = false;
					}
					num2 += num3;
				}
			}
			if (Config.Windows.aimWindow)
			{
				this.aimWindowRect = GUI.Window(1, this.aimWindowRect, new GUI.WindowFunction(this.AimWindow), "<b>" + Text.aim + "</b>", Interface.windowStyle);
			}
			if (Config.Windows.playersWindow)
			{
				PlayersWindow.playersWindowRect = GUI.Window(2, PlayersWindow.playersWindowRect, new GUI.WindowFunction(PlayersWindow.Window), "<b>" + Text.players + "</b>", Interface.windowStyle);
			}
			if (Config.Windows.zombiesWindow)
			{
				this.zombiesWindowRect = GUI.Window(3, this.zombiesWindowRect, new GUI.WindowFunction(this.ZombiesWindow), "<b>" + Text.zombies + "</b>", Interface.windowStyle);
			}
			if (Config.Windows.vehiclesWindow)
			{
				this.vehiclesWindowRect = GUI.Window(4, this.vehiclesWindowRect, new GUI.WindowFunction(this.VehiclesWindow), "<b>" + Text.vehicles + "</b>", Interface.windowStyle);
			}
			if (Config.Windows.itemsWindow)
			{
				this.itemsWindowRect = GUI.Window(5, this.itemsWindowRect, new GUI.WindowFunction(this.ItemsWindow), "<b>" + Text.items + "</b>", Interface.windowStyle);
			}
			if (Config.Windows.miscWindow)
			{
				this.miscWindowRect = GUI.Window(6, this.miscWindowRect, new GUI.WindowFunction(this.MiscWindow), "<b>" + Text.misc + "</b>", Interface.windowStyle);
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003798 File Offset: 0x00001998
		private void MainWindow(int WindowID)
		{
			if (GUI.Button(new Rect(5f, 20f, 150f, 30f), "<b>" + Text.aim + "</b>", Interface.buttonStyle))
			{
				this.SwitchWindow(Interface.Window.Aim);
			}
			if (GUI.Button(new Rect(5f, 55f, 150f, 30f), "<b>" + Text.players + "</b>", Interface.buttonStyle))
			{
				this.SwitchWindow(Interface.Window.Players);
			}
			if (GUI.Button(new Rect(5f, 90f, 150f, 30f), "<b>" + Text.zombies + "</b>", Interface.buttonStyle))
			{
				this.SwitchWindow(Interface.Window.Zombies);
			}
			if (GUI.Button(new Rect(5f, 125f, 150f, 30f), "<b>" + Text.vehicles + "</b>", Interface.buttonStyle))
			{
				this.SwitchWindow(Interface.Window.Vehicles);
			}
			if (GUI.Button(new Rect(5f, 160f, 150f, 30f), "<b>" + Text.items + "</b>", Interface.buttonStyle))
			{
				this.SwitchWindow(Interface.Window.Items);
			}
			if (GUI.Button(new Rect(5f, 195f, 150f, 30f), "<b>" + Text.misc + "</b>", Interface.buttonStyle))
			{
				this.SwitchWindow(Interface.Window.Misc);
			}
			if (GUI.Button(new Rect(5f, 230f, 75f, 20f), "<size=12><b>" + Text.reconnect + "</b></size>", Interface.buttonStyle))
			{
				Utils.Reconnect();
			}
			if (GUI.Button(new Rect(80f, 230f, 75f, 20f), "<size=12><b>" + Text.quit + "</b></size>", Interface.buttonStyle))
			{
				Utils.Disconnect();
			}
			if (GUI.Button(new Rect(5f, 250f, 75f, 20f), "<size=12><b>" + Text.langRus + "</b></size>", Interface.buttonStyle))
			{
				Text.currentLangId = 0;
			}
			if (GUI.Button(new Rect(80f, 250f, 75f, 20f), "<size=12><b>" + Text.langEng + "</b></size>", Interface.buttonStyle))
			{
				Text.currentLangId = 1;
			}
			GUIStyle guistyle = new GUIStyle(GUI.skin.label);
			guistyle.alignment = 4;
			GUI.color = new Color(0.8f, 0.8f, 0.9f);
			GUI.Label(new Rect(5f, 267f, 150f, 25f), "<size=10><b>www.capymod.ru</b></size>", guistyle);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003A73 File Offset: 0x00001C73
		private IEnumerator HarvestAll()
		{
			InteractableFarm[] array = Object.FindObjectsOfType<InteractableFarm>();
			InteractableFarm[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].use();
				yield return new WaitForSeconds(0.1f);
			}
			array2 = null;
			yield break;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003A7C File Offset: 0x00001C7C
		private void AimWindow(int WindowID)
		{
			float num = 20f;
			float num2 = 25f;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.noRecoil + ": " + (Config.Misc.noRecoil ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Misc.noRecoil = !Config.Misc.noRecoil;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.noSpread + ": " + (Config.Misc.noSpread ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Misc.noSpread = !Config.Misc.noSpread;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.onlyHeadshots + ": " + (Config.Misc.onlyHeadshots ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Misc.onlyHeadshots = !Config.Misc.onlyHeadshots;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.enabled + ": " + (Config.Aim.enabled ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Aim.enabled = !Config.Aim.enabled;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.melee + ": " + (Config.Aim.melee ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Aim.melee = !Config.Aim.melee;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.guns + ": " + (Config.Aim.guns ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Aim.guns = !Config.Aim.guns;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.aim_tp + ": " + (Config.Aim.tp ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Aim.tp = !Config.Aim.tp;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), "Зомби: " + (Config.Aim.zombie ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Aim.zombie = !Config.Aim.zombie;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.show_angle + ": " + (Config.Aim.showAngle ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Aim.showAngle = !Config.Aim.showAngle;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.show_victim + ": " + (Config.Aim.showVictim ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Aim.showVictim = !Config.Aim.showVictim;
			}
			num += num2;
			GUI.Label(new Rect(5f, num, 140f, 20f), "FOV (" + Config.Aim.angle.ToString("0") + "):");
			num += num2 - 5f;
			float num3 = GUI.HorizontalSlider(new Rect(5f, num, 140f, 20f), Config.Aim.angle, 1f, 360f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num3 != Config.Aim.angle)
			{
				Config.Aim.angle = num3;
			}
			num += num2 - 10f;
			GUI.Label(new Rect(5f, num, 140f, 20f), Text.maxDistance + " (" + Config.Aim.maxDistance.ToString("0") + "):");
			num += num2 - 5f;
			float num4 = GUI.HorizontalSlider(new Rect(5f, num, 140f, 20f), Config.Aim.maxDistance, 10f, 1024f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num4 != Config.Aim.maxDistance)
			{
				Config.Aim.maxDistance = num4;
			}
			num += num2 - 10f;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003EFC File Offset: 0x000020FC
		private void ZombiesWindow(int WindowID)
		{
			float num = 20f;
			float num2 = 25f;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.enabled + ": " + (Config.Zombies.enabled ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Zombies.enabled = !Config.Zombies.enabled;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.distance + ": " + (Config.Zombies.showDistance ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Zombies.showDistance = !Config.Zombies.showDistance;
			}
			num += num2;
			GUI.Label(new Rect(5f, num, 140f, 20f), Text.maxDistance + " (" + Config.Zombies.maxDistance.ToString("0") + "):");
			num += num2 - 5f;
			float num3 = GUI.HorizontalSlider(new Rect(5f, num, 140f, 20f), Config.Zombies.maxDistance, 10f, 500f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num3 != Config.Zombies.maxDistance)
			{
				Config.Zombies.maxDistance = num3;
			}
			num += num2 - 10f;
			GUI.Label(new Rect(5f, num, 140f, 20f), Text.interval + " (" + Config.Zombies.refreshInterval.ToString("0") + "):");
			num += num2 - 5f;
			float num4 = GUI.HorizontalSlider(new Rect(5f, num, 140f, 20f), Config.Zombies.refreshInterval, 0.1f, 10f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num4 != Config.Zombies.refreshInterval)
			{
				Config.Zombies.refreshInterval = num4;
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000040DC File Offset: 0x000022DC
		private void VehiclesWindow(int WindowID)
		{
			float num = 20f;
			float num2 = 25f;
			GUI.Label(new Rect(5f, num, 140f, 20f), "ESP");
			num += num2 - 5f;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.enabled + ": " + (Config.Vehicles.enabled ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Vehicles.enabled = !Config.Vehicles.enabled;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.info + ": " + (Config.Vehicles.showStats ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Vehicles.showStats = !Config.Vehicles.showStats;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.distance + ": " + (Config.Vehicles.showDistance ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Vehicles.showDistance = !Config.Vehicles.showDistance;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.unlockedOnly + ": " + (Config.Vehicles.notLockedOnly ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Vehicles.notLockedOnly = !Config.Vehicles.notLockedOnly;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.resetRot ?? "", Interface.buttonStyle))
			{
				Player player = Player.player;
				Component component;
				if (player == null)
				{
					component = null;
				}
				else
				{
					PlayerMovement movement = player.movement;
					component = ((movement != null) ? movement.getVehicle() : null);
				}
				component.transform.localRotation = Quaternion.identity;
			}
			num += num2;
			GUI.Label(new Rect(5f, num, 140f, 20f), Text.maxDistance + "  (" + Config.Vehicles.maxDistance.ToString("0") + "):");
			num += num2 - 5f;
			float num3 = GUI.HorizontalSlider(new Rect(5f, num, 140f, 20f), Config.Vehicles.maxDistance, 100f, 2000f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num3 != Config.Vehicles.maxDistance)
			{
				Config.Vehicles.maxDistance = num3;
			}
			num += num2 - 10f;
			GUI.Label(new Rect(5f, num, 140f, 20f), Text.interval + " (" + Config.Vehicles.refreshInterval.ToString("0") + "):");
			num += num2 - 5f;
			float num4 = GUI.HorizontalSlider(new Rect(5f, num, 140f, 20f), Config.Vehicles.refreshInterval, 0.1f, 10f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num4 != Config.Vehicles.refreshInterval)
			{
				Config.Vehicles.refreshInterval = num4;
			}
			num = 20f;
			GUI.Label(new Rect(155f, num, 140f, 20f), "NoClip");
			num += num2 - 5f;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.enabled + ": " + (Config.Vehicles.noClip ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Vehicles.noClip = !Config.Vehicles.noClip;
			}
			num += num2;
			GUI.Label(new Rect(155f, num, 140f, 20f), Text.speedMultiplier + " [W/S] (" + Config.Vehicles.noClipSpeedMultiplier.ToString("0") + "):");
			num += num2 - 5f;
			float num5 = GUI.HorizontalSlider(new Rect(155f, num, 140f, 20f), Config.Vehicles.noClipSpeedMultiplier, 0.01f, 10f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num5 != Config.Vehicles.noClipSpeedMultiplier)
			{
				Config.Vehicles.noClipSpeedMultiplier = num5;
			}
			num += num2 - 10f;
			GUI.Label(new Rect(155f, num, 140f, 20f), string.Concat(new string[]
			{
				"Y ",
				Text.position,
				" [shift/space] (",
				Config.Vehicles.yPosAmount.ToString("0"),
				"):"
			}));
			num += num2 - 5f;
			float num6 = GUI.HorizontalSlider(new Rect(155f, num, 140f, 20f), Config.Vehicles.yPosAmount, 0.01f, 10f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num6 != Config.Vehicles.yPosAmount)
			{
				Config.Vehicles.yPosAmount = num6;
			}
			num += num2 - 10f;
			GUI.Label(new Rect(155f, num, 140f, 20f), string.Concat(new string[]
			{
				"Y ",
				Text.rotation,
				" [A/D] (",
				Config.Vehicles.yRotAmount.ToString("0"),
				"):"
			}));
			num += num2 - 5f;
			float num7 = GUI.HorizontalSlider(new Rect(155f, num, 140f, 20f), Config.Vehicles.yRotAmount, 0.01f, 10f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num7 != Config.Vehicles.yRotAmount)
			{
				Config.Vehicles.yRotAmount = num7;
			}
			num += num2 - 10f;
			GUI.Label(new Rect(155f, num, 140f, 20f), string.Concat(new string[]
			{
				"X ",
				Text.rotation,
				" [↑/↓] (",
				Config.Vehicles.xRotAmount.ToString("0"),
				"):"
			}));
			num += num2 - 5f;
			float num8 = GUI.HorizontalSlider(new Rect(155f, num, 140f, 20f), Config.Vehicles.xRotAmount, 0.01f, 10f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num8 != Config.Vehicles.xRotAmount)
			{
				Config.Vehicles.xRotAmount = num8;
			}
			num += num2 - 10f;
			GUI.Label(new Rect(155f, num, 140f, 20f), string.Concat(new string[]
			{
				"Z ",
				Text.rotation,
				" [←/→] (",
				Config.Vehicles.zRotAmount.ToString("0"),
				"):"
			}));
			num += num2 - 5f;
			float num9 = GUI.HorizontalSlider(new Rect(155f, num, 140f, 20f), Config.Vehicles.zRotAmount, 0.01f, 10f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num9 != Config.Vehicles.zRotAmount)
			{
				Config.Vehicles.zRotAmount = num9;
			}
			num += num2 - 10f;
			num = 20f;
			GUI.Label(new Rect(305f, num, 140f, 20f), Text.misc ?? "");
			num += num2 - 5f;
			if (GUI.Button(new Rect(305f, num, 140f, 20f), Text.fill ?? "", Interface.buttonStyle))
			{
				Player player2 = Player.player;
				InteractableVehicle interactableVehicle;
				if (player2 == null)
				{
					interactableVehicle = null;
				}
				else
				{
					PlayerMovement movement2 = player2.movement;
					interactableVehicle = ((movement2 != null) ? movement2.getVehicle() : null);
				}
				interactableVehicle.askFillFuel(100);
			}
			num += num2;
			if (GUI.Button(new Rect(305f, num, 140f, 20f), Text.charge ?? "", Interface.buttonStyle))
			{
				Player player3 = Player.player;
				InteractableVehicle interactableVehicle2;
				if (player3 == null)
				{
					interactableVehicle2 = null;
				}
				else
				{
					PlayerMovement movement3 = player3.movement;
					interactableVehicle2 = ((movement3 != null) ? movement3.getVehicle() : null);
				}
				interactableVehicle2.askChargeBattery(100);
			}
			num += num2;
			if (GUI.Button(new Rect(305f, num, 140f, 20f), Text.repair ?? "", Interface.buttonStyle))
			{
				Player player4 = Player.player;
				InteractableVehicle interactableVehicle3;
				if (player4 == null)
				{
					interactableVehicle3 = null;
				}
				else
				{
					PlayerMovement movement4 = player4.movement;
					interactableVehicle3 = ((movement4 != null) ? movement4.getVehicle() : null);
				}
				interactableVehicle3.askRepair(100);
			}
			num += num2;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00004900 File Offset: 0x00002B00
		private void ItemsWindow(int WindowID)
		{
			float num = 20f;
			float num2 = 25f;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.enabled + ": " + (Config.Items.enabled ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.enabled = !Config.Items.enabled;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.category + ": " + (Config.Items.showCategory ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.showCategory = !Config.Items.showCategory;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.distance + ": " + (Config.Items.showDistance ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.showDistance = !Config.Items.showDistance;
			}
			num += num2;
			GUI.Label(new Rect(5f, num, 140f, 20f), Text.maxDistance + " (" + Config.Items.maxDistance.ToString("0") + "):");
			num += num2 - 5f;
			float num3 = GUI.HorizontalSlider(new Rect(5f, num, 140f, 20f), Config.Items.maxDistance, 10f, 800f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num3 != Config.Items.maxDistance)
			{
				Config.Items.maxDistance = num3;
			}
			num += num2 - 10f;
			GUI.Label(new Rect(5f, num, 140f, 20f), Text.interval + " (" + Config.Items.refreshInterval.ToString("0") + "):");
			num += num2 - 5f;
			float num4 = GUI.HorizontalSlider(new Rect(5f, num, 140f, 20f), Config.Items.refreshInterval, 0.1f, 10f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num4 != Config.Items.refreshInterval)
			{
				Config.Items.refreshInterval = num4;
			}
			num = 20f;
			GUI.Label(new Rect(155f, num, 140f, 20f), Text.filter + ":");
			num += num2 - 5f;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.clothes + ": " + (Config.Items.filterClothes ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.filterClothes = !Config.Items.filterClothes;
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.vests + ": " + (Config.Items.filterVest ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.filterVest = !Config.Items.filterVest;
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.backpacks + ": " + (Config.Items.filterBackpack ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.filterBackpack = !Config.Items.filterBackpack;
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.guns + ": " + (Config.Items.filterGuns ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.filterGuns = !Config.Items.filterGuns;
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.attachments + ": " + (Config.Items.filterAttachments ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.filterAttachments = !Config.Items.filterAttachments;
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.resources + ": " + (Config.Items.filterSupply ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.filterSupply = !Config.Items.filterSupply;
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.foodAndWater + ": " + (Config.Items.filterFoodAndWater ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.filterFoodAndWater = !Config.Items.filterFoodAndWater;
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.medicine + ": " + (Config.Items.filterMedicine ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.filterMedicine = !Config.Items.filterMedicine;
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.construction + ": " + (Config.Items.filterConstruction ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.filterConstruction = !Config.Items.filterConstruction;
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.throwable + ": " + (Config.Items.filterThrowable ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.filterThrowable = !Config.Items.filterThrowable;
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.tools + ": " + (Config.Items.filterTool ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.filterTool = !Config.Items.filterTool;
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.generators + ": " + (Config.Items.filterGenerator ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.filterGenerator = !Config.Items.filterGenerator;
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.other + ": " + (Config.Items.filterOther ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.filterOther = !Config.Items.filterOther;
			}
			num = 20f;
			GUI.Label(new Rect(305f, num, 140f, 20f), "Авто-подбор:");
			num += num2 - 5f;
			if (GUI.Button(new Rect(305f, num, 140f, 20f), Text.enabled + ": " + (Config.Items.autoPickup ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Items.autoPickup = !Config.Items.autoPickup;
			}
			num += num2;
			if (GUI.Button(new Rect(305f, num, 140f, 20f), Text.guns + ": " + ((Config.Items.itemsToAutoPickup != null && Config.Items.itemsToAutoPickup.Contains(7)) ? "+" : "-"), Interface.buttonStyle))
			{
				if (Config.Items.itemsToAutoPickup != null)
				{
					List<EItemType> list = Config.Items.itemsToAutoPickup.ToList<EItemType>();
					if (Config.Items.itemsToAutoPickup.Contains(7))
					{
						list.Remove(7);
					}
					else
					{
						list.Add(7);
					}
					Config.Items.itemsToAutoPickup = list.ToArray();
				}
				else
				{
					Config.Items.itemsToAutoPickup = new EItemType[]
					{
						7
					};
				}
			}
			num += num2;
			if (GUI.Button(new Rect(305f, num, 140f, 20f), "Магазины: " + (Config.Items.itemsToAutoPickup.Contains(12) ? "+" : "-"), Interface.buttonStyle))
			{
				if (Config.Items.itemsToAutoPickup != null)
				{
					List<EItemType> list2 = Config.Items.itemsToAutoPickup.ToList<EItemType>();
					if (Config.Items.itemsToAutoPickup.Contains(12))
					{
						list2.Remove(12);
					}
					else
					{
						list2.Add(12);
					}
					Config.Items.itemsToAutoPickup = list2.ToArray();
				}
				else
				{
					Config.Items.itemsToAutoPickup = new EItemType[]
					{
						12
					};
				}
			}
			num += num2;
			if (GUI.Button(new Rect(305f, num, 140f, 20f), Text.resources + ": " + (Config.Items.itemsToAutoPickup.Contains(25) ? "+" : "-"), Interface.buttonStyle))
			{
				if (Config.Items.itemsToAutoPickup != null)
				{
					List<EItemType> list3 = Config.Items.itemsToAutoPickup.ToList<EItemType>();
					if (Config.Items.itemsToAutoPickup.Contains(25))
					{
						list3.Remove(25);
					}
					else
					{
						list3.Add(25);
					}
					Config.Items.itemsToAutoPickup = list3.ToArray();
				}
				else
				{
					Config.Items.itemsToAutoPickup = new EItemType[]
					{
						25
					};
				}
			}
			num += num2;
			if (GUI.Button(new Rect(305f, num, 140f, 20f), Text.medicine + ": " + (Config.Items.itemsToAutoPickup.Contains(15) ? "+" : "-"), Interface.buttonStyle))
			{
				if (Config.Items.itemsToAutoPickup != null)
				{
					List<EItemType> list4 = Config.Items.itemsToAutoPickup.ToList<EItemType>();
					if (Config.Items.itemsToAutoPickup.Contains(15))
					{
						list4.Remove(15);
					}
					else
					{
						list4.Add(15);
					}
					Config.Items.itemsToAutoPickup = list4.ToArray();
				}
				else
				{
					Config.Items.itemsToAutoPickup = new EItemType[]
					{
						15
					};
				}
			}
			num += num2;
			if (GUI.Button(new Rect(305f, num, 140f, 20f), "Ферма: " + (Config.Items.itemsToAutoPickup.Contains(22) ? "+" : "-"), Interface.buttonStyle))
			{
				if (Config.Items.itemsToAutoPickup != null)
				{
					List<EItemType> list5 = Config.Items.itemsToAutoPickup.ToList<EItemType>();
					if (Config.Items.itemsToAutoPickup.Contains(22))
					{
						list5.Remove(22);
					}
					else
					{
						list5.Add(22);
					}
					Config.Items.itemsToAutoPickup = list5.ToArray();
				}
				else
				{
					Config.Items.itemsToAutoPickup = new EItemType[]
					{
						22
					};
				}
			}
			num += num2;
			if (GUI.Button(new Rect(305f, num, 140f, 20f), "Баррикады: " + (Config.Items.itemsToAutoPickup.Contains(19) ? "+" : "-"), Interface.buttonStyle))
			{
				if (Config.Items.itemsToAutoPickup != null)
				{
					List<EItemType> list6 = Config.Items.itemsToAutoPickup.ToList<EItemType>();
					if (Config.Items.itemsToAutoPickup.Contains(19))
					{
						list6.Remove(19);
					}
					else
					{
						list6.Add(19);
					}
					Config.Items.itemsToAutoPickup = list6.ToArray();
				}
				else
				{
					Config.Items.itemsToAutoPickup = new EItemType[]
					{
						19
					};
				}
			}
			num += num2;
			if (GUI.Button(new Rect(305f, num, 140f, 20f), "Хранение: " + (Config.Items.itemsToAutoPickup.Contains(20) ? "+" : "-"), Interface.buttonStyle))
			{
				if (Config.Items.itemsToAutoPickup != null)
				{
					List<EItemType> list7 = Config.Items.itemsToAutoPickup.ToList<EItemType>();
					if (Config.Items.itemsToAutoPickup.Contains(20))
					{
						list7.Remove(20);
					}
					else
					{
						list7.Add(20);
					}
					Config.Items.itemsToAutoPickup = list7.ToArray();
				}
				else
				{
					Config.Items.itemsToAutoPickup = new EItemType[]
					{
						20
					};
				}
			}
			num += num2;
			if (GUI.Button(new Rect(305f, num, 140f, 20f), "Еда: " + (Config.Items.itemsToAutoPickup.Contains(13) ? "+" : "-"), Interface.buttonStyle))
			{
				if (Config.Items.itemsToAutoPickup != null)
				{
					List<EItemType> list8 = Config.Items.itemsToAutoPickup.ToList<EItemType>();
					if (Config.Items.itemsToAutoPickup.Contains(13))
					{
						list8.Remove(13);
					}
					else
					{
						list8.Add(13);
					}
					Config.Items.itemsToAutoPickup = list8.ToArray();
				}
				else
				{
					Config.Items.itemsToAutoPickup = new EItemType[]
					{
						13
					};
				}
			}
			num += num2;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00005528 File Offset: 0x00003728
		private void MiscWindow(int WindowID)
		{
			float num = 20f;
			float num2 = 25f;
			GUI.Label(new Rect(5f, num, 140f, 20f), Text.speedhack + " (" + this.timeScale.ToString("2") + "):");
			num += num2 - 5f;
			float num3 = GUI.HorizontalSlider(new Rect(5f, num, 140f, 20f), this.timeScale, 1f, 1.2f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num3 != this.timeScale)
			{
				this.timeScale = num3;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.thirdPerson + ": " + ((Provider.cameraMode == 2) ? "+" : "-"), Interface.buttonStyle))
			{
				Provider.cameraMode = 2;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.debugCam ?? "", Interface.buttonStyle))
			{
				this.players.localPlayer.look.ReceiveFreecamAllowed(true);
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.setDay ?? "", Interface.buttonStyle))
			{
				LightingManager.time = (uint)(LightingManager.cycle * LevelLighting.transition);
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.setNight ?? "", Interface.buttonStyle))
			{
				LightingManager.time = (uint)(LightingManager.cycle * (LevelLighting.bias + LevelLighting.transition));
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.crosshair + ": " + (Config.Misc.crosshair ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Misc.crosshair = !Config.Misc.crosshair;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), Text.reconnect + ": " + (Config.Misc.autoReconnect ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Misc.autoReconnect = !Config.Misc.autoReconnect;
			}
			num += num2;
			if (GUI.Button(new Rect(5f, num, 140f, 20f), "FPS Boost", Interface.buttonStyle))
			{
				if (base.GetComponent<FPSBoost>())
				{
					return;
				}
				base.gameObject.AddComponent<FPSBoost>().ToggleFPSBoost();
			}
			num += num2;
			num = 20f;
			GUI.Label(new Rect(155f, num, 140f, 20f), "<b>" + Text.objects + "</b>");
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.far_interaction + ": " + (Config.Misc.far_interaction ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Misc.far_interaction = !Config.Misc.far_interaction;
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.remove ?? "", Interface.buttonStyle))
			{
				Camera main = Camera.main;
				RaycastHit raycastHit;
				if (Physics.Raycast(new Ray(main.transform.position, main.transform.forward), ref raycastHit))
				{
					GameObject gameObject = raycastHit.transform.gameObject;
					gameObject.SetActive(false);
					this.inactiveObjects.Add(gameObject);
				}
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), "Scale +", Interface.buttonStyle))
			{
				Camera main2 = Camera.main;
				RaycastHit raycastHit2;
				if (Physics.Raycast(new Ray(main2.transform.position, main2.transform.forward), ref raycastHit2))
				{
					Vector3 localScale = raycastHit2.transform.localScale;
					raycastHit2.transform.localScale = new Vector3(localScale.x + 1f, localScale.y + 1f, localScale.z + 1f);
				}
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), "Scale -", Interface.buttonStyle))
			{
				Camera main3 = Camera.main;
				RaycastHit raycastHit3;
				if (Physics.Raycast(new Ray(main3.transform.position, main3.transform.forward), ref raycastHit3))
				{
					Vector3 localScale2 = raycastHit3.transform.localScale;
					raycastHit3.transform.localScale = new Vector3(localScale2.x - 1f, localScale2.y - 1f, localScale2.z - 1f);
				}
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.addPhysics ?? "", Interface.buttonStyle))
			{
				Camera main4 = Camera.main;
				RaycastHit raycastHit4;
				if (Physics.Raycast(new Ray(main4.transform.position, main4.transform.forward), ref raycastHit4))
				{
					GameObject gameObject2 = raycastHit4.transform.gameObject;
					gameObject2.AddComponent<Rigidbody>();
					this.rigidbodyObjects.Add(gameObject2);
				}
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.removePhysics ?? "", Interface.buttonStyle))
			{
				Camera main5 = Camera.main;
				RaycastHit raycastHit5;
				if (Physics.Raycast(new Ray(main5.transform.position, main5.transform.forward), ref raycastHit5))
				{
					Object.DestroyImmediate(raycastHit5.transform.gameObject.GetComponent<Rigidbody>());
				}
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.tpObjectToMe ?? "", Interface.buttonStyle))
			{
				Camera main6 = Camera.main;
				RaycastHit raycastHit6;
				if (Physics.Raycast(new Ray(main6.transform.position, main6.transform.forward), ref raycastHit6))
				{
					raycastHit6.transform.gameObject.transform.position = Camera.main.transform.position;
				}
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.tpToObject ?? "", Interface.buttonStyle))
			{
				Camera main7 = Camera.main;
				RaycastHit raycastHit7;
				if (Physics.Raycast(new Ray(main7.transform.position, main7.transform.forward), ref raycastHit7))
				{
					Vector3 position = raycastHit7.transform.position;
					position.y += 0.5f;
					Player componentInParent = Camera.main.gameObject.GetComponentInParent<Player>();
					componentInParent.teleportToLocationUnsafe(position, main7.transform.rotation.z);
					componentInParent.teleportToLocationUnsafe(position, main7.transform.rotation.z);
					componentInParent.teleportToLocationUnsafe(position, main7.transform.rotation.z);
				}
			}
			num += num2;
			if (GUI.Button(new Rect(155f, num, 140f, 20f), Text.restore ?? "", Interface.buttonStyle))
			{
				foreach (GameObject gameObject3 in this.inactiveObjects)
				{
					gameObject3.SetActive(true);
				}
				foreach (GameObject gameObject4 in this.rigidbodyObjects)
				{
					Object.DestroyImmediate(gameObject4.gameObject.GetComponent<Rigidbody>());
				}
			}
			num = 20f;
			GUI.Label(new Rect(305f, num, 140f, 20f), "<b>" + Text.players + "</b>");
			num += num2;
			GUI.Label(new Rect(305f, num, 140f, 20f), string.Format("<size=11>Scale ({0}) [{1}]</size>", Text.localPlayer, this.players.localPlayerScale));
			num += num2;
			if (GUI.Button(new Rect(305f, num, 70f, 20f), "-", Interface.buttonStyle))
			{
				this.players.DecreaseLocalPlayerScale();
			}
			if (GUI.Button(new Rect(380f, num, 70f, 20f), "+", Interface.buttonStyle))
			{
				this.players.IncreaseLocalPlayerScale();
			}
			num += num2;
			GUI.Label(new Rect(305f, num, 140f, 20f), string.Format("<size=11>Scale ({0}) [{1}]</size>", Text.otherPlayers, this.players.playersScale));
			num += num2;
			if (GUI.Button(new Rect(305f, num, 70f, 20f), "-", Interface.buttonStyle))
			{
				this.players.DecreasePlayersScale();
			}
			if (GUI.Button(new Rect(380f, num, 70f, 20f), "+", Interface.buttonStyle))
			{
				this.players.IncreasePlayersScale();
			}
			num = 20f;
			GUI.Label(new Rect(460f, num, 140f, 20f), "<b>" + Text.construction + "</b>");
			num += num2;
			if (GUI.Button(new Rect(460f, num, 140f, 20f), Text.buildAnywhere + ": " + (Config.Misc.buildAnywhere ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Misc.buildAnywhere = !Config.Misc.buildAnywhere;
			}
			num += num2;
			if (GUI.Button(new Rect(460f, num, 140f, 20f), string.Concat(new string[]
			{
				"<size=12>",
				Text.instaRemove,
				": ",
				Config.Misc.immediateSalvage ? "+" : "-",
				"</size>"
			}), Interface.buttonStyle))
			{
				Config.Misc.immediateSalvage = !Config.Misc.immediateSalvage;
				if (Config.Misc.immediateSalvage)
				{
					this.players.localPlayer.interact.ReceiveSalvageTimeOverride(0.2f);
				}
				else
				{
					this.players.localPlayer.interact.ReceiveSalvageTimeOverride(3f);
				}
			}
			num = 20f;
			GUI.Label(new Rect(615f, num, 140f, 20f), "<b>Авто-кик</b>");
			num += num2;
			if (GUI.Button(new Rect(615f, num, 140f, 20f), "HP <= <color=green>10</color>: " + (Config.Misc.autokick_10hp ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Misc.autokick_10hp = !Config.Misc.autokick_10hp;
			}
			num += num2;
			if (GUI.Button(new Rect(615f, num, 140f, 20f), "HP <= <color=yellow>5</color>: " + (Config.Misc.autokick_5hp ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Misc.autokick_5hp = !Config.Misc.autokick_5hp;
			}
			num += num2;
			if (GUI.Button(new Rect(615f, num, 140f, 20f), "HP <= <color=red>3</color>: " + (Config.Misc.autokick_3hp ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Misc.autokick_3hp = !Config.Misc.autokick_3hp;
			}
			num += num2;
			if (GUI.Button(new Rect(615f, num, 140f, 20f), "HP <= <color=magenta>1</color>: " + (Config.Misc.autokick_1hp ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Misc.autokick_1hp = !Config.Misc.autokick_1hp;
			}
			num += num2;
			num = 20f;
			GUI.Label(new Rect(770f, num, 140f, 20f), "<b>Разное</b>");
			num += num2;
			if (GUI.Button(new Rect(770f, num, 140f, 20f), "Собрать урожай", Interface.buttonStyle))
			{
				base.StartCoroutine(this.HarvestAll());
			}
			num += num2;
			if (GUI.Button(new Rect(770f, num, 140f, 20f), "Галлюцинации: " + (Config.Misc.hallucination ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Misc.hallucination = !Config.Misc.hallucination;
				if (Config.Misc.hallucination)
				{
					this.players.localPlayer.life.serverModifyHallucination(255f);
				}
				else
				{
					this.players.localPlayer.life.serverModifyHallucination(1f);
				}
			}
			num += num2;
			if (GUI.Button(new Rect(770f, num, 140f, 20f), "Emo mode: " + (Config.Misc.emo_mode ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Misc.emo_mode = !Config.Misc.emo_mode;
				if (Config.Misc.emo_mode)
				{
					base.StartCoroutine(this.EmoMode());
				}
				else
				{
					base.StopCoroutine(this.EmoMode());
				}
			}
			num += num2;
			if (GUI.Button(new Rect(770f, num, 140f, 20f), "Суицид", Interface.buttonStyle))
			{
				this.players.localPlayer.life.sendSuicide();
			}
			num += num2;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000062FC File Offset: 0x000044FC
		private IEnumerator EmoMode()
		{
			while (Config.Misc.emo_mode)
			{
				this.players.localPlayer.animator.sendGesture(1, true);
				yield return new WaitForSeconds(0.5f);
			}
			yield break;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000630C File Offset: 0x0000450C
		private void ApplyGUIStyle()
		{
			Interface.windowStyle = new GUIStyle(GUI.skin.window);
			Interface.buttonStyle = new GUIStyle(GUI.skin.button);
			Interface.sliderStyle = new GUIStyle(GUI.skin.horizontalSlider);
			Interface.sliderThumbStyle = new GUIStyle(GUI.skin.horizontalSliderThumb);
			GUI.color = this.defaultTextColor;
			GUI.backgroundColor = new Color(0.16f, 0.15f, 0.16f);
			Interface.windowStyle.normal.background = this.windowBackground;
			Interface.windowStyle.onNormal.background = Interface.windowStyle.normal.background;
			Interface.windowStyle.active.background = Interface.windowStyle.normal.background;
			Interface.windowStyle.onActive.background = Interface.windowStyle.normal.background;
			Interface.windowStyle.focused.background = Interface.windowStyle.normal.background;
			Interface.windowStyle.onFocused.background = Interface.windowStyle.normal.background;
			Interface.windowStyle.normal.textColor = Color.white;
			Interface.windowStyle.onNormal.textColor = Interface.windowStyle.normal.textColor;
			Interface.windowStyle.active.textColor = Interface.windowStyle.normal.textColor;
			Interface.windowStyle.onActive.textColor = Interface.windowStyle.normal.textColor;
			Interface.windowStyle.focused.textColor = Interface.windowStyle.normal.textColor;
			Interface.windowStyle.onFocused.textColor = Interface.windowStyle.normal.textColor;
			Interface.buttonStyle.normal.background = this.buttonBackground;
			Interface.buttonStyle.onNormal.background = Interface.buttonStyle.normal.background;
			Interface.buttonStyle.active.background = Interface.buttonStyle.normal.background;
			Interface.buttonStyle.onActive.background = Interface.buttonStyle.normal.background;
			Interface.buttonStyle.focused.background = Interface.buttonStyle.normal.background;
			Interface.buttonStyle.onFocused.background = Interface.buttonStyle.normal.background;
			Interface.buttonStyle.normal.textColor = new Color32(240, 240, 240, byte.MaxValue);
			Interface.buttonStyle.onNormal.textColor = Interface.buttonStyle.normal.textColor;
			Interface.buttonStyle.active.textColor = Interface.buttonStyle.normal.textColor;
			Interface.buttonStyle.onActive.textColor = Interface.buttonStyle.normal.textColor;
			Interface.buttonStyle.focused.textColor = Interface.buttonStyle.normal.textColor;
			Interface.buttonStyle.onFocused.textColor = Interface.buttonStyle.normal.textColor;
			Interface.buttonStyle.onHover.background = this.buttonHoverBackground;
			Interface.buttonStyle.hover.background = Interface.buttonStyle.onHover.background;
			Interface.buttonStyle.onHover.textColor = Interface.buttonStyle.normal.textColor;
			Interface.buttonStyle.hover.textColor = Interface.buttonStyle.normal.textColor;
			Interface.buttonStyle.border = new RectOffset();
			Interface.sliderStyle.normal.background = this.sliderBackground;
			Interface.sliderStyle.active.background = Interface.sliderStyle.normal.background;
			Interface.sliderStyle.hover.background = Interface.sliderStyle.normal.background;
			Interface.sliderStyle.focused.background = Interface.sliderStyle.normal.background;
			Interface.sliderThumbStyle.normal.background = this.sliderThumbBackground;
			Interface.sliderThumbStyle.active.background = Interface.sliderThumbStyle.normal.background;
			Interface.sliderThumbStyle.hover.background = Interface.sliderThumbStyle.normal.background;
			Interface.sliderThumbStyle.focused.background = Interface.sliderThumbStyle.normal.background;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000067AC File Offset: 0x000049AC
		private void SwitchWindow(Interface.Window window)
		{
			this.hideAllWindows();
			switch (window)
			{
			case Interface.Window.Aim:
				Config.Windows.aimWindow = !Config.Windows.aimWindow;
				return;
			case Interface.Window.Players:
				Config.Windows.playersWindow = !Config.Windows.playersWindow;
				return;
			case Interface.Window.Zombies:
				Config.Windows.zombiesWindow = !Config.Windows.zombiesWindow;
				return;
			case Interface.Window.Vehicles:
				Config.Windows.vehiclesWindow = !Config.Windows.vehiclesWindow;
				return;
			case Interface.Window.Items:
				Config.Windows.itemsWindow = !Config.Windows.itemsWindow;
				return;
			case Interface.Window.Misc:
				Config.Windows.miscWindow = !Config.Windows.miscWindow;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00006831 File Offset: 0x00004A31
		public void SetModules(Players Players)
		{
			this.players = Players;
		}

		// Token: 0x04000015 RID: 21
		public static float xOffset = 180f;

		// Token: 0x04000016 RID: 22
		public static float yOffset = 20f;

		// Token: 0x04000017 RID: 23
		private Rect mainWindowRect = new Rect(20f, 20f, 160f, 290f);

		// Token: 0x04000018 RID: 24
		private Rect aimWindowRect = new Rect(180f, 20f, 150f, 345f);

		// Token: 0x04000019 RID: 25
		private Rect zombiesWindowRect = new Rect(180f, 20f, 150f, 145f);

		// Token: 0x0400001A RID: 26
		private Rect vehiclesWindowRect = new Rect(180f, 20f, 450f, 245f);

		// Token: 0x0400001B RID: 27
		private Rect itemsWindowRect = new Rect(180f, 20f, 450f, 370f);

		// Token: 0x0400001C RID: 28
		private Rect miscWindowRect = new Rect(180f, 20f, 915f, 270f);

		// Token: 0x0400001D RID: 29
		private List<GameObject> inactiveObjects = new List<GameObject>();

		// Token: 0x0400001E RID: 30
		private List<GameObject> rigidbodyObjects = new List<GameObject>();

		// Token: 0x0400001F RID: 31
		public static GUIStyle windowStyle;

		// Token: 0x04000020 RID: 32
		public static GUIStyle buttonStyle;

		// Token: 0x04000021 RID: 33
		public static GUIStyle sliderStyle;

		// Token: 0x04000022 RID: 34
		public static GUIStyle sliderThumbStyle;

		// Token: 0x04000023 RID: 35
		private Color defaultTextColor;

		// Token: 0x04000024 RID: 36
		private Texture2D windowBackground;

		// Token: 0x04000025 RID: 37
		private Texture2D buttonBackground;

		// Token: 0x04000026 RID: 38
		private Texture2D buttonHoverBackground;

		// Token: 0x04000027 RID: 39
		private Texture2D sliderBackground;

		// Token: 0x04000028 RID: 40
		private Texture2D sliderThumbBackground;

		// Token: 0x04000029 RID: 41
		private Players players;

		// Token: 0x0400002A RID: 42
		public static string debugString = "";

		// Token: 0x0400002B RID: 43
		private bool testbool;

		// Token: 0x0400002C RID: 44
		private float timeScale = 1f;

		// Token: 0x02000019 RID: 25
		private enum Window
		{
			// Token: 0x040000AB RID: 171
			Aim,
			// Token: 0x040000AC RID: 172
			Players,
			// Token: 0x040000AD RID: 173
			Zombies,
			// Token: 0x040000AE RID: 174
			Vehicles,
			// Token: 0x040000AF RID: 175
			Items,
			// Token: 0x040000B0 RID: 176
			Misc
		}
	}
}
