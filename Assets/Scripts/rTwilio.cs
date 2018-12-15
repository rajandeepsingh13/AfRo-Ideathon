using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rTwilio : MonoBehaviour
{

    string url = "api.twilio.com/2010-04-01/Accounts/";
    string service = "/Messages.json";
    string from = "+17065100284";
    public string to = "+919940174801";
    string account_sid = "AC639bf40703770822b479842ee8160a25";
    string auth = "bab975dccd1615d4cddd18dca072e91f";
    string body = "OTP: ";

    public void Start()
    {
       
    }

    public void SendSMS(int OTP)
    {
        to = "+91" + PlayerPrefs.GetString("Number");        
        body += OTP;
        Debug.Log(to + "," +body);
        WWWForm form = new WWWForm();
        form.AddField("To", to);
        form.AddField("From", from);
        form.AddField("Body", body);
        string completeurl = "https://" + account_sid + ":" + auth + "@" + url + account_sid + service;
        Debug.Log(completeurl);
        WWW www = new WWW(completeurl, form);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            Debug.Log("WWW Ok! SMS sent through Web API: " + www.text);
            body = "OTP: ";
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
