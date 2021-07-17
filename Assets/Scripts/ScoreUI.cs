using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoreManager scoreManager;
    void Start()
    {
        //scoreManager.AddScore(new Score("marco", 10));
        //scoreManager.AddScore(new Score("salvo", 11));
        var scores = scoreManager.GetHighScores().ToArray();
        for(int i=0; i<scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.nome.text = scores[i].nome;
            row.score.text = scores[i].score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
