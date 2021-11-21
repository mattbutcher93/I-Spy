using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private ISpyController iSpyController;

    [SerializeField]
    private int lifeLostScoreChange = -30;

    [SerializeField]
    private int correctGuessScoreChange = 90;

    private void Awake()
    {
        if (iSpyController != null)
        {
            iSpyController.OnGuess += GuessScoreChange;
        }
    }

    private void GuessScoreChange(bool correct)
    {
        if (correct)
        {
            CorrectGuess();
        }
        else
        {
            IncorrectGuess();
        }
    }

    private void IncorrectGuess()
    {
        GameManager.score += lifeLostScoreChange;
        LogScore();
    }

    private void CorrectGuess()
    {
        GameManager.score += correctGuessScoreChange;
        LogScore();
    }

    private void LogScore()
    {
        Debug.Log("Score: " + GameManager.score);
    }
}
