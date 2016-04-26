using UnityEngine;
using System.Collections;

public class PlayerTracking : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.FindWithTag("Player");

        transform.position = new Vector3(player.transform.position.x, 0, -10);
	}
}
