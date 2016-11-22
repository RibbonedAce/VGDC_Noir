using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void clickStart()
    {
        SceneManager.LoadScene(1);
    }

    public void clickQuit()
    {
        Application.Quit();
    }
}
