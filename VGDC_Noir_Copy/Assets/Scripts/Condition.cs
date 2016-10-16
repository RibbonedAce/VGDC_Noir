using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Condition : MonoBehaviour {
    public static bool lost = false;
    public static bool won = false;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {  
	    if (lost)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            lost = false;
        } // reload level if lost

        if (won)
        {
            GameObject.Find("Journal Text L").GetComponent<Text>().text = "You won!";

            Time.timeScale = 0;
        } // win the game
	}
}
