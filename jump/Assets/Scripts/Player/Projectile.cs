using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject Player;
    public GameObject spawner;
    public bool hasHooked;
    private bool Returning;

    

    private void Start()
    {
        
        hasHooked = false;
        
    }

    private void Awake()
    {
        
        Player = GameObject.Find("Player");
        spawner = GameObject.Find("bulletSpawn");
        StartCoroutine(killTimer());
        
    }

 

    private void Update()
    {
        Returning = Player.GetComponent<pl_GrapplingHook>().hookReturnActive; 
    }

    IEnumerator killTimer()
    {
        yield return new WaitForSeconds(0.5f);

        if (hasHooked == false)
        {
            print("Times up");
            Returning = true;
            Player.GetComponentInChildren<pl_GrapplingHook>().Hook = this.gameObject;

            // Destroy(this.gameObject);
            // spawner.GetComponent<ProjectileSpawner>().hasShot = false;
            // spawner.GetComponent<ProjectileSpawner>().grappleObject.SetActive(true);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag != "Player" && Returning == false)
        {
            hasHooked = true;
            //transform.rotation = Quaternion.FromToRotation(Vector3.forward, new Vector3(60, 80, 80));
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Collider>().enabled = false;
            Player.GetComponentInChildren<pl_GrapplingHook>().Hook = this.gameObject;
            



        }

        if (collision.gameObject.tag == "Player")
        {
            spawner.GetComponentInChildren<ProjectileSpawner>().hasShot = false;
            Player.GetComponentInChildren<pl_GrapplingHook>().grappleObject.SetActive(true);
            Player.GetComponentInChildren<pl_GrapplingHook>().rangeOut = false;
            Destroy(this.gameObject);
            Player.GetComponentInChildren<pl_GrapplingHook>().hookReturnActive = false;



        }


    }

  

}
