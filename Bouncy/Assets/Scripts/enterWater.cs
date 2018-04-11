using UnityEngine;
using System.Collections;

public class enterWater : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // if not trigger enable
        if (collision.gameObject.CompareTag("BouncyBig"))
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
 
    void OnTriggerExit2D(Collider2D collision)
    {
        // if trigger disable to not pass
        if (collision.gameObject.CompareTag("BouncySmall"))
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }   
        // pass and update exit
        if (collision.gameObject.CompareTag("BouncyBig"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = -0.25f;
            GameObject.Find("exit water").GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}