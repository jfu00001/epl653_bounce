using UnityEngine;
using System.Collections;

public class DeflaterBehaviourScript : MonoBehaviour
{
    public GameObject bouncy;
    public AudioClip shrinkSoundEffect;
    private GameObject BouncyHome;

    void Start()
    {
        BouncyHome = GameObject.Find("BouncyHome");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BouncyBig")
        {
            GetComponent<AudioSource>().clip = shrinkSoundEffect;
            GetComponent<AudioSource>().Play();
            bouncy.GetComponent<SpriteRenderer>().sprite = BouncyHome.GetComponent<SpriteRenderer>().sprite;
            //Instantiate first to get the position of the previous object
            Instantiate(bouncy, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}