using UnityEngine;
using TMPro;

public class RoundsUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textField;

    [SerializeField]
    private Rounds rounds;

    private void Awake()
    {
        rounds.OnRoundStarted.AddListener(UpdateRoundsText);
        rounds.OnRoundStarted.AddListener(UpdateRoundStarted);
    }

    private void UpdateRoundStarted()
    {
        textField.text = "Round: " + rounds.RoundNumber;
    }

    private void UpdateRoundsText()
    {
        textField.text = "Round: " + rounds.RoundNumber;
    }

    private void OnDestroy()
    {
        rounds.OnRoundStarted.RemoveListener(UpdateRoundsText);
        rounds.OnRoundStarted.RemoveListener(UpdateRoundStarted);
    }
}
