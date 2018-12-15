using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerUp : MonoBehaviour {

    public static PowerUp Instance;
    public GameObject BarcodePanel;
    public Text NumTex,ExistingBuff;
	void Start ()
    {
        Instance = this;
	}
	
     
    public void ShowPanel(string s)
    {
        BarcodePanel.SetActive(true);
        NumTex.text ="Barcode value:"+ s;
        ExistingBuff.text += "\nDefense 1.5x";
    }
	

}
