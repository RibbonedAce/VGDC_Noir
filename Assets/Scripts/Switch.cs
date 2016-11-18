using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
    public static bool isShadow = false;
    public float maxDistance;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject shadow = GameObject.FindWithTag("Shadow");

        float difference = (transform.position - shadow.transform.position).magnitude;

        ShadowMovement shadowMove = shadow.GetComponent<ShadowMovement>();
        PlayerMovement movement = GetComponent<PlayerMovement>();

        if (Input.GetButtonDown("Switch") || difference >= maxDistance || (isShadow && !Lighting.shadowInLight))
        {
            if (isShadow)
            {
                isShadow = false;

                shadowMove.enabled = false;

                movement.enabled = true;

                PlayerTracking.tagSearch = "PlayerCharacter";
            } // Switch to player
            else if (PlayerMovement.onGround && !isShadow && !Journal.inJournal)
            {
                isShadow = true;

                movement.enabled = false;

                shadowMove.enabled = true;

                PlayerTracking.tagSearch = "Shadow";
            } // Switch to shadow
        }

        shadow.GetComponent<SpriteRenderer>().color = new Color(0.21176470588f, 0.22745098039f, 0.25882352941f, 1 - difference / (2 * maxDistance)); 
        // Shadow color, fades with distance
	} 
}
