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
        Destroy(gameObject, 5f);
    }
    // Update is called once per frame
    void Update ()
    {
        velocity = Vector3.right*speed;

        transform.position += velocity * Time.deltaTime*120;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Die();
            Destroy(gameObject);
        }


        if (collision.tag == "Heart")
        {
            collision.gameObject.GetComponent<Heart>().Hit();

            Destroy(gameObject,0.1f);
        }
    }
}
