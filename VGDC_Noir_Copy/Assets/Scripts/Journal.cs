using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Journal : MonoBehaviour {
    private bool inJournal = false;
    private bool paused = false;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Text journalText = GameObject.Find("Journal Text").GetComponent<Text>();

        if (Input.GetKeyDown(KeyCode.J) && !paused)
        {
            inJournal = !inJournal;
            if (inJournal)
            {
                GetComponent<PlayerMovement>().enabled = false;
                journalText.text = "Journal Opened";
                Time.timeScale = 0;
            }
            else
            {
                GetComponent<PlayerMovement>().enabled = true;
                journalText.text = "";
                Time.timeScale = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !inJournal)
        {
            paused = !paused;
            if (paused && !inJournal)
            {
                GetComponent<PlayerMovement>().enabled = false;
                journalText.text = "Game Paused";
                Time.timeScale = 0;
            }
            else
            {
                GetComponent<PlayerMovement>().enabled = true;
                journalText.text = "";
                Time.timeScale = 1;
            }
        }
    }
}
