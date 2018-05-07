using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ENDBehaviourScript : MonoBehaviour
{
    public GameObject levelComplete;

    private GameManagerBehaviourScript gameManagerScript;
    private GameObject gameManager;

    public Sprite starSprite;
    public Button firstStar;
    public Button secondStar;
    public Button thirdStar;

    public Transform powerUps;
    private int powerUpsNum;

    private bool saveScore;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManagerBehaviourScript>();
        powerUpsNum = powerUps.childCount;
        saveScore = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameObject.FindGameObjectWithTag("BouncySmall"))
        {
            GameObject.FindGameObjectWithTag("BouncySmall").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            GameObject.FindGameObjectWithTag("BouncyBig").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }

        Color myColor = new Color32(253, 255, 0, 248);

        if (gameManagerScript.ringsLeft == 0)
        {
            firstStar.GetComponent<Image>().sprite = starSprite;
            firstStar.GetComponent<Image>().color = myColor;

            if (!gameManagerScript.lifetag)
            {
                secondStar.GetComponent<Image>().sprite = starSprite;
                secondStar.GetComponent<Image>().color = myColor;

                if (gameManagerScript.collisionObjects == powerUpsNum)
                {
                    thirdStar.GetComponent<Image>().sprite = starSprite;
                    thirdStar.GetComponent<Image>().color = myColor;
                }
            }
        }

        levelComplete.SetActive(true);

        // level 3 completed => game completed => save score
        if (Application.loadedLevel == 4 && !saveScore)
        {
            HighScoreManager._instance.SaveHighScore(gameManagerScript.getPoint());
            saveScore = true;
        }
    }
}