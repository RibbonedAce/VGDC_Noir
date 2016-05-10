using UnityEngine;
using System.Collections;

public class ShadowActive : MonoBehaviour {
    public static bool inWall = false;
    private GameObject master;

	// Use this for initialization
	void Start ()
    {
        master = GameObject.FindWithTag("PlayerCharacter");
	}
	
	// Update is called once per frame
	void Update ()
    {
        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Wall", "Floor", "PlayerCharacter" });

        SpriteRenderer _sprite = GetComponent<SpriteRenderer>();

        if (PlayerMovement.onGround && Lighting.inLight)
        {
            _sprite.enabled = true;
        }
        else
        {
            _sprite.enabled = false;
        }

        if (!Switch.isShadow)
        {
            transform.position = master.transform.position + new Vector3(0, -1.5f, 0);
        }
    }
}
