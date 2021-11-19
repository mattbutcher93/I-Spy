using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lives : MonoBehaviour
{
    public UnityEvent OnNoLives;
    public UnityEvent OnLifeLost;

    [SerializeField]
    private int maxLives = 3;

    public int CurrentLives { get; private set; }

    private void Start()
    {
        CurrentLives = maxLives;
    }

    //Lose a life and return current lives
    public int LoseALife()
    {
        if (CurrentLives > 0)
        {
            CurrentLives--;
            OnLifeLost.Invoke();
        }

        if (CurrentLives == 0)
        {
            OnNoLives.Invoke();
        }

        return CurrentLives;
    }
}
