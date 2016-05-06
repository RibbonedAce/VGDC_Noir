using UnityEngine;
using System.Collections;

public class ShadowMovement : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime);
        }
	}
}
