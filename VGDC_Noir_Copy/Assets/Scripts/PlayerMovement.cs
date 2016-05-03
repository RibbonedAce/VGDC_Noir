using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public int jumpHeight;
    public float gravity;
    public float climbSpeed;
    public static bool onGround = false;
    public static bool onLadder = false;
    private bool isCrouching = false;
    private Animator _animator;

	// Use this for initialization
	void Start ()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        Rigidbody2D _rigidbody = gameObject.GetComponent<Rigidbody2D>();

        Debug.Log(_animator.GetCurrentAnimatorStateInfo(0));
        Debug.Log(isCrouching);

        if (onLadder)
        {
            isCrouching = false;
            onGround = false;

            _rigidbody.gravityScale = 0;

            if (Input.GetAxis("Vertical") != 0)
            {
                transform.Translate(Vector3.up * Time.deltaTime * climbSpeed * Input.GetAxis("Vertical"));
            }
        }
        else
        {
            _rigidbody.gravityScale = gravity;

            if (Input.GetAxis("Vertical") == -1)
            {
                isCrouching = true;
            }
            else
            {
                isCrouching = false;
            }
        }

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

        _animator.SetBool("Crouching", isCrouching);
	}

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor") && !onLadder)
        {
            onGround = true;
        }
    }
}
