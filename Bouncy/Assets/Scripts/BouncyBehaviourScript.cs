using UnityEngine;
using System.Collections;

public class BouncyBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public bool isGrounded;
    public Vector2 checkpointPos;
    public Sprite checkpointSprite;
    public int life;
    public Sprite popSprite;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5;
        life = 3;
        checkpointPos = transform.position;
        checkpointSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(v * speed, rb.velocity.y);

        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Life")){
            other.gameObject.SetActive(false);
            life++;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "thorn")
        {
            GetComponent<Collider2D>().enabled = false;
            rb.isKinematic = true;
            life--;
            this.GetComponent<SpriteRenderer>().sprite = popSprite;
            StartCoroutine(wait(2));
           

        }
    }

    private IEnumerator wait(int sec)
    {
        float oldS = speed;
        speed = 0;
        yield return new WaitForSeconds(sec);
        respawn(oldS);
    }
    void respawn(float os)
    {
        transform.position = checkpointPos;
        this.GetComponent<SpriteRenderer>().sprite = checkpointSprite;
        rb.isKinematic = false;
        GetComponent<Collider2D>().enabled = true;
        speed = os;
    }
}