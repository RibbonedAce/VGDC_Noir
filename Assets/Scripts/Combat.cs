using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combat : MonoBehaviour {
    public int ammo;
    public GameObject bullet;
    public Text ammoDisplay;
    public AudioClip shootSound;
    private AudioSource _shoot;

	// Use this for initialization
	void Start ()
    {
        _shoot = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ammoDisplay.text = ammo.ToString();

	    if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            _shoot.clip = shootSound;
            _shoot.Play();

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
