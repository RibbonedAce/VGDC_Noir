using UnityEngine;
using System.Collections;

public class Lighting : MonoBehaviour {
    public static bool playerInLight;
    public static bool shadowInLight;
    public static int shadowLightsIn;
    public static int playerLightsIn;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (shadowLightsIn > 0)
        {
            shadowInLight = true;
        }
        else
        {
            shadowInLight = false;
        }

        if (playerLightsIn > 0)
        {
            playerInLight = true;
        }
        else
        {
            playerInLight = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            shadowLightsIn++;
        }
        if (other.CompareTag("PlayerCharacter"))
        {
            playerLightsIn++;
        } 
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            shadowLightsIn--;
        }
        if (other.CompareTag("PlayerCharacter"))
        {
            playerLightsIn--;
        }
    }
} // track the amount of lighting objects that the player/shadow is in
