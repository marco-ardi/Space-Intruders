using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : Singleton<Timer>
{
    public static float timer = 0f;
    public static int time = 0;
    public float delay = 1.0f;
    [SerializeField] private Text timerText;


    void Start()
    {
        timerText = GetComponent<Text>();
        StartCoroutine(SetTime());
    }

    private IEnumerator SetTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time++;
            timerText.text = "Time: " + time;
        }
    }   
}

