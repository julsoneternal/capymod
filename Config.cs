using System;
using SDG.Unturned;
using UnityEngine;

namespace SmartlyDressedMama
{
	// Token: 0x02000003 RID: 3
	internal class Config
	{
		// Token: 0x0400000E RID: 14
		public static bool debug = false;

		// Token: 0x0400000F RID: 15
		public static bool enabled = true;

		// Token: 0x04000010 RID: 16
		public static string version = "2.16";

		// Token: 0x02000011 RID: 17
		public static class Windows
		{
			// Token: 0x04000046 RID: 70
			public static bool mainWindow = true;

			// Token: 0x04000047 RID: 71
			public static bool aimWindow = false;

			// Token: 0x04000048 RID: 72
			public static bool playersWindow = false;

			// Token: 0x04000049 RID: 73
			public static bool zombiesWindow = false;

			// Token: 0x0400004A RID: 74
			public static bool vehiclesWindow = false;

			// Token: 0x0400004B RID: 75
			public static bool itemsWindow = false;

			// Token: 0x0400004C RID: 76
			public static bool miscWindow = false;
		}

		// Token: 0x02000012 RID: 18
		public static class Aim
		{
			// Token: 0x0400004D RID: 77
			public static bool enabled = false;

			// Token: 0x0400004E RID: 78
			public static bool melee = true;

			// Token: 0x0400004F RID: 79
			public static bool guns = true;

			// Token: 0x04000050 RID: 80
			public static bool tp = false;

			// Token: 0x04000051 RID: 81
			public static bool zombie = true;

			// Token: 0x04000052 RID: 82
			public static bool showAngle = true;

			// Token: 0x04000053 RID: 83
			public static bool showVictim = false;

			// Token: 0x04000054 RID: 84
			public static float angle = 30f;

			// Token: 0x04000055 RID: 85
			public static float maxDistance = 250f;
		}

		// Token: 0x02000013 RID: 19
		public static class Players
		{
			// Token: 0x04000056 RID: 86
			public static bool enabled = true;

			// Token: 0x04000057 RID: 87
			public static float maxDistance = 650f;

			// Token: 0x04000058 RID: 88
			public static float refreshInterval = 1f;

			// Token: 0x04000059 RID: 89
			public static bool highlight = false;

			// Token: 0x0400005A RID: 90
			public static Color highlightColor = Color.yellow;

			// Token: 0x0400005B RID: 91
			public static bool espBox = true;

			// Token: 0x0400005C RID: 92
			public static bool espLine = true;

			// Token: 0x0400005D RID: 93
			public static bool espInfo = true;

			// Token: 0x0400005E RID: 94
			public static bool espDistance = true;

			// Token: 0x0400005F RID: 95
			public static bool espIsBleeding = true;

			// Token: 0x04000060 RID: 96
			public static bool espIsBrokenLeg = true;

			// Token: 0x04000061 RID: 97
			public static bool espShowWeapon = true;

			// Token: 0x04000062 RID: 98
			public static float distanceVisible = 120f;

			// Token: 0x04000063 RID: 99
			public static float distanceClose = 300f;

			// Token: 0x04000064 RID: 100
			public static Color defaultEspColor = Color.green;

			// Token: 0x04000065 RID: 101
			public static float defaultEspThickness = 1f;

			// Token: 0x04000066 RID: 102
			public static Color visibleEspColor = Color.red;

			// Token: 0x04000067 RID: 103
			public static float visibleEspThickness = 1.4f;

			// Token: 0x04000068 RID: 104
			public static Color deadEspColor = Color.black;

			// Token: 0x04000069 RID: 105
			public static float deadEspThickness = 0.5f;

			// Token: 0x0400006A RID: 106
			public static Color distanceColor = Color.gray;

			// Token: 0x0400006B RID: 107
			public static Config.Players.ESPLineStart espLineStart = Config.Players.ESPLineStart.низ;

			// Token: 0x0200002D RID: 45
			public enum ESPLineStart
			{
				// Token: 0x040000BD RID: 189
				верх,
				// Token: 0x040000BE RID: 190
				центр,
				// Token: 0x040000BF RID: 191
				низ
			}
		}

		// Token: 0x02000014 RID: 20
		public static class Vehicles
		{
			// Token: 0x0400006C RID: 108
			public static bool enabled = false;

			// Token: 0x0400006D RID: 109
			public static float maxDistance = 800f;

			// Token: 0x0400006E RID: 110
			public static float refreshInterval = 3f;

			// Token: 0x0400006F RID: 111
			public static bool showStats = true;

			// Token: 0x04000070 RID: 112
			public static bool showDistance = true;

			// Token: 0x04000071 RID: 113
			public static bool notLockedOnly = false;

			// Token: 0x04000072 RID: 114
			public static Color lockedColor = new Color(1f, 0.7f, 0.7f);

