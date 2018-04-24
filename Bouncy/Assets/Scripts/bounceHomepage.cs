using UnityEngine;
using System.Collections;

public class bounceHomepage : MonoBehaviour
{
    private Rigidbody2D rb;
	public GameObject child;

  	public Sprite[] sprites;
	private SpriteRenderer spriteR;
	private SpriteRenderer spriteChildR;

	private int spriteIndex = 0;
	private bool created = false;

	private BouncyBigSpritesBehaviourScript bouncySpriteScript;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spriteR = GetComponent<SpriteRenderer>();
		spriteChildR= child.GetComponent<SpriteRenderer>();
		bouncySpriteScript = child.GetComponent<BouncyBigSpritesBehaviourScript> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        }
    }
    //When scene changes the game object is transfered to the new scene
    void Awake()
	{
		if (!created)
		{
			DontDestroyOnLoad(this.gameObject);
			created = true;
			this.gameObject.name = "BouncyHome";
			this.gameObject.tag = "BouncyHome";

		}
	}

	void OnMouseUp()
	{

		spriteIndex += 1;
		if (spriteIndex >=sprites.Length)
			spriteIndex = 0;

		spriteR.sprite = sprites[spriteIndex];
		spriteChildR.sprite = bouncySpriteScript.sprites[spriteIndex];

	}
}