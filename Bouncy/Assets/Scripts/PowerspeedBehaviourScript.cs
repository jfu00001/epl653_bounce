using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerspeedBehaviourScript : MonoBehaviour
{
    float oldSpeed, newSpeed, time, timeAmt;
    GameObject bouncy;

    // UI image: fill, horizontal, left, fillamount = 0 
    public Image bar;

    // Use this for initialization
    void Start()
    {
        bouncy = GameObject.Find("BouncyBig");
        oldSpeed = bouncy.GetComponent<BouncyBehaviourScript>().speed;
        newSpeed = oldSpeed * 1.5f;
        timeAmt = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            bar.fillAmount = time / timeAmt;

            if (time <= 0)
            {
                bouncy.GetComponent<BouncyBehaviourScript>().speed = oldSpeed;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<BouncyBehaviourScript>().speed = newSpeed;
        time = timeAmt;
        bar.fillAmount = 1;
    }
}