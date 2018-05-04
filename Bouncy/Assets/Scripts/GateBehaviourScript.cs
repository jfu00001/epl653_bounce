using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GateBehaviourScript : MonoBehaviour
{

	public EventSystem m_EventSystem;
	public GameObject levelComplete;
	public GameObject bouncy;
	private BouncyBehaviourScript bouncyScript;

	private GameManagerBehaviourScript gameManagerScript;
	private GameObject gameManager;

	public Sprite starSprite;
	public Button firstStar;
	public Button secondStar;
	public Button thirdStar;

	private GameObject rings;

	public Transform powerUps;
	private int powerUpsNum;

	private int gmLifes;
	private bool lifeTag;

    private bool saveScore;

    // Use this for initialization
    void Start () 
	{
		gameManager = GameObject.Find ("GameManager");
		gameManagerScript = gameManager.GetComponent<GameManagerBehaviourScript> ();
		powerUpsNum = powerUps.childCount;
		bouncyScript = bouncy.GetComponent<BouncyBehaviourScript>();
		rings= GameObject.Find ("Rings");
		lifeTag = false;
        saveScore = false;
    }
	
	// Update is called once per frame
	void Update () 
	{
		gmLifes = gameManagerScript.life;
      
        if (gmLifes < 3)
            lifeTag = true;
	}

	void OnTriggerEnter2D(Collider2D other) 
	{		
		Color myColor = new Color32( 253, 255, 0, 248 ); 

		if (gameManagerScript.ringsLeft == 0) 
		{
			firstStar.GetComponent<Image>().sprite = starSprite;
			firstStar.GetComponent<Image>().color= myColor;
         
			if (!lifeTag)
			{
			secondStar.GetComponent<Image>().sprite = starSprite;
			secondStar.GetComponent<Image>().color= myColor;
			
			if (bouncyScript.collisionObjects == powerUpsNum)
			{
			thirdStar.GetComponent<Image>().sprite = starSprite;
			thirdStar.GetComponent<Image>().color= myColor;

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

        bouncyScript.speed = 0;	
	}
}
