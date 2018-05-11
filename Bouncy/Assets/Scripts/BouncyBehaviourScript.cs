using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class BouncyBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public LayerMask groundLayer, environmentLayer;

    public float speed;

    public Sprite checkpointSprite;

    public Sprite popSprite;

    private int yForce;
    private bool colBounceBlock, onRing;

    public AudioClip collectableSoundEffect;
    public AudioClip dieSoundEffect;
    public AudioClip shrinkSoundEffect;
    public AudioClip enlargeSoundEffect;

    private GameObject gameManager;
    private GameManagerBehaviourScript gmScript;
    private GameObject bouncyHome;
    private SpriteRenderer bouncyHomeSRender;

    private int maxFallvelocity = -20, maxJumpvelocity = 20;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 10;
        yForce = 10;

        checkpointSprite = GetComponent<SpriteRenderer>().sprite;

        onRing = false;
        colBounceBlock = false;

        gameManager = GameObject.Find("GameManager");
        gmScript = gameManager.GetComponent<GameManagerBehaviourScript>();

        if (gmScript.spawnPosition == Vector2.zero)
        {
            gmScript.spawnPosition = transform.position;
        }

        bouncyHome = GameObject.Find("BouncyHome");
        bouncyHomeSRender = bouncyHome.GetComponent<SpriteRenderer>();
        bouncyHome.GetComponent<CircleCollider2D>().enabled = false;
        bouncyHome.GetComponent<Rigidbody2D>().isKinematic = true;
        bouncyHome.GetComponent<AudioSource>().enabled = false;
        bouncyHome.GetComponent<bounceHomepage>().enabled = false;

        GetComponent<Collider2D>().sharedMaterial.bounciness = 0.3f;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = true;
    }

    void FixedUpdate()
    {
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        float t = Mathf.Round(CrossPlatformInputManager.GetAxisRaw("Horizontal"));
        rb.velocity = new Vector2(t * speed, rb.velocity.y);
        Collider2D playerCollider = this.GetComponent<CircleCollider2D>();

        //bool jump = Input.GetButton("Jump");
        bool jump = CrossPlatformInputManager.GetButton("Jump");

        // jump and not on water
        if (jump && rb.gravityScale > 0)
        {
            rb.gravityScale = 1;
        }

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
                // bounce jump upper limit
                if (yForce < 15)
                {
                    yForce += 1;
                }
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
        Vector2 directiond = new Vector2(0, -1);
        Vector2 directionrd = new Vector2(1, -1);
        Vector2 directionld = new Vector2(-1, -1);
        float distance = playerCollider.bounds.extents.y + 0.1f;
        // check for collition with ground (below us)
        RaycastHit2D r = Physics2D.Raycast(position, directiond, distance, groundLayer);
        RaycastHit2D rl = Physics2D.Raycast(position, directionld, distance, groundLayer);
        RaycastHit2D rr = Physics2D.Raycast(position, directionrd, distance, groundLayer);
        if (r)
        {
            if (r.collider.CompareTag("bounce_block"))
            {
                colBounceBlock = true;
            }
        }

        return (r || rl || rr);
    }

    private void environmentCollisionCheck(Collider2D playerCollider)
    {
        Vector2 moveDirection = new Vector2(rb.velocity.x, rb.velocity.y) * Time.fixedDeltaTime;
        Vector2 newPos = transform.position;
        float distance = GetComponent<CircleCollider2D>().radius + 0.1f;
        // Move collider in direction that we are moving
        newPos += moveDirection;
        // if movement will result in a collision, stop it
        if (Physics2D.OverlapCircle(newPos, distance, environmentLayer))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // side collision with ground
        RaycastHit2D stepR = Physics2D.Raycast(newPos, Vector2.right, distance, groundLayer);
        RaycastHit2D stepL = Physics2D.Raycast(newPos, Vector2.left, distance, groundLayer);
        if (stepL || stepR)
        {
            GetComponent<Collider2D>().sharedMaterial.bounciness = 0;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Collider2D>().enabled = true;
        }

        // velocity y limit check
        if (rb.velocity.y < maxFallvelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxFallvelocity);
        }
        if (rb.velocity.y > maxJumpvelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxJumpvelocity);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Life"))
        {
            playSound(collectableSoundEffect);
            other.gameObject.SetActive(false);
            gmScript.addPoint(1000 * gmScript.life);
            gmScript.life++;
            gmScript.collisionObjects++;
        }

        if (other.gameObject.tag == "checkpoint")
        {
            playSound(collectableSoundEffect);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        GetComponent<Collider2D>().sharedMaterial.bounciness = 0;
        if (IsGrounded(this.GetComponent<CircleCollider2D>()) && collision.gameObject.CompareTag("ground"))
        {
            GetComponent<Collider2D>().sharedMaterial.bounciness = 0.3f;
        }

        // update collider
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = true;

        if (collision.gameObject.CompareTag("ring"))
        {
            onRing = true;
        }

        if (collision.gameObject.CompareTag("gonies"))
        {
            rb.gravityScale = 15;
        }
        // not on water and not on gonies
        else if (rb.gravityScale > 0)
        {
            rb.gravityScale = 1;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "thorn")
        {
            playSound(dieSoundEffect);
            GetComponent<Collider2D>().enabled = false;
            rb.isKinematic = true;
            gmScript.life--;
            gmScript.lifetag = true;
            this.GetComponent<SpriteRenderer>().sprite = popSprite;
            StartCoroutine(wait(2));
        }
    }

    private IEnumerator wait(int sec)
    {
        float oldS = speed;
        speed = 0;
        yield return new WaitForSeconds(sec);
        if (gmScript.life != 0)
        {
            respawn(oldS);
        }
    }
    void respawn(float os)
    {
        if (gmScript.checkpoint == Vector2.zero)
        {
            transform.position = gmScript.spawnPosition;
        }
        else
        {
            transform.position = gmScript.checkpoint;
        }

        this.GetComponent<SpriteRenderer>().sprite = checkpointSprite;
        rb.isKinematic = false;
        GetComponent<Collider2D>().enabled = true;
        speed = os;
        getBouncyTexture();
    }

    public void playSound(AudioClip nameSound)
    {
        GetComponent<AudioSource>().clip = nameSound;
        GetComponent<AudioSource>().Play();
    }

    private void getBouncyTexture()
    {
        this.GetComponent<BouncyBehaviourScript>();
        this.GetComponent<SpriteRenderer>();

        //Check if the Bouncy is big and load the appropriate sprite
        if (this.tag == "BouncyBig")
        {
            this.GetComponent<SpriteRenderer>().sprite = bouncyHome.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = bouncyHomeSRender.sprite;
        }

        bouncyHomeSRender.enabled = false;
    }
}