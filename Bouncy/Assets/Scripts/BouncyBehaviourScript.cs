using UnityEngine;
using System.Collections;

public class BouncyBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public LayerMask groundLayer, environmentLayer;

    public float speed;

    public Vector2 checkpointPos;
    public Sprite checkpointSprite;

    public int life;
    public Sprite popSprite;

    private int yForce = 50;
    private bool colBounceBlock, onRing;

    public AudioClip collectableSoundEffect; 
    public AudioClip dieSoundEffect; 
    public AudioClip shrinkSoundEffect; 
    public AudioClip enlargeSoundEffect;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5;
        life = 3;
        checkpointPos = transform.position;
        checkpointSprite = GetComponent<SpriteRenderer>().sprite;

        onRing = false;
        colBounceBlock = false;
    }

    // Update is called once per frame
    void Update() { }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        Collider2D playerCollider = this.GetComponent<CircleCollider2D>();

        bool jump = Input.GetButton("Jump");
        if (onRing && jump)
        {
            yForce = 10;
            rb.AddForce(new Vector2(0, yForce), ForceMode2D.Impulse);
            onRing = false;
        }

        if (IsGrounded(playerCollider) && jump)
        {
            if (colBounceBlock)
            {
                rb.AddForce(new Vector2(0, yForce), ForceMode2D.Impulse);
                yForce += 1;
                colBounceBlock = false;
            }
            else
            {
                yForce = 10;
                rb.AddForce(new Vector2(0, yForce), ForceMode2D.Impulse);
            }
        }

        environmentCollisionCheck(playerCollider);
    }

    public bool IsGrounded(Collider2D playerCollider)
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = playerCollider.bounds.extents.y + 0.1f;
        // check for collition with ground (below us)
        RaycastHit2D r = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (r)
        {
            if (r.collider.CompareTag("bounce_block"))
            {
                colBounceBlock = true;
            }
        }
        return r;
    }
    private void environmentCollisionCheck(Collider2D playerCollider)
    {
        // Get velocity and Collider bounds
        Vector2 moveDirection = new Vector2(rb.velocity.x, rb.velocity.y) * Time.fixedDeltaTime;
        Vector2 bottomLeft = new Vector2(playerCollider.bounds.min.x, playerCollider.bounds.min.y);
        Vector2 topRight = new Vector2(playerCollider.bounds.max.x, playerCollider.bounds.max.y);

        // Move collider in direction that we are moving
        bottomLeft += moveDirection;
        topRight += moveDirection;

        // if movement will result in a collision, stop it
        if (Physics2D.OverlapArea(bottomLeft, topRight, environmentLayer))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Life"))
        {

            playSound(collectableSoundEffect);
            other.gameObject.SetActive(false);
            life++;
        }

         if (other.gameObject.tag == "checkpoint")
         {
            playSound(collectableSoundEffect);
           
         }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ring"))
        {
            onRing = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "thorn")
        {
            playSound(dieSoundEffect);
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

    void playSound(AudioClip nameSound)
    {
        GetComponent<AudioSource> ().clip = nameSound;
        GetComponent<AudioSource> ().Play ();

    }
}