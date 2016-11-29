using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {
    public int ammo;
    public GameObject bullet;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            if (PlayerMovement.facingRight)
            {
                Instantiate(bullet, gameObject.transform.position + new Vector3(2, 1, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(bullet, gameObject.transform.position + new Vector3(-2, 1, 0), Quaternion.Euler(0, 0, 180));
            }

            ammo--;
        }// Shoot a gun
	}
}
