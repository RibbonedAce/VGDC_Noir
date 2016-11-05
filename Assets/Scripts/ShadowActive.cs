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

        if (PlayerMovement.onGround)
        {
            _sprite.enabled = true;
        } 
        else
        {
            _sprite.enabled = false;
        } // Don't show shadow if player is in air

        if (!Switch.isShadow)
        {
            transform.position = master.transform.position + new Vector3(0, -1.5f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            inWall = false;
        } // Put shadow under player
    }
}
