using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Rounds))]
public class ISpyController : MonoBehaviour
{
    public delegate void ISpyRequesetEventHandler(SpyObjectData spyObjectData);
    public delegate void ISpyGuessEventHandler(bool isCorrect);

    public event ISpyRequesetEventHandler OnISpyRequest = delegate { };
    public event ISpyGuessEventHandler OnGuess = delegate { };

    [SerializeField]
    private ObjectSelector objectSelector;

    private ISpy iSpy;
    private SpyObjectData currentRequest;

    private Lives lives;
    private Rounds rounds;

    private void Awake()
    {
        List<SpyObjectData> allSpyObjects = GameObject.FindObjectsOfType<SpyObject>().Select(spyObject => spyObject.Data)
                                                                                     .Where(data => data != null)
                                                                                     .Distinct()
                                                                                     .ToList();

        iSpy = new ISpy(allSpyObjects);

        lives = GetComponent<Lives>();
        rounds = GetComponent<Rounds>();

        if (objectSelector == null)
        {
            Debug.Log("No object selector set!");
        }
    }

    private void Start()
    {
        rounds.StartRounds();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && objectSelector.CurrentSelection != null)
        {
            SpyObjectData selectionData = objectSelector.CurrentSelection.GetComponent<SpyObject>()?.Data;
            if (selectionData != null)
            {
                if (selectionData == currentRequest)
                {
                    Debug.Log("Correct!");
                    OnGuess(true);
                    rounds.NextRound();
                }
                else
                {
                    Debug.Log("Incorrect!");
                    OnGuess(false);
                    if (lives != null && lives.enabled)
                    {
                        lives.LoseALife();
                    }
                }
            }
            else
            {
                Debug.Log("Selection data is null!");
            }

            objectSelector.DeselectCurrentObject();
        }
    }

    private void MakeRequest()
    {
        currentRequest = iSpy.SpyRequest();
        Debug.Log(currentRequest.name + " requested");
        OnISpyRequest(currentRequest);
    }

    public void GameOver()
    {
        Debug.Log("Game over!");
    }

    public void RoundStarted()
    {
        Debug.LogFormat("Round {0} started", rounds.RoundNumber);
        MakeRequest();
    }

    public void LifeLost()
    {
        Debug.LogFormat("Life lost. {0} lives left", lives.CurrentLives);
    }
}
