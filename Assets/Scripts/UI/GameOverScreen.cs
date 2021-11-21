using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI gameOverTextField;
    [SerializeField]
    private TextMeshProUGUI scoreTextField;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;

        gameOverTextField.text = GameManager.gameWon ? "Game Complete" : "Game Over";
        scoreTextField.text = "Score: " + GameManager.score;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}