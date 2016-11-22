using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lighting : MonoBehaviour {
    public static bool playerInLight;
    public static bool shadowInLight;
    public static List<GameObject> playerActiveLights;
    public static List<GameObject> shadowActiveLights;

	// Use this for initialization
	void Start ()
    {
        playerActiveLights = new List<GameObject>();
        shadowActiveLights = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (shadowActiveLights.Count > 0)
        {
            shadowInLight = true;
        }
        else
        {
            shadowInLight = false;
        }

        if (playerActiveLights.Count > 0)
        {
            playerInLight = true;
        }
        else
        {
            playerInLight = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            if (!shadowActiveLights.Contains(gameObject))
            {
                shadowActiveLights.Add(gameObject);
            }
        }
        if (other.CompareTag("PlayerCharacter"))
        {
            if (!playerActiveLights.Contains(gameObject))
            {
                playerActiveLights.Add(gameObject);
            }
        } 
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            if (shadowActiveLights.Contains(gameObject))
            {
                shadowActiveLights.Remove(gameObject);
            }
        }
        if (other.CompareTag("PlayerCharacter"))
        {
            if (playerActiveLights.Contains(gameObject))
            {
                playerActiveLights.Remove(gameObject);
            }
        }
    }// track the amount of lighting objects that the player/shadow is in

}