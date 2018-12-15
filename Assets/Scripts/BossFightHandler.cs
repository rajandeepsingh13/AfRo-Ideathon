using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightHandler : MonoBehaviour {

    public GameObject BossModel,GameOverUI,AttackBtn;
    private GameObject BossRef;
    public static int count=0;
	void Start ()
    {
        BossRef = Instantiate(BossModel, Camera.main.transform.position+ Camera.main.transform.forward*15, Quaternion.identity);
        BossRef.transform.LookAt(Camera.main.transform);
        AttackBtn.SetActive(false);
        StartCoroutine(HideInfo());
	}
	
	


    IEnumerator HideInfo()
    {
        yield return new WaitForSeconds(6);
        BossRef.transform.GetChild(0).gameObject.SetActive(false);
        AttackBtn.SetActive(true);
      
    }

  

    // Update is called once per frame
    void Update()
    {
        if(count>=3)
        {
            Scorekeeper.instance.AddScore(20);
            Scorekeeper.instance.FinalScore();
            GameOverUI.SetActive(true);
            Destroy(BossRef);
            this.enabled = false;
        }

        
    }


}
