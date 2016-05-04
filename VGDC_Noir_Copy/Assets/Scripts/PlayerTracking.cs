using UnityEngine;
using System.Collections;

public class PlayerTracking : MonoBehaviour {
    private GameObject player;
    public float baseVertical;
    public float baseHorizontal;
    public float shiftDelay;
    public float shiftSpeed;
    public float upShiftMax;
    public float downShiftMax;
    private float delay;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("PlayerCharacter");
    }
	
	// Update is called once per frame
	void Update ()
    {
        

        if (PlayerMovement.isCrouching && !PlayerMovement.cameraMoved && PlayerMovement.onGround)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                shiftDown();
            }
        }
        else if (PlayerMovement.isLooking && !PlayerMovement.cameraMoved && PlayerMovement.onGround)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                shiftUp();
            }
        }
        else
        {
            delay = shiftDelay;

            if (PlayerMovement.onLadder || PlayerMovement.onGround || (transform.position.y - player.transform.position.y > baseVertical))
            {
                TrackVertical();
            }
            else
            {
                NoVertical();
            }
        }
	}

    void TrackVertical ()
    {
        transform.position = new Vector3(player.transform.position.x + baseHorizontal, player.transform.position.y + baseVertical, -10);
    }

    void NoVertical ()
    {
        transform.position = new Vector3(player.transform.position.x + baseHorizontal, transform.position.y, -10);
    }

    void shiftDown ()
    {
        if (transform.position.y - player.transform.position.y > baseVertical - downShiftMax)
        {
            transform.Translate(Vector3.down * Time.deltaTime * shiftSpeed);
        }
    }

    void shiftUp ()
    {
        if (transform.position.y - player.transform.position.y < baseVertical + upShiftMax)
        {
            transform.Translate(Vector3.up * Time.deltaTime * shiftSpeed);
        }
    }

    public void reset()
    {
        transform.position = new Vector3(player.transform.position.x + baseHorizontal, player.transform.position.y + baseVertical, -10);
    }
}
