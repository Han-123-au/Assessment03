using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tweener : MonoBehaviour
{
    private List<Tween> activeTweens = new List<Tween>();

    public void AddTween(Transform target, Vector3 start, Vector3 end, float duration)
    {
        // 移除同一目标上已存在的Tween，避免重叠运动
        activeTweens.RemoveAll(t => t.Target == target);

        // 创建新的Tween并添加到列表
        Tween newTween = new Tween(target, start, end, Time.time, duration);
        activeTweens.Add(newTween);
    }

    void Update()
    {
        // 遍历并更新所有Tween
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
                // 完成Tween后确保目标处于最终位置
                tween.Target.position = tween.EndPos;
                activeTweens.RemoveAt(i);
            }
        }
    }
}
