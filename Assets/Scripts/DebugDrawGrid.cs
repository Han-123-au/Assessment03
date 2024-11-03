using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DebugDrawGrid : MonoBehaviour
{
    public Tilemap tilemap; // 确保在Inspector中将Tilemap组件拖拽到这个字段

    void OnDrawGizmos()
    {
        if (tilemap != null)
        {
            Gizmos.color = Color.yellow; // 设置Gizmos的颜色为黄色
            Vector3 size = new Vector3(tilemap.cellSize.x * tilemap.size.x, tilemap.cellSize.y * tilemap.size.y, 1);
            Vector3 center = tilemap.transform.position + size / 2;

            // 绘制Tilemap的边界框
            Gizmos.DrawWireCube(center, size);

            // 绘制原点位置
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(tilemap.transform.position, 0.1f); // 原点用红色球表示
        }
    }
}
