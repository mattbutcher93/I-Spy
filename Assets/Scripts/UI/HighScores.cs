using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class HighScores : MonoBehaviour
{
    public event Action<List<ScoreEntry>> OnScoresUpdated = delegate { };

    [System.Serializable]
    public struct ScoreEntry
    {
        public string name;
        public int score;
    }

    [SerializeField]
    private int maxScores = 5;

    [SerializeField]
    private List<ScoreEntry> highScores;

    [SerializeField]
    private EnterNameUI enterNameUI;

    private void Awake()
    {
        highScores = new List<ScoreEntry>();
        if (enterNameUI != null)
        {
            enterNameUI.OnNameEntered += AddScore;
        }
    }

    private void Start()
    {
        LoadScores();
    }

    private void AddScore(string name)
    {
        ScoreEntry scoreEntry;
        // Remove ',' as its used for splitting score and name data 
        scoreEntry.name = name.Replace(",", "");
        scoreEntry.score = GameManager.score;

        // Add highscore to list, reorder, remove lowest score
        highScores.Add(scoreEntry);
        OrderHighScores();
        if (highScores.Count > maxScores)
        {
            highScores.RemoveAt(highScores.Count - 1);
        }

        OnScoresUpdated(highScores);

        SaveScores();
    }

    // Scores are stored as a string, the form of <name>,<score> e.g. Matt,100
    private void LoadScore(int i)
    {
        if (PlayerPrefs.HasKey("Score" + i))
        {
            string scoreString = PlayerPrefs.GetString(ScoreKeyString(i));
            string[] nameScore = scoreString.Split(',');
            ScoreEntry scoreEntry;
            scoreEntry.name = nameScore[0];
            scoreEntry.score = int.Parse(nameScore[1]);
            highScores.Add(scoreEntry);
        }
    }

    private void LoadScores()
    {
        for (int i = 0; i < maxScores; i++)
        {
            LoadScore(i);
        }

        OrderHighScores();
        OnScoresUpdated(highScores);
    }

    private void SaveScores()
    {
        for (int i = 0; i < maxScores; i++)
        {
            if (i < highScores.Count)
            {
                string saveString = highScores[i].name + "," + highScores[i].score;
                PlayerPrefs.SetString(ScoreKeyString(i), saveString);
            }
        }
    }

    private void OrderHighScores()
    {
        highScores = highScores.OrderByDescending(scoreEntry => scoreEntry.score).ThenBy(scoreEntry => scoreEntry.name).ToList();
    }

    private string ScoreKeyString(int index)
    {
        return "Score" + index;
    }

    private void OnDestroy()
    {
        if (enterNameUI != null)
        {
            enterNameUI.OnNameEntered -= AddScore;
        }
    }
}
