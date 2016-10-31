using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerCharacter") && !PlayerMovement.onGround)
        {
            SnapPlayer(other.gameObject);
            PlayerMovement.onLadder = true;
        } // snap player onto the ladder if they jump into it
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerCharacter") && Input.GetAxis("Vertical") != 0 && other.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            SnapPlayer(other.gameObject);
            PlayerMovement.onLadder = true;
        } // snap player if they climb on ladder
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerCharacter"))
        {
            PlayerMovement.onLadder = false;
        } // tell player he got off ladder
    }

    void SnapPlayer (GameObject player)
    {
        player.transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);

        player.GetComponent<Rigidbody2D>().AddForce(-player.GetComponent<Rigidbody2D>().velocity * 200);
    } // force player to go on center of ladder
}
