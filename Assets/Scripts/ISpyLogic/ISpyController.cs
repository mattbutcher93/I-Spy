using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Rounds))]
public class ISpyController : MonoBehaviour
{
    public delegate void ISpyRequesetEventHandler(SpyObjectData spyObjectData);
    public delegate void ISpyGuessEventHandler(bool isCorrect, string objectName);

    public event ISpyRequesetEventHandler OnISpyRequest = delegate { };
    public event ISpyGuessEventHandler OnGuess = delegate { };

    [SerializeField]
    private ObjectSelector objectSelector;

    private ISpy iSpy;
    private SpyObjectData currentRequest;

    private Lives lives;
    private Rounds rounds;

    public KeyCode SubmitGuessKey { get; private set; } = KeyCode.E;

    private void Awake()
    {
        // Get all unique spy objects
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
        if (Input.GetKeyDown(SubmitGuessKey) && objectSelector.CurrentSelection != null)
        {
            SpyObjectData selectionData = objectSelector.CurrentSelection.GetComponent<SpyObject>()?.Data;
            if (selectionData != null)
            {
                if (selectionData == currentRequest)
                {
                    Debug.Log("Correct!");
                    OnGuess(true, currentRequest.name);
                    rounds.NextRound();
                }
                else
                {
                    Debug.Log("Incorrect!");
                    OnGuess(false, null);
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

        if (Input.GetKeyDown(KeyCode.Escape) && !Application.isEditor)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }

    private void MakeRequest()
    {
        currentRequest = iSpy.SpyRequest();
        Debug.Log(currentRequest.name + " requested");
        OnISpyRequest(currentRequest);
    }

    public void GameWon()
    {
        Debug.Log("Game won!");
        GameManager.gameWon = true;
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);

    }

    public void GameLost()
    {
        Debug.Log("Game lost!");
        GameManager.gameWon = false;
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
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
