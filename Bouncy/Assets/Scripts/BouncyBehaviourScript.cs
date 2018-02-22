using UnityEngine;
using System.Collections;

public class BouncyBehaviourScript : MonoBehaviour {
    public int speed;
    Vector2 movement;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() { 
    

        Rigidbody2D move = GetComponent<Rigidbody2D>();
        movement=new Vector2();
        if(Input.GetKey("left")){
            movement = new Vector2(-1, 0);
            move.AddForce (movement * speed);
            //move.velocity = movement * speed;

        }
        else if (Input.GetKey("right"))
        {
            movement = new Vector2(1, 0);
            move.AddForce(movement * speed);

            //move.velocity = movement * speed;

        }
        else
        {
            move.AddForce(movement * speed * -1);
            movement = new Vector2(0, 0);
        }

    }
}
