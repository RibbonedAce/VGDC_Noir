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
            foreach (Light l in lights.GetComponentsInChildren<Light>())
            {
                l.intensity = 8;
            }
        } // turn off
        else
        {
            foreach (Light l in lights.GetComponentsInChildren<Light>())
            {
                l.intensity = 0;
            }
        } // turn on
    }
}
