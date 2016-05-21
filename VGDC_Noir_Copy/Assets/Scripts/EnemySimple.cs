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
    public GameObject CloseSwitch;
    private float shadowTime;
    private Vector3 start;
    private bool breaks = false;

	// Use this for initialization
	void Start ()
    {
        paceTime = paceLength / speed;
        goingLeft = startsLeft;
        start = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(breaks);

        Animator _animator = GetComponent<Animator>();

        VisionCone cone = GetComponentInChildren<VisionCone>();

        Transform shadow = GameObject.FindWithTag("Shadow").transform;
        float difference = GameObject.FindWithTag("PlayerCharacter").transform.position.x - transform.position.x;
        float switchDifference = CloseSwitch.transform.position.x - transform.position.x;

        if (cone.detectsPlayer)
        {
            alertTime = alertDuration;
            breaks = true;
        }
        if(cone.detectsShadow)
        {
            shadowTime = alertDuration;
            breaks = true;
        }

        if (alertTime <= 0 && shadowTime <= 0)
        {
            if (breaks)
            {
                float goOriginal = start.x - transform.position.x;

                if (goOriginal < -0.1f)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    transform.Translate(Vector3.left * Time.deltaTime * speed / 2);
                }
                else if (goOriginal > 0.1f)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    transform.Translate(Vector3.left * Time.deltaTime * speed / 2);
                }
                else
                {
                    breaks = false;
                    goingLeft = startsLeft;
                    paceTime = paceLength / speed;
                }
            }
            else
            {
                if (paceTime >= 0)
                {
                    paceTime -= Time.deltaTime;
                    transform.Translate(Vector3.left * Time.deltaTime * speed / 2);
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
        }
        else if (alertTime > 0)
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
        else if (shadowTime > 0)
        {
            if (switchDifference >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if(CloseSwitch.GetComponent<LightSwitch>().on)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }

            shadowTime -= Time.deltaTime;

            if (Mathf.Abs(switchDifference) < 1)
            {
                if (CloseSwitch.GetComponent<LightSwitch>().on && shadowTime > 0)
                {
                    CloseSwitch.GetComponent<LightSwitch>().Turn();
                }
                else if (!CloseSwitch.GetComponent<LightSwitch>().on && shadowTime <= 0)
                {
                    CloseSwitch.GetComponent<LightSwitch>().Turn();
                }
            }
        }

        if (Mathf.Abs(shadow.position.x - transform.position.x) < 0.5 && transform.position.y - shadow.position.y <= 0.5f + shadow.localScale.y + transform.localScale.y && Input.GetButtonDown("Kill"))
        {
            Destroy(gameObject);
        }

        _animator.SetBool("Calm", alertTime <= 0 && shadowTime <= 0);
        _animator.SetBool("Alert", alertTime > 0);
        _animator.SetBool("Switching", alertTime <= 0 && shadowTime > 0);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerCharacter"))
        {
            alertTime = alertDuration;

            if (alertTime > 0)
            {
                Condition.lost = true;
            }
        }
    }
}
