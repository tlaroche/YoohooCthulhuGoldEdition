using UnityEngine;
using System.Collections;

public class BioBoom : MonoBehaviour {
    public float opacity;
	// Use this for initialization
	void Start () {
        opacity = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
        opacity -= .03f;
        if(opacity <= 0)
        {
            gameObject.SetActive(false);
        }
	}
}
