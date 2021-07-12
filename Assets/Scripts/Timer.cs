using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
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
    
    /*void Update()
    {
        timer += Time.deltaTime;
        if(time >= delay)
        {
            timer = 0f;
            time++;
            Debug.Log(time);
            timerText.text = "Time: " + time;
        }
    }*/
}
