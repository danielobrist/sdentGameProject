using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float deathSlomoFactor = 1000f;
    
    public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {

        // slow time
        Time.timeScale = 1f / deathSlomoFactor;
        Time.fixedDeltaTime = Time.fixedDeltaTime / deathSlomoFactor;

        yield return new WaitForSeconds(4f / deathSlomoFactor);

        // set back time
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * deathSlomoFactor;

        SceneManager.LoadScene("Game_Over");
    }
}
