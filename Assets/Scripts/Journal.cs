using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Journal : MonoBehaviour {
    private bool inJournal = false;
    private bool paused = false;
    public static List<string> pageContent;
    public static int page;

	// Use this for initialization
	void Start ()
    {
        pageContent = new List<string>();
        pageContent.Add("My Journal");
        pageContent.Add("Left/right in journal to flip through pages");
        pageContent.Add("A/D: move\nSpace: jump\nE: interact with object");
        pageContent.Add("Don't get spotted by enemies.");

        page = 0;
        // set the default text
    }
	
	// Update is called once per frame
	void Update ()
    {
        Image journal = GameObject.Find("Journal Book").GetComponent<Image>();
        Text pauseText = GameObject.Find("Pause Text").GetComponent<Text>();
        Text journalTextL = GameObject.Find("Journal Text L").GetComponent<Text>();
        Text journalTextR = GameObject.Find("Journal Text R").GetComponent<Text>();
        Text leftPageNum = GameObject.Find("PageNumL").GetComponent<Text>();
        Text rightPageNum = GameObject.Find("PageNumR").GetComponent<Text>();
        Text tutorialText = GameObject.Find("Tutorial Text").GetComponent<Text>();
        //set vars

        if (Input.GetKeyDown(KeyCode.J) && !paused)
        {
            inJournal = !inJournal;
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

        if (inJournal)
        {
            journalTextL.text = pageContent[page];
            journalTextR.text = pageContent[page + 1];
            tutorialText.enabled = false;
            journal.enabled = true;
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.LeftArrow) && page >= 2)
            {
                Debug.Log("turned back");
                page -= 2;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && page <= pageContent.Count-3)
            {
                Debug.Log("turned forward");
                page += 2;
            }

            leftPageNum.text = page.ToString();
            rightPageNum.text = (page + 1).ToString();
        } // pause game and show journal
        else
        {
            journalTextL.text = "";
            journalTextR.text = "";
            journal.enabled = false;
            Time.timeScale = 1;

            leftPageNum.text = "";
            rightPageNum.text = "";
        } // unpause game and close journal

        
    }
}
