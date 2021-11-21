using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject[] overlayItems;
    public GameObject[] quitItems;

    private bool quitVisible = false;

    private void Awake()
    {
        for (int i = 0; i < quitItems.Length; i++)
        {
            quitItems[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            quitVisible = !quitVisible;
            for (int i = 0; i < overlayItems.Length; i++)
            {
                overlayItems[i].SetActive(!quitVisible);
            }
            for (int i = 0; i < quitItems.Length; i++)
            {
                quitItems[i].SetActive(quitVisible);
            }

            Cursor.lockState = quitVisible ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
