using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class VideoPrepare : MonoBehaviour
{

    public VideoPlayer DefenseVid;
    public RawImage ImageRef;
	void Start () {
        DefenseVid.Prepare();
        DefenseVid.loopPointReached += PlayTransition.instance.GotoGame;
	}
	
	public void Play()
    {
        DefenseVid.Play();
        var col= ImageRef.color;
        col.a = 1;
        ImageRef.color = col;
    }

   
}
