using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoskiScript : MonoBehaviour {

    public float attackTimeGap=2f;
    public float attackSpeed=50f;
    public int damage = 5;
    float retreatSpeed;
    bool shouldAttack;
    bool shouldRetreat;
    bool isWaitOn;
    public static bool  isShieldUp=false;
    Vector3 spawnPosition;

    // Use this for initialization
    void Start () {
        StartCoroutine(attack());
        spawnPosition = transform.position;
        retreatSpeed = 1.5f * attackSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform);
        if (shouldAttack)
        {
            float step = attackSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, step);
            if (Vector3.Distance(transform.position, Camera.main.transform.position) < 5f)
            {
                if(!isShieldUp)
                ShieldHandler.Instance.DealDamage(damage);
                shouldAttack = false;
                shouldRetreat = true;
            }
        }
        if (shouldRetreat)
        {
            float step = retreatSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, spawnPosition, step);
            if (Vector3.Distance(transform.position, spawnPosition) == 0f)
            {
                shouldRetreat = false;
            }
        }
        if (!shouldAttack && !shouldRetreat && !isWaitOn)
        {
            StartCoroutine(attack());
        }
    }

    IEnumerator attack()
    {
        isWaitOn = true;
        yield return new WaitForSeconds(attackTimeGap);
        shouldAttack=true;
        isWaitOn = false;
    }



}
