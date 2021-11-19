using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ISpyController : MonoBehaviour
{
    [SerializeField]
    private ObjectSelector objectSelector;

    private ISpy iSpy;
    private SpyObjectData currentRequest;

    private Lives lives;
    private Rounds rounds;

    private void Awake()
    {
        List<SpyObjectData> allSpyObjects = GameObject.FindObjectsOfType<SpyObject>().Select(spyObject => spyObject.Data)
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
                    rounds.NextRound();
                }
                else
                {
                    Debug.Log("Incorrect!");
                    lives.LoseALife();
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
        Debug.Log("I spy with my little eye, something beginning with: " + currentRequest.name[0]);
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
