using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour {

    public Canvas c;
    public Image Spike, Flatline;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void Hit()
    {
        GetComponent<Animator>().enabled = true;
        StartCoroutine(hitHeart());
    }

    public void escape()
    {
        StartCoroutine(EscapeStart());
    }

    IEnumerator hitHeart()
    {
        Time.timeScale = 0;
        float t = Time.unscaledTime;
        while(Time.unscaledTime - t <= 4)
        {
            yield return null;

        }
        Time.timeScale = 1;

        c.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Spike.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);
        Spike.gameObject.SetActive(false);
        Flatline.gameObject.SetActive(true);


    }


    IEnumerator EscapeStart()
    {
        Time.timeScale = 0;
        float t = Time.unscaledTime;
        while (Time.unscaledTime - t <= 0.25f)
        {
            yield return null;

        }
        Time.timeScale = 1;

        c.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Flatline.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);
        Spike.gameObject.SetActive(true);
        Flatline.gameObject.SetActive(false);


    }
}
