using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
    public static bool isShadow;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        ShadowMovement shadow = gameObject.GetComponentInChildren<ShadowMovement>();
        PlayerMovement movement = gameObject.GetComponent<PlayerMovement>();

        if (Input.GetButtonDown("Switch"))
        {
            if (isShadow)
            {
                isShadow = false;

                shadow.enabled = false;

                movement.enabled = true;

                PlayerTracking.tagSearch = "PlayerCharacter";
            }
            else if (PlayerMovement.onGround)
            {
                isShadow = true;

                movement.enabled = false;

                shadow.enabled = true;
                

                PlayerTracking.tagSearch = "Shadow";
            }
        }
	}
}
