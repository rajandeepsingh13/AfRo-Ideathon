using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataContainer :ScriptableObject
{

    public bool isFirstTime = true;
    public int Age=999;
    public long GuardianNumber;
    public int Score=0;
    public int PlayCount;
    public int FuelVal;

}
