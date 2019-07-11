using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pl_GrapplingHook : MonoBehaviour
{

    private Rigidbody rig;
    public GameObject Hook;
    public GameObject grappleObject;
    public GameObject projSpawner;
    
    private bool projShot;
    public bool rangeOut;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        projShot = projSpawner.GetComponentInChildren<ProjectileSpawner>().hasShot;
        rangeOut = false;
    }

  

    void Update()
    {
        if (Hook != null)
        {
            // direction player is launched twards
            Vector3 hookPos = (Hook.transform.position - transform.position).normalized;
            // direction hook is launched twards
            Vector3 hookreturn = (transform.position - Hook.transform.position).normalized;

            //modifying the hook angle for return
            Rigidbody rig_Hook = Hook.GetComponent<Rigidbody>();
            Hook.transform.forward = hookreturn;

            //modifying the player for boost
            rig.velocity = hookPos;
            rig.AddForce(rig.velocity * 30, ForceMode.Impulse);

            
            if (Input.GetMouseButtonDown(1))
            {

                rig_Hook.isKinematic = false;
                rig_Hook.useGravity = false;
                // sending the hook back to the player
                rig_Hook.velocity = hookreturn * 10;
                Hook.GetComponent<SphereCollider>().isTrigger = true;
                Hook.GetComponent<SphereCollider>().enabled = true;


            }
        }
    }

    //public void OnCollisionEnter(Collision col)
    //{
    //    print(col.gameObject);
    //    if(col.gameObject.tag == "bullet")
    //    {
    //        grappleObject.SetActive(true);
    //        projSpawner.GetComponentInChildren<ProjectileSpawner>().hasShot = false;
    //        Destroy(col.gameObject);
    //    }
    //}

    // Update is called once per frame
    
}
