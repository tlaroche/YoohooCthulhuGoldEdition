using UnityEngine;
using System.Collections;

public class TentacleActive : MonoBehaviour {

    public Sprite[] stages = new Sprite[5];
    // Use this for initialization
    void Start () {
        
	}
    void OnBecameVisible()
    {
        frame1();
    }

    // Update is called once per frame
    void Update () {
	
	}
    void frame1()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = stages[0];
        Invoke("frame2", .1f);
        gameObject.GetComponent<SpriteRenderer>().sprite = stages[0];
    }
    void frame2()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = stages[1];
        Invoke("frame3", .1f);
        gameObject.GetComponent<SpriteRenderer>().sprite = stages[1];
    }
    void frame3()
    {
		AudioSource.PlayClipAtPoint (GetComponent<AudioSource> ().clip, transform.position);
        gameObject.GetComponent<SpriteRenderer>().sprite = stages[2];
        Invoke("frame4", .1f);
        gameObject.GetComponent<SpriteRenderer>().sprite = stages[2];
    }
    void frame4()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = stages[3];
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        Invoke("frame5", 1f);
        gameObject.GetComponent<SpriteRenderer>().sprite = stages[3];
    }
    void frame5()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = stages[4];
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("frame1", .1f);
        gameObject.GetComponent<SpriteRenderer>().sprite = stages[4];
    }
}
