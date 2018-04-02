using UnityEngine;
using System.Collections;

public class DyoThornBehaviourScript : MonoBehaviour {

    // Use this for initialization
    public float speed;
    private Rigidbody2D rb;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        speed = 1;

	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(0, speed );
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<Collider2D>().enabled = false;
        speed = speed * -1;
        StartCoroutine(wait());
        
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5F);
        GetComponent<Collider2D>().enabled = true;

    }


}
