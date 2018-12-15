using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }

    public void PopUp()
    {
            AndroidJavaObject ajc = new AndroidJavaObject("com.zeljkosassets.notifications.Notifier");
            ajc.CallStatic("sendNotification", "Don't Forget to apply FROooo!", "PB", "Looks like you are in a mosquito-prone area, apply FRO and stay safe!", 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
