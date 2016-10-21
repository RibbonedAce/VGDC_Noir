using UnityEngine;
using System.Collections;

public class LightSwitch: MonoBehaviour {
    public GameObject[] lights;
    public bool on = true;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Animator _animator = GetComponent<Animator>();
        _animator.SetBool("On", on);
	} // set on position

    public void Turn()
    {
        on = !on;

        foreach (GameObject light in lights)
        {
            if (on)
            {
                light.GetComponent<Light>().intensity = 8;
                light.GetComponentInChildren<PolygonCollider2D>().enabled = true;
            } // turn off
            else
            {
                light.GetComponent<Light>().intensity = 0;
                light.GetComponentInChildren<PolygonCollider2D>().enabled = false;
                Lighting.shadowLightsIn = 0;
            } // turn on
        }
    }
}
