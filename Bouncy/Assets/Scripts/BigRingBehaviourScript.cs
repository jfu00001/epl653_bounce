using UnityEngine;
using System.Collections;

public class BigRingBehaviourScript : MonoBehaviour {

    // Use this for initialization
    public Sprite rTop;
    public Sprite rBot;
    public bool isEnable;
	public GameObject gameManager;
	private GameManagerBehaviourScript gameManScript;



    void Start () {
        isEnable = true;
		gameManScript = gameManager.GetComponent<GameManagerBehaviourScript> ();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
		if (isEnable)
			gameManScript.ringsLeft--;
        isEnable = false;
        this.GetComponent<SpriteRenderer>().sprite = rTop;
        this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = rBot;

       

    }
}
