using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {
    public string LeftText;
    public string RightText;
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
            if (LeftText != "" || RightText != "")
            {
                AddPage();
            }
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

    void AddPage()
    {
        Journal.pageContent.Add(LeftText);
        Journal.pageContent.Add(RightText);
    }//Change the text of a journal upon opening
}
