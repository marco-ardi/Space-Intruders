using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    ScoreData sd;

    private void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(x => x.score);   //ordino in maniera decrescente ogni score
    }

    public void AddScore(Score newScore)
    {
        if(sd.scores.Count == 5)    //se sono 5, controlla che il punteggio sia alto e sostituisci
        {
            for(int i= sd.scores.Count-1; i>0; i--) //
            {
                if(sd.scores[i].score < newScore.score)
                {
                    sd.scores[i].nome = newScore.nome;
                    sd.scores[i].score = newScore.score;
                    break;
                }
            }
        }
        sd.scores.Add(newScore);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
    }
}
