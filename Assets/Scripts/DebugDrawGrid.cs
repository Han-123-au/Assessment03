using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DebugDrawGrid : MonoBehaviour
{
    public Tilemap tilemap; // ȷ����Inspector�н�Tilemap�����ק������ֶ�

    void OnDrawGizmos()
    {
        if (tilemap != null)
        {
            Gizmos.color = Color.yellow; // ����Gizmos����ɫΪ��ɫ
            Vector3 size = new Vector3(tilemap.cellSize.x * tilemap.size.x, tilemap.cellSize.y * tilemap.size.y, 1);
            Vector3 center = tilemap.transform.position + size / 2;

            // ����Tilemap�ı߽��
            Gizmos.DrawWireCube(center, size);

            // ����ԭ��λ��
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(tilemap.transform.position, 0.1f); // ԭ���ú�ɫ���ʾ
        }
    }
}
