using UnityEngine;
using System.Collections;

public class ShadowMovement : MonoBehaviour {
    public float speed;
    public static bool isMoving;
    public static Vector3 leftBound;
    public static Vector3 rightBound;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (SurfaceTransfer.moveTimer <= 0)
        {
	        if (Input.GetAxis("Horizontal") != 0 && !ShadowActive.inWall)
            {
                transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
                isMoving = true;
            } // Move on a floor/ceiling
            else if (Input.GetAxis("Vertical") != 0 && ShadowActive.inWall)
            {
                transform.Translate(Vector3.right * Input.GetAxis("Vertical") * speed * Time.deltaTime);
                isMoving = true;
            } // Move on a wall
            else
            {
                isMoving = false;
            }
        }

        if (transform.position.x > rightBound.x)
        {
            transform.position = new Vector3(rightBound.x, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < leftBound.x)
        {
            transform.position = new Vector3(leftBound.x, transform.position.y, transform.position.z);
        }
    }
}
