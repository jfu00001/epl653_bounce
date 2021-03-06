﻿using UnityEngine;
using System.Collections;

public class exitWater : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // temporaly disable to fall
        if (collision.gameObject.CompareTag("BouncySmall"))
        {
            StartCoroutine(wait());
        }
    }
    private IEnumerator wait()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        GetComponent<Collider2D>().enabled = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // back to normal, disable trigger to not fall
        if (collision.gameObject.CompareTag("BouncyBig"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}