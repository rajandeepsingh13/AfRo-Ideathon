using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDisable : MonoBehaviour {

    public float delay;
	void Start ()
    {
        StartCoroutine(dis());
	}
	
    IEnumerator dis()
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
