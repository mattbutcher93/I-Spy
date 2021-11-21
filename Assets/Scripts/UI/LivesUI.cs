using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textField;

    [SerializeField]
    private Lives lives;

    private void Awake()
    {
        lives.OnLifeLost.AddListener(UpdateLifeText);
        lives.OnLivesSet.AddListener(UpdateLifeText);
    }

    private void UpdateLifeText()
    {
        textField.text = "Lives: " + lives.CurrentLives;
    }

    private void OnDestroy()
    {
        lives.OnLifeLost.RemoveListener(UpdateLifeText);
        lives.OnLivesSet.RemoveListener(UpdateLifeText);
    }
}
