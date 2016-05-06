using UnityEngine;
using System.Collections;

public class ShadowActive : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        SpriteRenderer _sprite = gameObject.GetComponent<SpriteRenderer>();

        if (PlayerMovement.onGround)
        {
            _sprite.enabled = true;
        }
        else
        {
            _sprite.enabled = false;
        }

        if (!Switch.isShadow)
        {
            transform.localPosition = new Vector3(0, -1.5f, transform.localPosition.z);
        }
    }
}
