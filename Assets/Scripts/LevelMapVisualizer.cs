using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMapVisualizer : MonoBehaviour
{
    public int[,] levelMap;

    void OnDrawGizmos()
    {
        if (levelMap == null) return;

        int width = levelMap.GetLength(0);
        int height = levelMap.GetLength(1);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Gizmos.color = levelMap[x, y] == 0 ? Color.green : Color.red;
                Vector3 pos = new Vector3(x, y, 0);
                Gizmos.DrawCube(pos, Vector3.one * 0.95f);
            }
        }
    }
}
