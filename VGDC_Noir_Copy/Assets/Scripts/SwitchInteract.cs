using UnityEngine;
using System.Collections;

public class SwitchInteract : Interact {

    // Update is called once per frame
    protected override void Update ()
    {
        if (Input.GetButtonDown("Interact") && canInteract)
        {
            GetComponent<LightSwitch>().Turn();
        }
    }
}
