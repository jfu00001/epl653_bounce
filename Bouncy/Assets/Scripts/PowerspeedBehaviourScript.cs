using UnityEngine;
using System.Collections;

public class PowerspeedBehaviourScript : MonoBehaviour
{
    private float oldSpeed, newSpeed;

    // Use this for initialization
    void Start()
    {
        oldSpeed = GameObject.Find("BouncyBig").GetComponent<BouncyBehaviourScript>().speed;
        newSpeed = oldSpeed * 1.25f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<BouncyBehaviourScript>().speed = newSpeed;
        StartCoroutine("Countdown");
    }

    private IEnumerator Countdown(int time)
    {
        while (time > 0)
        {
            time--;
            // power bar reducing UI??????
            yield return new WaitForSeconds(1);
        }
        GameObject.Find("BouncyBig").GetComponent<BouncyBehaviourScript>().speed = oldSpeed;
    }
}