using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddEntry : MonoBehaviour
{
    public GameObject scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewScore(string nome)
    {
        scoreManager.GetComponent<ScoreManager>().AddScore(new Score(nome, PlayerScore.score));
    }
}
