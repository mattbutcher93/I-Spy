using UnityEngine;
using TMPro;

public class ScoreElementUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameTextField;

    [SerializeField]
    private TextMeshProUGUI scoreTextField;

    public void SetElement(HighScores.ScoreEntry scoreEntry)
    {
        nameTextField.text = scoreEntry.name;
        scoreTextField.text = "Score: " + scoreEntry.score;
    }
}
