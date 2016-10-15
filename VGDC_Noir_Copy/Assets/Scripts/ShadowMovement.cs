using UnityEngine;
using System.Collections;

public class ShadowMovement : MonoBehaviour {
    public float speed;
    public static bool isMoving;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
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
}
