﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void GameQuit()
    {
        Application.Quit ();
        Debug.Log("Game is exiting");
    }
}