using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void EnterGame()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
