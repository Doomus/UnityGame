using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject Player;
    public GameObject spawner;
    public bool hasHooked;

    IEnumerator killTimer()
    {
        yield return new WaitForSeconds(0.5f);

        if(hasHooked == false)
        {
            print("Times up");
            Destroy(this.gameObject);
            spawner.GetComponent<ProjectileSpawner>().hasShot = false;
            spawner.GetComponent<ProjectileSpawner>().grappleObject.SetActive(true);
        }

    }

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



    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag != "Player")
        {
            hasHooked = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Collider>().enabled = false;
            Player.GetComponentInChildren<pl_GrapplingHook>().Hook = this.gameObject;
            
            
        }

     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            spawner.GetComponentInChildren<ProjectileSpawner>().hasShot = false;
            Player.GetComponentInChildren<pl_GrapplingHook>().grappleObject.SetActive(true);
            Player.GetComponentInChildren<pl_GrapplingHook>().rangeOut = false;
            Destroy(this.gameObject);
            


        }
    }

}
