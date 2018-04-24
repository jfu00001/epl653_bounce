using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// High score manager. Local highScore manager for LeaderboardLength number of entries
/// Singleton class:  To access these functions, use HighScoreManager._instance object.
/// eg: HighScoreManager._instance.SaveHighScore(1232);
/// No need to attach this to any game object, thought it wouldnot create errors attaching.

public class HighScoreManager : MonoBehaviour
{
    private static HighScoreManager m_instance;
    private const int LeaderboardLength = 10;

    public static HighScoreManager _instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new GameObject("HighScoreManager").AddComponent<HighScoreManager>();
            }
            return m_instance;
        }
    }

    void Awake()
    {
        if (m_instance == null)
            m_instance = this;
        else if (m_instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Store high score
    public void SaveHighScore(int score)
    {
        List<int> HighScores = new List<int>();
        int i = 1;
        while (i <= LeaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
        {
            int temp = PlayerPrefs.GetInt("HighScore" + i + "score");
            HighScores.Add(temp);
            i++;
        }

        if (HighScores.Count == 0)
        {
            int _temp = score;
            HighScores.Add(_temp);
        }
        else
        {
            for (i = 1; i <= HighScores.Count && i <= LeaderboardLength; i++)
            {
                if (score > HighScores[i - 1])
                {
                    HighScores.Insert(i - 1, score);
                    break;
                }
                if (i == HighScores.Count && i < LeaderboardLength)
                {
                    HighScores.Add(score);
                    break;
                }
            }
        }

        i = 1;
        while (i <= LeaderboardLength && i <= HighScores.Count)
        {
            PlayerPrefs.SetInt("HighScore" + i + "score", HighScores[i - 1]);
            i++;
        }
    }

    // Return highscores
    public List<int> GetHighScore()
    {
        List<int> HighScores = new List<int>();
        int i = 1;
        while (i <= LeaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
        {
            int temp = PlayerPrefs.GetInt("HighScore" + i + "score");
            HighScores.Add(temp);
            i++;
        }
        return HighScores;
    }

    public void ClearLeaderBoard()
    {
        PlayerPrefs.DeleteAll();
    }
}