using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    public GameObject projectile;
    public GameObject projectileSpawnerPos;
    public GameObject grappleObject;
    public ParticleSystem bulletParticle;
    public bool hasShot;
    private GameObject bullet;


  

    public void SpawnProjectile()
    {
        if (!hasShot)
        {

            bullet = Instantiate(projectile, projectileSpawnerPos.transform.position, projectileSpawnerPos.transform.rotation * Quaternion.Euler(0, -90, 0)) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(projectileSpawnerPos.transform.forward * 4000);
            gameObject.GetComponent<ParticleSystem>().Emit(100);
            bulletParticle.Emit(58);
            hasShot = true;


        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            grappleObject.SetActive(false);
            SpawnProjectile();
            
            
        }
        AkSoundEngine.PostEvent("Grappling_Hook_Fire_Hiss", gameObject);

    }
}
