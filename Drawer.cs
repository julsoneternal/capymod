using System;
using UnityEngine;

namespace SmartlyDressedMama
{
	// Token: 0x02000004 RID: 4
	internal class Drawer
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000023BE File Offset: 0x000005BE
		// (set) Token: 0x0600000B RID: 11 RVA: 0x000023C5 File Offset: 0x000005C5
		public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000023CD File Offset: 0x000005CD
		// (set) Token: 0x0600000D RID: 13 RVA: 0x000023D4 File Offset: 0x000005D4
		public static Color Color
		{
			get
			{
				return GUI.color;
			}
			set
			{
				GUI.color = value;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000023DC File Offset: 0x000005DC
		public static void DrawString(Vector2 position, string label, Color color, float sizeMultiplier = 1f, bool centered = true, bool bottom = false)
		{
			sizeMultiplier = 1f;
			Color color2 = GUI.color;
			GUI.color = Color.black;
			GUIContent guicontent = new GUIContent(label);
			Vector2 vector = Drawer.StringStyle.CalcSize(guicontent) * sizeMultiplier;
			if (bottom)
			{
				position.y += vector.y - 15f;
			}
			object obj = centered ? (position - vector / 2f) : position;
			int fontSize = Drawer.StringStyle.fontSize;
			Drawer.StringStyle.fontSize = (int)((float)fontSize * sizeMultiplier);
			object obj2 = obj;
			GUI.Label(new Rect(obj2 + new Vector2(1f, 1f), vector), guicontent);
			GUI.Label(new Rect(obj2 + new Vector2(-1f, -1f), vector), guicontent);
			GUI.Label(new Rect(obj2 + new Vector2(-1f, 1f), vector), guicontent);
			GUI.Label(new Rect(obj2 + new Vector2(1f, -1f), vector), guicontent);
			GUI.color = color;
			GUI.Label(new Rect(obj2, vector), guicontent);
			Drawer.StringStyle.fontSize = fontSize;
			GUI.color = color2;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000250C File Offset: 0x0000070C
		public static void DrawLine(Vector2 pointA, Vector2 pointB, float width, Color color)
		{
			Matrix4x4 matrix = GUI.matrix;
			Color color2 = GUI.color;
			GUI.color = color;
			float num = Vector3.Angle(pointB - pointA, Vector2.right);
			if (pointA.y > pointB.y)
			{
				num = -num;
			}
			GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));
			GUIUtility.RotateAroundPivot(num, pointA);
			GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1f, 1f), Drawer.lineTex);
			GUI.matrix = matrix;
			GUI.color = color2;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000025C0 File Offset: 0x000007C0
		public static void DrawBox(float x, float y, float w, float h, float thickness, Color color)
		{
			Drawer.DrawLine(new Vector2(x, y), new Vector2(x + w, y), thickness, color);
			Drawer.DrawLine(new Vector2(x, y), new Vector2(x, y + h + 1f), thickness, color);
			Drawer.DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), thickness, color);
			Drawer.DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), thickness, color);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002640 File Offset: 0x00000840
		public static void DrawCircle(float FOV, Color color, float thickness = 2f)
		{
			float num = FOV / 90f * ((float)Screen.height / 2f);
			float num2 = (float)Screen.width;
			float num3 = (float)Screen.height;
			Vector2 vector;
			vector..ctor(num2 / 2f, num3 / 2f);
			int num4 = 24;
			for (int i = 0; i < num4; i++)
			{
				float num5 = 0.017453292f * ((float)i * 360f / (float)num4);
				Vector2 pointA = new Vector2(num * Mathf.Cos(num5), num * Mathf.Sin(num5)) + vector;
				num5 = 0.017453292f * ((float)(i + 1) * 360f / (float)num4);
				Vector2 pointB = new Vector2(num * Mathf.Cos(num5), num * Mathf.Sin(num5)) + vector;
				Drawer.DrawLine(pointA, pointB, thickness, color);
			}
		}

		// Token: 0x04000012 RID: 18
		private static Texture2D lineTex = new Texture2D(1, 1);
	}
}
