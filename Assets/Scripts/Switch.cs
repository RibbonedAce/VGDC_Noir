using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
    public static bool isShadow = false;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(PlayerMovement.isMoving);

        GameObject shadow = GameObject.FindWithTag("Shadow");

        ShadowMovement shadowMove = shadow.GetComponent<ShadowMovement>();
        PlayerMovement movement = GetComponent<PlayerMovement>();

        if (Input.GetButtonDown("Switch"))
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
                PlayerMovement.isMoving = false;
                movement.reAnimate();
            } // Switch to shadow
        }

        shadow.GetComponent<SpriteRenderer>().color = new Color(0.21176470588f, 0.22745098039f, 0.25882352941f, 1); 
        // Shadow color, fades with distance
	} 
}
