using UnityEngine;
using System.Collections;

public class Hazard_All : MonoBehaviour {

    public GameObject exploding;
    public Character Character_Management;
    public Color Green;
    float rockX, rockY;
    //public Animator Hazard_GasPocketAnimator;
    //public AnimationClip Hazard_GasPocketAnimationClip;

    // Use this for initialization
    void Start () {
        Character_Management = GameObject.Find("Character").GetComponent<Character>();
        Green.g = 255;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.name == "Character")
        {
			AudioSource.PlayClipAtPoint (GetComponent<AudioSource> ().clip, transform.position);
            if (gameObject.tag == "AcidPit")
            {
                GameObject.Find("Acid Effect").GetComponent<Renderer>().enabled = true;
                Character_Management.damageMod = 3;
                Invoke("Waiting", 5f);
                gameObject.SetActive(false);
            }
            else if (gameObject.tag == "GasPocket")
            {
                Instantiate(exploding, transform.position, transform.rotation);
                Character_Management.DealDamage();
                gameObject.SetActive(false);
            }
            else if (gameObject.tag == "Rock")
            {
                rockX = hit.gameObject.transform.position.x - transform.position.x;
                rockY = hit.gameObject.transform.position.y - transform.position.y;
				if ((Character_Management.transform.rotation.eulerAngles.z == 0) && (rockY > rockX) && (rockY > 0))
				{
					//   if (gameObject.transform.position.x - Character_Management.transform.position.x <= 3)
					if (!Character_Management.RocksSuck) {
						Character_Management.transform.rotation = Quaternion.Euler (0, 0, 90);
						Character_Management.transform.Translate (new Vector3 (.8f, 0, 0));
						Character_Management.DealDamage ();
						Character_Management.RocksSuck = true;
					}
				}
                else if ((Character_Management.transform.rotation.eulerAngles.z == 270 || Character_Management.transform.rotation.eulerAngles.z == -90) && (rockX > rockY))
                {
                  //  if(gameObject.transform.position.x - Character_Management.transform.position.x <= 5)
					if (!Character_Management.RocksSuck) {
						Character_Management.transform.rotation = Quaternion.Euler (0, 0, 0);
						Character_Management.transform.Translate (new Vector3(.8f, 0, 0));
						Character_Management.DealDamage ();
						Character_Management.RocksSuck = true;
					}
                }
                else if ((Character_Management.transform.rotation.eulerAngles.z == 90) && (rockY > rockX))
                {
                  //  if (gameObject.transform.position.x - Character_Management.transform.position.x <= 5)
					if (!Character_Management.RocksSuck) {
						Character_Management.transform.rotation = Quaternion.Euler (0, 0, 0);
						Character_Management.transform.Translate (new Vector3 (-.8f, 0, 0));
						Character_Management.DealDamage ();
						Character_Management.RocksSuck = true;
					}
                }
                
                Character_Management.controllable = false;
            }
            else if(gameObject.tag == "DustCloud")
            {
                GameObject.Find("Dirt_Effect").GetComponent<Renderer>().enabled = true;
                gameObject.SetActive(false);
                Invoke("DustEnd", 10f);
            }
        }
        else if (hit.tag == "TNTBoom")
        {
            gameObject.SetActive(false);
        }
    }
    void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.name == "Character")
        {
            Character_Management.controllable = true;
        }
    }

    void Waiting()
    {
        Character_Management.damageMod = 1;
        GameObject.Find("Acid Effect").GetComponent<Renderer>().enabled = false;
    }

    void DustEnd()
    {
        GameObject.Find("Dirt_Effect").GetComponent<Renderer>().enabled = false;
    }
}
