using UnityEngine;
using System.Collections;

public class VisionCone : MonoBehaviour {
    public bool detectsPlayer = false;
    public bool detectsShadow = false;

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
        if ((other.CompareTag("PlayerCharacter") && (Lighting.playerInLight || PlayerMovement.isMoving)))
        {
            detectsPlayer = true;
        }
        if (other.CompareTag("Shadow") && Lighting.shadowInLight)
        {
            detectsShadow = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCharacter"))
        {
            detectsPlayer = false;
        }
        if (other.CompareTag("Shadow"))
        {
            detectsShadow = false;
        }
    }
}
