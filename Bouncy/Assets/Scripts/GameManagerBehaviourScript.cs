using UnityEngine;
using System.Collections;

public class GameManagerBehaviourScript : MonoBehaviour
{

    // Use this for initialization
    public int life;
    public int ringsLeft;
    public Vector2 spawnPosition;
    public Transform RingSet;
    public GameObject animatorObject;
    private int countRings;
    private Animator gateAnimator;

    void Start()
    {
        life = 3;
        countRings = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gateAnimator = animatorObject.GetComponent<Animator>();

        foreach (Transform ring in RingSet)
        {
            if ((ring.GetComponent<SpriteRenderer>().sprite.name.Equals("ring_small_catched_top@2x")) ||
                (ring.GetComponent<SpriteRenderer>().sprite.name.Equals("ring_big_catched_top@2x")))
                countRings += 1;
        }

        if (RingSet.childCount == countRings)
            gateAnimator.SetBool("setActive", true);
        else if (countRings > RingSet.childCount)
            countRings = 0;
    }
}