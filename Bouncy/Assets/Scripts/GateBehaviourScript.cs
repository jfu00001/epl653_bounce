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
	private int ringsCounter;


	// Use this for initialization
	void Start () 
	{

		gameManager = GameObject.Find ("GameManager");
		gameManagerScript = gameManager.GetComponent<GameManagerBehaviourScript> ();
		bouncyScript = bouncy.GetComponent<BouncyBehaviourScript>();
		rings= GameObject.Find ("Rings");
	
	}
	
	// Update is called once per frame
	void Update () {}

	void OnTriggerEnter2D(Collider2D other) 
	{
		ringsCounter = rings.transform.childCount;
		int tempPoints=0;
		int.TryParse(gameManagerScript.txtpoint.text, out tempPoints);
		print(tempPoints);
		print(ringsCounter*500);
		Color myColor = new Color32( 253, 255, 0, 248 ); 

		if (tempPoints >= (ringsCounter*500)) 
		{
			firstStar.GetComponent<Image>().sprite = starSprite;
			firstStar.GetComponent<Image>().color= myColor;
			tempPoints = tempPoints - (ringsCounter*500);

			if (tempPoints>=1000)
			{
			secondStar.GetComponent<Image>().sprite = starSprite;
			secondStar.GetComponent<Image>().color= myColor;
			tempPoints = tempPoints - 1000;

			if (tempPoints>=1000)
			{
			thirdStar.GetComponent<Image>().sprite = starSprite;
			thirdStar.GetComponent<Image>().color= myColor;

			}

			}

		}



        
		levelComplete.SetActive(true);
		bouncyScript.speed = 0;
	
	}
}
