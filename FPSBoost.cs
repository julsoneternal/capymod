using System;
using System.Collections;
using UnityEngine;

namespace SmartlyDressedMama
{
	// Token: 0x02000005 RID: 5
	public class FPSBoost : MonoBehaviour
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002738 File Offset: 0x00000938
		public void ToggleFPSBoost()
		{
			this.enableFPSBoost = !this.enableFPSBoost;
			this.whiteMaterial = new Material(Shader.Find("Standard"));
			Terrain activeTerrain = Terrain.activeTerrain;
			QualitySettings.shadows = (this.enableFPSBoost ? 0 : 2);
			QualitySettings.masterTextureLimit = (this.enableFPSBoost ? 1 : 0);
			QualitySettings.antiAliasing = (this.enableFPSBoost ? 0 : 2);
			QualitySettings.pixelLightCount = (this.enableFPSBoost ? 0 : 4);
			QualitySettings.shadowResolution = (this.enableFPSBoost ? 0 : 2);
			QualitySettings.realtimeReflectionProbes = !this.enableFPSBoost;
			if (this.enableFPSBoost)
			{
				activeTerrain.detailObjectDensity = 0f;
				activeTerrain.heightmapPixelError = 20f;
				activeTerrain.terrainData.heightmapResolution = 4;
				activeTerrain.terrainData.SetDetailResolution(4, activeTerrain.terrainData.detailResolutionPerPatch);
				RenderSettings.skybox = null;
				RenderSettings.fog = false;
				RenderSettings.reflectionIntensity = 0f;
				RenderSettings.sun = null;
				base.StartCoroutine(this.ReplaceMaterialsEvery3Seconds());
			}
			else
			{
				base.StopCoroutine(this.ReplaceMaterialsEvery3Seconds());
			}
			ParticleSystem[] array = Object.FindObjectsOfType<ParticleSystem>();
			for (int i = 0; i < array.Length; i++)
			{
				ParticleSystem.MainModule main = array[i].main;
				main.maxParticles = (this.enableFPSBoost ? (main.maxParticles / 2) : (main.maxParticles * 2));
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000288D File Offset: 0x00000A8D
		private IEnumerator ReplaceMaterialsEvery3Seconds()
		{
			while (this.enableFPSBoost)
			{
				this.ReplaceAllMaterials();
				yield return new WaitForSeconds(3f);
			}
			yield break;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000289C File Offset: 0x00000A9C
		private void ReplaceAllMaterials()
		{
			this.whiteMaterial.color = Color.white;
			MeshRenderer[] array = Object.FindObjectsOfType<MeshRenderer>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].material = this.whiteMaterial;
			}
		}

		// Token: 0x04000013 RID: 19
		public bool enableFPSBoost;

		// Token: 0x04000014 RID: 20
		private Material whiteMaterial;
	}
}
