using UnityEngine;
using System.Collections;

public class BadgermoleScript : MonoBehaviour {

    private float speed = 2.56F;
    private float[] directionArray = new float[3];
    private float distanceTurn = 0;
    private int input = 2;
    private int previousDirection = 2;
    float distanceToTravel;
    float distanceTravelled;
    public GameObject[] tunnels = new GameObject[6];
    public Vector3 Pos;
    public bool Active = false;
    //int countmyshitupbruh;

    // Use this for initialization
    void Start () {
        directionArray[0] = 90; //Right
        directionArray[1] = 270; //Left
        directionArray[2] = 0; //Down
        distanceToTravel = Random.Range(8, 12);
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
            if (distanceTravelled >= distanceToTravel)
            {
                Destroy(gameObject);
            }
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed * 2);
            distanceTurn += speed * Time.deltaTime;
            distanceTravelled += speed * Time.deltaTime;
            //Distance 2.56 is size of tunnel, check if turn when travel that distance
            if (distanceTurn >= 2.56 / 1.9)
            {
                Pos = new Vector3(transform.position.x, transform.position.y, 0);
                previousDirection = input;
                distanceTurn = 0;
                input = Random.Range(0, 3);

				AudioSource.PlayClipAtPoint (GetComponent<AudioSource> ().clip, transform.position);

                if (input == 0 && transform.rotation.eulerAngles.z != 270)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                }
                else if (input == 1 && transform.rotation.eulerAngles.z != 90)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 270);
                }
                else if (input == 2)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                //Right = 0 / Left = 1 / Down = 2
                if (previousDirection == 0 && input == 2) // Right then down
                {
                    //Debug.Log("Right then Down");
                    Instantiate(tunnels[3], Pos, Quaternion.identity);
                }
                if (previousDirection == 1 && input == 2) // Left then down
                {
                    //Debug.Log("Left then Down");
                    Instantiate(tunnels[2], Pos, Quaternion.identity);
                }
                if (previousDirection == 2 && input == 1) // Down then left
                {
                    //Debug.Log("Down then Left");
                    Instantiate(tunnels[5], Pos, Quaternion.identity);
                }
                if (previousDirection == 2 && input == 0) //Down then right
                {
                    //Debug.Log("Down then Right");
                    Instantiate(tunnels[4], Pos, Quaternion.identity);
                }
                if (input == 1) //left 
                {
                   // Debug.Log("Horizontal" + (countmyshitupbruh++));
                    Instantiate(tunnels[1], Pos, Quaternion.identity);
                }
                if (input == 0) //right 
                {
                 //   Debug.Log("Horizontal" + (countmyshitupbruh++));
                    Instantiate(tunnels[1], Pos, Quaternion.identity);
                }
                if (input == 2) // Any then Down
                {
                    //Debug.Log("Down");
                    Instantiate(tunnels[0], Pos, Quaternion.identity);
                }
            }
        }
    }

    void OnBecameVisible()
    {
        Active = true;
    }
}
