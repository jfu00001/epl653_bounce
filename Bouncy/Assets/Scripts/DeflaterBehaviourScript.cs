using UnityEngine;
using System.Collections;

public class DeflaterBehaviourScript : MonoBehaviour
{
    public Transform prefab;
    public AudioClip shrinkSoundEffect; 


    void Start() { }

    void Update() { }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "BouncyBig")
        {
            GetComponent<AudioSource> ().clip = shrinkSoundEffect;
            GetComponent<AudioSource> ().Play ();
            //Instantiate first to get the position of the previous object
            Instantiate(prefab, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}