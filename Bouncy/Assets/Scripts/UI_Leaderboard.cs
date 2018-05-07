using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_Leaderboard : MonoBehaviour
{
    public GameObject textTemplate;

    void Start()
    {
        show();
        GameObject b = GameObject.FindGameObjectWithTag("BouncyHome");
        Destroy(b);
    }

    public void clearLeaderboard()
    {
        HighScoreManager._instance.ClearLeaderBoard();
        show();
    }

    void show()
    {
        // destroy previous leaderboard
        GameObject old = GameObject.FindGameObjectWithTag("list");
        if (old)
        {
            Destroy(old.gameObject);
        }

        // get current leaderboard
        List<int> highscore = HighScoreManager._instance.GetHighScore();
        string display = "";
        for (int i = 0; i < highscore.Count; i++)
        {
            if (highscore[i] == 0)
            {
                break;
            }
            display += highscore[i] + "\n";
        }

        // display leaderboard
        GameObject t = Instantiate(textTemplate) as GameObject;
        t.tag = "list";
        t.GetComponent<Text>().text = display;
        t.transform.SetParent(this.transform, false);
    }
}