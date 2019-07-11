using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_doorOpen : MonoBehaviour
{

    public GameObject Door;
    private Animator doorAnimator;

    private void Start()
    {
        doorAnimator = Door.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == ("Player"))
        {
           

            if (Input.GetKeyDown("e"))
            {
                
                doorAnimator.SetBool("doorOpen", true);

            }
        }
    
        
    }
}
