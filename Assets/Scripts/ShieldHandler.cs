using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShieldHandler : MonoBehaviour {

    public static ShieldHandler Instance;

    public Image FillImg;
    public Text ShieldRatio,TimeLeftText;

    public bool isNew=true;

    public int timeLeft;

    public int TotShieldValue,CurShieldVal;

    public GameObject GameOverUI;

    System.DateTime from, to;
    private void Awake()
    {
        Instance = this;
    }

    


    void Start ()
    {
        
        if (PlayerPrefs.HasKey("Shield"))
        {
            if (PlayerPrefs.GetInt("Shield") > 0)
            {
                
                from =System.DateTime.Parse(PlayerPrefs.GetString("StartTime"));
                to = System.DateTime.Parse(PlayerPrefs.GetString("EndTime"));
                if(from<=System.DateTime.Now && System.DateTime.Now<=to)
                {
                    isNew = false;
                    var span= to.Subtract(System.DateTime.Now);
                    var hrstr = span.TotalHours.ToString();
                    TotShieldValue =100-(8-(int) (Mathf.Ceil(float.Parse(hrstr))))*5;
                    CurShieldVal = TotShieldValue;
                }
                else
                {
                    isNew = true;
                    PlayerPrefs.SetInt("Shield", 0);

                }
                
               
            }
            else
                isNew = true;
        }
        else
        {
            PlayerPrefs.SetInt("Shield", 0);
            isNew = true;
        }
            
	}

    private void Update()
    {
        var Span = to.Subtract(System.DateTime.Now);
        TimeLeftText.text= string.Format("{0:00}:{1:00}:{2:00}",Span.Hours, Span.Minutes,Span.Seconds);
    }

    public void StartNewGame()
    {
        PlayerPrefs.SetInt("Shield", 100);
        PlayerPrefs.SetString("StartTime", System.DateTime.Now.ToString());
        PlayerPrefs.SetString("EndTime", System.DateTime.Now.AddHours(8).ToString());
        TotShieldValue = 100;
        to = System.DateTime.Now.AddHours(8);
    }

    public void RefreshShield()
    {
        CurShieldVal = TotShieldValue;
        ShieldRatio.text = CurShieldVal.ToString() + "/" + TotShieldValue.ToString();
    }

    public void DealDamage(int damg)
    {
       
        CurShieldVal =Mathf.Clamp(CurShieldVal-damg,0,100);
        FillImg.fillAmount = CurShieldVal / TotShieldValue;
        ShieldRatio.text = CurShieldVal.ToString() + "/" + TotShieldValue.ToString();
        if (CurShieldVal==0)
        {
            Scorekeeper.instance.FinalScore();
            var spawnScr = GetComponent<Spawning>();
            spawnScr.DestroyPar();
            GameOverUI.SetActive(true);
        }
    }



}
