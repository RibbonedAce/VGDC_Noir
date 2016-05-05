using UnityEngine;
using System.Collections;

public class EnemySimple : MonoBehaviour {
    private bool isCalm = true;
    public float paceLength;
    public string direciton;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isCalm)
        {
            StartCou
        }
	    
	}

    IEnumerator pace (string direction, float time)
    {
        if (direction == "left")
        {
            transform.Translate(Vector3.left * Time.deltaTime);

            yield return new WaitForSeconds(time);

            transform.Translate(Vector3.right * Time.deltaTime);

            yield return new WaitForSeconds(time);
        }

        if (direction == "right")
        {
            transform.Translate(Vector3.right * Time.deltaTime);

            yield return new WaitForSeconds(time);

            transform.Translate(Vector3.left * Time.deltaTime);

            yield return new WaitForSeconds(time);
        }

    }
}
