using UnityEngine;
using System.Collections;

public class Items_All : MonoBehaviour
{
    public Character Character_Management;
    // Use this for initialization
    void Start()
    {
        Character_Management = GameObject.Find("Character").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.name == "Character")
        {
			AudioSource.PlayClipAtPoint (GetComponent<AudioSource> ().clip, transform.position);
            if(gameObject.tag == "TNT")
            {
                Character_Management.TNT++;
            }
            else if(gameObject.tag == "BioBomb")
            {
                Character_Management.BioBomb++;
            }
            else if(gameObject.tag == "Dash")
            {
                Character_Management.Dash++;
            }
            else if(gameObject.tag == "PlotArmor")
            {
                Character_Management.damageMod = 0;
                GameObject.Find("PlotArmor_Effect").GetComponent < Renderer >().enabled= true;
                Invoke("EndPlotArmor", 5f);
            }
            else if(gameObject.tag == "SloMo")
            {
                Time.timeScale = .5f;
                Invoke("TimeScale", 5f);
            }
            //else if(gameObject.tag == "TransmutationField")
            //{
            //    GameObject.Find("Transmutation_Effect").GetComponent<CircleCollider2D>().enabled = true;
            //    GameObject.Find("Transmutation_Effect").GetComponent<Renderer>().enabled = true;
            //    Invoke("EndTransmutation",10f);
            //}
            else if(gameObject.tag == "Repair")
            {
                if(Character_Management.health < 3)
                 Character_Management.health++;
            }
            gameObject.SetActive(false);
        }
    }

    void EndPlotArmor()
    {
        Character_Management.damageMod = 1;
        GameObject.Find("PlotArmor_Effect").GetComponent<Renderer>().enabled = false;
    }

    void TimeScale()
    {
        Time.timeScale = 1f;
    }

    //void EndTransmutation()
    //{
    //    Debug.Log("End Effect");
    //    GameObject.Find("Transmutation_Effect").GetComponent<Renderer>().enabled = false;
    //    GameObject.Find("Transmutation_Effect").GetComponent<CircleCollider2D>().enabled = false;
    //}
}
