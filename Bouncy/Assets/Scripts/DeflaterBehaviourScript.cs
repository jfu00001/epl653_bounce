using UnityEngine;
using System.Collections;

public class DeflaterBehaviourScript : MonoBehaviour {
	
	public Transform prefab;

	void Start () {}

	void Update () {}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "BouncyBig") {
			//Instantiate first to get the position of the previous object
			Instantiate (prefab, other.gameObject.transform.position, other.gameObject.transform.rotation);
			Destroy (other.gameObject);

		} 
	}
}