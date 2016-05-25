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
        Image journal = GameObject.Find("Journal Book").GetComponent<Image>();
        Text pauseText = GameObject.Find("Pause Text").GetComponent<Text>();
        Text journalTextL = GameObject.Find("Journal Text L").GetComponent<Text>();
        Text journalTextR = GameObject.Find("Journal Text R").GetComponent<Text>();

        if (Input.GetKeyDown(KeyCode.J) && !paused)
        {
            inJournal = !inJournal;
            if (inJournal)
            {
                GetComponent<PlayerMovement>().enabled = false;
                journalTextL.text = "I need to find clues to rescue this girl. She left behind a coin while they dragged her off, but guards are patrolling the area.";
                journalTextR.text = "Objectvies:\n1.Don't get caught\n2.Retrieve the coin";
                journal.enabled = true;
                Time.timeScale = 0;
            }
            else
            {
                GetComponent<PlayerMovement>().enabled = true;
                journalTextL.text = "";
                journalTextR.text = "";
                journal.enabled = false;
                Time.timeScale = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !inJournal)
        {
            paused = !paused;
            if (paused && !inJournal)
            {
                GetComponent<PlayerMovement>().enabled = false;
                pauseText.text = "Game Paused";
                Time.timeScale = 0;
            }
            else
            {
                GetComponent<PlayerMovement>().enabled = true;
                pauseText.text = "";
                Time.timeScale = 1;
            }
        }
    }
}
