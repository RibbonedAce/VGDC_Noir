using UnityEngine;
using System.Collections;

public class VisionCone : MonoBehaviour {
    public bool detectsPlayer = false;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	      
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.CompareTag("PlayerCharacter") && (Lighting.playerInLight || PlayerMovement.isMoving)) || 
            (other.CompareTag("Shadow") && Lighting.shadowInLight))
        {
            detectsPlayer = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCharacter") || other.CompareTag("Shadow"))
        {
            detectsPlayer = false;
        }
    }
}
