using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void ChangeToGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
