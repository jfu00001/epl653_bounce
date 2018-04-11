using UnityEngine;
using System.Collections;

public class GameManagerBehaviourScript : MonoBehaviour {

    // Use this for initialization
    public int life;
    public int ringsLeft;
    public Vector2 spawnPosition;
	public Transform ringSet;
	public Animator portalAnimator;
	private GameObject portal;
	private Collider2D portalCollider;



    void Start () {
        life = 3;
		ringsLeft = ringSet.childCount;
		portal = GameObject.Find ("portal");
		portalCollider = portal.GetComponent<Collider2D>();

	}
	
	// Update is called once per frame
	void Update () {

		if (ringsLeft == 0) {
			portalAnimator.SetBool ("setActive", true);
			portalCollider.enabled = false;
		}
			

	}
}
