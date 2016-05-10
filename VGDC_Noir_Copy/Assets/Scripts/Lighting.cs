using UnityEngine;
using System.Collections;

public class Lighting : MonoBehaviour {
    public static bool inLight;

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
        if (other.gameObject.CompareTag("PlayerCharacter"))
        {
            inLight = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerCharacter"))
        {
            inLight = false;
        }
    }
}
