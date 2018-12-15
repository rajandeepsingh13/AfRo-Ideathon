using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Redeem : MonoBehaviour {

    string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    public Text CodeText;
    public void Generate()
    {
        CodeText.text = "";
        for (int i = 0; i < 6; i++)
            CodeText.text += characters[Random.Range(0, characters.Length)];
        Scorekeeper.instance.Redeem();
    }


}
