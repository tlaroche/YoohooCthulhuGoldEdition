using UnityEngine;
using System.Collections;

public class InsanityMaw : MonoBehaviour {
	private bool visible = false;
	// Use this for initialization
	void Start () 
	{
		GetComponent<AudioSource> ().loop = true;
		AudioSource.PlayClipAtPoint (GetComponent<AudioSource> ().clip, transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!visible) 
		{
			GetComponent<AudioSource> ().volume -= .1f;
		} 
		else 
		{
			GetComponent<AudioSource> ().volume = 1;
		}
	}
	void OnBecameVisible()
	{
		visible = true;
	}
	void OnBecameInvisible()
	{
		visible = true;
		Invoke ("Die", 3);
	}
	void Die()
	{
		Destroy (gameObject);
	}
}
