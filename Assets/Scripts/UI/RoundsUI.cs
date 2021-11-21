using UnityEngine;
using TMPro;

public class RoundsUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Rounds rounds;

    private void Awake()
    {
        rounds.OnRoundStarted.AddListener(UpdateRoundsText);
        rounds.OnRoundStarted.AddListener(UpdateRoundStarted);
    }

    private void UpdateRoundStarted()
    {
        text.text = "Round: " + rounds.RoundNumber;
    }

    private void UpdateRoundsText()
    {
        text.text = "Round: " + rounds.RoundNumber;
    }

    private void OnDestroy()
    {
        rounds.OnRoundStarted.RemoveListener(UpdateRoundsText);
        rounds.OnRoundStarted.RemoveListener(UpdateRoundStarted);
    }
}
