﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
    public void ChangeToGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}

