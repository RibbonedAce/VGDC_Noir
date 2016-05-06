using UnityEngine;
using System.Collections;

public class EnemySimple : MonoBehaviour {
    private bool isCalm = true;
    public float paceLength;
    private float paceTime;
    public bool startsLeft;
    private bool goingLeft;
    public float speed;

	// Use this for initialization
	void Start ()
    {
        paceTime = paceLength;
        goingLeft = startsLeft;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Animator _animator = gameObject.GetComponent<Animator>();

        VisionCone cone = gameObject.GetComponentInChildren<VisionCone>();

        if (cone.detectsPlayer)
        {
            isCalm = false;
        }

        if (isCalm)
        {
            if (paceTime >= 0)
            {
                paceTime -= Time.deltaTime;
            }
            else
            {
                goingLeft = !goingLeft;
                paceTime = paceLength;
            }

            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (goingLeft)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }

        _animator.SetBool("Calm", isCalm);
	}
}
