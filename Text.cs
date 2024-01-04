using System;

namespace SmartlyDressedMama
{
	// Token: 0x0200000D RID: 13
	internal class Text
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00007ED8 File Offset: 0x000060D8
		public static string langRus
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "<color=grey>РУС</color>";
				}
				return "<color=green>РУС</color>";
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00007EEC File Offset: 0x000060EC
		public static string langEng
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "<color=green>ENG</color>";
				}
				return "<color=grey>ENG</color>";
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00007F00 File Offset: 0x00006100
		public static string aim
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Aim";
				}
				return "Аим";
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00007F14 File Offset: 0x00006114
		public static string aim_tp
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "[TEST] TP to me";
				}
				return "<size=9>[TEST]</size> ТП к себе";
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00007F28 File Offset: 0x00006128
		public static string melee
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Punch&Melee";
				}
				return "Punch&Melee";
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00007F3C File Offset: 0x0000613C
		public static string show_angle
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Show FOV";
				}
				return "Отображать FOV";
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00007F50 File Offset: 0x00006150
		public static string show_victim
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Show victim";
				}
				return "Показать жертву";
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00007F64 File Offset: 0x00006164
		public static string players
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Players";
				}
				return "Игроки";
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00007F78 File Offset: 0x00006178
		public static string zombies
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Zombies";
				}
				return "Зомби";
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00007F8C File Offset: 0x0000618C
		public static string vehicles
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Vehicles";
				}
				return "Транспорт";
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00007FA0 File Offset: 0x000061A0
		public static string items
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Items";
				}
				return "Предметы";
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00007FB4 File Offset: 0x000061B4
		public static string misc
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Misc";
				}
				return "Прочее";
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00007FC8 File Offset: 0x000061C8
		public static string reconnect
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Reconnect";
				}
				return "Реконнект";
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00007FDC File Offset: 0x000061DC
		public static string quit
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Quit";
				}
				return "Выйти";
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00007FF0 File Offset: 0x000061F0
		public static string enabled
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Enabled";
				}
				return "Включено";
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00008004 File Offset: 0x00006204
		public static string maxDistance
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Max distance";
				}
				return "Макс. дистанция";
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00008018 File Offset: 0x00006218
		public static string noRecoil
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "NoRecoil";
				}
				return "АнтиОтдача";
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600005E RID: 94 RVA: 0x0000802C File Offset: 0x0000622C
		public static string noSpread
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "NoSpread";
				}
				return "АнтиРазброс";
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00008040 File Offset: 0x00006240
		public static string onlyHeadshots
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "OnlyHeadshots";
				}
				return "Только в голову";
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00008054 File Offset: 0x00006254
		public static string distance
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Distance";
				}
				return "Дистанция";
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00008068 File Offset: 0x00006268
		public static string interval
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Refresh interval";
				}
				return "Интервал обновления";
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000062 RID: 98 RVA: 0x0000807C File Offset: 0x0000627C
		public static string info
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Info";
				}
				return "Информация";
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00008090 File Offset: 0x00006290
		public static string unlockedOnly
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Not locked only";
				}
				return "Только открытые";
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000080A4 File Offset: 0x000062A4
		public static string resetRot
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Reset rotation";
				}
				return "Сбросить ротацию";
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000065 RID: 101 RVA: 0x000080B8 File Offset: 0x000062B8
		public static string speedMultiplier
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Speed multiplier";
				}
				return "Множитель скорости";
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000080CC File Offset: 0x000062CC
		public static string position
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "position";
				}
				return "позиция";
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000067 RID: 103 RVA: 0x000080E0 File Offset: 0x000062E0
		public static string rotation
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "rotation";
				}
				return "ротация";
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000080F4 File Offset: 0x000062F4
		public static string fill
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Fill fuel";
				}
				return "Заправить";
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00008108 File Offset: 0x00006308
		public static string charge
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Charge battery";
				}
				return "Зарядить батарею";
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600006A RID: 106 RVA: 0x0000811C File Offset: 0x0000631C
		public static string repair
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Repair";
				}
				return "Отремонтировать";
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00008130 File Offset: 0x00006330
		public static string category
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Category";
				}
				return "Категория";
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00008144 File Offset: 0x00006344
		public static string filter
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Filter";
				}
				return "Фильтр";
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00008158 File Offset: 0x00006358
		public static string clothes
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Clothes";
				}
				return "Одежда";
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600006E RID: 110 RVA: 0x0000816C File Offset: 0x0000636C
		public static string vests
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Vests";
				}
				return "Жилеты";
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00008180 File Offset: 0x00006380
		public static string backpacks
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Backpacks";
				}
				return "Рюкзаки";
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00008194 File Offset: 0x00006394
		public static string guns
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Guns";
				}
				return "Оружие";
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000081A8 File Offset: 0x000063A8
		public static string attachments
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Attachments";
				}
				return "Обвес";
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000081BC File Offset: 0x000063BC
		public static string resources
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Resources";
				}
				return "Ресурсы";
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000073 RID: 115 RVA: 0x000081D0 File Offset: 0x000063D0
		public static string foodAndWater
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Food and Water";
				}
				return "Еда и вода";
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000074 RID: 116 RVA: 0x000081E4 File Offset: 0x000063E4
		public static string medicine
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Medical";
				}
				return "Медикаменты";
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000075 RID: 117 RVA: 0x000081F8 File Offset: 0x000063F8
		public static string construction
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Construction";
				}
				return "Строительство";
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000076 RID: 118 RVA: 0x0000820C File Offset: 0x0000640C
		public static string throwable
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Throwable";
				}
				return "Бросаемое";
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00008220 File Offset: 0x00006420
		public static string tools
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Tools";
				}
				return "Инструменты";
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00008234 File Offset: 0x00006434
		public static string generators
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Generators";
				}
				return "Генераторы";
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00008248 File Offset: 0x00006448
		public static string other
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Other";
				}
				return "Прочее";
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600007A RID: 122 RVA: 0x0000825C File Offset: 0x0000645C
		public static string speedhack
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Speedhack";
				}
				return "Спидхак";
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00008270 File Offset: 0x00006470
		public static string thirdPerson
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Third person";
				}
				return "3-е лицо";
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00008284 File Offset: 0x00006484
		public static string debugCam
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Debug cam";
				}
				return "Дебаг-камера";
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00008298 File Offset: 0x00006498
		public static string setDay
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Set day";
				}
				return "Установить день";
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600007E RID: 126 RVA: 0x000082AC File Offset: 0x000064AC
		public static string setNight
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Set night";
				}
				return "Установить ночь";
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600007F RID: 127 RVA: 0x000082C0 File Offset: 0x000064C0
		public static string crosshair
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Crosshair";
				}
				return "Прицел";
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000080 RID: 128 RVA: 0x000082D4 File Offset: 0x000064D4
		public static string objects
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Objects";
				}
				return "Объекты";
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000081 RID: 129 RVA: 0x000082E8 File Offset: 0x000064E8
		public static string remove
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Remove";
				}
				return "Удалить";
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000082 RID: 130 RVA: 0x000082FC File Offset: 0x000064FC
		public static string addPhysics
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Add physics";
				}
				return "Добавить физику";
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00008310 File Offset: 0x00006510
		public static string removePhysics
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Remove physics";
				}
				return "Убрать физику";
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00008324 File Offset: 0x00006524
		public static string tpObjectToMe
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "TP object to me";
				}
				return "ТП объект ко мне";
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00008338 File Offset: 0x00006538
		public static string tpToObject
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "TP to object";
				}
				return "ТП к объекту";
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000086 RID: 134 RVA: 0x0000834C File Offset: 0x0000654C
		public static string restore
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Restore";
				}
				return "Восстановить";
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00008360 File Offset: 0x00006560
		public static string buildAnywhere
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "BuildAnywhere";
				}
				return "Разрешить везде";
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00008374 File Offset: 0x00006574
		public static string instaRemove
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Instant Salvage";
				}
				return "Мгновенный разбор";
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00008388 File Offset: 0x00006588
		public static string localPlayer
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "local player";
				}
				return "локальный игрок";
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600008A RID: 138 RVA: 0x0000839C File Offset: 0x0000659C
		public static string otherPlayers
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "other players";
				}
				return "другие игроки";
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600008B RID: 139 RVA: 0x000083B0 File Offset: 0x000065B0
		public static string line
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Line";
				}
				return "Линия";
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600008C RID: 140 RVA: 0x000083C4 File Offset: 0x000065C4
		public static string lineFrom
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Line from";
				}
				return "Линия от";
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000083D8 File Offset: 0x000065D8
		public static string weaponInHands
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Weapon from";
				}
				return "Оружие в руках";
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600008E RID: 142 RVA: 0x000083EC File Offset: 0x000065EC
		public static string highlight
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Highlight";
				}
				return "Контур (свечение)";
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00008400 File Offset: 0x00006600
		public static string customization
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Customization";
				}
				return "Кастомизация";
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00008414 File Offset: 0x00006614
		public static string boxColorDefault
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Box (by default)";
				}
				return "Box (по умолчанию)";
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00008428 File Offset: 0x00006628
		public static string autokick
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Auto-kick";
				}
				return "Авто-кик";
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000092 RID: 146 RVA: 0x0000843C File Offset: 0x0000663C
		public static string far_interaction
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Far interact";
				}
				return "Дальнее взаим.";
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00008450 File Offset: 0x00006650
		public static string hallucination
		{
			get
			{
				if (Text.currentLangId != 0)
				{
					return "Hallucination";
				}
				return "Галлюцинации";
			}
		}

		// Token: 0x04000040 RID: 64
		public static byte currentLangId;
	}
}
