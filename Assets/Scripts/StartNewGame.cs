﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
    public void ChangeToGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
