using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Journal : MonoBehaviour {
    public static bool inJournal = false;
    public static bool paused = false;
    public static List<string> pageContent;
    public static int page;

	// Use this for initialization
	void Start ()
    {
        pageContent = new List<string>();
        pageContent.Add("My Journal");
        pageContent.Add("Left/right in journal to flip through pages");
        pageContent.Add("A/D: move\nSpace: jump\nE: interact with object");
        pageContent.Add("Don't get spotted by enemies.\nPicking up coins adds more pages.");

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

        if (Input.GetKeyDown(KeyCode.J) && !paused && !Switch.isShadow)
        {
            inJournal = !inJournal;
            if (!inJournal)
            {
                GetComponent<PlayerMovement>().enabled = true;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (!paused)
            {
                GetComponent<PlayerMovement>().enabled = true;
            }
        }

        if (paused || inJournal)
        {
            GetComponent<PlayerMovement>().enabled = false;
            Time.timeScale = 0;
        } // send game to stopped state
        else
        {
            Time.timeScale = 1;
        } // send game to normal state

        if (paused)
        {
            pauseText.text = "Game Paused";
        } // show pause text
        else
        {
            pauseText.text = "";
        } // remove pause text

        if (inJournal)
        {
            journalTextL.text = pageContent[page];
            journalTextR.text = pageContent[page + 1];
            tutorialText.enabled = false;
            journal.enabled = true;

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
        } // show journal and allow journal controls
        else
        {
            journalTextL.text = "";
            journalTextR.text = "";
            journal.enabled = false;

            leftPageNum.text = "";
            rightPageNum.text = "";
        } // close journald
    }
}
