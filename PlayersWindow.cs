using System;
using UnityEngine;

namespace SmartlyDressedMama
{
	// Token: 0x0200000B RID: 11
	internal class PlayersWindow
	{
		// Token: 0x06000047 RID: 71 RVA: 0x0000768C File Offset: 0x0000588C
		public static void Window(int WindowID)
		{
			float num = 5f;
			float num2 = 20f;
			float num3 = 140f;
			float num4 = 20f;
			float num5 = 10f;
			float num6 = 25f;
			float num7 = num;
			float num8 = num2;
			GUI.Label(new Rect(num7, num8, num3, num4), "<b>ESP</b>");
			num8 += num6 - 5f;
			if (GUI.Button(new Rect(num7, num8, num3, num4), Text.enabled + ": " + (Config.Players.enabled ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Players.enabled = !Config.Players.enabled;
			}
			num8 += num6;
			if (GUI.Button(new Rect(num7, num8, num3, num4), "Box: " + (Config.Players.espBox ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Players.espBox = !Config.Players.espBox;
			}
			num8 += num6;
			if (GUI.Button(new Rect(num7, num8, num3, num4), Text.line + ": " + (Config.Players.espLine ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Players.espLine = !Config.Players.espLine;
			}
			num8 += num6;
			if (GUI.Button(new Rect(num7, num8, num3, num4), string.Format("{0}: {1}", Text.lineFrom, Config.Players.espLineStart), Interface.buttonStyle))
			{
				switch (Config.Players.espLineStart)
				{
				case Config.Players.ESPLineStart.верх:
					Config.Players.espLineStart = Config.Players.ESPLineStart.центр;
					break;
				case Config.Players.ESPLineStart.центр:
					Config.Players.espLineStart = Config.Players.ESPLineStart.низ;
					break;
				case Config.Players.ESPLineStart.низ:
					Config.Players.espLineStart = Config.Players.ESPLineStart.верх;
					break;
				}
			}
			num8 += num6;
			if (GUI.Button(new Rect(num7, num8, num3, num4), Text.info + ": " + (Config.Players.espInfo ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Players.espInfo = !Config.Players.espInfo;
			}
			num8 += num6;
			if (GUI.Button(new Rect(num7, num8, num3, num4), Text.distance + ": " + (Config.Players.espDistance ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Players.espDistance = !Config.Players.espDistance;
			}
			num8 += num6;
			if (GUI.Button(new Rect(num7, num8, num3, num4), Text.weaponInHands + ": " + (Config.Players.espShowWeapon ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Players.espShowWeapon = !Config.Players.espShowWeapon;
			}
			num8 += num6;
			if (GUI.Button(new Rect(num7, num8, num3, num4), Text.highlight + ": " + (Config.Players.highlight ? "+" : "-"), Interface.buttonStyle))
			{
				Config.Players.highlight = !Config.Players.highlight;
			}
			num8 += num6;
			GUI.Label(new Rect(num7, num8, num3, num4), string.Concat(new string[]
			{
				"<size=11>",
				Text.maxDistance,
				" (",
				Config.Players.maxDistance.ToString("0"),
				"):</size>"
			}));
			num8 += num6 - 5f;
			float num9 = GUI.HorizontalSlider(new Rect(num7, num8, num3, num4), Config.Players.maxDistance, 100f, 2000f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num9 != Config.Players.maxDistance)
			{
				Config.Players.maxDistance = num9;
			}
			num8 += num6 - 10f;
			GUI.Label(new Rect(num7, num8, num3, num4), string.Concat(new string[]
			{
				"<size=11>",
				Text.interval,
				" (",
				Config.Players.refreshInterval.ToString("0"),
				"):</size>"
			}));
			num8 += num6 - 5f;
			float num10 = GUI.HorizontalSlider(new Rect(num7, num8, num3, num4), Config.Players.refreshInterval, 0.1f, 10f, Interface.sliderStyle, Interface.sliderThumbStyle);
			if (num10 != Config.Players.refreshInterval)
			{
				Config.Players.refreshInterval = num10;
			}
			num8 = num2;
			num7 += num3 + num5;
			GUI.Label(new Rect(num7, num8, num3, num4), "<b>ESP " + Text.customization + " [RGB]</b>");
			num8 += num6 - 5f;
			GUI.Label(new Rect(num7, num8, num3, num4), Text.highlight ?? "");
			num8 += num6 - 5f;
			float num11 = GUI.HorizontalSlider(new Rect(num7, num8, num3, num4), Config.Players.highlightColor.r, 0f, 1f, Interface.sliderStyle, Interface.sliderThumbStyle);
			num8 += num6 - 5f;
			float num12 = GUI.HorizontalSlider(new Rect(num7, num8, num3, num4), Config.Players.highlightColor.g, 0f, 1f, Interface.sliderStyle, Interface.sliderThumbStyle);
			num8 += num6 - 5f;
			float num13 = GUI.HorizontalSlider(new Rect(num7, num8, num3, num4), Config.Players.highlightColor.b, 0f, 1f, Interface.sliderStyle, Interface.sliderThumbStyle);
			Color color;
			color..ctor(num11, num12, num13);
			if (color != Config.Players.highlightColor)
			{
				Config.Players.highlightColor = color;
			}
			num8 += num6;
			GUI.Label(new Rect(num7, num8, num3, num4), Text.boxColorDefault ?? "");
			num8 += num6 - 5f;
			float num14 = GUI.HorizontalSlider(new Rect(num7, num8, num3, num4), Config.Players.defaultEspColor.r, 0f, 1f, Interface.sliderStyle, Interface.sliderThumbStyle);
			num8 += num6 - 5f;
			float num15 = GUI.HorizontalSlider(new Rect(num7, num8, num3, num4), Config.Players.defaultEspColor.g, 0f, 1f, Interface.sliderStyle, Interface.sliderThumbStyle);
			num8 += num6 - 5f;
			float num16 = GUI.HorizontalSlider(new Rect(num7, num8, num3, num4), Config.Players.defaultEspColor.b, 0f, 1f, Interface.sliderStyle, Interface.sliderThumbStyle);
			Color color2;
			color2..ctor(num14, num15, num16);
			if (color2 != Config.Players.defaultEspColor)
			{
				Config.Players.defaultEspColor = color2;
			}
			num8 += num6;
			GUI.Label(new Rect(num7, num8, num3, num4), "Box (<120m)");
			num8 += num6 - 5f;
			float num17 = GUI.HorizontalSlider(new Rect(num7, num8, num3, num4), Config.Players.visibleEspColor.r, 0f, 1f, Interface.sliderStyle, Interface.sliderThumbStyle);
			num8 += num6 - 5f;
			float num18 = GUI.HorizontalSlider(new Rect(num7, num8, num3, num4), Config.Players.visibleEspColor.g, 0f, 1f, Interface.sliderStyle, Interface.sliderThumbStyle);
			num8 += num6 - 5f;
			float num19 = GUI.HorizontalSlider(new Rect(num7, num8, num3, num4), Config.Players.visibleEspColor.b, 0f, 1f, Interface.sliderStyle, Interface.sliderThumbStyle);
			Color color3;
			color3..ctor(num17, num18, num19);
			if (color3 != Config.Players.visibleEspColor)
			{
				Config.Players.visibleEspColor = color3;
			}
		}

		// Token: 0x0400003F RID: 63
		public static Rect playersWindowRect = new Rect(Interface.xOffset, Interface.yOffset, 300f, 315f);
	}
}
