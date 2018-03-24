using UnityEngine;
using System.Collections;

public class BouncyBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public bool isGrounded;
    public GameObject checkpointState;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5;
        checkpointState = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(v * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, 10), ForceMode2D.Impulse);
        }
    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("ground") || collisionInfo.gameObject.CompareTag("power_speed")
            || collisionInfo.gameObject.CompareTag("pumper") || collisionInfo.gameObject.CompareTag("deflater")
            || collisionInfo.gameObject.CompareTag("bounce_block")
            //|| collisionInfo.gameObject.CompareTag("power_gravity") || collisionInfo.gameObject.CompareTag("power_jump")
            )
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
            isGrounded = false;
    }
}