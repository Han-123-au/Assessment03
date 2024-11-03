using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // ���ʹ��TextMeshPro������Ҫ��������ռ�

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // ���ʹ��TextMeshPro
    // public Text timerText; // ���ʹ����ͨ��Text�������ȡ��ע����һ��

    private float startTime;
    private bool timerRunning = false;

    void Start()
    {
        // ��ʼ��ʱ
        timerRunning = true;
        startTime = Time.time;
    }

    void Update()
    {
        if (timerRunning)
        {
            // ��������ʱ��
            float timeElapsed = Time.time - startTime;

            // ת��Ϊ���ӡ���ͺ���
            int minutes = Mathf.FloorToInt(timeElapsed / 60F);
            int seconds = Mathf.FloorToInt(timeElapsed % 60F);
            int milliseconds = Mathf.FloorToInt((timeElapsed * 100) % 100);

            // ��ʽ��ʱ���ı�����ʾ
            timerText.text = string.Format("Time: {0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
    }

    // ֹͣ��ʱ���ķ���������Ҫʱ���ã�������Ϸ������
    public void StopTimer()
    {
        timerRunning = false;
    }
}
