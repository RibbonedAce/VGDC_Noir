using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public int jumpHeight;
    public float gravity;
    public float climbSpeed;
    public static bool onGround = false;
    public static bool onLadder = false;
    public static bool isCrouching = false;
    public static bool isLooking = false;
    private Animator _animator;
    public static bool cameraMoved = false;

	// Use this for initialization
	void Start ()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        Rigidbody2D _rigidbody = gameObject.GetComponent<Rigidbody2D>();

        if (onLadder)
        {
            isCrouching = false;
            isLooking = false;
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

            if (Input.GetAxis("Vertical") == -1 && onGround)
            {
                isLooking = false;
                isCrouching = true;

                if (Input.GetAxis("Horizontal") != 0)
                {
                    cameraMoved = true;
                }
            }
            else if (Input.GetAxis("Vertical") == 1 && onGround)
            {
                isCrouching = false;
                isLooking = true;

                if (Input.GetAxis("Horizontal") != 0)
                {
                    cameraMoved = true;
                }
            }
            else
            {
                isCrouching = false;
                isLooking = false;
                cameraMoved = false;
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
            isCrouching = false;
            isLooking = false;

            GameObject.FindWithTag("MainCamera").GetComponent<PlayerTracking>().reset();
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);

        _animator.SetBool("Crouching", isCrouching);
        _animator.SetBool("Looking", isLooking);
	}

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor") && !onLadder)
        {
            onGround = true;
        }
    }
}
