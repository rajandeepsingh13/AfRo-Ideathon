using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawning : MonoBehaviour {

    public int SpawnCount;
    public GameObject Moski,ClearPanel,BossPanel;
    public float radius=10f;
    public float radRange = 5f;
    public float yOffset = 5f;
    public float waitBetweenSpawns = 2f;
  

    private GameObject TempPar;
    public static int killCt = 0;
    private bool isClear=false;

    private void Update()
    {
        if(killCt==SpawnCount && !isClear)
        {
            ClearPanel.SetActive(true);
            isClear = true;
            StartCoroutine(Delay());
        }

    }

    public void StartSpawn()
    {
        StartCoroutine(MoskiSpawn());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        BossPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<BossFightHandler>().enabled = true;
    }

    IEnumerator MoskiSpawn()
    {
        yield return new WaitForSeconds(1);
        TempPar = new GameObject("TempParent");
        yield return new WaitForSeconds(waitBetweenSpawns);
        for (int i = 0; i < SpawnCount; i++) {
            yield return new WaitForSeconds(waitBetweenSpawns);
            bool isFront= i<(0.5f*SpawnCount);
            GameObject MoskiInstance = (GameObject)Instantiate(Moski, RandomCircle(Camera.main.transform.position, radius, isFront), Quaternion.identity);
            MoskiInstance.transform.parent = TempPar.transform;
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius_f,bool isFront)
    {
        radius_f = Random.Range(radius_f - radRange, radius_f + radRange);
        int view = isFront ? 60 : 180;
        float ang = Random.Range(-1f,1f) * view;
        Vector3 pos;
        pos.x = center.x + radius_f * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + Random.Range(-yOffset,+yOffset);
        pos.z = center.z + radius_f * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }

    public void DestroyPar()
    {
        Destroy(TempPar);
    }
}
