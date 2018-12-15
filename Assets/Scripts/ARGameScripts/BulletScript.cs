using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour {

    private void Start()
    {
        StartCoroutine(Suicide());
    }


    IEnumerator Suicide()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Moski")
        {
            Spawning.killCt++;
            Scorekeeper.instance.AddScore(5);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Boss")
        {
            BossFightHandler.count++;
            Destroy(this.gameObject);
        }
    }
}
