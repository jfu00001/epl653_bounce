using UnityEngine;
using System.Collections;

public class SamllRingBehaviourScript : MonoBehaviour {
    public Sprite rTop;
    public Sprite rBot;
    public bool isEnable;
    // Use this for initialization
    void Start () {
        isEnable = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BouncySmall")
        {
            isEnable = false;
            this.GetComponent<SpriteRenderer>().sprite = rTop;
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = rBot;
        }

    }
}
