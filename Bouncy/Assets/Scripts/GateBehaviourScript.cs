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

	public Sprite completeStar;
	public Button UIStar;

	// Use this for initialization
	void Start () 
	{

		gameManager = GameObject.Find ("GameManager");
		gameManagerScript = gameManager.GetComponent<GameManagerBehaviourScript> ();
		bouncyScript = bouncy.GetComponent<BouncyBehaviourScript>();
	
	}
	
	// Update is called once per frame
	void Update () {}

	void OnTriggerEnter2D(Collider2D other) 
	{
		bouncy= GameObject.FindWithTag("BouncySmall");
		bouncyScript = bouncy.GetComponent<BouncyBehaviourScript>();
		if (gameManagerScript.ringsLeft == 0) 
		{

			Color myColor = new Color32( 253, 255, 0, 248 ); 
			UIStar.GetComponent<Image>().sprite = completeStar;
			UIStar.GetComponent<Image>().color= myColor;

		}

		levelComplete.SetActive(true);
		bouncyScript.speed = 0;
	
	}
}
