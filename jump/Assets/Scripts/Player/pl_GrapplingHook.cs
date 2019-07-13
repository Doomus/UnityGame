using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pl_GrapplingHook : MonoBehaviour
{

    private Rigidbody rig;
    public Rigidbody rig_Hook;

    public GameObject Hook;
    public GameObject grappleObject;
    public GameObject projSpawner;


    private Vector3 hookPos;
    private Vector3 hookreturn;

    private bool projHasShot;
    public bool hookReturnActive;
    public bool rangeOut;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        projHasShot = projSpawner.GetComponentInChildren<ProjectileSpawner>().hasShot;
        rangeOut = false;
        hookReturnActive = false;
        
    }

    private void rapelForward( GameObject Hook)
    {
        hookPos = (Hook.transform.position - transform.position).normalized;
        Hook.transform.forward = hookreturn;

        rig.velocity = hookPos;
        rig.AddForce(rig.velocity * 30, ForceMode.Impulse);

    }

    private void rapelReturn(GameObject Hook)
    {

        
        rig_Hook = Hook.GetComponent<Rigidbody>();
        
        hookReturnActive = true;
        rig_Hook.isKinematic = false;
        Hook.GetComponent<MeshCollider>().isTrigger = false;
        Hook.GetComponent<MeshCollider>().enabled = true;
    }
  
    public void returnHookValue(bool isreturning)
    {
        
        if (isreturning == true)
        {
            rig_Hook = Hook.GetComponent<Rigidbody>();
            print("is reutnring");
            hookreturn = (transform.position - Hook.transform.position).normalized;
            rig_Hook.velocity = hookreturn * 10;
        }
        
    }

    void Update()
    {

        if (Hook != null && hookReturnActive == false)
        {

            //rapelForward(Hook);
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            rapelReturn(Hook);

        }

        returnHookValue(hookReturnActive);

    }

    
    
}
