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
    public static float jumpHeight = 2000;

	// Use this for initialization
	void Start ()
    {
        paceTime = paceLength / speed; //sets distance going in one direction
        goingLeft = startsLeft;     
        start = transform.position; //initializes start of pathing
    }
	
	// Update is called once per frame
	void Update ()
    {
        Animator _animator = GetComponent<Animator>();

        VisionCone cone = GetComponentInChildren<VisionCone>();

        Transform shadow = GameObject.FindWithTag("Shadow").transform;
        float difference = GameObject.FindWithTag("PlayerCharacter").transform.position.x - transform.position.x;
        float switchDifference = CloseSwitch.transform.position.x - transform.position.x;

        if (cone.detectsPlayer) // if he sees the player, be alerted
        {
            alertTime = alertDuration;
            breaks = true;
        }
        if(cone.detectsShadow) // if he sees the shadow, be alerted differently
        {
            shadowTime = alertDuration;
            breaks = true;
        }

        if (alertTime <= 0 && shadowTime <= 0)
        {
            if (breaks) // if unalerted but still moved over
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
                } //go back to original spot and start pathing again
            }
            else
            {
                if (paceTime >= 0)
                {
                    paceTime -= Time.deltaTime;
                    transform.Translate(Vector3.left * Time.deltaTime * speed / 2);
                } //pace left
                else if (paceTime < 0 && paceTime >= -pacePause)
                {
                    paceTime -= Time.deltaTime;
                }
                else
                {
                    goingLeft = !goingLeft;
                    paceTime = paceLength / speed;
                } //turn right

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
            if (difference >= 0.5)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            } // move to player if not close
            else if (difference <= -0.5)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            } // stop if close to player

            
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
            } // turn to switch

            if(CloseSwitch.GetComponent<LightSwitch>().on)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }  // go to switch

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
            } // turn off switch if close
        }

        if (Mathf.Abs(shadow.position.x - transform.position.x) < 0.5 && transform.position.y - shadow.position.y <= 0.5f + shadow.localScale.y + transform.localScale.y && Input.GetButtonDown("Kill"))
        {
            Destroy(gameObject);
        } // die under certain circumstances

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
            } // be alerted if player is touched
        }
    }
}
