using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerScore
{
    private static int score = 0;
    private static bool alive = true;

    public static int Score
    {
        get => score;
        set => score = value;
    }

    public static bool Alive
    {
        get => alive;
        set => alive = value;
    }
}
