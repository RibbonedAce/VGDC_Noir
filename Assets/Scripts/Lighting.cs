using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lighting : MonoBehaviour {
    public static bool playerInLight;
    public static GameObject activeArea;
    public bool isOn = true;
    public GameObject startPos;
    public GameObject endPos;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (activeArea == gameObject)
        {
            ShadowMovement.leftBound = startPos.transform.position;
            ShadowMovement.rightBound = endPos.transform.position;
            if (!isOn)
            {
                activeArea = null;
            }
        }// Set lighting area if on, remove it if off
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isOn)
        {
            activeArea = gameObject;
        }
    }
}