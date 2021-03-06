﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerBehaviourScript : MonoBehaviour
{
    // Use this for initialization
    public int life;
    public int ringsLeft;
    public static int points;
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

    private bool updateScore = false;

    public GameObject pausemenu;

    public RawImage ringTemplateUI;
    public RawImage[] ringsUI;
    public int collisionObjects;
    public bool lifetag;

    void Start()
    {
        life = 3;
        lifetag = false;
        collisionObjects = 0;
        ringsLeft = ringSet.childCount;
        if (Application.loadedLevel == 2)
        {
            points = 0;
        }
        gate = GameObject.Find("portal");
        gateCollider = gate.GetComponent<BoxCollider2D>();

        bouncyScript = Bouncy.GetComponent<BouncyBehaviourScript>();
        BouncySRender = Bouncy.GetComponent<SpriteRenderer>();

        BouncyHome = GameObject.Find("BouncyHome");
        BouncyHomeSRender = BouncyHome.GetComponent<SpriteRenderer>();
        //Check if the Bouncy is big and load the appropriate sprite
        if (Bouncy.tag == "BouncyBig")
        {
            BouncySRender.sprite = BouncyHome.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            BouncySRender.sprite = BouncyHomeSRender.sprite;
        }

        BouncyHomeSRender.enabled = false;
        ringsUI = new RawImage[ringsLeft];
        ringsUI[0] = ringTemplateUI;
        for (int i = 1; i < ringsLeft; i++)
        {
            ringsUI[i] = Instantiate(ringsUI[i - 1]);
            ringsUI[i].transform.SetParent(ringsUI[0].transform, false);
            ringsUI[i].transform.position = ringsUI[0].transform.position + new Vector3(35f * i, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If there are no rings open the gate and disable bouncy
        if (ringsLeft == 0)
        {
            gateCollider.enabled = false;
            gateAnimator.SetBool("setActive", true);
        }

        if (life == 0)
        {
            levelFail.SetActive(true);
            bouncyScript.speed = 0;
            // lose => add current score
            if (!updateScore)
            {
                HighScoreManager._instance.SaveHighScore(points);
                updateScore = true;
            }
        }
        else
        {
            updateScore = false;
        }

        txtlifes.text = "X" + life.ToString();
        txtpoint.text = points.ToString();
    }

    public void addPoint(int toadd)
    {
        points += toadd;
    }

    public int getPoint()
    {
        return points;
    }

    //UI Buttons
    public void NextLevelButton()
    {
        int nextLevel = Application.loadedLevel + 1;
        Application.LoadLevel(nextLevel);
    }

    public void ReplayLevelButton()
    {
        Application.LoadLevel(2);
    }

    public void MainMenuButton()
    {
        Application.LoadLevel(1);
        GameObject b = GameObject.FindGameObjectWithTag("BouncyHome");
        Destroy(b);
    }

    public void pauseButton()
    {
        pausemenu.SetActive(true);
        GameObject bouncy = GameObject.FindGameObjectWithTag("BouncySmall");
        if (bouncy == null)
        {
            bouncy = GameObject.FindGameObjectWithTag("BouncyBig");
        }
        bouncy.GetComponent<Rigidbody2D>().isKinematic = true;

        GameObject[] thorns = GameObject.FindGameObjectsWithTag("thorn");
        foreach (GameObject thorn in thorns)
        {
            if (thorn.GetComponent<Rigidbody2D>() != null)
            {
                thorn.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }

    public void resumeButton()
    {
        pausemenu.SetActive(false);
        GameObject bouncy = GameObject.FindGameObjectWithTag("BouncySmall");
        if (bouncy == null)
        {
            bouncy = GameObject.FindGameObjectWithTag("BouncyBig");
        }
        bouncy.GetComponent<Rigidbody2D>().isKinematic = false;

        GameObject[] thorns = GameObject.FindGameObjectsWithTag("thorn");
        foreach (GameObject thorn in thorns)
        {
            if (thorn.GetComponent<Rigidbody2D>() != null)
            {
                thorn.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}