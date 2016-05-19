using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {
    public bool canInteract = false;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        if (Input.GetButtonDown("Interact") && canInteract)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("PlayerCharacter"))
        {
            canInteract = true;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("PlayerCharacter"))
        {
            canInteract = false;
        }
    }
}
