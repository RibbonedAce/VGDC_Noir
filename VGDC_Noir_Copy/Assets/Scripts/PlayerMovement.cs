using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public int jumpHeight;
    private bool onGround = false;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
        }

        if (Input.GetButtonDown("Jump") && onGround)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpHeight);
            onGround = false;
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
	}

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            onGround = true;
        }
    }
}
