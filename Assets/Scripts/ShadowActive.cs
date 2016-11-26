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

        if (!Switch.isShadow)
        {
            PublicFunctions.PhaseThruTag(gameObject, new string[] { "Transfer" });

            if (master.transform.position.x > ShadowMovement.rightBound.x)
            {
                transform.position = ShadowMovement.rightBound;
            }
            else if (master.transform.position.x < ShadowMovement.leftBound.x)
            {
                transform.position = ShadowMovement.leftBound;
            }
            else
            {
                transform.position = new Vector3(master.transform.position.x, transform.position.y, master.transform.position.z);
            }

            transform.rotation = Quaternion.Euler(0, 0, 0);
            inWall = false;
        } // Put shadow under player, enforce bounds
    }

    public static void Attach ()
    {
        GameObject shadow = GameObject.FindWithTag("Shadow");
        shadow.transform.position = new Vector3(shadow.transform.position.x, master.transform.position.y - 1.5f, shadow.transform.position.z);
    }
}
