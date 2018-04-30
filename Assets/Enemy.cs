using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    protected Vector3 center;
    float angle;
    public float speed = 0.010f;
    public float radius = 1.2f;

    [Range(0, 0.1f)]
    public float noise = 0.09f;
    [Range(0, 1f)]
    public float smoothness = 0.2f;

    [Header("Sin Values")]
    public float frequency = 1;
    public float amplitude = 1, delay = 0;



    protected virtual void Awake()
    {
        center = transform.position;
    }

    public virtual void Update()
    {
        movement();

    }

    public virtual void movement()
    {

        angle += speed;
        float sinVal = (Mathf.Sin(Time.time * frequency) * amplitude) + delay;

        float x = center.x + Mathf.Cos(angle) * radius + sinVal;//Random.Range(-noise,noise);
        float y = center.y + Mathf.Sin(angle) * radius + sinVal;//Random.Range(-noise, noise);

        transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, transform.position.z), smoothness) ;
    }



    public virtual void Die()
    {
        StartCoroutine(dieSequence());
    }

    protected virtual IEnumerator dieSequence()
    {
        tag = "Untagged";
        while (transform.localScale.x > 0.05f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero,0.05f);
            yield return null;
        }

        Destroy(gameObject);
    }
}
