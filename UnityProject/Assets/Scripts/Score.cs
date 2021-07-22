using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]      //necessario per json
public class Score
{
    public string nome;
    public float score;

    public Score(string nome, float score)
    {
        this.nome = nome;
        this.score = score;
    }
}
