﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTutorial : MonoBehaviour
{
    public void StartIt()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
