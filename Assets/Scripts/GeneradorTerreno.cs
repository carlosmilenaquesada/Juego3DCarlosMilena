
using UnityEngine;

public class GeneradorTerreno : MonoBehaviour
{
    private float perlinNoise = 0f;
    private float refinamiento = 0.02f;
    private float alturaMedia = 0.25f;
    public Terrain terreno;
    void Start()
    {
        float[,] alturas = terreno.terrainData.GetHeights(0, 0, terreno.terrainData.heightmapResolution, terreno.terrainData.heightmapResolution);

        for (int i = 0; i < alturas.GetLength(0); i++)
        {
            for (int j = 0; j < alturas.GetLength(1); j++)
            {
                perlinNoise = Mathf.PerlinNoise(i * refinamiento, j * refinamiento) * alturaMedia;
                alturas[i, j] = perlinNoise;
                

            }
        }

        


    }

}
