using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        GameManager.gameWon = false;
        GameManager.score = 0;
    }

    public void EnterGame()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
