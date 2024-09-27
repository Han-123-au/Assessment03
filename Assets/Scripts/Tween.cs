using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tween.cs
public class Tween
{
    public Transform Target { get; private set; }
    public Vector3 StartPos { get; private set; }
    public Vector3 EndPos { get; private set; }
    public float StartTime { get; private set; }
    public float Duration { get; private set; }

    public Tween(Transform target, Vector3 start, Vector3 end, float startTime, float duration)
    {
        Target = target;
        StartPos = start;
        EndPos = end;
        StartTime = startTime;
        Duration = duration;
    }
}
