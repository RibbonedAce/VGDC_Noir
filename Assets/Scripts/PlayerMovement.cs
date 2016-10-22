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
    public static bool isMoving;

	// Use this for initialization
	void Start ()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        Rigidbody2D _rigidbody = GetComponent<Rigidbody2D>();

        if (onLadder)
        {
            isCrouching = false;
            isLooking = false;
            onGround = false;

            _rigidbody.gravityScale = 0;

            if (Input.GetAxis("Vertical") != 0)
            {
                transform.Translate(Vector3.up * Time.deltaTime * climbSpeed * Input.GetAxis("Vertical"));
            } // Climb up ladder

            if (Input.GetButtonDown("Jump"))
            {
                onLadder = false;
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpHeight);

                GameObject.FindWithTag("MainCamera").GetComponent<PlayerTracking>().reset();
            } // Jump off ladder
        } // Player behavior on ladder
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
            } // Crouch and pan camera down
            else if (Input.GetAxis("Vertical") == 1 && onGround)
            {
                isCrouching = false;
                isLooking = true;

                if (Input.GetAxis("Horizontal") != 0)
                {
                    cameraMoved = true;
                }
            } // Pan camera up
            else
            {
                isCrouching = false;
                isLooking = false;
                cameraMoved = false;
            }
        }

	    if (Input.GetAxis("Horizontal") != 0 && !onLadder)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
        } // Move

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        } // Trigger if player is moving

        if (Input.GetButtonDown("Jump") && onGround)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpHeight);
            onGround = false;
            isCrouching = false;
            isLooking = false;

            GameObject.FindWithTag("MainCamera").GetComponent<PlayerTracking>().reset();
        } // jump

        transform.rotation = Quaternion.Euler(0, 0, 0);

        _animator.SetBool("Crouching", isCrouching);
        _animator.SetBool("Looking", isLooking);
	}

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor") && !onLadder)
        {
            onGround = true;
        } // Detect if on ground
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            onGround = false;
        } // Detect if not on ground
    }
}
