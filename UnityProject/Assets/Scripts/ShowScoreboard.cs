using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScoreboard : MonoBehaviour
{
    public Canvas scoreCanvas;
    //public GameObject scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreCanvas = GameObject.Find("ScoreBoard").GetComponent<Canvas>();
        //scoreManager = GameObject.Find("ScoreManager").GetComponent<GameObject>();
        //scoreCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            scoreCanvas.enabled = !scoreCanvas.enabled;     //accende/spegne la canvas
        }
        
    }
}
