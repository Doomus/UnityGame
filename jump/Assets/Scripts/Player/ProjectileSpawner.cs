using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    public GameObject projectile;
    public GameObject projectileSpawnerPos;
    public GameObject grappleObject;
    private GameObject bullet;

    public ParticleSystem bulletParticle;

    public bool hasShot;

    
    public void SpawnProjectile()
    {
        if (!hasShot)
        {
            hasShot = true;
            bullet = Instantiate(projectile, projectileSpawnerPos.transform.position, projectileSpawnerPos.transform.rotation * Quaternion.Euler(0, -90, 0)) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(projectileSpawnerPos.transform.forward * 4000);
            gameObject.GetComponent<ParticleSystem>().Emit(100);
            bulletParticle.Emit(58);
            


        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && hasShot == false)
        {
            grappleObject.SetActive(false);
            SpawnProjectile();
            
            
        }


    }
}
