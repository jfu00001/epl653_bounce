using UnityEngine;
using System.Collections;

public class GameManagerBehaviourScript : MonoBehaviour
{

    // Use this for initialization
    public int life;
    public int ringsLeft;
    public Vector2 spawnPosition;
    public Transform ringSet;
    
    public GameObject Bouncy;
    private BouncyBehaviourScript bouncyScript;
    public GameObject levelFail;
    public Animator gateAnimator;
    private GameObject gate;
    private Collider2D gateCollider;

    void Start()
    {
        life = 3;
        ringsLeft = ringSet.childCount;
        gate = GameObject.Find ("portal");
        gateCollider = gate.GetComponent<Collider2D>();
        bouncyScript = Bouncy.GetComponent<BouncyBehaviourScript>();
        
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

        if (bouncyScript.life == 0) 
        {
            levelFail.SetActive (true);
            bouncyScript.speed = 0;
            
        }
    
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