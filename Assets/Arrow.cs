using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    Vector3 velocity;

    [HideInInspector]
    public float speed = 0.0001f;

    private void Awake()
    {
        speed = 0.1f;
    }
    // Update is called once per frame
    void Update ()
    {
        velocity = Vector3.right*speed;

        transform.position += velocity;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Die();
            Destroy(gameObject);
        }
    }
}
