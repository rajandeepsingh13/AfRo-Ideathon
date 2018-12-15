using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOrientation : MonoBehaviour {

	
	public void Landscape()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void Portrait()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