			// Token: 0x04000073 RID: 115
			public static Color notLockedColor = new Color(0.7f, 1f, 0.7f);

			// Token: 0x04000074 RID: 116
			public static Color drivenColor = new Color(1f, 1f, 0.7f);

			// Token: 0x04000075 RID: 117
			public static bool noClip = false;

			// Token: 0x04000076 RID: 118
			public static float noClipSpeedMultiplier = 1f;

			// Token: 0x04000077 RID: 119
			public static float xRotAmount = 1.5f;

			// Token: 0x04000078 RID: 120
			public static float yRotAmount = 2f;

			// Token: 0x04000079 RID: 121
			public static float zRotAmount = 1.5f;

			// Token: 0x0400007A RID: 122
			public static float yPosAmount = 0.2f;
		}

		// Token: 0x02000015 RID: 21
		public static class Items
		{
			// Token: 0x0400007B RID: 123
			public static bool enabled = false;

			// Token: 0x0400007C RID: 124
			public static float maxDistance = 120f;

			// Token: 0x0400007D RID: 125
			public static float refreshInterval = 1f;

			// Token: 0x0400007E RID: 126
			public static bool showCategory = true;

			// Token: 0x0400007F RID: 127
			public static bool showDistance = true;

			// Token: 0x04000080 RID: 128
			public static bool autoPickup = false;

			// Token: 0x04000081 RID: 129
			public static float autoPickupMaxDistance = 20f;

			// Token: 0x04000082 RID: 130
			public static EItemType[] itemsToAutoPickup = new EItemType[0];

			// Token: 0x04000083 RID: 131
			public static Color espColor = new Color(0.9f, 0.9f, 0.9f);

			// Token: 0x04000084 RID: 132
			public static bool filterClothes = true;

			// Token: 0x04000085 RID: 133
			public static bool filterVest = true;

			// Token: 0x04000086 RID: 134
			public static bool filterBackpack = true;

			// Token: 0x04000087 RID: 135
			public static bool filterGuns = true;

			// Token: 0x04000088 RID: 136
			public static bool filterAttachments = true;

			// Token: 0x04000089 RID: 137
			public static bool filterSupply = true;

			// Token: 0x0400008A RID: 138
			public static bool filterFoodAndWater = true;

			// Token: 0x0400008B RID: 139
			public static bool filterMedicine = true;

			// Token: 0x0400008C RID: 140
			public static bool filterTool = true;

			// Token: 0x0400008D RID: 141
			public static bool filterFuel = true;

			// Token: 0x0400008E RID: 142
			public static bool filterConstruction = true;

			// Token: 0x0400008F RID: 143
			public static bool filterThrowable = true;

			// Token: 0x04000090 RID: 144
			public static bool filterGenerator = true;

			// Token: 0x04000091 RID: 145
			public static bool filterOther = true;
		}

		// Token: 0x02000016 RID: 22
		public static class Zombies
		{
			// Token: 0x04000092 RID: 146
			public static bool enabled = false;

			// Token: 0x04000093 RID: 147
			public static float maxDistance = 80f;

			// Token: 0x04000094 RID: 148
			public static float refreshInterval = 2f;

			// Token: 0x04000095 RID: 149
			public static bool showDistance = true;

			// Token: 0x04000096 RID: 150
			public static Color espColor = new Color(0.6f, 0.7f, 0.6f);
		}

		// Token: 0x02000017 RID: 23
		public static class Misc
		{
			// Token: 0x04000097 RID: 151
			public static bool noRecoil = false;

			// Token: 0x04000098 RID: 152
			public static bool noSpread = false;

			// Token: 0x04000099 RID: 153
			public static bool onlyHeadshots = false;

			// Token: 0x0400009A RID: 154
			public static bool buildAnywhere = false;

			// Token: 0x0400009B RID: 155
			public static bool crosshair = false;

			// Token: 0x0400009C RID: 156
			public static bool autoKick = true;

			// Token: 0x0400009D RID: 157
			public static bool autoReconnect = true;

			// Token: 0x0400009E RID: 158
			public static int autoReconnectTime = 380;

			// Token: 0x0400009F RID: 159
			public static bool immediateSalvage = false;

			// Token: 0x040000A0 RID: 160
			public static bool autokick_10hp = false;

			// Token: 0x040000A1 RID: 161
			public static bool autokick_5hp = false;

			// Token: 0x040000A2 RID: 162
			public static bool autokick_3hp = false;

			// Token: 0x040000A3 RID: 163
			public static bool autokick_1hp = false;

			// Token: 0x040000A4 RID: 164
			public static bool far_interaction = true;

			// Token: 0x040000A5 RID: 165
			public static bool hallucination = true;

			// Token: 0x040000A6 RID: 166
			public static bool emo_mode = false;
		}
	}
}
