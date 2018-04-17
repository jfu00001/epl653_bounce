using UnityEngine;
using System.Collections;

public class PumperBehaviourScript : MonoBehaviour
{
    public Transform prefab;
    public AudioClip enlargeSoundEffect; 

    void Start() { }

    void Update() { }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "BouncySmall")
        {
            GetComponent<AudioSource> ().clip = enlargeSoundEffect;
            GetComponent<AudioSource> ().Play ();
            //Instantiate first to get the position of the previous object
            Instantiate(prefab, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}