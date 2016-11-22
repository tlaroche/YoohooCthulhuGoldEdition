using UnityEngine;
using System.Collections;

public class TransmutationField_Script : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Character")
        {
            GameObject.Find("Transmutation_Effect").GetComponent<Renderer>().enabled = true;
            GameObject.Find("Transmutation_Effect").GetComponent<CircleCollider2D>().enabled = true;
            gameObject.SetActive(false);
            Invoke("EndEffect", 10f);
        }
    }

    void EndEffect()
    {
        GameObject.Find("Transmutation_Effect").GetComponent<Renderer>().enabled = false;
        GameObject.Find("Transmutation_Effect").GetComponent<CircleCollider2D>().enabled = false;
    }
}
