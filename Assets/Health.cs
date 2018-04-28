using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    SpriteRenderer spr;
    Coroutine crtn;

    public int lives = 3;
    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        
    }

    void hit()
    {
        lives--;
        if (lives <= 0)
            StartCoroutine(death());

        if (crtn != null) 
            StopCoroutine(crtn);

        crtn =  StartCoroutine(hitNow());
    }

    IEnumerator hitNow()
    {
        spr.color = Color.red;
        while (spr.color != Color.black)
        {
            spr.color = Color.Lerp(spr.color, Color.black,0.02f);
            yield return null;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            hit();
        }
    }


    IEnumerator death()
    {
        yield return null;
        Destroy(gameObject);
    }
}
