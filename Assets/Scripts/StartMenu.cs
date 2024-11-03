using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // 如果使用TextMeshPro，则需要这个命名空间

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // 如果使用TextMeshPro
    // public Text timerText; // 如果使用普通的Text组件，则取消注释这一行

    private float startTime;
    private bool timerRunning = false;

    void Start()
    {
        // 开始计时
        timerRunning = true;
        startTime = Time.time;
    }

    void Update()
    {
        if (timerRunning)
        {
            // 计算已用时间
            float timeElapsed = Time.time - startTime;

            // 转换为分钟、秒和毫秒
            int minutes = Mathf.FloorToInt(timeElapsed / 60F);
            int seconds = Mathf.FloorToInt(timeElapsed % 60F);
            int milliseconds = Mathf.FloorToInt((timeElapsed * 100) % 100);

            // 格式化时间文本并显示
            timerText.text = string.Format("Time: {0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
    }

    // 停止计时器的方法（在需要时调用，比如游戏结束）
    public void StopTimer()
    {
        timerRunning = false;
    }
}
