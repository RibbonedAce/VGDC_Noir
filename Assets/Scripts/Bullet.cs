using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed;

    // Use this for initialization
    void Start()
    {
        PublicFunctions.PhaseThruTag(gameObject, new string[] { "PlayerCharacter" });
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Transfer") || other.gameObject.CompareTag("Wall"))
        Destroy(gameObject);
    }
}