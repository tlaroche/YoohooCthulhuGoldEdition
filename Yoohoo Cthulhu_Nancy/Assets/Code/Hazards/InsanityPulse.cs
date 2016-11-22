using UnityEngine;
using System.Collections;

public class InsanityPulse : MonoBehaviour {

    private float rate = 1.5F;
    public bool visible = false;
	// Use this for initialization
	void Start () {
        transform.localScale.Set(1, 1, 1);
    }

    void OnBecameVisible()
    {
        visible = true;
    }
    void OnBecameInvisible()
    {
        visible = false;
    }

    // Update is called once per frame
    void Update () {
        if (visible)
        {
	        if(transform.localScale.x > 100)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x + rate, transform.localScale.y + rate, transform.localScale.z);
            }
        }
	}
}
