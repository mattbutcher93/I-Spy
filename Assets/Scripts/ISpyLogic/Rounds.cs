using UnityEngine;
using UnityEngine.Events;

public class Rounds : MonoBehaviour
{
    public UnityEvent OnRoundStarted;
    public UnityEvent OnAllRoundsFinished;

    [SerializeField]
    private int maxRounds;

    public int RoundNumber { get; private set; }

    public bool unlimitedRounds;

    public void StartRounds()
    {
        RoundNumber = 1;
        OnRoundStarted.Invoke();
    }

    //Returns the current roundNumber
    public int NextRound()
    {
        if (RoundNumber < maxRounds || unlimitedRounds)
        {
            RoundNumber++;
            OnRoundStarted.Invoke();
        }
        else
        {
            OnAllRoundsFinished.Invoke();
        }

        return RoundNumber;
    }
}
