using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject Bullet;
    public float Bullet_Speed;


    
    public void checkTouch()
    {

        GameObject Temporary_Bullet;
        Temporary_Bullet = Instantiate(Bullet, Camera.main.transform.position, Camera.main.transform.rotation) as GameObject;
        Rigidbody Temporary_RigidBody = Temporary_Bullet.GetComponent<Rigidbody>();
        Temporary_RigidBody.AddForce(Camera.main.transform.forward * Bullet_Speed);
   
    }

    public void ShieldOn()
    {
        MoskiScript.isShieldUp = true;
    }

    public void ShieldOff()
    {
        MoskiScript.isShieldUp = false;
    }

   
}
