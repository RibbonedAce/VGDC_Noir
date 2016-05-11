using UnityEngine;
using System.Collections;

public class Lighting : MonoBehaviour {
    public static bool playerInLight;
    public static bool shadowInLight;

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
        if (other.CompareTag("Shadow"))
        {
            shadowInLight = true;
        }
        if (other.CompareTag("PlayerCharacter"))
        {
            playerInLight = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            shadowInLight = false;
        }
        if (other.CompareTag("PlayerCharacter"))
        {
            playerInLight = false;
        }
    }
}
