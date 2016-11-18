using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {
    public string LeftText;
    public string RightText;
    public bool canInteract = false;
    private AudioSource sound;

	// Use this for initialization
	void Start ()
    {
        sound = GameObject.Find("Coin Sound Holder").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        if (Input.GetButtonDown("Interact") && canInteract)
        {
            sound.Play();

            if (LeftText != "" || RightText != "")
            {
                AddPage();
            }

            Destroy(gameObject);
        } // Interact with object
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
