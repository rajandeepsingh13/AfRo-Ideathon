using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AgeCheck : MonoBehaviour {

  
    public GameObject AgeEntryPanel,NumberEntryPanel,OtpEntryPanel;
    public InputField AgeInput,NumberInput,OtpInput;
    private int OTP;
	void Start ()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        if (!PlayerPrefs.HasKey("Age"))
            AgeEntryPanel.SetActive(true);
        else
            AgeEntryPanel.SetActive(false);
	}
	
    public void RegisterAge()
    {
        PlayerPrefs.SetInt("Age",int.Parse(AgeInput.text));
        if(int.Parse(AgeInput.text)<14)
            NumberEntryPanel.SetActive(true);  
 
    }


    public void RegisterNumber()
    {
        PlayerPrefs.SetString("Number", NumberInput.text);
        NumberEntryPanel.SetActive(false);
    }

    public void ParentalControl()
    {
        if (PlayerPrefs.GetInt("Age") < 14 && ShieldHandler.Instance.isNew)
        {
            OtpEntryPanel.SetActive(true);
            var SmsScr = gameObject.GetComponent<rTwilio>();
            OTP = Random.Range(1111, 9999);
            SmsScr.SendSMS(OTP);
        }
           
        else
            OtpEntryPanel.SetActive(false);
    }

    public void OtpVerification()
    {
        //if (OTP == int.Parse(OtpInput.text))
        OtpEntryPanel.SetActive(false);
    }
	
}
