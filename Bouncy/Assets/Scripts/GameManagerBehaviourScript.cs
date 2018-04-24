using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GameManagerBehaviourScript : MonoBehaviour
{

    // Use this for initialization
    public int life;
    public int ringsLeft;
    public int points;
    public Vector2 spawnPosition;
    public Vector2 checkpoint;
    public Transform ringSet;
    
    public GameObject Bouncy;
    private BouncyBehaviourScript bouncyScript;
    public GameObject levelFail;

    public Animator gateAnimator;
    private GameObject gate;
    private Collider2D gateCollider;

    private GameObject BouncyHome;
    private SpriteRenderer BouncySRender;
    private SpriteRenderer BouncyHomeSRender;

    public Text txtlifes;
    public Text txtpoint;

    void Start()
    {
        life = 3;
        ringsLeft = ringSet.childCount;
        points = 0;

        gate = GameObject.Find ("portal");
        gateCollider = gate.GetComponent<Collider2D>();

        bouncyScript = Bouncy.GetComponent<BouncyBehaviourScript>();
        BouncySRender= Bouncy.GetComponent<SpriteRenderer>();

        BouncyHome= GameObject.Find("BouncyHome");
        BouncyHomeSRender = BouncyHome.GetComponent<SpriteRenderer> ();
        //Check if the Bouncy is big and load the appropriate sprite
        if (Bouncy.tag == "BouncyBig") 
        {
            
            BouncySRender.sprite = BouncyHome.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
        }
        else 
        {

            BouncySRender.sprite = BouncyHomeSRender.sprite;
        }

    
        BouncyHomeSRender.enabled= false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //If there are no rings open the gate and disable bouncy
        if (ringsLeft == 0) 
        {
            gateAnimator.SetBool ("setActive", true);
            gateCollider.enabled = false;
        }

        if (life == 0) 
        {
            levelFail.SetActive (true);
            bouncyScript.speed = 0;
            
        }
        txtlifes.text = "X" + life.ToString();
        txtpoint.text = points.ToString();

    
    }

     //UI Buttons
    public void NextLevelButton()
    {
        Application.LoadLevel(Application.loadedLevel +1);
    }

    public void ReplayLevelButton()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenuButton()
    {
        Application.LoadLevel(1);

    }
}