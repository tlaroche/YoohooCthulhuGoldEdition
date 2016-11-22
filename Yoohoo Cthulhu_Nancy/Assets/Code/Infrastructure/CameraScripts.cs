using UnityEngine;
using System.Collections;

public class CameraScripts : MonoBehaviour {
    private Character Player_main;
    bool BossZoom = false;
    public float LerpSpeed;
    public Vector3 BossPositionOriginal;
    bool ReduceSpeed = true;
    //public GameObject Cthulhu;
	// Use this for initialization
	void Start () {
        Player_main = GameObject.Find("Character").GetComponent<Character>();
        LerpSpeed = 0f;
        BossPositionOriginal = new Vector3(0, 0, 0);
       // Cthulhu = new GameObject();
    }
	
	// Update is called once per frame
	void Update () {
        if (Player_main.transform.position.y > -1450)
        {
            if ((Player_main.transform.position.x != gameObject.transform.position.x) && (Player_main.transform.position.x >= -10 && Player_main.transform.position.x <= 10))
            {
                transform.position = new Vector3(Player_main.transform.position.x, transform.position.y, transform.position.z);

            }
            else
            {
                if (Player_main.transform.rotation == Quaternion.Euler(0, 0, 270) && (Player_main.transform.position.x > -10) && (Player_main.transform.position.x < 10))
                {
                    transform.Translate(Vector3.left * Time.deltaTime * Player_main.speed);
                }
                if (Player_main.transform.rotation == Quaternion.Euler(0, 0, 90) && (Player_main.transform.position.x < 10) && (Player_main.transform.position.x > -10))
                {
                    transform.Translate(Vector3.right * Time.deltaTime * Player_main.speed);
                }
                if (Player_main.transform.rotation == Quaternion.Euler(0, 0, 0))
                {
                    transform.Translate(Vector3.down * Time.deltaTime * Player_main.speed);
                }
            }
        }
        else
        {
            //Instantiate(Cthulhu, new Vector3(0, -1500, 0), Quaternion.identity);
            if (ReduceSpeed)
            {
                Player_main.speed = Player_main.speed/3;
                ReduceSpeed = false;
            }
            if(BossZoom == false)
            {
                if(BossPositionOriginal == Vector3.zero)
                {
                    BossPositionOriginal = gameObject.transform.position;
                }
                if (gameObject.GetComponent<Camera>().orthographicSize < 45)
                {
                    gameObject.GetComponent<Camera>().orthographicSize += Time.deltaTime * 16;
                    gameObject.transform.position = Vector3.Lerp(BossPositionOriginal, new Vector3(0, -1475, -10), LerpSpeed);
                    LerpSpeed += .5f * Time.deltaTime;
                }
                else
                {
                    BossZoom = true;
                }
            }
        }
    }
}
