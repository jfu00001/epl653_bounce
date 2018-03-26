using UnityEngine;
using System.Collections;

public class CheckpointBehaviourScript : MonoBehaviour
{
    public Sprite catched;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<SpriteRenderer>().sprite = catched;
        other.GetComponent<BouncyBehaviourScript>().checkpointPos = other.transform.position;
        other.GetComponent<BouncyBehaviourScript>().checkpointSprite = other.GetComponent<SpriteRenderer>().sprite;
        GetComponent<Collider2D>().enabled = false;
    }
}