using UnityEngine;
using System.Collections;

public class enterWater : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BouncyBig"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = -0.25f;
            GameObject.Find("exit water").GetComponent<BoxCollider2D>().isTrigger = true;
            StartCoroutine(wait());
        }
        if (collision.gameObject.CompareTag("BouncySmall") && collision.transform.position.y > transform.position.y)
        {
            StartCoroutine(wait());
        }
    }
    private IEnumerator wait()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.25f);
        GetComponent<Collider2D>().enabled = true;
    }
}