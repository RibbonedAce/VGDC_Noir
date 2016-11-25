using UnityEngine;
using System.Collections;

public class LightSwitch: MonoBehaviour {
    public GameObject lights;
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

        if (on)
        {
            lights.GetComponentInChildren<Light>().intensity = 8;
        } // turn off
        else
        {
            lights.GetComponentInChildren<Light>().intensity = 0;
        } // turn on
    }
}
