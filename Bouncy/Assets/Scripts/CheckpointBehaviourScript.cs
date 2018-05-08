using UnityEngine;
using System.Collections;

public class CheckpointBehaviourScript : MonoBehaviour
{
    public Sprite catched;
    private GameObject gameManager;
    private GameManagerBehaviourScript gmScript;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gmScript = gameManager.GetComponent<GameManagerBehaviourScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<SpriteRenderer>().sprite = catched;
        gmScript.checkpoint = transform.position;
        gmScript.addPoint(500 * gmScript.life);
        gmScript.collisionObjects++;

        other.GetComponent<BouncyBehaviourScript>().checkpointSprite = other.GetComponent<SpriteRenderer>().sprite;
        GetComponent<Collider2D>().enabled = false;
    }
}