using UnityEngine;
using System.Collections;

public class BigRingBehaviourScript : MonoBehaviour {

    // Use this for initialization
    public Sprite rTop;
    public Sprite rBot;
    public bool isEnable;



    void Start () {
        isEnable = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        isEnable = false;
        this.GetComponent<SpriteRenderer>().sprite = rTop;
        this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = rBot;
       

    }
}
