using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public TextMesh scoreText;
    public void ChangeToGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    void Start()
    {
        scoreText.text = "Score:" + PlayerScore.Score;
    }
}
