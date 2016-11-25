using UnityEngine;
using System.Collections;

public class ShadowActive : MonoBehaviour {
    public static bool inWall = false;
    public static GameObject master;

	// Use this for initialization
	void Start ()
    {
        master = GameObject.FindWithTag("PlayerCharacter");
	}
	
	// Update is called once per frame
	void Update ()
    {
        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Wall", "Floor", "PlayerCharacter" });
        // Don't collide with objects
        SpriteRenderer _sprite = GetComponent<SpriteRenderer>();

        if (!Switch.isShadow)
        {
            if (transform.position.x > ShadowMovement.rightBound.x)
            {
                transform.position = new Vector3(ShadowMovement.rightBound.x, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < ShadowMovement.leftBound.x)
            {
                transform.position = new Vector3(ShadowMovement.leftBound.x, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = master.transform.position + new Vector3(0, -1.5f, 0);
            }

            transform.rotation = Quaternion.Euler(0, 0, 0);
            inWall = false;
        } // Put shadow under player, enforce bounds
    }
}
