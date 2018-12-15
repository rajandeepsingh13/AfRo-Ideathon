//Decides if pre play screen should be displayed
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTransition : MonoBehaviour {

    public static PlayTransition instance;
    public GameObject GameUI, MainUI, PrePlayUI,HomeUI;
    private Spawning _SpawnRef;
    private void Awake()
    {
        instance = this;
        _SpawnRef = GetComponent<Spawning>();
    }

    public void Transition()
    {
        if (ShieldHandler.Instance.isNew)
        {
            PrePlayUI.SetActive(true);
            HomeUI.SetActive(false);
        }           
        else
        {
            MainUI.SetActive(false);
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            GameUI.SetActive(true);
            ShieldHandler.Instance.RefreshShield();
            _SpawnRef.StartSpawn();
            
        }
           
    }

    public void GotoGame(UnityEngine.Video.VideoPlayer vp)
    {
        PrePlayUI.SetActive(false);
        MainUI.SetActive(false);
        HomeUI.SetActive(true);
        ShieldHandler.Instance.RefreshShield();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        GameUI.SetActive(true);
        ShieldHandler.Instance.RefreshShield();
        _SpawnRef.StartSpawn();
    }
}
