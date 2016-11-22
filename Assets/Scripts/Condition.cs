using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Condition : MonoBehaviour {
    public static bool lost = false;
    public static bool won = false;
    public double menuTimerSet;
    public static double menuTimer;

	// Use this for initialization
	void Start ()
    {
        menuTimer = menuTimerSet;
	}
	
	// Update is called once per frame
	void Update ()
    {  
	    if (lost)
        {
            GameObject.Find("Pause Text").GetComponent<Text>().text = "Game Over";
            Destroy(GameObject.FindWithTag("PlayerCharacter"));
            menuTimer -= Time.deltaTime;

            if (menuTimer <= 0)
            {
                lost = false;
                menuTimer = menuTimerSet;
                SceneManager.LoadScene(0);
            }
        } // lose the game

        if (won)
        {
            GameObject.Find("Pause Text").GetComponent<Text>().text = "You won!";
            menuTimer -= Time.deltaTime;

            if (menuTimer <= 0)
            {
                won = false;
                menuTimer = menuTimerSet;
                SceneManager.LoadScene(0);
            }
        } // win the game
	}
}
