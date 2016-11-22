using UnityEngine;
using System.Collections;

public class Spitball : MonoBehaviour
{
    public bool Visible = false;
    public Character CharacterScript_Manager;
    // Use this for initialization
    void Start()
    {
        CharacterScript_Manager = GameObject.Find("Character").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 5.5f * 2);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void Awake()
    {

    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.name == "Character")
        {
            CharacterScript_Manager.DealDamage();
            Destroy(gameObject);
        }
    }


}
