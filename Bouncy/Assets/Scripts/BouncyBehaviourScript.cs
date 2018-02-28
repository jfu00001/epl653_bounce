using UnityEngine;
using System.Collections;

public class BouncyBehaviourScript : MonoBehaviour {
    public int speed;
    public Rigidbody2D ballrigi;
    public bool isGrounded;
    // Use this for initialization
    void Start () {
        ballrigi = GetComponent<Rigidbody2D>();
        speed = 5;
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            ballrigi.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }



    }
    void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Horizontal");
        ballrigi.velocity = new Vector2(v*speed, ballrigi.velocity.y );
       
    }


    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        isGrounded = false;
    }


}
