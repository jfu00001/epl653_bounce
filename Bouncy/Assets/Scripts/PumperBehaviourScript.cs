using UnityEngine;
using System.Collections;

public class PumperBehaviourScript : MonoBehaviour
{
    public GameObject bouncy;
    public AudioClip enlargeSoundEffect; 
    private GameObject BouncyHome;

    void Start() 
    { 
        BouncyHome = GameObject.Find("BouncyHome");


    }

    void Update() { }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "BouncySmall")
        {
            GetComponent<AudioSource> ().clip = enlargeSoundEffect;
            GetComponent<AudioSource> ().Play ();
            bouncy.GetComponent<SpriteRenderer>().sprite = BouncyHome.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
            //Instantiate first to get the position of the previous object
            Instantiate(bouncy, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}