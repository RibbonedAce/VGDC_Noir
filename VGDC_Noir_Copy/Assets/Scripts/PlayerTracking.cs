using UnityEngine;
using System.Collections;

public class PlayerTracking : MonoBehaviour {
    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerMovement.onLadder || PlayerMovement.onGround || (gameObject.transform.position.y - player.transform.position.y > 2))
        {   
            TrackVertical();
        }
        else
        {
            NoVertical();
        }
	}

    void TrackVertical ()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, -10);
    }

    void NoVertical ()
    {
        transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y, -10);
    }
}
