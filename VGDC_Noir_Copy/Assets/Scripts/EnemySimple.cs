using UnityEngine;
using System.Collections;

public class EnemySimple : MonoBehaviour {
    public float paceLength;
    private float paceTime;
    public bool startsLeft;
    private bool goingLeft;
    public float speed;
    public float pacePause;
    public float alertDuration;
    private float alertTime;

	// Use this for initialization
	void Start ()
    {
        paceTime = paceLength / speed;
        goingLeft = startsLeft;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Animator _animator = GetComponent<Animator>();

        VisionCone cone = GetComponentInChildren<VisionCone>();

        Transform shadow = GameObject.FindWithTag("Shadow").transform;
        float difference = GameObject.FindWithTag("PlayerCharacter").transform.position.x - transform.position.x;

        if (cone.detectsPlayer)
        {
            alertTime = alertDuration;
        }

        if (alertTime <= 0)
        {
            if (paceTime >= 0)
            {
                paceTime -= Time.deltaTime;
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            else if (paceTime < 0 && paceTime >= -pacePause)
            {
                paceTime -= Time.deltaTime;
            }
            else
            {
                goingLeft = !goingLeft;
                paceTime = paceLength / speed;
            }

            if (goingLeft)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
        else
        {
            if (difference >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            transform.Translate(Vector3.left * Time.deltaTime * speed);
            alertTime -= Time.deltaTime;
        }

        if (Mathf.Abs(shadow.position.x - transform.position.x) < 0.5 && transform.position.y - shadow.position.y <= 0.5f + shadow.localScale.y + transform.localScale.y && Input.GetButtonDown("Kill"))
        {
            Destroy(gameObject);
        }

        _animator.SetBool("Calm", alertTime <= 0);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerCharacter"))
        {
            alertTime = alertDuration;
        }
    }
}
