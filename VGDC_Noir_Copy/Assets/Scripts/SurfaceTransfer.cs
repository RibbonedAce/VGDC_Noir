using UnityEngine;
using System.Collections;

public class SurfaceTransfer : MonoBehaviour {
    public GameObject wall;
    public GameObject floor;
    private bool connectFloor;
    private bool connectLeft;

	// Use this for initialization
	void Start ()
    {
	    if (floor.transform.position.x < transform.position.x)
        {
            connectLeft = true;
        }
        else
        {
            connectLeft = false;
        }

        if (wall.transform.position.y > transform.position.y)
        {
            connectFloor = true;
        }
        else
        {
            connectFloor = false;
        }
	} // Set which corner this objects acts as
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Shadow"))
        {
            ShadowActive.inWall = !ShadowActive.inWall;

            Vector3 transferWally = new Vector3(0, wall.transform.localScale.x / 2 - other.transform.localScale.x, 0);
            Vector3 transferFloory = new Vector3(0, (1 - floor.transform.localScale.y) / 2, 0);
            // Set connected ceiling
            if (connectFloor)
            {
                transferWally = new Vector3(0, other.transform.localScale.x - wall.transform.localScale.x / 2, 0);
                transferFloory = new Vector3(0, (floor.transform.localScale.y - 1) / 2, 0);
            } // Set connected floor if applicable

            Vector3 transferFloorx = new Vector3(other.transform.localScale.x - floor.transform.localScale.x / 2, 0, 0);
            Vector3 transferWallx = new Vector3((1 - wall.transform.localScale.y) / 2, 0, 0);
            // Set connected right wall
            if (connectLeft)
            {
                transferFloorx = new Vector3(floor.transform.localScale.x / 2 - other.transform.localScale.x, 0, 0);
                transferWallx = new Vector3((wall.transform.localScale.y - 1) / 2, 0, 0);
            } // Set connected left wall if applicable

            if (ShadowActive.inWall)
            {
                other.transform.position = wall.transform.position + transferWallx + transferWally;

                other.transform.rotation = wall.transform.rotation;
            } // Transfer shadow to wall
            else
            {
                other.transform.position = floor.transform.position + transferFloorx + transferFloory;

                other.transform.rotation = floor.transform.rotation;
            } // Transfer shadow to floor
        }
    }
}
