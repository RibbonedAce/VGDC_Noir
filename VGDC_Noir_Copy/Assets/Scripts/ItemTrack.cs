using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemTrack : MonoBehaviour {
    private int items;
    public static int remaining;

	// Use this for initialization
	void Start ()
    {
        items = GameObject.FindGameObjectsWithTag("Interactible").Length;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(items);
        
        remaining = GameObject.FindGameObjectsWithTag("Interactible").Length;
        
        Debug.Log(remaining);

        GetComponent<Text>().text = (items - remaining).ToString() + "/" + items.ToString();

        if (remaining == 0)
        {
            Condition.won = true;
        }
	}
}
