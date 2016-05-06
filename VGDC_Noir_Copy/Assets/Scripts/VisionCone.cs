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

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triggered");

        if (other.CompareTag("PlayerCharacter"))
        {
            detectsPlayer = true;
        }
    }
}
