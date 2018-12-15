using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rLocation : MonoBehaviour {

    public float longitude;
    public float latitude;
    //public Text text;

	void Start () {
        StartCoroutine(StartLocationServices());
    }

    public void StartNotificationProcess()
    {
    StartCoroutine(StartLocationServices());
    }

    IEnumerator StartLocationServices()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("lol, no location");
            SendGoogleAPI(77.73592f, 12.98713f);
            yield break;
        }
        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Can't do location lol");
            yield break;
        }
        else
        {
            longitude = Input.location.lastData.longitude;
            latitude = Input.location.lastData.latitude;
            print("Location: " + latitude + " " + longitude);
            //text.text= "Long" +longitude + "Lat" +latitude;
            SendGoogleAPI(longitude, latitude);
            // SendGoogleAPI(77.73592f,12.98713f);
        }
    }


    [HideInInspector]
    public static bool isCloseToWater = false;

    public void SendGoogleAPI(float longi,float lati)
    {
        WWW www = new WWW("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" +lati+","+longi+"&radius=1000&type=natural_feature&key=AIzaSyBc-XmxRCMfJDUetHWGUHhO2xj6X429E-o");
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            Debug.Log("WWW Ok! " + www.text);
       //     text.text += www.text;
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
      //      text.text += www.text;
        }
        JSONObject jsonCharInfo = new JSONObject(www.text);
        var status = jsonCharInfo.GetField("status");
        Debug.Log(status.ToString());
        isCloseToWater = status.ToString().Equals("\"OK\"");
        Debug.Log(isCloseToWater);
        if(isCloseToWater)
            LocalNotification.SendNotification(1, 5000, "Mosquito prone area", "Use FRO to stay protected", new Color32(0xff, 0x44, 0x44, 255));
    }

    void Update () {
		
	}
}
