using UnityEngine;
using System.Collections;

public class SpitballSpawner_Script : MonoBehaviour {
    public GameObject SpitBaller;
    bool spawn = false;
    int WaveSize = 5;
    private float timer = 0;
	// Use this for initialization
	void Start () {
        //SpitBaller = new GameObject();

    }
	
	// Update is called once per frame
	void Update () {
        if (spawn)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                Instantiate(SpitBaller, new Vector3(gameObject.transform.position.x + (Random.Range(-5, 6) * 3), gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                timer = 0;
            }
        }
	}
    void OnBecameVisible()
    {
        spawn = true;
    }

    void SpawnWave()
    {
        for(int i=0; i <WaveSize; i++)
        {
            Instantiate(SpitBaller, new Vector3(Random.Range(-15, 15), gameObject.transform.position.y, 0),Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.name == "Character")
        {
            spawn = false;
        }
    }
}
