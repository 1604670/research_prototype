using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject arrow;
    public float cooldown = 0.5f;
    float fired, lastFired;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            checkCooldown();
        }


	}

    void checkCooldown()
    {
        fired = Time.time;
        if(fired-lastFired >= cooldown)
        {
            lastFired = fired;
            fire();
        }
    }

    void fire()
    {
        float mul = Mathf.Abs(transform.localScale.x) / transform.localScale.x;

        GameObject g =  Instantiate(arrow, transform.position + (mul*Vector3.right*0.5f), Quaternion.identity);
        g.GetComponent<Arrow>().speed *= mul;
        g.transform.localScale*= mul;
    }
}
