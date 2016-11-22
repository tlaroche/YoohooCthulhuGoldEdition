using UnityEngine;
using System.Collections;

public class TNTBoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Wait", .6f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void Wait()
    {
        gameObject.SetActive(false);
    }
}
