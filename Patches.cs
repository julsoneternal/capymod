using System;
using System.Reflection;
using HarmonyLib;
using SDG.NetTransport;
using SDG.NetTransport.SteamNetworkingSockets;
using SDG.Unturned;
using UnityEngine;

namespace SmartlyDressedMama
{
	// Token: 0x02000009 RID: 9
	internal class Patches : MonoBehaviour
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00006DE0 File Offset: 0x00004FE0
		public void Init()
		{
			try
			{
				Harmony.DEBUG = Config.debug;
				FileLog.Reset();
				new Harmony(Utils.GenerateRandomString(24)).PatchAll();
			}
			catch (Exception arg)
			{
				Logger.Log(string.Format("Ошибка инициализации Harmony: {0}", arg));
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00006E34 File Offset: 0x00005034
		private static void writeinfo(RaycastInfo info)
		{
			string text = (info.player != null) ? info.player.name.ToString() : "null";
			string text2 = (info.collider != null) ? info.collider.ToString() : "null";
			Vector3 point = info.point;
			string text3 = info.point.ToString();
			Vector3 normal = info.normal;
			string text4 = info.normal.ToString();
			string text5 = info.section.ToString();
			string text6 = info.limb.ToString();
			Vector3 direction = info.direction;
			string text7 = info.direction.ToString();
			string text8 = (info.transform != null) ? info.transform.position.ToString() : "null";
			string text9 = info.distance.ToString();
			Logger.Log(string.Concat(new string[]
			{
				text,
				" ",
				text2,
				" ",
				text3,
				" ",
				text4,
				" ",
				text5,
				" ",
				text6,
				" ",
				text7,
				" ",
				text8,
				" ",
				text9
			}));
		}

		// Token: 0x04000033 RID: 51
		private Harmony harmony;

		// Token: 0x04000034 RID: 52
		private static Player localPlayer;

		// Token: 0x04000035 RID: 53
		private static int counter;

		// Token: 0x04000036 RID: 54
		private static bool pussy;

		// Token: 0x04000037 RID: 55
		private static ClientTransportReady _callback;

		// Token: 0x04000038 RID: 56
		private static ClientTransportFailure _failureCallback;

		// Token: 0x0200001C RID: 28
		[HarmonyPatch(typeof(UseableGun))]
		[HarmonyPatch("fire")]
		private class UseableGun_shootPatch
		{
			// Token: 0x060000C6 RID: 198 RVA: 0x00009254 File Offset: 0x00007454
			private unsafe static void Prefix(UseableGun __instance)
			{
				if (!Config.enabled)
				{
					return;
				}
				if (Config.Misc.noSpread)
				{
					*Patches.UseableGun_shootPatch.aimAccuracy.Invoke(__instance) = 10000;
					*Patches.UseableGun_shootPatch.maxAimingAccuracy.Invoke(__instance) = 10000;
					*Patches.UseableGun_shootPatch.steadyAccuracy.Invoke(__instance) = 10000U;
					*Patches.UseableGun_shootPatch.swayTime.Invoke(__instance) = 0f;
				}
			}

			// Token: 0x040000B8 RID: 184
			private static AccessTools.FieldRef<UseableGun, int> aimAccuracy = AccessTools.FieldRefAccess<UseableGun, int>("aimAccuracy");

			// Token: 0x040000B9 RID: 185
			private static AccessTools.FieldRef<UseableGun, int> maxAimingAccuracy = AccessTools.FieldRefAccess<UseableGun, int>("maxAimingAccuracy");

			// Token: 0x040000BA RID: 186
			private static AccessTools.FieldRef<UseableGun, uint> steadyAccuracy = AccessTools.FieldRefAccess<UseableGun, uint>("steadyAccuracy");

			// Token: 0x040000BB RID: 187
			private static AccessTools.FieldRef<UseableGun, float> swayTime = AccessTools.FieldRefAccess<UseableGun, float>("swayTime");
		}

		// Token: 0x0200001D RID: 29
		[HarmonyPatch(typeof(Player))]
		[HarmonyPatch("sendScreenshot")]
		private class Player_sendScreenshot
		{
			// Token: 0x060000C9 RID: 201 RVA: 0x000092FA File Offset: 0x000074FA
			private static void Prefix(Player __instance)
			{
				if (!Config.enabled)
				{
					return;
				}
				if (Config.enabled)
				{
					Config.enabled = false;
					Base.wasSpied = true;
				}
			}
		}

		// Token: 0x0200001E RID: 30
		[HarmonyPatch(typeof(Player))]
		[HarmonyPatch("takeScreenshot")]
		private class Player_sendScreensho
		{
			// Token: 0x060000CB RID: 203 RVA: 0x0000931F File Offset: 0x0000751F
			private static void Prefix(Player __instance)
			{
				if (!Config.enabled)
				{
					return;
				}
				if (Config.enabled)
				{
					Config.enabled = false;
					Base.wasSpied = true;
				}
			}
		}

		// Token: 0x0200001F RID: 31
		[HarmonyPatch(typeof(Player))]
		[HarmonyPatch("askScreenshot")]
		private class Player_askScreenshot
		{
			// Token: 0x060000CD RID: 205 RVA: 0x00009344 File Offset: 0x00007544
			private static void Prefix(Player __instance)
			{
				if (!Config.enabled)
				{
					return;
				}
				if (Config.enabled)
				{
					Config.enabled = false;
					Base.wasSpied = true;
				}
			}
		}

		// Token: 0x02000020 RID: 32
		[HarmonyPatch(typeof(PlayerLook))]
		[HarmonyPatch("recoil")]
		private class PlayerLook_recoil
		{
			// Token: 0x060000CF RID: 207 RVA: 0x00009369 File Offset: 0x00007569
			private static bool Prefix(PlayerLook __instance)
			{
				return !Config.enabled || !Config.Misc.noRecoil;
			}
		}

		// Token: 0x02000021 RID: 33
		[HarmonyPatch(typeof(UseableBarricade))]
		[HarmonyPatch("check")]
		private class UseableBarricade_check
		{
			// Token: 0x060000D1 RID: 209 RVA: 0x00009386 File Offset: 0x00007586
			private static bool Prefix(ref bool __result)
			{
				if (!Config.enabled)
				{
					return true;
				}
				if (Config.Misc.buildAnywhere)
				{
					__result = true;
					return false;
				}
				return true;
			}
		}

		// Token: 0x02000022 RID: 34
		public static class InteractThroughWallsPatch
		{
			// Token: 0x0200002E RID: 46
			[HarmonyPatch(typeof(PlayerInteract))]
			[HarmonyPatch("Update")]
			internal class PlayerInteract_Update_Patch
			{
				// Token: 0x060000E7 RID: 231 RVA: 0x00009A34 File Offset: 0x00007C34
				private static void Prefix(PlayerInteract __instance)
				{
					if (!Config.enabled)
					{
						return;
					}
					if (!Config.Misc.far_interaction || __instance == null || !__instance.gameObject.CompareTag("Player"))
					{
						return;
					}
					int num = RayMasks.PLAYER_INTERACT;
					if (__instance.player.stance.stance == null)
					{
						num &= -33554433;
					}
					RaycastHit raycastHit;
					if (__instance.player.look.isCam)
					{
						Physics.Raycast(new Ray(__instance.player.look.aim.position, __instance.player.look.aim.forward), ref raycastHit, 50f, num);
					}
					else
					{
						Physics.Raycast(new Ray(MainCamera.instance.transform.position, MainCamera.instance.transform.forward), ref raycastHit, (float)((__instance.player.look.perspective == 1) ? 50 : 50), num);
					}
					Patches.InteractThroughWallsPatch.PlayerInteract_Update_Patch.hitField.SetValue(__instance, raycastHit);
				}

				// Token: 0x040000C0 RID: 192
				private static FieldInfo hitField = AccessTools.Field(typeof(PlayerInteract), "hit");
			}
		}

		// Token: 0x02000023 RID: 35
		[HarmonyPatch("Provider", "battlEyeClientSendPacket", 0)]
		private class Provider_battlEyeClientSendPacket
		{
			// Token: 0x060000D3 RID: 211 RVA: 0x000093A8 File Offset: 0x000075A8
			private static bool Prefix(IntPtr packetHandle, int length)
			{
				if (!Config.enabled)
				{
					return true;
				}
				if (!Config.Misc.autoKick || !Config.Misc.autoReconnect)
				{
					return true;
				}
				Logger.Log(length.ToString());
				if (length == 3)
				{
					Patches.counter++;
					if (Patches.counter == 10)
					{
						Base.willBeKickedSoon = true;
					}
					if (Patches.counter == 11)
					{
						Base.hasToLeave = true;
						Patches.counter = 0;
					}
				}
				return true;
			}
		}

		// Token: 0x02000024 RID: 36
		[HarmonyPatch(typeof(ClientTransport_SteamNetworkingSockets), "Initialize")]
		private class IClientTransport_Initialize
		{
			// Token: 0x060000D5 RID: 213 RVA: 0x00009417 File Offset: 0x00007617
			private static void Prefix(ref ClientTransportReady callback, ref ClientTransportFailure failureCallback)
			{
				Patches._callback = callback;
				Patches._failureCallback = failureCallback;
			}
		}

		// Token: 0x02000025 RID: 37
		[HarmonyPatch("UnturnedLog", "info", 0)]
		[HarmonyPatch(new Type[]
		{
			typeof(string)
		})]
		private class gfdgdf2
		{
			// Token: 0x060000D7 RID: 215 RVA: 0x0000942F File Offset: 0x0000762F
			private static void Prefix(string message)
			{
				Logger.Log("INFO: " + message);
			}
		}

		// Token: 0x02000026 RID: 38
		[HarmonyPatch("UnturnedLog", "warn", 0)]
		[HarmonyPatch(new Type[]
		{
			typeof(string)
		})]
		private class gfdgdssf2
		{
			// Token: 0x060000D9 RID: 217 RVA: 0x00009449 File Offset: 0x00007649
			private static void Prefix(string message)
			{
				Logger.Log("WARN: " + message);
			}
		}

		// Token: 0x02000027 RID: 39
		[HarmonyPatch("UnturnedLog", "error", 0)]
		[HarmonyPatch(new Type[]
		{
			typeof(string)
		})]
		private class gfdagdssf2
		{
			// Token: 0x060000DB RID: 219 RVA: 0x00009463 File Offset: 0x00007663
			private static void Prefix(string message)
			{
				Logger.Log("ERROR: " + message);
			}
		}

		// Token: 0x02000028 RID: 40
		[HarmonyPatch(typeof(Provider), "battlEyeClientPrintMessage")]
		private class dakofkg
		{
			// Token: 0x060000DD RID: 221 RVA: 0x0000947D File Offset: 0x0000767D
			private static void Prefix(string message)
			{
				Logger.Log("BATTLEYE MESSAGE: " + message);
			}
		}

		// Token: 0x02000029 RID: 41
		[HarmonyPatch(typeof(Provider), "battlEyeClientRequestRestart")]
		private class dakofkgdf
		{
			// Token: 0x060000DF RID: 223 RVA: 0x00009497 File Offset: 0x00007697
			private static void Prefix(int reason)
			{
				Logger.Log(string.Format("BATTLEYE RESTART REQUEST: {0}", reason));
			}
		}

		// Token: 0x0200002A RID: 42
		[HarmonyPatch("NetMessages", "SendMessageToServer", 0)]
		private class dfgsgf
		{
			// Token: 0x060000E1 RID: 225 RVA: 0x000094B6 File Offset: 0x000076B6
			private static bool Prefix(EServerMessage index)
			{
				return true;
			}
		}

		// Token: 0x0200002B RID: 43
		[HarmonyPatch(typeof(DamageTool))]
		[HarmonyPatch("getLimb")]
		private class DamageTool_getLimb
		{
			// Token: 0x060000E3 RID: 227 RVA: 0x000094C1 File Offset: 0x000076C1
			private static bool Prefix(ref ELimb __result)
			{
				if (!Config.enabled)
				{
					return true;
				}
				if (Config.Misc.onlyHeadshots)
				{
					__result = 13;
					return false;
				}
				return true;
			}
		}

		// Token: 0x0200002C RID: 44
		[HarmonyPatch(typeof(PlayerInput))]
		[HarmonyPatch("sendRaycast")]
		private class PlayerInput_sendRaycast
		{
			// Token: 0x060000E5 RID: 229 RVA: 0x000094E4 File Offset: 0x000076E4
			private static bool Prefix(ref RaycastInfo info, ERaycastInfoUsage usage)
			{
				if (!Config.enabled)
				{
					return true;
				}
				if (Patches.localPlayer == null)
				{
					foreach (Player player in Object.FindObjectsOfType<Player>())
					{
						if (player.channel.IsLocalPlayer)
						{
							Patches.localPlayer = player;
							break;
						}
					}
				}
				ELimb elimb = 12;
				if (Config.Misc.onlyHeadshots)
				{
					elimb = 13;
				}
				Patches.writeinfo(info);
				if (!Config.enabled || !Config.Aim.enabled)
				{
					return true;
				}
				if (usage == 3)
				{
					try
					{
						Player fovplayer = Utils.GetFOVPlayer();
						if (fovplayer != null)
						{
							float num = Vector3.Distance(MainCamera.instance.transform.position, fovplayer.transform.position);
							if (fovplayer != null && !fovplayer.channel.IsLocalPlayer && num <= Config.Aim.maxDistance)
							{
								if (Config.Aim.tp && num <= 15f)
								{
									fovplayer.transform.position = Patches.localPlayer.transform.position;
								}
								Vector3 vector = fovplayer.look.getEyesPosition() - Patches.localPlayer.look.getEyesPosition();
								info.player = fovplayer;
								info.collider = fovplayer.gameObject.GetComponentInChildren<BoxCollider>();
								info.point = info.collider.transform.position;
								info.transform = info.collider.transform;
								info.direction = vector.normalized;
								info.distance = num;
								info.limb = elimb;
								PlayerUI.hitmark(info.point, false, (elimb == 13) ? 2 : 1);
							}
						}
						else if (fovplayer == null && Config.Aim.zombie)
						{
							Zombie fovzombie = Utils.GetFOVZombie();
							if (fovzombie != null)
							{
								float distance = Vector3.Distance(MainCamera.instance.transform.position, fovzombie.transform.position);
								Vector3 vector2 = fovzombie.transform.position - MainCamera.instance.transform.position;
								info.zombie = fovzombie;
								info.collider = fovzombie.gameObject.GetComponentInChildren<BoxCollider>();
								info.point = info.collider.transform.position;
								info.transform = info.collider.transform;
								info.direction = vector2.normalized;
								info.distance = distance;
								info.limb = elimb;
								PlayerUI.hitmark(info.point, false, (elimb == 13) ? 2 : 1);
							}
						}
						goto IL_4FA;
					}
					catch (Exception ex)
					{
						Logger.Log(ex.ToString());
						return true;
					}
				}
				if (usage == 2 || usage == null)
				{
					try
					{
						Player fovplayer2 = Utils.GetFOVPlayer();
						if (fovplayer2 != null)
						{
							fovplayer2.transform.position = Patches.localPlayer.transform.position;
							float num2 = Vector3.Distance(MainCamera.instance.transform.position, fovplayer2.transform.position);
							if (fovplayer2 != null && !fovplayer2.channel.IsLocalPlayer && num2 <= 15.5f)
							{
								Vector3 vector3 = fovplayer2.transform.position - MainCamera.instance.transform.position;
								info.player = fovplayer2;
								info.collider = fovplayer2.gameObject.GetComponentInChildren<BoxCollider>();
								info.point = info.collider.transform.position;
								info.transform = info.collider.transform;
								info.direction = vector3.normalized;
								info.distance = num2;
								info.limb = elimb;
								PlayerUI.hitmark(info.point, false, (elimb == 13) ? 2 : 1);
							}
						}
						else if (fovplayer2 == null && Config.Aim.zombie)
						{
							Zombie fovzombie2 = Utils.GetFOVZombie();
							if (fovzombie2 != null)
							{
								Vector3 position = fovzombie2.transform.position;
								fovzombie2.transform.position = Patches.localPlayer.transform.position;
								float distance2 = Vector3.Distance(MainCamera.instance.transform.position, fovzombie2.transform.position);
								Vector3 vector4 = fovzombie2.transform.position - MainCamera.instance.transform.position;
								info.zombie = fovzombie2;
								info.collider = fovzombie2.gameObject.GetComponentInChildren<BoxCollider>();
								info.point = info.collider.transform.position;
								info.transform = info.collider.transform;
								info.direction = vector4.normalized;
								info.distance = distance2;
								info.limb = elimb;
								fovzombie2.transform.position = position;
								PlayerUI.hitmark(info.point, false, (elimb == 13) ? 2 : 1);
							}
						}
					}
					catch (Exception ex2)
					{
						Logger.Log(ex2.ToString());
						return true;
					}
				}
				IL_4FA:
				Patches.writeinfo(info);
				return true;
			}
		}
	}
}
