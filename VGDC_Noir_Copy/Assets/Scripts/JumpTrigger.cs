using UnityEngine;
using System.Collections;

public class JumpTrigger : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Rigidbody2D>().AddForce(Vector3.up * EnemySimple.jumpHeight);
        } // make the enemy that touched this jump
}
