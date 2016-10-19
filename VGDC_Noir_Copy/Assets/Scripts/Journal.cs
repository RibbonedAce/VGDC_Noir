using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Journal : MonoBehaviour {
    private bool inJournal = false;
    private bool paused = false;
    public static string setLeftText;
    public static string setRightText;

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
                journalTextL.text = setLeftText;
                journalTextR.text = setRightText;
                journal.enabled = true;
                Time.timeScale = 0;
            } // pause game and show journal
            else
            {
                GetComponent<PlayerMovement>().enabled = true;
                journalTextL.text = "";
                journalTextR.text = "";
                journal.enabled = false;
                Time.timeScale = 1;
            } // unpause game and close journal
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !inJournal)
        {
            paused = !paused;
            if (paused && !inJournal)
            {
                GetComponent<PlayerMovement>().enabled = false;
                pauseText.text = "Game Paused";
                Time.timeScale = 0;
            } // pause game (not journal)
            else
            {
                GetComponent<PlayerMovement>().enabled = true;
                pauseText.text = "";
                Time.timeScale = 1;
            } // unpause game (not journal)
        }
    }
}
