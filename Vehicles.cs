using System;
using SDG.Unturned;
using UnityEngine;

namespace SmartlyDressedMama
{
	// Token: 0x0200000F RID: 15
	internal class Vehicles : MonoBehaviour
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x00008730 File Offset: 0x00006930
		private void Update()
		{
			try
			{
				if (Config.Vehicles.enabled && Config.enabled)
				{
					this.lastRefreshTime += Time.deltaTime;
					if (this.lastRefreshTime > Config.Vehicles.refreshInterval)
					{
						this.UpdateVehicles();
						this.lastRefreshTime = 0f;
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00008794 File Offset: 0x00006994
		private void FixedUpdate()
		{
			if (!Config.Vehicles.noClip)
			{
				return;
			}
			Player player = Player.player;
			InteractableVehicle interactableVehicle;
			if (player == null)
			{
				interactableVehicle = null;
			}
			else
			{
				PlayerMovement movement = player.movement;
				interactableVehicle = ((movement != null) ? movement.getVehicle() : null);
			}
			InteractableVehicle interactableVehicle2 = interactableVehicle;
			if (interactableVehicle2 != null && interactableVehicle2 && Provider.isConnected && !Provider.isLoading)
			{
				Rigidbody component = interactableVehicle2.GetComponent<Rigidbody>();
				component.constraints = 0;
				component.freezeRotation = false;
				component.useGravity = false;
				component.isKinematic = true;
				Transform transform = interactableVehicle2.transform;
				if (Input.GetKey(119))
				{
					component.MovePosition(transform.position + transform.forward * (interactableVehicle2.asset.speedMax * Config.Vehicles.noClipSpeedMultiplier * Time.fixedDeltaTime));
				}
				if (Input.GetKey(115))
				{
					component.MovePosition(transform.position - transform.forward * (interactableVehicle2.asset.speedMax * Config.Vehicles.noClipSpeedMultiplier * Time.fixedDeltaTime));
				}
				if (Input.GetKey(97))
				{
					transform.Rotate(0f, -Config.Vehicles.yRotAmount, 0f);
				}
				if (Input.GetKey(100))
				{
					transform.Rotate(0f, Config.Vehicles.yRotAmount, 0f);
				}
				if (Input.GetKey(273))
				{
					transform.Rotate(Config.Vehicles.xRotAmount, 0f, 0f);
				}
				if (Input.GetKey(274))
				{
					transform.Rotate(-Config.Vehicles.xRotAmount, 0f, 0f);
				}
				if (Input.GetKey(276))
				{
					transform.Rotate(0f, 0f, Config.Vehicles.zRotAmount);
				}
				if (Input.GetKey(275))
				{
					transform.Rotate(0f, 0f, -Config.Vehicles.zRotAmount);
				}
				if (Input.GetKey(32))
				{
					transform.position += new Vector3(0f, Config.Vehicles.yPosAmount, 0f);
				}
				if (Input.GetKey(304))
				{
					transform.position -= new Vector3(0f, Config.Vehicles.yPosAmount, 0f);
				}
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000089B6 File Offset: 0x00006BB6
		private void OnGUI()
		{
			if (!Config.Vehicles.enabled || !Config.enabled)
			{
				return;
			}
			this.DrawVehicles();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000089D0 File Offset: 0x00006BD0
		private void DrawVehicles()
		{
			foreach (InteractableVehicle vehicle in this.vehicles)
			{
				try
				{
					this.DrawVehicle(vehicle);
				}
				catch (Exception arg)
				{
					Logger.Log(string.Format("Ошибка при отрисовке авто: {0}", arg));
				}
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00008A24 File Offset: 0x00006C24
		private void DrawVehicle(InteractableVehicle vehicle)
		{
			if ((vehicle.isLocked && Config.Vehicles.notLockedOnly) || vehicle == null)
			{
				return;
			}
			Vector3 position = vehicle.transform.position;
			float num = Vector3.Distance(Camera.main.transform.position, position);
			if (num > Config.Vehicles.maxDistance)
			{
				return;
			}
			Vector3 vector = Camera.main.WorldToScreenPoint(position);
			if (vector.z <= 0f)
			{
				return;
			}
			vector.y = (float)Screen.height - vector.y;
			Color color = Color.white;
			if (vehicle.isLocked)
			{
				color = Config.Vehicles.lockedColor;
			}
			else
			{
				color = Config.Vehicles.notLockedColor;
			}
			if (vehicle.isDriven)
			{
				color = Config.Vehicles.drivenColor;
			}
			string text = "<size=10>";
			text += vehicle.asset.name;
			if (Config.Vehicles.showStats)
			{
				text += string.Format("\nH:{0:.0} F:{1:.0} C:{2:.0}", (int)(vehicle.health / 6), (int)(vehicle.fuel / 10), (int)(vehicle.batteryCharge / 100));
			}
			if (Config.Vehicles.showDistance)
			{
				text += string.Format("\n{0}m", Mathf.Round(num));
			}
			text += "</size>";
			Drawer.DrawString(vector, text, color, 1f, true, false);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00008B74 File Offset: 0x00006D74
		private void UpdateVehicles()
		{
			InteractableVehicle[] array = Object.FindObjectsOfType<InteractableVehicle>();
			if (array != null && array.Length != 0)
			{
				this.vehicles = array;
			}
		}

		// Token: 0x04000042 RID: 66
		public InteractableVehicle[] vehicles;

		// Token: 0x04000043 RID: 67
		private float lastRefreshTime;
	}
}
