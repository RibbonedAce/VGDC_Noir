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
        } // Make object vanish
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("PlayerCharacter"))
        {
            canInteract = true;
        } // Interaction trigger
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("PlayerCharacter"))
        {
            canInteract = false;
        }  // Exit interaction trigger
    }
}
