using UnityEngine;
using System.Collections;

public class Buttongame_Dash : MonoBehaviour {

    private Character Player_main;
    public float SpeedPrev;
	public bool collisionChecker;
    // Use this for initialization
    void Start () {
        Player_main = GameObject.Find("Character").GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (Player_main.Dash > 0)
		{
			GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            SpeedPrev = Player_main.speed;
            Player_main.speed *= 20;
			Invoke ("Wait", .1f);
            Player_main.Dash--;
			Player_main.GoFuckYourselfFlash = true;
			collisionChecker = Player_main.CheckMyFuckUp ();
			if (collisionChecker == true)
            {
                Player_main.GetComponent<BoxCollider2D>().enabled = false;
                Player_main.GoFuckYourselfFlash = true;
                Invoke("TurnColliderOn", .1f);
			}
        }
    }

    void Wait()
    {
			Player_main.GoFuckYourselfFlash = false;
        	Player_main.speed /= 20;
    }

    void TurnColliderOn()
    {
        Player_main.GetComponent<BoxCollider2D>().enabled = true;
        Player_main.GoFuckYourselfFlash = false;
    }
}
