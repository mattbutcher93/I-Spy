using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardUI : MonoBehaviour
{
    [SerializeField]
    private Transform leaderBoardParent;

    [SerializeField]
    private GameObject scoreElement;

    [SerializeField]
    private List<ScoreElementUI> currentElements;

    [SerializeField]
    private HighScores highScores;

    private void Awake()
    {
        if (highScores != null)
        {
            highScores.OnScoresUpdated += SetScores;
        }
    }

    public void SetScores(List<HighScores.ScoreEntry> scores)
    {
        foreach (ScoreElementUI scoreElementUI in currentElements)
        {
            Destroy(scoreElementUI.gameObject);
        }
        currentElements.Clear();

        foreach (HighScores.ScoreEntry scoreEntry in scores)
        {
            ScoreElementUI scoreElementUI = GameObject.Instantiate(scoreElement, Vector3.zero, Quaternion.identity, leaderBoardParent).GetComponent<ScoreElementUI>();
            scoreElementUI.SetElement(scoreEntry);
            currentElements.Add(scoreElementUI);
        }
    }

    private void OnDestroy()
    {
        if (highScores != null)
        {
            highScores.OnScoresUpdated -= SetScores;
        }
    }
}
