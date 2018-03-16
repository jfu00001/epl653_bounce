using UnityEngine;
using System.Collections;

public class bounceHomepage : MonoBehaviour
{
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        }
    }
}