using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static Timer _instance;
    public static float timer = 0f;
    public static int time = 0;
    public float delay = 1.0f;
    [SerializeField] private Text timerText;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

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

