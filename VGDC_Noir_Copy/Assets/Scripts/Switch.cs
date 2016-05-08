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

        if (Input.GetButtonDown("Switch") || difference >= maxDistance)
        {
            if (isShadow)
            {
                isShadow = false;

                shadowMove.enabled = false;

                movement.enabled = true;

                PlayerTracking.tagSearch = "PlayerCharacter";
            }
            else if (PlayerMovement.onGround)
            {
                isShadow = true;

                movement.enabled = false;

                shadowMove.enabled = true;

                PlayerTracking.tagSearch = "Shadow";
            }
        }

        shadow.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - difference / (2 * maxDistance));
	} 
}
