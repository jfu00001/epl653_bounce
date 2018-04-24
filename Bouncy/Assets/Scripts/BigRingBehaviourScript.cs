using UnityEngine;
using System.Collections;

public class BigRingBehaviourScript : MonoBehaviour
{
    // Use this for initialization
    public Sprite rTop;
    public Sprite rBot;
    public bool isEnable;
    private GameObject gameManager;
    private GameManagerBehaviourScript gameManScript;
    public AudioClip ringSoundEffect;  

    void Start()
    {
        isEnable = true;
        gameManager = GameObject.Find("GameManager");
        gameManScript = gameManager.GetComponent<GameManagerBehaviourScript>();
    }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isEnable)
        {
            //GetComponent<AudioSource> ().clip = ringSoundEffect;
            //GetComponent<AudioSource> ().Play ();
            gameManScript.ringsLeft--;
            gameManScript.points += 500;
        }
        isEnable = false;
        this.GetComponent<SpriteRenderer>().sprite = rTop;
        this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = rBot;
    }
}