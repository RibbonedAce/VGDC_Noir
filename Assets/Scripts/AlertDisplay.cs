using UnityEngine;
using System.Collections;

public class AlertDisplay : MonoBehaviour {
    public bool alerted;

	// Use this for initialization
	void Start ()
    {
        alerted = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (alerted)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
	}
}
