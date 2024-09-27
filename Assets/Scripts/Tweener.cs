using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tweener : MonoBehaviour
{
    private List<Tween> activeTweens = new List<Tween>();

    public void AddTween(Transform target, Vector3 start, Vector3 end, float duration)
    {
        // �Ƴ�ͬһĿ�����Ѵ��ڵ�Tween�������ص��˶�
        activeTweens.RemoveAll(t => t.Target == target);

        // �����µ�Tween����ӵ��б�
        Tween newTween = new Tween(target, start, end, Time.time, duration);
        activeTweens.Add(newTween);
    }

    void Update()
    {
        // ��������������Tween
        for (int i = activeTweens.Count - 1; i >= 0; i--)
        {
            Tween tween = activeTweens[i];
            float timeFraction = (Time.time - tween.StartTime) / tween.Duration;

            if (timeFraction < 1.0f)
            {
                tween.Target.position = Vector3.Lerp(tween.StartPos, tween.EndPos, timeFraction);
            }
            else
            {
                // ���Tween��ȷ��Ŀ�괦������λ��
                tween.Target.position = tween.EndPos;
                activeTweens.RemoveAt(i);
            }
        }
    }
}
